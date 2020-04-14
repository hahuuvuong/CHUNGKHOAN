using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ChungKhoan
{
    public partial class BangGiaTrucTuyen : Form
    {
        public string m_connect = "Data Source=Quang-PC;Initial Catalog=CHUNGKHOAN;Persist Security Info=True;User ID=sa;Password=123456";
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
        }

        private void BangGiaTrucTuyen_Load(object sender, EventArgs e)
        {
            OnNewHome += new NewHome(Form1_OnNewHome);
            //tab
            //load data vao datagrid
            LoadData();
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

            SqlCommand cmd = new SqlCommand("select MACP as [Mã CP], GIADAT as [GIÁ 2],SOLUONG as [KL2],GIADAT as [GIÁ 1], SOLUONG as [KL1], GIAKHOP AS [Giá khớp], SOLUONGKHOP AS [KL khớp] from dbo.LENHDAT,  DBO.LENHKHOP where dbo.LENHDAT.ID = dbo.LENHKHOP.IDLENHDAT", Program.conn);
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
    }
}
