using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Majireskun
{
    public partial class Form_Main : Form
    {
        public Option OptionInstanse;   // バージョン情報フォーム
        public Queue QueueInstanse;     // 設定フォーム
        public View ViewInstanse;       // スレ表示フォーム
        public Thread th = null;        // 本スレ取得スレッド
        public Thread th_h = null;      // 避難所スレ取得スレッド
        static readonly object syncObject = new object(); // 同期オブジェクト

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


    }
}
