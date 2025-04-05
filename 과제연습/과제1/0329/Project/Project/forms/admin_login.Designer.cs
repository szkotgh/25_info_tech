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
            this.login_button = new System.Windows.Forms.Button();
            this.login_pw = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.login_id = new System.Windows.Forms.TextBox();
            this.login_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // login_button
            // 
            this.login_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.login_button.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.login_button.ForeColor = System.Drawing.Color.White;
            this.login_button.Location = new System.Drawing.Point(620, 129);
            this.login_button.Name = "login_button";
            this.login_button.Size = new System.Drawing.Size(150, 71);
            this.login_button.TabIndex = 13;
            this.login_button.Text = "로그인";
            this.login_button.UseVisualStyleBackColor = false;
            this.login_button.Click += new System.EventHandler(this.login_button_Click);
            // 
            // login_pw
            // 
            this.login_pw.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.login_pw.Location = new System.Drawing.Point(184, 174);
            this.login_pw.Name = "login_pw";
            this.login_pw.Size = new System.Drawing.Size(419, 29);
            this.login_pw.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(31, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 36);
            this.label1.TabIndex = 11;
            this.label1.Text = "PW";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // login_id
            // 
            this.login_id.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.login_id.Location = new System.Drawing.Point(184, 127);
            this.login_id.Name = "login_id";
            this.login_id.Size = new System.Drawing.Size(419, 29);
            this.login_id.TabIndex = 10;
            // 
            // login_label
            // 
            this.login_label.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.login_label.Location = new System.Drawing.Point(31, 124);
            this.login_label.Name = "login_label";
            this.login_label.Size = new System.Drawing.Size(131, 36);
            this.login_label.TabIndex = 9;
            this.login_label.Text = "ID";
            this.login_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // admin_login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 240);
            this.Controls.Add(this.login_button);
            this.Controls.Add(this.login_pw);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.login_id);
            this.Controls.Add(this.login_label);
            this.Name = "admin_login";
            this.Text = "admin_login";
            this.Controls.SetChildIndex(this.login_label, 0);
            this.Controls.SetChildIndex(this.login_id, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.login_pw, 0);
            this.Controls.SetChildIndex(this.login_button, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button login_button;
        private System.Windows.Forms.TextBox login_pw;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox login_id;
        private System.Windows.Forms.Label login_label;
    }
}