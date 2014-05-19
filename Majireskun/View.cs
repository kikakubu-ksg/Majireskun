using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Majireskun
{
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public partial class View : Form
    {
        // access member
        private Form_Main _parentForm;      //親フォーム

        public View()
        {
            InitializeComponent();
            
        }
        private void View_Load(object sender, EventArgs e)
        {
            webBrowser1.AllowWebBrowserDrop = false;
            webBrowser1.IsWebBrowserContextMenuEnabled = false;
            webBrowser1.WebBrowserShortcutsEnabled = false;
            webBrowser1.ObjectForScripting = this;
            this.webBrowser1.Navigate(System.Windows.Forms.Application.StartupPath + "\\index.html");
            //this.webBrowser1.Navigate("http://ksg.que.jp/tmp/bootstrap/index.html");
        }


        private void View_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
            this.Hide();
            _parentForm.changeViewChecked(false);
        }

        public Form_Main parentForm
        {
            get
            {

                return _parentForm;

            }
            set
            {
                _parentForm = value;
            }
        }

        public void Test(String message)
        {
            MessageBox.Show(message, "client code");
        }

        public void Reload()
        {
            //mainformのreloadを呼ぶ
            _parentForm.Reload();
        }

        //本スレURL
        public string getMainURL()
        {
            return (string)webBrowser1.Document.InvokeScript("getMainURL");
        }
        //避難所URL
        public string getHavenURL()
        {
            return (string)webBrowser1.Document.InvokeScript("getHavenURL");
        }

        //オートリロードフラグ
        public bool isAutoReload()
        {
            return (bool)this.webBrowser1.Document.InvokeScript("isAutoReload");
        }

        public void InvokeTestMethod(String name, String address)
        {
            if (webBrowser1.Document != null)
            {
                Object[] objArray = new Object[2];
                objArray[0] = (Object)name;
                objArray[1] = (Object)address;
                webBrowser1.Document.InvokeScript("testtest", objArray);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (webBrowser1.Document != null)
            {
                string name = "111";
                string address = "999";
                Object[] objArray = new Object[2];
                objArray[0] = (Object)name;
                objArray[1] = (Object)address;
                webBrowser1.Document.InvokeScript("testtest", objArray);
            }
        }

        public void inputres(String message)
        {
            if (webBrowser1.Document != null)
            {
                Object[] objArray = new Object[1];
                objArray[0] = (Object)message;
                webBrowser1.Document.InvokeScript("inputres", objArray);
            }
        }

        private void webBrowser1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //Console.WriteLine(e.KeyCode.ToString() + "  " + e.Modifiers.ToString());
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.V)
            {
                webBrowser1.Document.ExecCommand("Paste", false, null);
            }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.C) 
            {
                webBrowser1.Document.ExecCommand("Copy", false, null);
            }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.A)
            {
                webBrowser1.Document.ExecCommand("SELECTALL", false, null);
            }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Z)
            {
                webBrowser1.Document.ExecCommand("UNDO", false, null);
            }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.X)
            {
                webBrowser1.Document.ExecCommand("CUT", false, null);
            }
            
        }

    }
}
