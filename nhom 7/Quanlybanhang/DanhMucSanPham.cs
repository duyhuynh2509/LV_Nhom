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
    public partial class DanhMucSanPham : Form
    {
        public DanhMucSanPham()
        {
            InitializeComponent();
        }
        SqlConnection con;
        DataSet ds = new DataSet("dsQLSP");
        private int chon;
        private void DanhMucSanPham_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=DESKTOP-5O1714P\SQLEXPRESS;Initial Catalog=QLKHO;Integrated Security=True");
            string sql = "select * from NHACUNGCAP";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbb_mancc.DataSource = dt;
            cbb_mancc.DisplayMember = "TENNCC";
            cbb_mancc.ValueMember = "MANCC";

            txt_dvt.Text = "VND";
            con.Open();
            loaddulieu();
            khoidong();
        }
        public void loaddulieu()
        {
            string sql = "select MASP,TENSP,GIASP,DVT,SOLUONG,TENNCC,NHACUNGCAP.MANCC from SANPHAM,NHACUNGCAP where NHACUNGCAP.MANCC=SANPHAM.MANCC";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dtgv_danhsachsanpham.DataSource = dt;

        }
        public void khoidong()
        {
            txt_masp.Enabled = false;
            txt_giasp.Enabled = false;
            txt_soluong.Enabled = false;
            txt_tensp.Enabled = false;
            txt_dvt.Enabled = false;
            cbb_mancc.Enabled = false;

        }

        private void dtgv_danhsachsanpham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtgv_danhsachsanpham_Click(object sender, EventArgs e)
        {
            DataGridViewRow dgr = dtgv_danhsachsanpham.SelectedRows[0];
            txt_masp.Text = dgr.Cells["MASP"].Value.ToString();
            txt_tensp.Text = dgr.Cells["TENSP"].Value.ToString();
            txt_giasp.Text = dgr.Cells["GIASP"].Value.ToString();
            txt_soluong.Text = dgr.Cells["SOLUONG"].Value.ToString();
            cbb_mancc.SelectedValue = dgr.Cells["MANCC"].Value.ToString();
        }
        public bool checkMasp()
        {
            string sqlcheck = "select COUNT(*) from SANPHAM where MASP='" + txt_masp.Text + "'";
            SqlCommand cmd = new SqlCommand(sqlcheck, con);
            int count = (int)cmd.ExecuteScalar();
            if (count >= 1)
                return true;
            return false;
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            if (chon == 1)
            {
                if (txt_masp.Text == "" || txt_giasp.Text == "" || txt_soluong.Text == "" || txt_tensp.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                }
                else
                {
                        if (checkMasp() == false)
                        {
                            string sql = "insert into SANPHAM values(@MASP,@TENSP,@GIASP,@DVT,@SOLUONG,@MANCC)  ";
                            SqlCommand cmd = new SqlCommand(sql, con);
                            cmd.Parameters.AddWithValue("MASP", txt_masp.Text);
                            cmd.Parameters.AddWithValue("TENSP", txt_tensp.Text);
                            cmd.Parameters.AddWithValue("GIASP", txt_giasp.Text);
                            cmd.Parameters.AddWithValue("DVT", txt_dvt.Text);
                            cmd.Parameters.AddWithValue("SOLUONG", txt_soluong.Text);
                            cmd.Parameters.AddWithValue("MANCC", cbb_mancc.SelectedValue);
                            cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                            loaddulieu();
                        }
                        else
                        {
                            MessageBox.Show("trùng mã sản phẩm");
                        }
                }
                khoidong();
            }
            else if(chon ==2)
            {
                string sql = "update SANPHAM set MASP=@MASP,TENSP=@TENSP,GIASP=@GIASP,DVT=@DVT,SOLUONG=@SOLUONG,MANCC=@MANCC where MASP=@MASP";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("MASP", txt_masp.Text);
                cmd.Parameters.AddWithValue("TENSP", txt_tensp.Text);
                cmd.Parameters.AddWithValue("GIASP", txt_giasp.Text);
                cmd.Parameters.AddWithValue("DVT", txt_dvt.Text);
                cmd.Parameters.AddWithValue("SOLUONG", txt_soluong.Text);
                cmd.Parameters.AddWithValue("MANCC", cbb_mancc.SelectedValue);
                cmd.ExecuteNonQuery();                
                loaddulieu();
            }
            else
            {
                chon = 0;
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            chon = 1;
            txt_masp.Enabled = true;
            txt_giasp.Enabled = true;
            txt_soluong.Enabled = true;
            txt_tensp.Enabled = true;
            cbb_mancc.Enabled = true;
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            chon = 2;
            txt_masp.Enabled = false;
            txt_giasp.Enabled = true;
            txt_soluong.Enabled = true;
            txt_tensp.Enabled = true;
            cbb_mancc.Enabled = true;
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            string sql = "delete from SANPHAM where MASP=@MASP ";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("MASP", txt_masp.Text);
            cmd.Parameters.AddWithValue("TENSP", txt_tensp.Text);
            cmd.Parameters.AddWithValue("GIASP", txt_giasp.Text);
            cmd.Parameters.AddWithValue("DVT", txt_dvt.Text);
            cmd.Parameters.AddWithValue("SOLUONG", txt_soluong.Text);
            cmd.Parameters.AddWithValue("MANCC", cbb_mancc.SelectedValue);
            cmd.ExecuteNonQuery();
            loaddulieu();
        }

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            string sql = "select * from SANPHAM where MASP=@MASP";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("MASP", txt_tim.Text);
            cmd.Parameters.AddWithValue("TENSP", txt_tensp.Text);
            cmd.Parameters.AddWithValue("GIASP", txt_giasp.Text);
            cmd.Parameters.AddWithValue("DVT", txt_dvt.Text);
            cmd.Parameters.AddWithValue("SOLUONG", txt_soluong.Text);
            cmd.Parameters.AddWithValue("MANCC", cbb_mancc.SelectedValue);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dtgv_danhsachsanpham.DataSource = dt;
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            Main a = new Main();
            a.Show();
            this.Hide();
        }
    }
}

