using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ChungKhoan
{
    public partial class BangGiaTrucTuyen : Form
    {
        public string m_connect = "Data Source=QUANG-PC;Initial Catalog=CHUNGKHOAN;Persist Security Info=True;User ID=sa;Password=123456";
        SqlConnection con = null;
        public delegate void NewHome();
        public event NewHome OnNewHome;
        public BangGiaTrucTuyen()
        {
            InitializeComponent();

            try
            {
                SqlClientPermission ss = new SqlClientPermission(System.Security.Permissions.PermissionState.Unrestricted);
                ss.Demand();
            }
            catch (Exception)
            {

                throw;
            }
            SqlDependency.Stop(m_connect);
            SqlDependency.Start(m_connect);
            Program.conn = new SqlConnection(m_connect);
            string strLenh = "EXEC SP_BangGiaTrucTuyen";

            Program.myReader = Program.ExecSqlDataReader(strLenh);
            if (Program.myReader == null) return;
            Program.myReader.Close();
        }

        private void BangGiaTrucTuyen_Load(object sender, EventArgs e)
        {
            

            OnNewHome += new NewHome(Form1_OnNewHome);
            //tab
            //load data vao datagrid
            LoadData();
            dataGridView1.ColumnHeadersHeight = dataGridView1.ColumnHeadersHeight * 2;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Paint += new PaintEventHandler(dataGridView1_Paint);
            dataGridView1.Scroll += new ScrollEventHandler(dataGridView1_Scroll);
            dataGridView1.ColumnWidthChanged += new DataGridViewColumnEventHandler(dataGridView1_ColumnWidthChanged);
        }

        void dataGridView1_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            Rectangle rtHeader = dataGridView1.DisplayRectangle;
            rtHeader.Height = dataGridView1.ColumnHeadersHeight / 2;
            dataGridView1.Invalidate(rtHeader);
        }
        void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            Rectangle rtHeader = dataGridView1.DisplayRectangle;
            rtHeader.Height = dataGridView1.ColumnHeadersHeight / 2;
            dataGridView1.Invalidate(rtHeader);

        }
        void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
            string[] texts = { "Lệnh mua", "Khớp lệnh", "Lệnh bán"};
            for (int j = 1; j < 4;)
            {

                ////////////////////////////////////////////
                Rectangle r1 = dataGridView1.GetCellDisplayRectangle(j, -1, true);
                int w2 = dataGridView1.GetCellDisplayRectangle(j + 1, -1, true).Width;
                r1.X += 1;
                r1.Y += 1;
                r1.Width = r1.Width + w2 - 2;
                r1.Height = r1.Height / 2 - 2;
                e.Graphics.FillRectangle(new SolidBrush(dataGridView1.ColumnHeadersDefaultCellStyle.BackColor), r1);

                StringFormat format = new StringFormat();

                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;
                e.Graphics.DrawString(texts[0], dataGridView1.ColumnHeadersDefaultCellStyle.Font,
                    new SolidBrush(dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor), r1, format);
                j += 2;


            }
            for (int j = 5; j < 6;)
            {

                ////////////////////////////////////////////
                Rectangle r1 = dataGridView1.GetCellDisplayRectangle(j, -1, true);
                int w2 = dataGridView1.GetCellDisplayRectangle(j + 1, -1, true).Width;
                r1.X += 1;
                r1.Y += 1;
                r1.Width = r1.Width + w2 - 2;
                r1.Height = r1.Height / 2 - 2;
                e.Graphics.FillRectangle(new SolidBrush(dataGridView1.ColumnHeadersDefaultCellStyle.BackColor), r1);

                StringFormat format = new StringFormat();

                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;
                e.Graphics.DrawString(texts[1], dataGridView1.ColumnHeadersDefaultCellStyle.Font,
                    new SolidBrush(dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor), r1, format);
                j += 2;


            }
            for (int j = 7; j < 11;)
            {

                ////////////////////////////////////////////
                Rectangle r1 = dataGridView1.GetCellDisplayRectangle(j, -1, true);
                int w2 = dataGridView1.GetCellDisplayRectangle(j + 1, -1, true).Width;
                r1.X += 1;
                r1.Y += 1;
                r1.Width = r1.Width + w2 - 2;
                r1.Height = r1.Height / 2 - 2;
                e.Graphics.FillRectangle(new SolidBrush(dataGridView1.ColumnHeadersDefaultCellStyle.BackColor), r1);

                StringFormat format = new StringFormat();

                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;
                e.Graphics.DrawString(texts[2], dataGridView1.ColumnHeadersDefaultCellStyle.Font,
                    new SolidBrush(dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor), r1, format);
                j += 2;


            }
        }

        public void Form1_OnNewHome()
        {
            ISynchronizeInvoke i = (ISynchronizeInvoke)this;
            if (i.InvokeRequired)//tab
            {
                NewHome dd = new NewHome(Form1_OnNewHome);
                i.BeginInvoke(dd, null);
                return;
            }
            LoadData();

        }

        //Ham load data
        void LoadData()
        {
            DataTable dt = new DataTable();
            if (Program.conn.State == ConnectionState.Closed)
            {
                Program.conn.Open();
            }

            SqlCommand cmd = new SqlCommand("select MACP as [Mã CP], MUA_GIA2 as [GIÁ 2], MUA_KL2 as [KL2], MUA_GIA1 as [GIÁ 1], MUA_KL1 as [KL1], GIAKHOP AS [Giá khớp], KLKHOP AS [KL khớp], BAN_GIA1 AS [Giá 1], BAN_KL1 AS [KL1], BAN_GIA2 AS [Giá 2], BAN_KL2 AS [KL2] FROM dbo.BangGiaTrucTuyen", Program.conn);
            cmd.Notification = null;

            SqlDependency de = new SqlDependency(cmd);
            de.OnChange += new OnChangeEventHandler(de_OnChange);

            dt.Load(cmd.ExecuteReader(CommandBehavior.CloseConnection));
            dataGridView1.DataSource = dt;
        }

        public void de_OnChange(object sender, SqlNotificationEventArgs e)
        {
            SqlDependency de = sender as SqlDependency;
            de.OnChange -= de_OnChange;
            if (OnNewHome != null)
            {
                OnNewHome();
            }
        }

        private void btnGIAODICH_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
        }
    }
}
