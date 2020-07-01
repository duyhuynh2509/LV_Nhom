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
    public partial class DoiMatKhau : Form
    {
        public DoiMatKhau()
        {
            InitializeComponent();
        }

        private void Btn_thoat_Click(object sender, EventArgs e)
        {
            Main a = new Main();
            a.Show();
            this.Hide();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-5O1714P\SQLEXPRESS;Initial Catalog=QLKHO;Integrated Security=True");

        private void Btn_doimk_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select count (*) from DANGNHAP where TAIKHOAN=N'" + txt_taikhoan.Text + "'and MATKHAU=N'" + txt_matkhau.Text + "'", conn);
            DataTable dt = new DataTable();
            da1.Fill(dt);
            errorProvider1.Clear();
            if (dt.Rows[0][0].ToString() == "1")
            {
                if (txt_matkhaumoi.Text == txt_nhaplaimk.Text)
                {
                    SqlDataAdapter data1 = new SqlDataAdapter("update DANGNHAP set MATKHAU = N'" + txt_matkhaumoi.Text + "'where TAIKHOAN=N'" + txt_taikhoan.Text + "'and MATKHAU=N'" + txt_matkhau.Text + "'", conn);
                    DataTable table = new DataTable();
                    data1.Fill(table);
                    MessageBox.Show("Đổi mật khẩu thành công !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    errorProvider1.SetError(txt_matkhaumoi, "Vui lòng nhập mật khẩu mới !");
                    errorProvider1.SetError(txt_nhaplaimk, "Mật khẩu không khớp !");
                }

            }
            else
            {
                errorProvider1.SetError(txt_taikhoan, "Tài khoản không đúng ! vui lòng nhập lại");
                errorProvider1.SetError(txt_matkhau, " Mật khẩu không đúng ! vui lòng nhập lại");
            }
            
        }

        private void DoiMatKhau_Load(object sender, EventArgs e)
        {

        }
    }
}
