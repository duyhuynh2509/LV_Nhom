using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quanlybanhang
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void DanhMụcSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DanhMucSanPham b = new DanhMucSanPham();
            b.Show();
            this.Hide();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void thôngTinNhânViênToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ThongTinNhanVien a = new ThongTinNhanVien();
            a.Show();
            this.Hide();
        }

        private void đổiMậtKhẩuToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DoiMatKhau b = new DoiMatKhau();
            b.Show();
            this.Hide();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DangNhap c = new DangNhap();
            c.Show();
            this.Hide();
        }
    }
}
