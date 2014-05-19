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
            this.textBox_res = new System.Windows.Forms.TextBox();
            this.checkBox_option = new System.Windows.Forms.CheckBox();
            this.checkBox_view = new System.Windows.Forms.CheckBox();
            this.checkBox_queue = new System.Windows.Forms.CheckBox();
            this.label_message = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.textBox_mail = new System.Windows.Forms.TextBox();
            this.label_name = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox_Autoreload = new System.Windows.Forms.CheckBox();
            this.checkBox_assyncwrite = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_send
            // 
            this.button_send.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_send.Location = new System.Drawing.Point(402, 246);
            this.button_send.Name = "button_send";
            this.button_send.Size = new System.Drawing.Size(75, 23);
            this.button_send.TabIndex = 0;
            this.button_send.Text = "Send";
            this.button_send.UseVisualStyleBackColor = true;
            this.button_send.Click += new System.EventHandler(this.button_send_Click);
            // 
            // textBox_res
            // 
            this.textBox_res.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_res.Location = new System.Drawing.Point(2, 59);
            this.textBox_res.Multiline = true;
            this.textBox_res.Name = "textBox_res";
            this.textBox_res.Size = new System.Drawing.Size(475, 181);
            this.textBox_res.TabIndex = 1;
            this.textBox_res.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_res_KeyDown);
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
            this.checkBox_queue.Location = new System.Drawing.Point(330, 1);
            this.checkBox_queue.Name = "checkBox_queue";
            this.checkBox_queue.Size = new System.Drawing.Size(47, 22);
            this.checkBox_queue.TabIndex = 4;
            this.checkBox_queue.Text = "Queue";
            this.checkBox_queue.UseVisualStyleBackColor = true;
            this.checkBox_queue.CheckedChanged += new System.EventHandler(this.checkBox_queue_CheckedChanged);
            // 
            // label_message
            // 
            this.label_message.AutoSize = true;
            this.label_message.Location = new System.Drawing.Point(4, 248);
            this.label_message.Name = "label_message";
            this.label_message.Size = new System.Drawing.Size(75, 12);
            this.label_message.TabIndex = 5;
            this.label_message.Text = "tiny-message";
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
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(49, 34);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(100, 19);
            this.textBox_name.TabIndex = 7;
            // 
            // textBox_mail
            // 
            this.textBox_mail.Location = new System.Drawing.Point(193, 34);
            this.textBox_mail.Name = "textBox_mail";
            this.textBox_mail.Size = new System.Drawing.Size(100, 19);
            this.textBox_mail.TabIndex = 8;
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Location = new System.Drawing.Point(8, 37);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(32, 12);
            this.label_name.TabIndex = 9;
            this.label_name.Text = "name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(161, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "mail";
            // 
            // checkBox_Autoreload
            // 
            this.checkBox_Autoreload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox_Autoreload.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_Autoreload.AutoSize = true;
            this.checkBox_Autoreload.Location = new System.Drawing.Point(165, 1);
            this.checkBox_Autoreload.Name = "checkBox_Autoreload";
            this.checkBox_Autoreload.Size = new System.Drawing.Size(74, 22);
            this.checkBox_Autoreload.TabIndex = 11;
            this.checkBox_Autoreload.Text = "AutoReload";
            this.checkBox_Autoreload.UseVisualStyleBackColor = true;
            // 
            // checkBox_assyncwrite
            // 
            this.checkBox_assyncwrite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox_assyncwrite.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_assyncwrite.AutoSize = true;
            this.checkBox_assyncwrite.Location = new System.Drawing.Point(245, 1);
            this.checkBox_assyncwrite.Name = "checkBox_assyncwrite";
            this.checkBox_assyncwrite.Size = new System.Drawing.Size(79, 22);
            this.checkBox_assyncwrite.TabIndex = 12;
            this.checkBox_assyncwrite.Text = "AssyncWrite";
            this.checkBox_assyncwrite.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(321, 246);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 269);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBox_assyncwrite);
            this.Controls.Add(this.checkBox_Autoreload);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label_name);
            this.Controls.Add(this.textBox_mail);
            this.Controls.Add(this.textBox_name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_message);
            this.Controls.Add(this.checkBox_queue);
            this.Controls.Add(this.checkBox_view);
            this.Controls.Add(this.checkBox_option);
            this.Controls.Add(this.textBox_res);
            this.Controls.Add(this.button_send);
            this.KeyPreview = true;
            this.Name = "Form_Main";
            this.Text = "Form_main";
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form_Main_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form_Main_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_send;
        private System.Windows.Forms.TextBox textBox_res;
        private System.Windows.Forms.CheckBox checkBox_option;
        private System.Windows.Forms.CheckBox checkBox_view;
        private System.Windows.Forms.CheckBox checkBox_queue;
        private System.Windows.Forms.Label label_message;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.TextBox textBox_mail;
        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox_Autoreload;
        private System.Windows.Forms.CheckBox checkBox_assyncwrite;
        private System.Windows.Forms.Button button1;


    }
}

