using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace _30_NgoThiThuyLinh_Buoi09
{
    public partial class Form1 : Form
    {
        ConnectDB cont = new ConnectDB();
        SqlConnection consql;
        public Form1()
        {
            
            InitializeComponent();
            consql = cont.connect;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void cbb_MaCL_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        void Load_MaCL()
        {
            consql.Open();
            string read;
            read = "select * from DMChatLieu";
            SqlCommand cmd = new SqlCommand(read, consql);
            SqlDataReader rdr = cmd.ExecuteReader();
            cbb_MaCL.Items.Clear();
            while (rdr.Read())
            {
                cbb_MaCL.Items.Add(rdr["MaChatlieu"].ToString());
            }
            consql.Close();
        }
        void Load_Data()
        {
            consql.Open();
            string read;
            read = "select MaHang,TenHang,MaChatlieu,SoLuong,DonGiaNhap,DonGiaBan,Hinh from DMHang";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(read, consql);
            da.Fill(ds, "DMHang");
            dataGridView1.DataSource = ds.Tables["DMHang"];
            consql.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Load_MaCL();
            Load_Data();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dataGridView1.Rows[e.RowIndex];
            txt_MaHang.Text = Convert.ToString(row.Cells["MaHang"].Value);
            txt_TenHang.Text = Convert.ToString(row.Cells["TenHang"].Value);
            cbb_MaCL.Text = Convert.ToString(row.Cells["MaChatlieu"].Value);
            txt_SoLuong.Text = Convert.ToString(row.Cells["SoLuong"].Value);
            txt_DonGiaNhap.Text = Convert.ToString(row.Cells["DonGiaNhap"].Value);
            txt_DonGiaBan.Text = Convert.ToString(row.Cells["DonGiaBan"].Value);
            txt_Anh.Text = Convert.ToString(row.Cells["Anh"].Value);
            pictureBox1.Image = Image.FromFile(@"HinhAnh\" + row.Cells["Anh"].Value.ToString());
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
                txt_MaHang.Enabled = true;
                txt_TenHang.Enabled = true;
                txt_DonGiaNhap.Enabled = true;
                txt_DonGiaBan.Enabled = true;
            try
            {
                if (consql.State == ConnectionState.Closed)
                {
                    consql.Open();
                }
                
                string insert;
                insert = "insert into DMHang values ('"+txt_MaHang.Text+"',N'"+txt_TenHang.Text+"','"+cbb_MaCL.SelectedValue.ToString()+"',"+txt_SoLuong.Text+","+txt_DonGiaNhap.Text+","+txt_DonGiaBan.Text+",'"+txt_Anh.Text+"','"+txt_GhiChu.Text+"')";
                SqlCommand cmd = new SqlCommand(insert, consql);
                cmd.ExecuteNonQuery();
                if (consql.State == ConnectionState.Open)
                {
                    consql.Close();
                }
                MessageBox.Show("Them Thanh Cong");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
