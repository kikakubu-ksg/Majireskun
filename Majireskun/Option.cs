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
    public partial class Option : Form
    {
        // access member
        private Form_Main _parentForm;      //親フォーム

        public Option()
        {
            InitializeComponent();
        }

        private void Option_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
            this.Hide();
            _parentForm.changeOptionChecked(false);
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

    }
}
