using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan__BTVN_
{
    public partial class QLKS : Form
    {
        SqlConnection con = new SqlConnection();
        public QLKS()
        {
            InitializeComponent();
        }
        public void ketnoi()
        {
            SqlConnection con = new SqlConnection(@"Data Source=LILI\THAOLY03;Initial Catalog=quanlykhachsan;Integrated Security=True");
            con.Open();
            string sql = "Select * from tbIPhong";
            SqlDataAdapter adp = new SqlDataAdapter(sql, con);
            DataTable tabletbIPhong = new DataTable();
            adp.Fill(tabletbIPhong);
            dataGridView1.DataSource = tabletbIPhong;
        }
        private void QLKS_Load(object sender, EventArgs e)
        {
            ketnoi();
        }
        int index;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = dataGridView1.CurrentRow.Index;
            txtMaPhong.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
            txtTenPhong.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
            txtDonGia.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
            txtMaPhong.Enabled = false;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaPhong.Text = "";
            txtTenPhong.Text = "";
            txtDonGia.Text = "";
            txtMaPhong.Enabled = true;
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql = @" UPDATE tbIPhong SET
                        MaPhong=N'" + txtMaPhong.Text + @"',TenPhong =N'" + txtTenPhong.Text + @"',Dongia =N'" + txtDonGia.Text + @"'
                     Where (MaPhong=N'" + txtMaPhong.Text + @"')";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            ketnoi();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;

            if (txtMaPhong.Text == "") //nếu chưa chọn bản ghi nào 
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE tblPhong WHERE MaPhong=N'" + txtMaPhong.Text + "'"; SqlCommand cmd = new SqlCommand(sql, con); ; ketnoi();
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaPhong.Text == "")
            {
                MessageBox.Show("Ban can nhap Ma Phong");
                txtMaPhong.Focus();
                return;
            }
            if (txtTenPhong.Text == "")
            {
                MessageBox.Show("Ban can nhap Ten Phong");
                txtTenPhong.Focus();
                return;
            }
            else
            {
                string sql = "insert into tbIPhong Values('" + txtMaPhong.Text + "','" + txtTenPhong.Text + "'";
                if (txtDonGia.Text != "")
                    sql = sql + "," + txtDonGia.Text.Trim();
                sql = sql + ")";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                ketnoi();

            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
