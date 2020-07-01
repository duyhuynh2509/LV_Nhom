using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Quanlybanhang
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void Btn_dangnhap_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-5O1714P\SQLEXPRESS;Initial Catalog=QLKHO;Integrated Security=True");
            try
            {
                conn.Open();
                string tk = txt_taikhoan.Text;
                string mk = txt_matkhau.Text;
                string sql = "select *from DANGNHAP where TAIKHOAN='" + tk + "'and MATKHAU='" + mk + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader data = cmd.ExecuteReader();
                errorProvider1.Clear();
                if (data.Read() == true)
                {
                    Main f = new Main();
                    this.Hide();
                    f.Show();
                }
                else
                {
                    errorProvider1.SetError(txt_matkhau, "Vui lòng nhập mật khẩu");
                    MessageBox.Show("Đăng Nhập Thất Bại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mật khẩu không đúng ! vui lòng nhập lại");
            }
        }

        private void Btn_thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}
