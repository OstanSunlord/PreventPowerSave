
namespace PreventPowerSave.Client
{
    partial class AddOrEditSchedulerDialog
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
            this.lbTitleHeader = new System.Windows.Forms.Label();
            this.lbStartHeader = new System.Windows.Forms.Label();
            this.lbEndHeader = new System.Windows.Forms.Label();
            this.txTitle = new System.Windows.Forms.TextBox();
            this.nubStart = new System.Windows.Forms.NumericUpDown();
            this.nubEnd = new System.Windows.Forms.NumericUpDown();
            this.btnCancel = new PreventPowerSave.Client.AButton(this.components);
            this.btnAmend = new PreventPowerSave.Client.AButton(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nubStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nubEnd)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTitleHeader
            // 
            this.lbTitleHeader.AutoSize = true;
            this.lbTitleHeader.Location = new System.Drawing.Point(12, 20);
            this.lbTitleHeader.Name = "lbTitleHeader";
            this.lbTitleHeader.Size = new System.Drawing.Size(30, 13);
            this.lbTitleHeader.TabIndex = 0;
            this.lbTitleHeader.Text = "Title:";
            // 
            // lbStartHeader
            // 
            this.lbStartHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbStartHeader.AutoSize = true;
            this.lbStartHeader.Location = new System.Drawing.Point(51, 45);
            this.lbStartHeader.Name = "lbStartHeader";
            this.lbStartHeader.Size = new System.Drawing.Size(29, 13);
            this.lbStartHeader.TabIndex = 1;
            this.lbStartHeader.Text = "Start";
            // 
            // lbEndHeader
            // 
            this.lbEndHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbEndHeader.AutoSize = true;
            this.lbEndHeader.Location = new System.Drawing.Point(51, 71);
            this.lbEndHeader.Name = "lbEndHeader";
            this.lbEndHeader.Size = new System.Drawing.Size(26, 13);
            this.lbEndHeader.TabIndex = 2;
            this.lbEndHeader.Text = "End";
            // 
            // txTitle
            // 
            this.txTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txTitle.Location = new System.Drawing.Point(48, 17);
            this.txTitle.Name = "txTitle";
            this.txTitle.Size = new System.Drawing.Size(139, 20);
            this.txTitle.TabIndex = 3;
            // 
            // nubStart
            // 
            this.nubStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nubStart.Location = new System.Drawing.Point(86, 43);
            this.nubStart.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.nubStart.Name = "nubStart";
            this.nubStart.Size = new System.Drawing.Size(101, 20);
            this.nubStart.TabIndex = 4;
            // 
            // nubEnd
            // 
            this.nubEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nubEnd.Location = new System.Drawing.Point(86, 69);
            this.nubEnd.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.nubEnd.Name = "nubEnd";
            this.nubEnd.Size = new System.Drawing.Size(101, 20);
            this.nubEnd.TabIndex = 5;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(112, 108);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnAmend
            // 
            this.btnAmend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAmend.BackColor = System.Drawing.SystemColors.Control;
            this.btnAmend.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnAmend.ForeColor = System.Drawing.Color.Black;
            this.btnAmend.Location = new System.Drawing.Point(31, 108);
            this.btnAmend.Name = "btnAmend";
            this.btnAmend.Size = new System.Drawing.Size(75, 23);
            this.btnAmend.TabIndex = 7;
            this.btnAmend.Text = "Amend";
            this.btnAmend.UseVisualStyleBackColor = false;
            this.btnAmend.Click += new System.EventHandler(this.btn_Click);
            // 
            // AddOrEditSchedulerDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(199, 143);
            this.Controls.Add(this.btnAmend);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.nubEnd);
            this.Controls.Add(this.nubStart);
            this.Controls.Add(this.txTitle);
            this.Controls.Add(this.lbEndHeader);
            this.Controls.Add(this.lbStartHeader);
            this.Controls.Add(this.lbTitleHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AddOrEditSchedulerDialog";
            this.Text = "AddOrEditSchedulerDialog";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddOrEditSchedulerDialog_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.nubStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nubEnd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTitleHeader;
        private System.Windows.Forms.Label lbStartHeader;
        private System.Windows.Forms.Label lbEndHeader;
        private System.Windows.Forms.TextBox txTitle;
        private System.Windows.Forms.NumericUpDown nubStart;
        private System.Windows.Forms.NumericUpDown nubEnd;
        private AButton btnCancel;
        private AButton btnAmend;
    }
}