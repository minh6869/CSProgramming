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

namespace quanlimaytinh
{
    public partial class Form1 : Form
    {
        string connect = @"Data Source=ZHISHU\SQLEXPRESS;
                           Initial Catalog=quanlimaytinh;Integrated Security=True";
        SqlConnection pipe_connect = null;
        DataTable table_hoa_don = new DataTable();
        string mau_sac;
        private void ket_noi()
        {
            try
            {
                if (pipe_connect == null)
                    pipe_connect = new SqlConnection(connect);
                if (pipe_connect.State == ConnectionState.Closed)
                    pipe_connect.Open();
            }
            catch
            {
                MessageBox.Show("Ket noi khong thanh cong");
            }
        }

        private void load_bang_hoa_don()
        {
            table_hoa_don.Clear();
            using  (SqlCommand query = new SqlCommand())
            {
                query.CommandText = $@"SELECT * FROM hoadon";
                query.Connection = pipe_connect;
                SqlDataReader reader = query.ExecuteReader();
                while(reader.Read())
                {
                    
                    if (reader[4].ToString() == "False")
                        mau_sac = "Đen";
                    else
                        mau_sac = "Màu khác";
                    string ngay_thue = DateTime.Parse(reader[2].ToString()).ToString("dd/MM/yyyy");
                    table_hoa_don.Rows.Add(reader[0].ToString(), reader[1].ToString(), ngay_thue, reader[3].ToString(), mau_sac, reader[5].ToString(), reader[6].ToString());
                }
                reader.Close();
                bang_hoa_don.DataSource = table_hoa_don;
            }

            ten_dien_thoai_textbox.Text = "";
            ma_hd_textbox.Text = "";
            don_gia_textbox.Text = "";
            ten_kh_textbox.Text = "";
            den.Checked = false;
            mau_khac.Checked = false;
            
        }

       


        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            
        }

        private void don_gia_textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char .IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ket_noi();
            table_hoa_don.Columns.Add("Mã HĐ");
            table_hoa_don.Columns.Add("Tên KH");
            table_hoa_don.Columns.Add("Ngày Bán");
            table_hoa_don.Columns.Add("Tên ĐT");
            table_hoa_don.Columns.Add("Màu sắc");
            table_hoa_don.Columns.Add("Đơn giá");
            table_hoa_don.Columns.Add("Số Lượng");
            table_hoa_don.Columns.Add("Thành tiền");
            
            load_bang_hoa_don();
        }

        private void them_button_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Ấn nút thêm");
            if(ten_dien_thoai_textbox.Text != "" && ma_hd_textbox.Text != "" && don_gia_textbox.Text != "" && ten_kh_textbox.Text != "" && (den.Checked != false || mau_khac.Checked != false))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = pipe_connect;
                    cmd.CommandText = @"INSERT INTO hoadon
                                    VALUES(@ma_hd, @ten_khach, @ngay_ban, @ten_dt, @mau_sac, @don_gia, @so_luong)";
                    DateTime ngaybanDatetime = ngay_ban_datetimepicker.Value;
                    string ngay_ban = ngaybanDatetime.ToString("yyyy/MM/dd");
                    string mausac;
                    if (den.Checked)
                        mausac = "0";
                    else
                        mausac = "1";
                    cmd.Parameters.AddWithValue("@ma_hd", ma_hd_textbox.Text.Trim());
                    cmd.Parameters.AddWithValue("@ten_khach", ten_kh_textbox.Text);
                    cmd.Parameters.AddWithValue("@ngay_ban", ngay_ban);
                    cmd.Parameters.AddWithValue("@ten_dt", ten_dien_thoai_textbox.Text);
                    cmd.Parameters.AddWithValue("@mau_sac", mausac);
                    cmd.Parameters.AddWithValue("@don_gia", int.Parse(don_gia_textbox.Text));
                    cmd.Parameters.AddWithValue("@so_luong", int.Parse(so_luong.Value.ToString()));
                    try
                    {

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("them thanh cong");
                        load_bang_hoa_don();
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Khong the them hoa don da ton tai");
                    }


                }
            }
            


        }
        private void sua_button_Click(object sender, EventArgs e)
        {
            if(bang_hoa_don.SelectedRows.Count == 0)
            {
                MessageBox.Show("Hay chon mot hang de sua");
                return;
            }
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = pipe_connect;
                cmd.CommandText = @"UPDATE hoadon
                                    SET ten_khach = @ten_khach, ngay_ban = @ngay_ban, ten_dt = @ten_dt, mau_sac = @mau_sac,
                                        don_gia = @don_gia, so_luong = @so_luong
                                    WHERE ma_hd = @ma_hd";
                DateTime ngaybanDatetime = ngay_ban_datetimepicker.Value;
                string ngay_ban = ngaybanDatetime.ToString("yyyy/MM/dd");
                string mausac;
                if (den.Checked)
                    mausac = "0";
                else
                    mausac = "1";
                cmd.Parameters.AddWithValue("@ma_hd", ma_hd_textbox.Text.Trim());
                cmd.Parameters.AddWithValue("@ten_khach", ten_kh_textbox.Text);
                cmd.Parameters.AddWithValue("@ngay_ban", ngay_ban);
                cmd.Parameters.AddWithValue("@ten_dt", ten_dien_thoai_textbox.Text);
                cmd.Parameters.AddWithValue("@mau_sac", mausac);
                cmd.Parameters.AddWithValue("@don_gia", int.Parse(don_gia_textbox.Text));
                cmd.Parameters.AddWithValue("@so_luong", int.Parse(so_luong.Value.ToString()));
                cmd.ExecuteNonQuery();
                MessageBox.Show("cap nhat thanh cong");
                load_bang_hoa_don();
            }
        }

        private void dong_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bang_hoa_don_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (bang_hoa_don.SelectedCells[0].Value != null)
            {
                try
                {
                    var selectedRow = bang_hoa_don.SelectedRows[0];
                    ten_dien_thoai_textbox.Text = selectedRow.Cells[3].Value.ToString();
                    ma_hd_textbox.Text = selectedRow.Cells[0].Value.ToString();
                    ten_kh_textbox.Text = selectedRow.Cells[1].Value.ToString();
                    don_gia_textbox.Text = selectedRow.Cells[5].Value.ToString();
                    string s = selectedRow.Cells[2].Value.ToString();
                    string[] parts = s.Split('/');
                    
                    ngay_ban_datetimepicker.Text = parts[1] + "/" + parts[0] + "/" + parts[2];
                    if (selectedRow.Cells[4].Value.ToString() == "Đen")
                    {
                        den.Checked = true;
                    }
                    else
                        mau_khac.Checked = true;
                    

                }
                catch
                {
                    ;
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                dong_Click(sender, e);
            }
            if(e.KeyCode == Keys.Enter)
            {
                them_button_Click(them_button,e);
            }

        }

        private void màuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                if (colorDialog.Color != Color.Black)
                {
                   ten_dien_thoai_textbox.BackColor = colorDialog.Color;
                }
            }
        }
    }
}
