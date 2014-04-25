namespace Majireskun
{
    partial class Queue
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.queueContainerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.noDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CheckBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Resname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Resmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Res = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusStr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RtimeStr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FingerPrint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.queueContainerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.noDataGridViewTextBoxColumn,
            this.CheckBox,
            this.Resname,
            this.Resmail,
            this.Res,
            this.StatusStr,
            this.RtimeStr,
            this.FingerPrint});
            this.dataGridView1.DataSource = this.queueContainerBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(762, 329);
            this.dataGridView1.TabIndex = 0;
            // 
            // queueContainerBindingSource
            // 
            this.queueContainerBindingSource.DataSource = typeof(Majireskun.QueueContainer);
            // 
            // noDataGridViewTextBoxColumn
            // 
            this.noDataGridViewTextBoxColumn.DataPropertyName = "No";
            this.noDataGridViewTextBoxColumn.HeaderText = "No";
            this.noDataGridViewTextBoxColumn.Name = "noDataGridViewTextBoxColumn";
            this.noDataGridViewTextBoxColumn.ReadOnly = true;
            this.noDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.noDataGridViewTextBoxColumn.Width = 30;
            // 
            // CheckBox
            // 
            this.CheckBox.HeaderText = "CheckBox";
            this.CheckBox.Name = "CheckBox";
            this.CheckBox.ReadOnly = true;
            // 
            // Resname
            // 
            this.Resname.DataPropertyName = "Resname";
            this.Resname.HeaderText = "名前";
            this.Resname.Name = "Resname";
            this.Resname.ReadOnly = true;
            this.Resname.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Resmail
            // 
            this.Resmail.DataPropertyName = "Resmail";
            this.Resmail.HeaderText = "メアド";
            this.Resmail.Name = "Resmail";
            this.Resmail.ReadOnly = true;
            this.Resmail.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Res
            // 
            this.Res.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Res.DataPropertyName = "Res";
            this.Res.HeaderText = "書き込み内容";
            this.Res.Name = "Res";
            this.Res.ReadOnly = true;
            this.Res.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // StatusStr
            // 
            this.StatusStr.DataPropertyName = "StatusStr";
            this.StatusStr.HeaderText = "ステータス";
            this.StatusStr.Name = "StatusStr";
            this.StatusStr.ReadOnly = true;
            this.StatusStr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // RtimeStr
            // 
            this.RtimeStr.DataPropertyName = "RtimeStr";
            this.RtimeStr.HeaderText = "登録時刻";
            this.RtimeStr.Name = "RtimeStr";
            this.RtimeStr.ReadOnly = true;
            this.RtimeStr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // FingerPrint
            // 
            this.FingerPrint.DataPropertyName = "FingerPrint";
            this.FingerPrint.HeaderText = "MD5";
            this.FingerPrint.Name = "FingerPrint";
            this.FingerPrint.ReadOnly = true;
            this.FingerPrint.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Queue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 329);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Queue";
            this.Text = "Queue";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Queue_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.queueContainerBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource queueContainerBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn noDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn Resname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Resmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn Res;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusStr;
        private System.Windows.Forms.DataGridViewTextBoxColumn RtimeStr;
        private System.Windows.Forms.DataGridViewTextBoxColumn FingerPrint;
    }
}