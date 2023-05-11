namespace PerformanceEvaluationSystem
{
    partial class FormCoefficientManager
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
            this.dataGridViewCoeManager = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCoeManager)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewCoeManager
            // 
            this.dataGridViewCoeManager.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCoeManager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewCoeManager.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewCoeManager.Name = "dataGridViewCoeManager";
            this.dataGridViewCoeManager.RowTemplate.Height = 23;
            this.dataGridViewCoeManager.Size = new System.Drawing.Size(800, 450);
            this.dataGridViewCoeManager.TabIndex = 0;
            this.dataGridViewCoeManager.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCoeManager_CellValueChanged);
            // 
            // FormCoefficientManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridViewCoeManager);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormCoefficientManager";
            this.Text = "FormCoefficientManager";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormCoefficientManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCoeManager)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewCoeManager;
    }
}