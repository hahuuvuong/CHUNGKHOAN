namespace ChungKhoan
{
    partial class BangGiaTrucTuyen
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnGIAODICH = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 28);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1181, 254);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnGIAODICH
            // 
            this.btnGIAODICH.Location = new System.Drawing.Point(557, 315);
            this.btnGIAODICH.Name = "btnGIAODICH";
            this.btnGIAODICH.Size = new System.Drawing.Size(104, 23);
            this.btnGIAODICH.TabIndex = 1;
            this.btnGIAODICH.Text = "Giao dịch";
            this.btnGIAODICH.UseVisualStyleBackColor = true;
            this.btnGIAODICH.Click += new System.EventHandler(this.btnGIAODICH_Click);
            // 
            // BangGiaTrucTuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1205, 367);
            this.Controls.Add(this.btnGIAODICH);
            this.Controls.Add(this.dataGridView1);
            this.Name = "BangGiaTrucTuyen";
            this.Text = "BangGiaTrucTuyen";
            this.Load += new System.EventHandler(this.BangGiaTrucTuyen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnGIAODICH;
    }
}