namespace Project
{
    partial class Mother
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mother));
            this.title = new System.Windows.Forms.Label();
            this.wave = new System.Windows.Forms.Label();
            this.asdasdasd = new System.Windows.Forms.Label();
            this.dasdasd = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.title.Font = new System.Drawing.Font("맑은 고딕", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.title.ForeColor = System.Drawing.Color.White;
            this.title.Location = new System.Drawing.Point(0, 0);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(800, 92);
            this.title.TabIndex = 0;
            this.title.Text = "Let\'s corail";
            this.title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // wave
            // 
            this.wave.BackColor = System.Drawing.Color.White;
            this.wave.Location = new System.Drawing.Point(71, 20);
            this.wave.Name = "wave";
            this.wave.Size = new System.Drawing.Size(113, 10);
            this.wave.TabIndex = 1;
            // 
            // asdasdasd
            // 
            this.asdasdasd.BackColor = System.Drawing.Color.White;
            this.asdasdasd.Location = new System.Drawing.Point(12, 40);
            this.asdasdasd.Name = "asdasdasd";
            this.asdasdasd.Size = new System.Drawing.Size(113, 10);
            this.asdasdasd.TabIndex = 2;
            // 
            // dasdasd
            // 
            this.dasdasd.BackColor = System.Drawing.Color.White;
            this.dasdasd.Location = new System.Drawing.Point(44, 62);
            this.dasdasd.Name = "dasdasd";
            this.dasdasd.Size = new System.Drawing.Size(113, 10);
            this.dasdasd.TabIndex = 3;
            // 
            // Mother
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dasdasd);
            this.Controls.Add(this.asdasdasd);
            this.Controls.Add(this.wave);
            this.Controls.Add(this.title);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Mother";
            this.Text = "mother";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label wave;
        private System.Windows.Forms.Label asdasdasd;
        private System.Windows.Forms.Label dasdasd;
    }
}

