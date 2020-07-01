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
    public partial class ThongTinNhanVien : Form
    {
        public ThongTinNhanVien()
        {
            InitializeComponent();
        }
        SqlConnection con;
        DataSet ds = new DataSet("dsQLNV");
        string GIOITINH = string.Empty;
        private int chon;

        private void ThongTinNhanVien_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=DESKTOP-5O1714P\SQLEXPRESS;Initial Catalog=QLKHO;Integrated Security=True");
            con.Open();
            loaddulieu();
            khoidong();
        }
        public void khoidong()
        {
            txt_manv.Enabled = false;
            txt_tennv.Enabled = false;
            txt_sdt.Enabled = false;
            datime_ngaysinh.Enabled = false;
            radio_nam.Enabled = false;
            radio_nu.Enabled = false;
            
        }
        public void loaddulieu()
        {
            string sql = "select MANV,TENNV,NGAYSINH,GIOITINH,SDT from NHANVIEN";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dtgv_dsnhanvien.DataSource = dt;

        }

        private void radio_nam_CheckedChanged(object sender, EventArgs e)
        {
            GIOITINH = "Nam";
        }

        private void radio_nu_CheckedChanged(object sender, EventArgs e)
        {
            GIOITINH = "Nữ";
        }

        private void dtgv_dsnhanvien_Click(object sender, EventArgs e)
        {
            DataGridViewRow dgr = dtgv_dsnhanvien.SelectedRows[0];
            txt_manv.Text = dgr.Cells["MANV"].Value.ToString();
            txt_tennv.Text = dgr.Cells["TENNV"].Value.ToString();
            datime_ngaysinh.Text= dgr.Cells["NGAYSINH"].Value.ToString();
            if (dgr.Cells["GIOITINH"].Value.ToString() == "Nam")
            {
                radio_nam.Checked = true;
            }
            else
            {
                radio_nu.Checked = true;
            }
            txt_sdt.Text = dgr.Cells["SDT"].Value.ToString();
        }
        public bool checkManv()
        {
            string sqlcheck = "select COUNT(*) from NHANVIEN where MANV='" + txt_manv.Text + "'";
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
                    if (txt_manv.Text == "" || txt_sdt.Text == "" || txt_tennv.Text == "")
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                    }
                    else
                    {
                        if (radio_nam.Checked == false && radio_nu.Checked == false)
                        {
                            MessageBox.Show("vui lòng chọn giới tính");
                        }
                        else
                        {
                            if (checkManv() == false)
                            {


                                string sql = "insert into NHANVIEN values(@MANV,@TENNV,@NGAYSINH,@GIOITINH,@SDT) ";
                                SqlCommand cmd = new SqlCommand(sql, con);
                                cmd.Parameters.AddWithValue("MANV", txt_manv.Text);
                                cmd.Parameters.AddWithValue("TENNV", txt_tennv.Text);
                                cmd.Parameters.AddWithValue("GIOITINH", GIOITINH);
                                cmd.Parameters.AddWithValue("NGAYSINH", datime_ngaysinh.Value);
                                cmd.Parameters.AddWithValue("SDT", txt_sdt.Text);
                                cmd.ExecuteNonQuery();
                                cmd.Parameters.Clear();
                                loaddulieu();
                            }
                            else
                            {
                                MessageBox.Show("trùng mã nhân viên");
                            }
                        }
                    }
                }
                else if (chon == 2)
                {
                    string sql = "update nhanvien set MANV=@MANV,TENNV=@TENNV,NGAYSINH=@NGAYSINH,GIOITINH=@GIOITINH,SDT=@SDT where MANV=@MANV";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("MANV", txt_manv.Text);
                    cmd.Parameters.AddWithValue("TENNV", txt_tennv.Text);
                    cmd.Parameters.AddWithValue("GIOITINH", GIOITINH);
                    cmd.Parameters.AddWithValue("NGAYSINH", datime_ngaysinh.Value);
                    cmd.Parameters.AddWithValue("SDT", txt_sdt.Text);
                    cmd.ExecuteNonQuery();
                    loaddulieu();
                }
                else
                {
                    chon = 0;
                }
            khoidong();
            }

        private void btn_them_Click(object sender, EventArgs e)
        {
            chon = 1;
            txt_manv.Enabled = true;
            txt_tennv.Enabled = true;
            txt_sdt.Enabled = true;
            datime_ngaysinh.Enabled = true;
            radio_nam.Enabled = true;
            radio_nu.Enabled = true;
            
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            chon = 2;
            txt_manv.Enabled = false;
            txt_tennv.Enabled = true;
            txt_sdt.Enabled = true;
            datime_ngaysinh.Enabled = true;
            radio_nam.Enabled = true;
            radio_nu.Enabled = true;
            
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            string sql = "delete from NHANVIEN where MANV=@MANV";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("MANV", txt_manv.Text);
            cmd.Parameters.AddWithValue("TENNV", txt_tennv.Text);
            cmd.Parameters.AddWithValue("GIOITINH", GIOITINH);
            cmd.Parameters.AddWithValue("NGAYSINH", datime_ngaysinh.Text);
            cmd.Parameters.AddWithValue("SDT", txt_sdt.Text);
            cmd.ExecuteNonQuery();
            loaddulieu();
        }

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            string sqlFIND = "select * from NHANVIEN where MANV=@MANV ";
            SqlCommand cmd = new SqlCommand(sqlFIND, con);
            cmd.Parameters.AddWithValue("MANV", txt_timkiem.Text);
            cmd.Parameters.AddWithValue("TENNV", txt_tennv.Text);
            cmd.Parameters.AddWithValue("GIOITINH", GIOITINH);
            cmd.Parameters.AddWithValue("NGAYSINH", datime_ngaysinh.Text);
            cmd.Parameters.AddWithValue("SDT", txt_sdt.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dtgv_dsnhanvien.DataSource = dt;
        }

        private void btn_quaylai_Click(object sender, EventArgs e)
        {
            Main a = new Main();
            a.Show();
            this.Hide();
        }
    }
}
