
namespace PreventLockScreen.Client
{
    partial class RunDialog
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
            this.components = new System.ComponentModel.Container();
            this.btnClose = new PreventLockScreen.Client.AButton(this.components);
            this.btnConfig = new PreventLockScreen.Client.AButton(this.components);
            this.bthStartAndStop = new PreventLockScreen.Client.AButton(this.components);
            this.pbWorkingStatus = new System.Windows.Forms.ProgressBar();
            this.lbEndTimeContext = new System.Windows.Forms.Label();
            this.lbStatusContext = new System.Windows.Forms.Label();
            this.btnScheduler = new PreventLockScreen.Client.AButton(this.components);
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(320, 88);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 25);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnConfig
            // 
            this.btnConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfig.BackColor = System.Drawing.SystemColors.Control;
            this.btnConfig.FlatAppearance.BorderSize = 0;
            this.btnConfig.ForeColor = System.Drawing.Color.Black;
            this.btnConfig.Location = new System.Drawing.Point(239, 88);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(75, 25);
            this.btnConfig.TabIndex = 1;
            this.btnConfig.Text = "Config";
            this.btnConfig.UseVisualStyleBackColor = false;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // bthStartAndStop
            // 
            this.bthStartAndStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bthStartAndStop.BackColor = System.Drawing.SystemColors.Control;
            this.bthStartAndStop.ForeColor = System.Drawing.Color.Black;
            this.bthStartAndStop.Location = new System.Drawing.Point(12, 88);
            this.bthStartAndStop.Name = "bthStartAndStop";
            this.bthStartAndStop.Size = new System.Drawing.Size(75, 25);
            this.bthStartAndStop.TabIndex = 0;
            this.bthStartAndStop.Text = "Start";
            this.bthStartAndStop.UseVisualStyleBackColor = false;
            this.bthStartAndStop.Click += new System.EventHandler(this.bthStartAndStop_Click);
            // 
            // pbWorkingStatus
            // 
            this.pbWorkingStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbWorkingStatus.Location = new System.Drawing.Point(12, 57);
            this.pbWorkingStatus.Name = "pbWorkingStatus";
            this.pbWorkingStatus.Size = new System.Drawing.Size(383, 25);
            this.pbWorkingStatus.TabIndex = 3;
            this.pbWorkingStatus.Value = 50;
            // 
            // lbEndTimeContext
            // 
            this.lbEndTimeContext.AutoSize = true;
            this.lbEndTimeContext.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEndTimeContext.Location = new System.Drawing.Point(12, 9);
            this.lbEndTimeContext.Name = "lbEndTimeContext";
            this.lbEndTimeContext.Size = new System.Drawing.Size(97, 29);
            this.lbEndTimeContext.TabIndex = 4;
            this.lbEndTimeContext.Text = "<Date>";
            // 
            // lbStatusContext
            // 
            this.lbStatusContext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbStatusContext.AutoSize = true;
            this.lbStatusContext.Location = new System.Drawing.Point(333, 9);
            this.lbStatusContext.Name = "lbStatusContext";
            this.lbStatusContext.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbStatusContext.Size = new System.Drawing.Size(65, 16);
            this.lbStatusContext.TabIndex = 5;
            this.lbStatusContext.Text = "<STATE>";
            this.lbStatusContext.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnScheduler
            // 
            this.btnScheduler.BackColor = System.Drawing.SystemColors.Control;
            this.btnScheduler.ForeColor = System.Drawing.Color.Black;
            this.btnScheduler.Location = new System.Drawing.Point(158, 88);
            this.btnScheduler.Name = "btnScheduler";
            this.btnScheduler.Size = new System.Drawing.Size(75, 25);
            this.btnScheduler.TabIndex = 6;
            this.btnScheduler.Text = "Scheduler";
            this.btnScheduler.UseVisualStyleBackColor = false;
            this.btnScheduler.Click += new System.EventHandler(this.btnScheduler_Click);
            // 
            // RunDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 126);
            this.Controls.Add(this.btnScheduler);
            this.Controls.Add(this.lbStatusContext);
            this.Controls.Add(this.lbEndTimeContext);
            this.Controls.Add(this.pbWorkingStatus);
            this.Controls.Add(this.bthStartAndStop);
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "RunDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Prevent Lockscreen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AButton btnClose;
        private AButton btnConfig;
        private AButton bthStartAndStop;
        private System.Windows.Forms.ProgressBar pbWorkingStatus;
        private System.Windows.Forms.Label lbEndTimeContext;
        private System.Windows.Forms.Label lbStatusContext;
        private AButton btnScheduler;
    }
}