
namespace PreventLockScreen.Client
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
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxSplashScreen)).BeginInit();
            this.SuspendLayout();
            // 
            // PictureBoxSplashScreen
            // 
            this.PictureBoxSplashScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PictureBoxSplashScreen.Image = global::PreventLockScreen.Properties.Resources.loadingScreen;
            this.PictureBoxSplashScreen.Location = new System.Drawing.Point(0, 0);
            this.PictureBoxSplashScreen.Name = "PictureBoxSplashScreen";
            this.PictureBoxSplashScreen.Size = new System.Drawing.Size(400, 225);
            this.PictureBoxSplashScreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBoxSplashScreen.TabIndex = 0;
            this.PictureBoxSplashScreen.TabStop = false;
            // 
            // SplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 225);
            this.Controls.Add(this.PictureBoxSplashScreen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SplashScreen";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SplashScreen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SplashScreen_FormClosing);
            this.Shown += new System.EventHandler(this.SplashScreen_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxSplashScreen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PictureBoxSplashScreen;
    }
}