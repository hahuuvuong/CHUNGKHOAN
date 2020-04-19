namespace ChungKhoan
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtMACP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.soluong = new System.Windows.Forms.Label();
            this.giadat = new System.Windows.Forms.Label();
            this.txtGIADAT = new System.Windows.Forms.NumericUpDown();
            this.txtSOLUONG = new System.Windows.Forms.NumericUpDown();
            this.btnDATLENH = new System.Windows.Forms.Button();
            this.rdbtnBan = new System.Windows.Forms.RadioButton();
            this.rdbtnMua = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.txtGIADAT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSOLUONG)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 188);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "MÃ CỔ PHIẾU:";
            // 
            // txtMACP
            // 
            this.txtMACP.Location = new System.Drawing.Point(216, 185);
            this.txtMACP.Name = "txtMACP";
            this.txtMACP.Size = new System.Drawing.Size(191, 22);
            this.txtMACP.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "LOẠI GIAO DỊCH:";
            // 
            // soluong
            // 
            this.soluong.AutoSize = true;
            this.soluong.Location = new System.Drawing.Point(84, 255);
            this.soluong.Name = "soluong";
            this.soluong.Size = new System.Drawing.Size(72, 15);
            this.soluong.TabIndex = 3;
            this.soluong.Text = "SỐ LƯỢNG:";
            // 
            // giadat
            // 
            this.giadat.AutoSize = true;
            this.giadat.Location = new System.Drawing.Point(84, 329);
            this.giadat.Name = "giadat";
            this.giadat.Size = new System.Drawing.Size(61, 15);
            this.giadat.TabIndex = 4;
            this.giadat.Text = "GIÁ ĐẶT:";
            // 
            // txtGIADAT
            // 
            this.txtGIADAT.Location = new System.Drawing.Point(216, 322);
            this.txtGIADAT.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.txtGIADAT.Name = "txtGIADAT";
            this.txtGIADAT.Size = new System.Drawing.Size(191, 22);
            this.txtGIADAT.TabIndex = 6;
            // 
            // txtSOLUONG
            // 
            this.txtSOLUONG.Location = new System.Drawing.Point(216, 253);
            this.txtSOLUONG.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.txtSOLUONG.Name = "txtSOLUONG";
            this.txtSOLUONG.Size = new System.Drawing.Size(191, 22);
            this.txtSOLUONG.TabIndex = 7;
            // 
            // btnDATLENH
            // 
            this.btnDATLENH.Location = new System.Drawing.Point(244, 409);
            this.btnDATLENH.Name = "btnDATLENH";
            this.btnDATLENH.Size = new System.Drawing.Size(99, 29);
            this.btnDATLENH.TabIndex = 10;
            this.btnDATLENH.Text = "Đặt lệnh";
            this.btnDATLENH.UseVisualStyleBackColor = true;
            this.btnDATLENH.Click += new System.EventHandler(this.btnDATLENH_Click);
            // 
            // rdbtnBan
            // 
            this.rdbtnBan.AutoSize = true;
            this.rdbtnBan.Location = new System.Drawing.Point(114, 52);
            this.rdbtnBan.Name = "rdbtnBan";
            this.rdbtnBan.Size = new System.Drawing.Size(46, 19);
            this.rdbtnBan.TabIndex = 12;
            this.rdbtnBan.TabStop = true;
            this.rdbtnBan.Text = "Bán";
            this.rdbtnBan.UseVisualStyleBackColor = true;
            // 
            // rdbtnMua
            // 
            this.rdbtnMua.AutoSize = true;
            this.rdbtnMua.Location = new System.Drawing.Point(22, 52);
            this.rdbtnMua.Name = "rdbtnMua";
            this.rdbtnMua.Size = new System.Drawing.Size(50, 19);
            this.rdbtnMua.TabIndex = 11;
            this.rdbtnMua.TabStop = true;
            this.rdbtnMua.Text = "Mua";
            this.rdbtnMua.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdbtnMua);
            this.panel1.Controls.Add(this.rdbtnBan);
            this.panel1.Location = new System.Drawing.Point(197, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 13;
            // 
            // Form1
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 596);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnDATLENH);
            this.Controls.Add(this.txtSOLUONG);
            this.Controls.Add(this.txtGIADAT);
            this.Controls.Add(this.giadat);
            this.Controls.Add(this.soluong);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMACP);
            this.Controls.Add(this.label1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.Text = "FORM GIAO DỊCH";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtGIADAT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSOLUONG)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMACP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label soluong;
        private System.Windows.Forms.Label giadat;
        private System.Windows.Forms.NumericUpDown txtGIADAT;
        private System.Windows.Forms.NumericUpDown txtSOLUONG;
        private System.Windows.Forms.Button btnDATLENH;
        private System.Windows.Forms.RadioButton rdbtnBan;
        private System.Windows.Forms.RadioButton rdbtnMua;
        private System.Windows.Forms.Panel panel1;
    }
}

