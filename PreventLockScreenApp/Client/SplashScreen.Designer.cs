
namespace ImNotAFK.Client
{
    partial class SplashScreen
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
            this.PictureBoxSplashScreen = new System.Windows.Forms.PictureBox();
            this.lbLoadingText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxSplashScreen)).BeginInit();
            this.SuspendLayout();
            // 
            // PictureBoxSplashScreen
            // 
            this.PictureBoxSplashScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PictureBoxSplashScreen.Image = global::ImNotAFK.Properties.Resources.loadingScreen;
            this.PictureBoxSplashScreen.Location = new System.Drawing.Point(0, 0);
            this.PictureBoxSplashScreen.Name = "PictureBoxSplashScreen";
            this.PictureBoxSplashScreen.Size = new System.Drawing.Size(400, 225);
            this.PictureBoxSplashScreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBoxSplashScreen.TabIndex = 0;
            this.PictureBoxSplashScreen.TabStop = false;
            // 
            // lbLoadingText
            // 
            this.lbLoadingText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbLoadingText.AutoSize = true;
            this.lbLoadingText.BackColor = System.Drawing.Color.White;
            this.lbLoadingText.Location = new System.Drawing.Point(334, 9);
            this.lbLoadingText.Name = "lbLoadingText";
            this.lbLoadingText.Size = new System.Drawing.Size(54, 13);
            this.lbLoadingText.TabIndex = 1;
            this.lbLoadingText.Text = "Loading...";
            // 
            // SplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 225);
            this.Controls.Add(this.lbLoadingText);
            this.Controls.Add(this.PictureBoxSplashScreen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SplashScreen";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SplashScreen";
            this.Shown += new System.EventHandler(this.SplashScreen_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxSplashScreen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PictureBoxSplashScreen;
        private System.Windows.Forms.Label lbLoadingText;
    }
}