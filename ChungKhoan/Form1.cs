using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ChungKhoan
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
            Program.conn.ConnectionString = "Data Source=VUONG;Initial Catalog=CHUNGKHOAN;User ID=sa;Password=123456;";
            Program.conn.Open();
        }

        private void btnDATLENH_Click(object sender, EventArgs e)
        {
            if(rdbtnBan.Checked == false && rdbtnMua.Checked == false )
            {
                MessageBox.Show("Vui lòng chọn loại giao dịch!!!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (txtMACP.Text ==  "")
            {
                MessageBox.Show("Vui lòng nhập mã cổ phiếu!!!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (txtGIADAT.Value == 0)
            {
                MessageBox.Show("Vui lòng nhập giá đặt!!!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (txtSOLUONG.Value == 0)
            {
                MessageBox.Show("Vui lòng nhập số lượng!!!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            string query = "DECLARE	@result int " +
                      "EXEC @result = SP_KHOPLENH_LO @macp, @ngay, @LoaiGD, @soluongMB, @giadatMB " +
                      "SELECT 'result' = @result";
            if (Program.conn.State == ConnectionState.Closed)
            {
                Program.conn.Open();
            }
            SqlCommand sqlCommand = new SqlCommand(query, Program.conn);
            //MessageBox.Show(cmbMaCP.SelectedValue.ToString(), "Notification", MessageBoxButtons.OK);

            sqlCommand.Parameters.AddWithValue("@macp", txtMACP.Text);
            sqlCommand.Parameters.AddWithValue("@ngay", DateTime.Now);
            sqlCommand.Parameters.AddWithValue("@LoaiGD", rdbtnBan.Checked == true ? "B" : "M");
            sqlCommand.Parameters.AddWithValue("@soluongMB", txtSOLUONG.Value);
            sqlCommand.Parameters.AddWithValue("@giadatMB", txtGIADAT.Value);
            SqlDataReader dataReader = null;
            try
            {
                if (Program.conn.State == ConnectionState.Closed)
                {
                    Program.conn.Open();
                }
                dataReader = sqlCommand.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thực thi Database!\n" + ex.Message, "Notification",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataReader.Close();
                return;
            }
            dataReader.Read();
            int result = int.Parse(dataReader.GetValue(0).ToString());
            dataReader.Close();
            MessageBox.Show("Đặt lệnh thành công " , "Thông báo");
            MessageBox.Show("Số lượng khớp: " + result, "Notification", MessageBoxButtons.OK);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
