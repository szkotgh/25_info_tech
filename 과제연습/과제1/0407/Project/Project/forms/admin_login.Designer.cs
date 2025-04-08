namespace Project.forms
{
    partial class admin_login
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
            this.login_btn = new System.Windows.Forms.Button();
            this.login_pw_txt = new System.Windows.Forms.TextBox();
            this.login_type_txt = new System.Windows.Forms.TextBox();
            this.login_pw_lb = new System.Windows.Forms.Label();
            this.login_type_lb = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // login_btn
            // 
            this.login_btn.AutoSize = true;
            this.login_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.login_btn.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.login_btn.ForeColor = System.Drawing.Color.White;
            this.login_btn.Location = new System.Drawing.Point(566, 134);
            this.login_btn.Name = "login_btn";
            this.login_btn.Size = new System.Drawing.Size(139, 88);
            this.login_btn.TabIndex = 13;
            this.login_btn.Text = "로그인";
            this.login_btn.UseVisualStyleBackColor = false;
            this.login_btn.Click += new System.EventHandler(this.login_btn_Click);
            // 
            // login_pw_txt
            // 
            this.login_pw_txt.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.login_pw_txt.Location = new System.Drawing.Point(182, 187);
            this.login_pw_txt.Name = "login_pw_txt";
            this.login_pw_txt.Size = new System.Drawing.Size(358, 35);
            this.login_pw_txt.TabIndex = 12;
            // 
            // login_type_txt
            // 
            this.login_type_txt.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.login_type_txt.Location = new System.Drawing.Point(182, 134);
            this.login_type_txt.Name = "login_type_txt";
            this.login_type_txt.Size = new System.Drawing.Size(358, 35);
            this.login_type_txt.TabIndex = 11;
            // 
            // login_pw_lb
            // 
            this.login_pw_lb.Font = new System.Drawing.Font("돋움", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.login_pw_lb.Location = new System.Drawing.Point(81, 187);
            this.login_pw_lb.Name = "login_pw_lb";
            this.login_pw_lb.Size = new System.Drawing.Size(95, 35);
            this.login_pw_lb.TabIndex = 10;
            this.login_pw_lb.Text = "PW";
            this.login_pw_lb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // login_type_lb
            // 
            this.login_type_lb.Font = new System.Drawing.Font("돋움", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.login_type_lb.Location = new System.Drawing.Point(81, 134);
            this.login_type_lb.Name = "login_type_lb";
            this.login_type_lb.Size = new System.Drawing.Size(95, 35);
            this.login_type_lb.TabIndex = 9;
            this.login_type_lb.Text = "ID";
            this.login_type_lb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // admin_login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 261);
            this.Controls.Add(this.login_btn);
            this.Controls.Add(this.login_pw_txt);
            this.Controls.Add(this.login_type_txt);
            this.Controls.Add(this.login_pw_lb);
            this.Controls.Add(this.login_type_lb);
            this.Name = "admin_login";
            this.Text = "관리자 로그인";
            this.Controls.SetChildIndex(this.login_type_lb, 0);
            this.Controls.SetChildIndex(this.login_pw_lb, 0);
            this.Controls.SetChildIndex(this.login_type_txt, 0);
            this.Controls.SetChildIndex(this.login_pw_txt, 0);
            this.Controls.SetChildIndex(this.login_btn, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button login_btn;
        private System.Windows.Forms.TextBox login_pw_txt;
        private System.Windows.Forms.TextBox login_type_txt;
        private System.Windows.Forms.Label login_pw_lb;
        private System.Windows.Forms.Label login_type_lb;
    }
}