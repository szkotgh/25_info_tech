namespace Project
{
    partial class mother
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mother));
            this.title = new System.Windows.Forms.Label();
            this.wave = new System.Windows.Forms.Label();
            this.wave2 = new System.Windows.Forms.Label();
            this.wave3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.title.Font = new System.Drawing.Font("맑은 고딕", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.title.ForeColor = System.Drawing.Color.White;
            this.title.Location = new System.Drawing.Point(0, 0);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(803, 102);
            this.title.TabIndex = 0;
            this.title.Text = "Let\'s corail";
            this.title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // wave
            // 
            this.wave.Location = new System.Drawing.Point(64, 20);
            this.wave.Name = "wave";
            this.wave.Size = new System.Drawing.Size(131, 10);
            this.wave.TabIndex = 1;
            // 
            // wave2
            // 
            this.wave2.Location = new System.Drawing.Point(12, 46);
            this.wave2.Name = "wave2";
            this.wave2.Size = new System.Drawing.Size(131, 10);
            this.wave2.TabIndex = 2;
            // 
            // wave3
            // 
            this.wave3.Location = new System.Drawing.Point(41, 73);
            this.wave3.Name = "wave3";
            this.wave3.Size = new System.Drawing.Size(131, 10);
            this.wave3.TabIndex = 3;
            // 
            // mother
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.wave3);
            this.Controls.Add(this.wave2);
            this.Controls.Add(this.wave);
            this.Controls.Add(this.title);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "mother";
            this.Text = "Form";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label wave;
        private System.Windows.Forms.Label wave2;
        private System.Windows.Forms.Label wave3;
    }
}

