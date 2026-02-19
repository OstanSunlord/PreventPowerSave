
namespace PreventPowerSave.Client
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
            this.btnClose = new PreventPowerSave.Client.AButton(this.components);
            this.btnConfig = new PreventPowerSave.Client.AButton(this.components);
            this.bthStartAndStop = new PreventPowerSave.Client.AButton(this.components);
            this.pbWorkingStatus = new System.Windows.Forms.ProgressBar();
            this.lbEndTimeContext = new System.Windows.Forms.Label();
            this.btnScheduler = new PreventPowerSave.Client.AButton(this.components);
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(260, 82);
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
            this.btnConfig.ForeColor = System.Drawing.Color.Black;
            this.btnConfig.Location = new System.Drawing.Point(179, 82);
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
            this.bthStartAndStop.Location = new System.Drawing.Point(12, 82);
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
            this.pbWorkingStatus.ForeColor = System.Drawing.SystemColors.Control;
            this.pbWorkingStatus.Location = new System.Drawing.Point(12, 51);
            this.pbWorkingStatus.Name = "pbWorkingStatus";
            this.pbWorkingStatus.Size = new System.Drawing.Size(323, 25);
            this.pbWorkingStatus.TabIndex = 3;
            this.pbWorkingStatus.Value = 50;
            // 
            // lbEndTimeContext
            // 
            this.lbEndTimeContext.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbEndTimeContext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbEndTimeContext.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEndTimeContext.Location = new System.Drawing.Point(12, 9);
            this.lbEndTimeContext.Name = "lbEndTimeContext";
            this.lbEndTimeContext.Size = new System.Drawing.Size(323, 39);
            this.lbEndTimeContext.TabIndex = 4;
            this.lbEndTimeContext.Text = "End time: 10-01-2022 17:00";
            this.lbEndTimeContext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnScheduler
            // 
            this.btnScheduler.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnScheduler.BackColor = System.Drawing.SystemColors.Control;
            this.btnScheduler.ForeColor = System.Drawing.Color.Black;
            this.btnScheduler.Location = new System.Drawing.Point(98, 82);
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
            this.ClientSize = new System.Drawing.Size(347, 120);
            this.Controls.Add(this.btnScheduler);
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

        }

        #endregion

        private AButton btnClose;
        private AButton btnConfig;
        private AButton bthStartAndStop;
        private System.Windows.Forms.ProgressBar pbWorkingStatus;
        private System.Windows.Forms.Label lbEndTimeContext;
        private AButton btnScheduler;
    }
}