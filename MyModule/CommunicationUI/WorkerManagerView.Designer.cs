namespace MyModule.CommunicationUI
{
    partial class WorkerManagerView
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
            this.gridViewTaskManager = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTaskManager)).BeginInit();
            this.SuspendLayout();
            // 
            // gridViewTaskManager
            // 
            this.gridViewTaskManager.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridViewTaskManager.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridViewTaskManager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridViewTaskManager.Location = new System.Drawing.Point(0, 0);
            this.gridViewTaskManager.Name = "gridViewTaskManager";
            this.gridViewTaskManager.RowTemplate.Height = 23;
            this.gridViewTaskManager.Size = new System.Drawing.Size(800, 450);
            this.gridViewTaskManager.TabIndex = 0;
            // 
            // WorkerManagerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gridViewTaskManager);
            this.Name = "WorkerManagerView";
            this.Text = "WorkerManagerView";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WorkerManagerView_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTaskManager)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridViewTaskManager;
    }
}