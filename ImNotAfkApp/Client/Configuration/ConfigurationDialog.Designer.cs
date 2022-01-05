
namespace ImNotAfkApp.Client.Configuration
{
    partial class ConfigurationDialog
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
            this.lbThemeHeader = new System.Windows.Forms.Label();
            this.cbThemeSelect = new System.Windows.Forms.ComboBox();
            this.cbRunOnStart = new System.Windows.Forms.CheckBox();
            this.btnAmend = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lbIntervalHeader = new System.Windows.Forms.Label();
            this.tbInterVal = new System.Windows.Forms.TextBox();
            this.lbMinuteHeader = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbThemeHeader
            // 
            this.lbThemeHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbThemeHeader.AutoSize = true;
            this.lbThemeHeader.Location = new System.Drawing.Point(16, 18);
            this.lbThemeHeader.Name = "lbThemeHeader";
            this.lbThemeHeader.Size = new System.Drawing.Size(53, 16);
            this.lbThemeHeader.TabIndex = 0;
            this.lbThemeHeader.Text = "Theme:";
            // 
            // cbThemeSelect
            // 
            this.cbThemeSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbThemeSelect.FormattingEnabled = true;
            this.cbThemeSelect.Location = new System.Drawing.Point(86, 15);
            this.cbThemeSelect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbThemeSelect.Name = "cbThemeSelect";
            this.cbThemeSelect.Size = new System.Drawing.Size(140, 24);
            this.cbThemeSelect.TabIndex = 2;
            // 
            // cbRunOnStart
            // 
            this.cbRunOnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbRunOnStart.AutoSize = true;
            this.cbRunOnStart.Location = new System.Drawing.Point(115, 124);
            this.cbRunOnStart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbRunOnStart.Name = "cbRunOnStart";
            this.cbRunOnStart.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbRunOnStart.Size = new System.Drawing.Size(111, 20);
            this.cbRunOnStart.TabIndex = 3;
            this.cbRunOnStart.Text = "Run on startup";
            this.cbRunOnStart.UseVisualStyleBackColor = true;
            // 
            // btnAmend
            // 
            this.btnAmend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAmend.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnAmend.Location = new System.Drawing.Point(45, 152);
            this.btnAmend.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAmend.Name = "btnAmend";
            this.btnAmend.Size = new System.Drawing.Size(87, 28);
            this.btnAmend.TabIndex = 4;
            this.btnAmend.Text = "Amend";
            this.btnAmend.UseVisualStyleBackColor = true;
            this.btnAmend.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(139, 152);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 28);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btn_Click);
            // 
            // lbIntervalHeader
            // 
            this.lbIntervalHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbIntervalHeader.AutoSize = true;
            this.lbIntervalHeader.Location = new System.Drawing.Point(16, 48);
            this.lbIntervalHeader.Name = "lbIntervalHeader";
            this.lbIntervalHeader.Size = new System.Drawing.Size(56, 16);
            this.lbIntervalHeader.TabIndex = 6;
            this.lbIntervalHeader.Text = "Interval:";
            // 
            // tbInterVal
            // 
            this.tbInterVal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbInterVal.Location = new System.Drawing.Point(86, 45);
            this.tbInterVal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbInterVal.Name = "tbInterVal";
            this.tbInterVal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tbInterVal.Size = new System.Drawing.Size(70, 23);
            this.tbInterVal.TabIndex = 7;
            this.tbInterVal.Text = "120";
            // 
            // lbMinuteHeader
            // 
            this.lbMinuteHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbMinuteHeader.AutoSize = true;
            this.lbMinuteHeader.Location = new System.Drawing.Point(162, 48);
            this.lbMinuteHeader.Name = "lbMinuteHeader";
            this.lbMinuteHeader.Size = new System.Drawing.Size(53, 16);
            this.lbMinuteHeader.TabIndex = 8;
            this.lbMinuteHeader.Text = "minutes";
            // 
            // ConfigurationDialog
            // 
            this.AcceptButton = this.btnAmend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 195);
            this.Controls.Add(this.lbMinuteHeader);
            this.Controls.Add(this.tbInterVal);
            this.Controls.Add(this.lbIntervalHeader);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAmend);
            this.Controls.Add(this.cbRunOnStart);
            this.Controls.Add(this.cbThemeSelect);
            this.Controls.Add(this.lbThemeHeader);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigurationDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ConfigurationView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbThemeHeader;
        private System.Windows.Forms.ComboBox cbThemeSelect;
        private System.Windows.Forms.CheckBox cbRunOnStart;
        private System.Windows.Forms.Button btnAmend;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lbIntervalHeader;
        private System.Windows.Forms.TextBox tbInterVal;
        private System.Windows.Forms.Label lbMinuteHeader;
    }
}