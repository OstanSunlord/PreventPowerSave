
namespace ImNotAFK.Client
{
    partial class SchedulerDialog
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
            this.btnClose = new ImNotAFK.Client.AButton(this.components);
            this.btnAmend = new ImNotAFK.Client.AButton(this.components);
            this.dgvScheduler = new System.Windows.Forms.DataGridView();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartTid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScheduler)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(370, 318);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 28);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAmend
            // 
            this.btnAmend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAmend.BackColor = System.Drawing.SystemColors.Control;
            this.btnAmend.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnAmend.ForeColor = System.Drawing.Color.Black;
            this.btnAmend.Location = new System.Drawing.Point(275, 318);
            this.btnAmend.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAmend.Name = "btnAmend";
            this.btnAmend.Size = new System.Drawing.Size(87, 28);
            this.btnAmend.TabIndex = 4;
            this.btnAmend.Text = "Amend";
            this.btnAmend.UseVisualStyleBackColor = false;
            this.btnAmend.Click += new System.EventHandler(this.btnAmend_Click);
            // 
            // dgvScheduler
            // 
            this.dgvScheduler.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvScheduler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvScheduler.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Title,
            this.StartTid,
            this.EndTime});
            this.dgvScheduler.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dgvScheduler.Location = new System.Drawing.Point(14, 15);
            this.dgvScheduler.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvScheduler.Name = "dgvScheduler";
            this.dgvScheduler.Size = new System.Drawing.Size(443, 296);
            this.dgvScheduler.TabIndex = 5;
            // 
            // Title
            // 
            this.Title.HeaderText = "Name";
            this.Title.Name = "Title";
            this.Title.Width = 200;
            // 
            // StartTid
            // 
            this.StartTid.HeaderText = "Start";
            this.StartTid.Name = "StartTid";
            // 
            // EndTime
            // 
            this.EndTime.HeaderText = "End";
            this.EndTime.Name = "EndTime";
            // 
            // SchedulerDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 361);
            this.Controls.Add(this.dgvScheduler);
            this.Controls.Add(this.btnAmend);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SchedulerDialog";
            this.Text = "SchedulerDialog";
            ((System.ComponentModel.ISupportInitialize)(this.dgvScheduler)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private AButton btnClose;
        private AButton btnAmend;
        private System.Windows.Forms.DataGridView dgvScheduler;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartTid;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndTime;
    }
}