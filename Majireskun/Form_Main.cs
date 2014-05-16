using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Text.RegularExpressions;
using System.Configuration;

namespace Majireskun
{
    public partial class Form_Main : Form
    {
        public Option OptionInstanse;   // バージョン情報フォーム
        public Queue QueueInstanse;     // 設定フォーム
        public View ViewInstanse;       // スレ表示フォーム
        public Thread th = null;        // 本スレ取得スレッド
        public Thread th_h = null;      // 避難所スレ取得スレッド
        public Thread th_w = null;        // 書き込み用スレッド
        public static readonly object syncObject = new object(); // 同期オブジェクト

        public Boolean boolStartFlag;   // 追跡開始フラグ
        public Boolean boolResExist;    // レス存在フラグ
        public Int64 timersec = 0;      // 経過時間
        public Int64 basetime = 0;      // 基準時刻
        public Int64 timerdiff = 0;     // タイマー差分
        public int httptimersec = 0;    // データ取得処理クロック

        public Int32 resnum = 0;        // 読み込み済みレス数
        public Int32 resnum_h = 0;      // 読み込み済みレス数（避難所）
        public Boolean boolThreadDup = false;    //スレッド重複防止
        public Boolean boolThreadDup_h = false;  //スレッド重複防止（避難所）

        private string strThread;
        private string strThread_haven;

        public Form_Main()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Main_Load(object sender, EventArgs e)
        {
            // フォーム作成
            this.QueueInstanse = new Queue();
            this.OptionInstanse = new Option();
            this.ViewInstanse = new View();
            
            QueueInstanse.parentForm = this;
            OptionInstanse.parentForm = this;
            ViewInstanse.parentForm = this;

            // バージョン情報
            //System.Diagnostics.FileVersionInfo ver =
            //     System.Diagnostics.FileVersionInfo.GetVersionInfo(
            //     System.Reflection.Assembly.GetExecutingAssembly().Location);
            //this.VersionInstanse.strVersion = ver.ProductVersion;

            // コンフィグファイルパス
            this.OptionInstanse.strConfig = ConfigurationManager.OpenExeConfiguration(
                ConfigurationUserLevel.PerUserRoamingAndLocal).FilePath;

            //TabControlをオーナードローする
            //tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;

            // 設定値割り当て
            //this.OptionInstanse.strThread = Properties.Settings.Default.Thread;
            //this.OptionInstanse.strID = Properties.Settings.Default.ID;
            //this.OptionInstanse.strNameSpace = Properties.Settings.Default.NameSpace;
            //this.OptionInstanse.strMailSpace = Properties.Settings.Default.MailSpace;
            //this.OptionInstanse.strThread_haven = Properties.Settings.Default.Thread_haven;
            //this.OptionInstanse.strID_haven = Properties.Settings.Default.ID_haven;
            //this.OptionInstanse.strNameSpace_haven = Properties.Settings.Default.NameSpace_haven;
            //this.OptionInstanse.strMailSpace_haven = Properties.Settings.Default.MailSpace_haven;
            //this.OptionInstanse.intLimit1 = Properties.Settings.Default.limit_1;
            //this.OptionInstanse.intLimit2 = Properties.Settings.Default.limit_2;
            //this.OptionInstanse.topMost = Properties.Settings.Default.topmost;
            //this.OptionInstanse.viewName = Properties.Settings.Default.view_name;
            //this.OptionInstanse.viewMail = Properties.Settings.Default.view_mail;
            //this.OptionInstanse.viewId = Properties.Settings.Default.view_id;
            //this.OptionInstanse.viewDate = Properties.Settings.Default.view_date;
            //this.OptionInstanse.viewNum = Properties.Settings.Default.view_num;

            

            // 開始フラグ
            boolStartFlag = false;

            // 開始メッセージ
            this.label_message.Enabled = false;
            this.label_message.Text = DateTime.Now.ToString() + " " + "アプリケーション開始";

            timer1.Interval = 1000;

        }

        /// <summary>
        /// タイマーイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {

            // 本スレ
            if (this.httptimersec % 15 == 0 && !boolThreadDup)
            {
                // データ取得処理
                boolThreadDup = true;
                //Threadオブジェクトを作成する
                object[] obj = new object[5]; // 引数

                obj[0] = Const.BOARD_MAIN;
                obj[1] = this.strThread; //スレURL

                th =
                    new System.Threading.Thread(
                    new System.Threading.ParameterizedThreadStart(HttpThread));
                //スレッドを開始する
                th.Start(obj);

            }
            // 避難所
            if (this.httptimersec % 15 == 0 && !boolThreadDup_h)
            {
                // データ取得処理
                boolThreadDup_h = true;
                //Threadオブジェクトを作成する
                object[] obj = new object[5]; // 引数

                obj[0] = Const.BOARD_HAVEN;
                obj[1] = this.strThread_haven; //スレURL

                th_h =
                    new System.Threading.Thread(
                    new System.Threading.ParameterizedThreadStart(HttpThread));
                //スレッドを開始する
                th_h.Start(obj);

            }

            this.httptimersec++;

        }



        /// <summary>
        /// スレ情報取得
        /// </summary>
        /// <param name="args"></param>
        private void HttpThread(object args)
        {
            string host;
            string strGet = "";
            Encoding enc = Encoding.GetEncoding("shift-jis");
            int bbstype;
            int indexThreadName;
            int indexDate;
            int indexBody;
            int indexName;
            int indexMail;

            object[] argsTmp = (object[])args;
            int bbsCode = (int)argsTmp[0]; // 本/避難所区分
            string strUrl = (string)argsTmp[1]; // スレURL
            string strID = (string)argsTmp[2]; // スレID
            string strNameSpace = (string)argsTmp[3]; // 
            string strMailSpace = (string)argsTmp[4]; // 
            string strHi = "";
            if (bbsCode == Const.BOARD_HAVEN)
            {
                strHi = "[避]";
            }

            strID = Const.NZ(strID);
            strNameSpace = Const.NZ(strNameSpace);
            strMailSpace = Const.NZ(strMailSpace);

            try
            {
                // logger
                LogoutputDelegate logdlg = new LogoutputDelegate(this.logoutput);

                // datURL取得
                Console.WriteLine(strUrl);
                //Regexオブジェクトを作成
                Regex r1 = new Regex(@"2ch\.net");
                Regex r2 = new Regex(@"jbbs\.shitaraba\.net");
                Regex r3 = new Regex(@"http:\/\/([^:\/]*).*read\.cgi\/([^\/]*)\/([0-9]*)\/?");
                Regex r4 = new Regex(@"http:\/\/([^:\/]*).*read\.cgi\/([^\/]*)\/([0-9]*)\/([0-9]*)\/?");
                Regex r5 = new Regex(@"(\d{4})\/(\d{2})\/(\d{2})\(.*\) (\d{2}):(\d{2}):(\d{2})\.\d{2} ID:(.*)");
                Regex r6 = new Regex(@"(\d{4})\/(\d{2})\/(\d{2})\(.*\) (\d{2}):(\d{2}):(\d{2})");

                if (r1.Match(strUrl).Success)
                {
                    bbstype = Const.BBS_2CH;
                    indexThreadName = 4;
                    indexDate = 2;
                    indexBody = 3;
                    indexName = 0;
                    indexMail = 1;
                    Match m = r3.Match(strUrl);
                    if (!m.Success)
                    {
                        this.BeginInvoke(logdlg, new object[] { "スレッドURLが不正です。" });
                        return;
                    }
                    host = m.Groups[1].Value;
                    string board = m.Groups[2].Value;
                    string datid = m.Groups[3].Value;
                    strGet = "http://" + host + "/" + board + "/dat/" + datid + ".dat";
                    Console.WriteLine(strGet);

                    enc = Encoding.GetEncoding("shift-jis");

                }
                else if (r2.Match(strUrl).Success)
                {
                    bbstype = Const.BBS_SHITARABA;
                    indexThreadName = 5;
                    indexDate = 3;
                    indexBody = 4;
                    indexName = 1;
                    indexMail = 2;
                    Match m = r4.Match(strUrl);
                    if (!m.Success)
                    {
                        this.BeginInvoke(logdlg, new object[] { "スレッドURLが不正です。" });
                        return;
                    }
                    host = m.Groups[1].Value;
                    string bbs = m.Groups[2].Value;
                    string key1 = m.Groups[3].Value;
                    string key2 = m.Groups[4].Value;
                    strGet = @"http://jbbs.shitaraba.net/bbs/rawmode.cgi/" + bbs + "/" + key1 + "/" + key2 + "/";
                    Console.WriteLine(strGet);

                    enc = Encoding.GetEncoding("euc-jp");

                }
                else
                {
                    this.BeginInvoke(logdlg, new object[] { "スレッドURLが不正です。" });
                    return;
                }

                // サーバーソケット初期化
                this.BeginInvoke(logdlg, new object[] { "データを取得します。" });
                //HttpWebRequestの作成
                System.Net.HttpWebRequest webreq =
                    (System.Net.HttpWebRequest)
                        System.Net.WebRequest.Create(strGet);

                webreq.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                webreq.Proxy = null;

                //サーバーからの応答を受信するためのHttpWebResponseを取得
                System.Net.HttpWebResponse webres =
                    (System.Net.HttpWebResponse)webreq.GetResponse();

                //System.Text.Encoding.GetEncoding("euc-jp");
                //応答データを受信するためのStreamを取得
                System.IO.Stream st = webres.GetResponseStream();
                System.IO.StreamReader sr = new System.IO.StreamReader(st, enc);

                // 一行ずつパース
                Int32 rescnt = 0;
                int news = 0; //新レス数
                while (!sr.EndOfStream)
                {
                    rescnt++;
                    string h = sr.ReadLine();
                    if (bbsCode == Const.BOARD_MAIN && rescnt <= this.resnum) { continue; }
                    if (bbsCode == Const.BOARD_HAVEN && rescnt <= this.resnum_h) { continue; }
                    string[] stArrayData = h.Split(new string[] { "<>" }, StringSplitOptions.None);
                    if (rescnt == 1 && bbsCode == Const.BOARD_HAVEN) // 本スレのみ
                    {
                        this.BeginInvoke(new Action<String>(delegate(String str) { this.threadnameupdate(stArrayData[indexThreadName]); }), new object[] { "" });
                        //this.BeginInvoke(new Action<String>(delegate(String str) { this.idupdate(this.OptionInstanse.strID); }), new object[] { "" });
                    }

                    // 読み込んだレス番号を更新
                    switch (bbsCode)
                    {
                        case Const.BOARD_MAIN:
                            this.BeginInvoke(new Action<Int32>(delegate(Int32 i) { this.resnumupdate(rescnt); }), new object[] { 0 });
                            break;
                        case Const.BOARD_HAVEN:
                            this.BeginInvoke(new Action<Int32>(delegate(Int32 i) { this.resnumhupdate(rescnt); }), new object[] { 0 });
                            break;
                        default:
                            // Invalid code;
                            throw new Exception("Invalid board code.");
                    }

                    string target = "";
                    if (bbstype == Const.BBS_2CH)
                    {
                        Match m = r5.Match(stArrayData[indexDate]);
                        if (!m.Success) { continue; }
                        string aid = m.Groups[7].Value;
                        // filter
                        if (aid.Contains(strID) && stArrayData[indexName].Contains(strNameSpace) && stArrayData[indexMail].Contains(strMailSpace))
                        {
                            // 経過時刻更新
                            DateTime d = DateTime.Parse(
                                m.Groups[1].Value + "/" + m.Groups[2].Value + "/" + m.Groups[3].Value + " " +
                                m.Groups[4].Value + ":" + m.Groups[5].Value + ":" + m.Groups[6].Value);
                            long tick = DateTime.Now.Ticks - d.Ticks;
                            if (this.timersec > tick / 10000000)
                            {
                                this.BeginInvoke(new Action<Int64>(delegate(Int64 i) { this.timersecupdate(tick / 10000000); }), new object[] { 0 });
                            }
                            string body = "";
                            string patternStr = @"<.*?>";
                            body = stArrayData[indexBody];
                            body = body.Replace("<br>", "\r\n");
                            body = Regex.Replace(body, patternStr, string.Empty, RegexOptions.Singleline);

                            // レス更新
                            string name =  stArrayData[indexName] + " " ;
                            string mail =  "[" + stArrayData[indexMail] + "] ";
                            string date = "";
                            string id = "";
                            string[] arrDate = stArrayData[indexDate].Split(' ');
                            try
                            {
                                date = arrDate[0] + " " + arrDate[1] + " ";
                            }
                            catch (Exception) { }
                            try
                            {
                                id = arrDate[2] + " ";
                            }
                            catch (Exception) { }
                            string num = rescnt.ToString() + " " ;
                            body = WebUtility.HtmlDecode(body);
                            target = strHi + num + name + mail + date + id + "\r\n" + body;
                            news++;
                        }
                    }
                    else if (bbstype == Const.BBS_SHITARABA)
                    {
                        Match m = r6.Match(stArrayData[indexDate]);
                        if (!m.Success) { continue; }
                        string aid = stArrayData[6];
                        if (aid.Contains(strID) && stArrayData[indexName].Contains(strNameSpace) && stArrayData[indexMail].Contains(strMailSpace))
                        {
                            // 経過時刻更新
                            DateTime d = DateTime.Parse(
                                m.Groups[1].Value + "/" + m.Groups[2].Value + "/" + m.Groups[3].Value + " " +
                                m.Groups[4].Value + ":" + m.Groups[5].Value + ":" + m.Groups[6].Value);
                            long tick = DateTime.Now.Ticks - d.Ticks;
                            if (this.timersec > tick / 10000000)
                            {
                                this.BeginInvoke(new Action<Int64>(delegate(Int64 i) { this.timersecupdate(tick / 10000000); }), new object[] { 0 });
                            }
                            string body = "";
                            string patternStr = @"<.*?>";
                            body = stArrayData[indexBody];
                            body = body.Replace("<br>", "\r\n");
                            body = Regex.Replace(body, patternStr, string.Empty, RegexOptions.Singleline);

                            // レス更新
                            string name =  stArrayData[indexName] + " " ;
                            string mail =  "[" + stArrayData[indexMail] + "] ";
                            string date =  stArrayData[indexDate] + " " ;
                            string id =  "ID:" + aid + " " ;
                            string num =  rescnt.ToString() + " " ;
                            body = WebUtility.HtmlDecode(body);
                            target = strHi + num + name + mail + date + id + "\r\n" + body;
                            news++;
                        }


                    }

                    if (target.Length != 0)
                    {
                        // 排他制御入れる
                        Monitor.Enter(syncObject);
                        try
                        {
                            this.BeginInvoke(new Action<String>(delegate(String str)
                            {
                                this.resoutput(target);
                            }), new object[] { "" });
                            Console.WriteLine(target);
                        }
                        catch (Exception ex)
                        {
                            // 何もしない
                            Console.WriteLine(ex.GetType());
                        }
                        finally
                        {
                            Monitor.Exit(syncObject);
                        }
                    }

                }

                if (news > 0) //レスがあった場合
                {
                    // 開始フラグ
                    this.BeginInvoke(new Action<Boolean>(delegate(Boolean str)
                    {
                        this.resexistupdate(true);
                    }), new object[] { false });



                    this.BeginInvoke(new Action(delegate()
                    {
                        this.resetbasetime();
                    }), new object[] { });
                }

                //閉じる
                //webres.Close()でもよい
                sr.Close();
                this.BeginInvoke(new Action<String>(delegate(String str) { this.logoutput(news.ToString() + "件の安価人レス取得"); }), new object[] { "" });
                this.BeginInvoke(new Action(delegate()
                {
                    this.resetthreaddup();
                }), new object[] { });
            }
            catch (InvalidOperationException ioex)
            {
                // 何もしない
                Console.WriteLine(ioex.Message);
            }
            catch (System.Threading.ThreadAbortException aex)
            {
                // 何もしない(スレッド強制終了時)
                Console.WriteLine(aex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                this.BeginInvoke(new Action<String>(delegate(String str) { this.logoutput("エラー:" + ex.Message); }), new object[] { "" });
            }
            finally
            {

            }
        }


        /// <summary>
        /// 書き込みキューフォーム表示／非表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox_queue_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox obj = (CheckBox)sender;
            if (obj.Checked)
            {
                QueueInstanse.Show();
            }
            else 
            {
                QueueInstanse.Hide();
            }
        }

        private void checkBox_option_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox obj = (CheckBox)sender;
            if (obj.Checked)
            {
                OptionInstanse.Show();
            }
            else
            {
                OptionInstanse.Hide();
            }
        }

        private void checkBox_view_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox obj = (CheckBox)sender;
            if (obj.Checked)
            {
                ViewInstanse.Show();
            }
            else
            {
                ViewInstanse.Hide();
            }
        }

        /// <summary>
        /// チェックボックス（トグル）変化
        /// </summary>
        /// <param name="checkBox"></param>
        /// <param name="bl"></param>
        private void changeChecked(CheckBox checkBox, bool bl)
        {
            checkBox.Checked = bl;
        }
        public void changeQueueChecked(bool bl)
        {
            checkBox_queue.Checked = bl;
        }
        public void changeOptionChecked(bool bl)
        {
            checkBox_option.Checked = bl;
        }
        public void changeViewChecked(bool bl)
        {
            checkBox_view.Checked = bl;
        }

        private void button_send_Click(object sender, EventArgs e)
        {
            if (textBox_res.Text == "") { return; }
            //キューに追加
            QueueInstanse.addQueueContainerBindingSource(new QueueContainer(textBox_name.Text,textBox_mail.Text,textBox_res.Text));
            //bodyをクリア
            textBox_res.Text = "";
        }


        // delegates
        public delegate void LogoutputDelegate(String str);
        public void logoutput(String str)
        {
            this.label_message.Text = DateTime.Now.ToString() + " " + str + "\r\n";
        }

        //label更新
        public delegate void ThreadnameupdateDelegate(String str);
        public void threadnameupdate(String str)
        {
            //this.label_threadname.Text = str;
            //タイトルバーにスレッド名を表示する
        }

        public delegate void ResoutputDelegate(String str);
        public void resoutput(String str)
        {
            //this.textBox1.AppendText(str + "\r\n");
            //this.textBox1.AppendText("------------------\r\n");
            //レスをリストに追加
            //MD5を生成
            //書き込みリストとぶつけて自分書き込みを検証
            //データをJSON化してViewの関数で処理×データ分かな
        }

        /// <summary>
        ///  読み込みレス番号更新
        /// </summary>
        /// <param name="i"></param>
        public delegate void ResnumupdateDelegate(Int32 i);
        public void resnumupdate(Int32 i)
        {
            this.resnum = i;
        }

        /// <summary>
        ///  読み込みレス番号更新(避難所)
        /// </summary>
        /// <param name="i"></param>
        public delegate void ResnumhupdateDelegate(Int32 i);
        public void resnumhupdate(Int32 i)
        {
            this.resnum_h = i;
        }

        // 経過秒更新
        public delegate void TimersecupdateDelegate(Int64 i);
        public void timersecupdate(Int64 i)
        {
            this.timersec = i;
        }

        public delegate void ResexistupdateDelegate(Boolean i);
        public void resexistupdate(Boolean i)
        {
            this.boolResExist = i;
        }

        public delegate void ResetbasetimeDelegate();
        public void resetbasetime()
        {
            this.basetime = 0;
            this.timerdiff = 0;
        }

        public delegate void ThreaddupDelegate();
        public void resetthreaddup()
        {
            this.boolThreadDup = false;
            this.boolThreadDup_h = false;
        }

        private void Form_Main_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Shift && e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                if (textBox_res.Text == "") { return; }
                //キューに追加
                QueueInstanse.addQueueContainerBindingSource(new QueueContainer(textBox_name.Text, textBox_mail.Text, textBox_res.Text));
                //bodyをクリア
                textBox_res.ResetText();
            }
        }

        private void textBox_res_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Shift && e.KeyCode == Keys.Enter)
            {
                Console.WriteLine(e.KeyCode);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                int SelectionStart = textBox_res.SelectionStart;
                this.textBox_res.Text = textBox_res.Text.Substring(0, textBox_res.SelectionStart)
 + Environment.NewLine 
 + textBox_res.Text.Substring(textBox_res.SelectionStart + textBox_res.SelectionLength);
                textBox_res.Select(SelectionStart + Environment.NewLine.Length, 0);
                //e.Handled = true;
            }
        }

        private void Form_Main_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                e.Handled = true;
        }

    }
}
