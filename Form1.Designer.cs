namespace PDFUncompress
{
    partial class Form1
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
            this.btnUncompress = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnUncompress
            // 
            this.btnUncompress.Location = new System.Drawing.Point(33, 14);
            this.btnUncompress.Name = "btnUncompress";
            this.btnUncompress.Size = new System.Drawing.Size(150, 28);
            this.btnUncompress.TabIndex = 0;
            this.btnUncompress.Text = "解凍";
            this.btnUncompress.UseVisualStyleBackColor = true;
            this.btnUncompress.Click += new System.EventHandler(this.btnUncompress_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(208, 62);
            this.Controls.Add(this.btnUncompress);
            this.Name = "Form1";
            this.Text = "PDF解凍";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUncompress;
    }
}

