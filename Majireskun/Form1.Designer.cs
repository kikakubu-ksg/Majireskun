namespace Majireskun
{
    partial class Form_Main
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button_send = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.checkBox_option = new System.Windows.Forms.CheckBox();
            this.checkBox_view = new System.Windows.Forms.CheckBox();
            this.checkBox_queue = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // button_send
            // 
            this.button_send.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_send.Location = new System.Drawing.Point(402, 206);
            this.button_send.Name = "button_send";
            this.button_send.Size = new System.Drawing.Size(75, 23);
            this.button_send.TabIndex = 0;
            this.button_send.Text = "Send";
            this.button_send.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(2, 29);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(475, 171);
            this.textBox1.TabIndex = 1;
            // 
            // checkBox_option
            // 
            this.checkBox_option.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox_option.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_option.AutoSize = true;
            this.checkBox_option.Location = new System.Drawing.Point(383, 1);
            this.checkBox_option.Name = "checkBox_option";
            this.checkBox_option.Size = new System.Drawing.Size(48, 22);
            this.checkBox_option.TabIndex = 2;
            this.checkBox_option.Text = "Option";
            this.checkBox_option.UseVisualStyleBackColor = true;
            this.checkBox_option.CheckedChanged += new System.EventHandler(this.checkBox_option_CheckedChanged);
            // 
            // checkBox_view
            // 
            this.checkBox_view.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox_view.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_view.AutoSize = true;
            this.checkBox_view.Location = new System.Drawing.Point(437, 1);
            this.checkBox_view.Name = "checkBox_view";
            this.checkBox_view.Size = new System.Drawing.Size(40, 22);
            this.checkBox_view.TabIndex = 3;
            this.checkBox_view.Text = "View";
            this.checkBox_view.UseVisualStyleBackColor = true;
            this.checkBox_view.CheckedChanged += new System.EventHandler(this.checkBox_view_CheckedChanged);
            // 
            // checkBox_queue
            // 
            this.checkBox_queue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox_queue.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_queue.AutoSize = true;
            this.checkBox_queue.Location = new System.Drawing.Point(327, 1);
            this.checkBox_queue.Name = "checkBox_queue";
            this.checkBox_queue.Size = new System.Drawing.Size(47, 22);
            this.checkBox_queue.TabIndex = 4;
            this.checkBox_queue.Text = "Queue";
            this.checkBox_queue.UseVisualStyleBackColor = true;
            this.checkBox_queue.CheckedChanged += new System.EventHandler(this.checkBox_queue_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 211);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "tiny-message";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "timer-message";
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 229);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox_queue);
            this.Controls.Add(this.checkBox_view);
            this.Controls.Add(this.checkBox_option);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button_send);
            this.Name = "Form_Main";
            this.Text = "Form_main";
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_send;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox checkBox_option;
        private System.Windows.Forms.CheckBox checkBox_view;
        private System.Windows.Forms.CheckBox checkBox_queue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;


    }
}

