namespace EncryptDocuments
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chk_password = new System.Windows.Forms.CheckBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_open = new System.Windows.Forms.Button();
            this.txt_file = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_enc = new System.Windows.Forms.Button();
            this.btn_dec = new System.Windows.Forms.Button();
            this.ofd_Menu = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chk_password);
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt_password);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btn_open);
            this.groupBox1.Controls.Add(this.txt_file);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(343, 160);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Encrypt files";
            // 
            // chk_password
            // 
            this.chk_password.AutoSize = true;
            this.chk_password.Location = new System.Drawing.Point(253, 63);
            this.chk_password.Name = "chk_password";
            this.chk_password.Size = new System.Drawing.Size(84, 16);
            this.chk_password.TabIndex = 8;
            this.chk_password.Text = "비밀번호 표시";
            this.chk_password.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(119, 112);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(218, 23);
            this.progressBar1.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(117, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(182, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "(비밀번호는 6 자리 이상이어야합니다.)";
            // 
            // txt_password
            // 
            this.txt_password.Location = new System.Drawing.Point(119, 61);
            this.txt_password.Name = "txt_password";
            this.txt_password.Size = new System.Drawing.Size(119, 21);
            this.txt_password.TabIndex = 5;
            this.txt_password.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "암호화/복호화 진행：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "암호화/복호화 암호：";
            // 
            // btn_open
            // 
            this.btn_open.Location = new System.Drawing.Point(303, 31);
            this.btn_open.Name = "btn_open";
            this.btn_open.Size = new System.Drawing.Size(34, 23);
            this.btn_open.TabIndex = 2;
            this.btn_open.Text = "열기";
            this.btn_open.UseVisualStyleBackColor = true;
            this.btn_open.Click += new System.EventHandler(this.btn_open_Click);
            // 
            // txt_file
            // 
            this.txt_file.Location = new System.Drawing.Point(14, 33);
            this.txt_file.Name = "txt_file";
            this.txt_file.Size = new System.Drawing.Size(275, 21);
            this.txt_file.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "파일 암호화 또는 복호화 선택:";
            // 
            // btn_enc
            // 
            this.btn_enc.Location = new System.Drawing.Point(193, 183);
            this.btn_enc.Name = "btn_enc";
            this.btn_enc.Size = new System.Drawing.Size(75, 23);
            this.btn_enc.TabIndex = 1;
            this.btn_enc.Text = "암호화";
            this.btn_enc.UseVisualStyleBackColor = true;
            // 
            // btn_dec
            // 
            this.btn_dec.Location = new System.Drawing.Point(274, 183);
            this.btn_dec.Name = "btn_dec";
            this.btn_dec.Size = new System.Drawing.Size(75, 23);
            this.btn_dec.TabIndex = 2;
            this.btn_dec.Text = "복호화";
            this.btn_dec.UseVisualStyleBackColor = true;
            // 
            // ofd_Menu
            // 
            this.ofd_Menu.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 229);
            this.Controls.Add(this.btn_dec);
            this.Controls.Add(this.btn_enc);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "파일 암호화";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_open;
        private System.Windows.Forms.TextBox txt_file;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_enc;
        private System.Windows.Forms.CheckBox chk_password;
        private System.Windows.Forms.Button btn_dec;
        private System.Windows.Forms.OpenFileDialog ofd_Menu;
    }
}

