namespace Quanlybanhang
{
    partial class ThongKeDanhThu
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
            this.datime_ngaynhap = new System.Windows.Forms.DateTimePicker();
            this.datime_ngayxuat = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtgv_nhapxuat = new System.Windows.Forms.DataGridView();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_nhapxuat)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(192, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Thống Kê Danh Thu";
            // 
            // datime_ngaynhap
            // 
            this.datime_ngaynhap.Location = new System.Drawing.Point(6, 19);
            this.datime_ngaynhap.Name = "datime_ngaynhap";
            this.datime_ngaynhap.Size = new System.Drawing.Size(200, 20);
            this.datime_ngaynhap.TabIndex = 0;
            // 
            // datime_ngayxuat
            // 
            this.datime_ngayxuat.Location = new System.Drawing.Point(426, 19);
            this.datime_ngayxuat.Name = "datime_ngayxuat";
            this.datime_ngayxuat.Size = new System.Drawing.Size(200, 20);
            this.datime_ngayxuat.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(290, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Thống Kê";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtgv_nhapxuat);
            this.groupBox2.Location = new System.Drawing.Point(7, 49);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(613, 278);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh Sách Hóa Đơn Nhập/Xuất";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.datime_ngayxuat);
            this.groupBox1.Controls.Add(this.datime_ngaynhap);
            this.groupBox1.Location = new System.Drawing.Point(12, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(626, 333);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thống Kê Theo Tháng/Năm";
            // 
            // dtgv_nhapxuat
            // 
            this.dtgv_nhapxuat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_nhapxuat.Location = new System.Drawing.Point(-15, 20);
            this.dtgv_nhapxuat.Name = "dtgv_nhapxuat";
            this.dtgv_nhapxuat.Size = new System.Drawing.Size(643, 275);
            this.dtgv_nhapxuat.TabIndex = 0;
            // 
            // ThongKeDanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 388);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "ThongKeDanhThu";
            this.Text = "ThongKeDanhThu";
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_nhapxuat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker datime_ngaynhap;
        private System.Windows.Forms.DateTimePicker datime_ngayxuat;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dtgv_nhapxuat;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}