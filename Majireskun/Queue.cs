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
    public partial class Queue : Form
    {
        // access member
        private Form_Main _parentForm;      //親フォーム

        public Queue()
        {
            InitializeComponent();
        }

        private void Queue_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
            this.Hide();
            _parentForm.changeQueueChecked(false);
        }

        // Properties
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

        // methods
        public void addQueueContainerBindingSource(QueueContainer cont)
        {
            queueContainerBindingSource.Add(cont);
        }
    }
}
