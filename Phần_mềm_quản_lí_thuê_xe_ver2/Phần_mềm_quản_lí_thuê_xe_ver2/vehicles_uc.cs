using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebSockets;
using System.Windows.Forms;

namespace Phần_mềm_quản_lí_thuê_xe_ver2
{
    public partial class vehicles_uc : UserControl
    {
        string bienso, tenxe, loaixe, mauxe, hangxe, socho, trangthai, ten_ncc;
        int giathue, tiencoc;
        DataTable datatable1 = new DataTable();

        

        control_dash_board control = new control_dash_board();

        public vehicles_uc()
        {
            InitializeComponent();
            

        }


        private void LoadData()
        {
            
            using (SqlCommand query = new SqlCommand())
            {
                datatable1.Clear();
                DataTable temp = datatable1;
                query.CommandText = "SELECT * FROM Xe";
                query.Connection = control_dash_board.pipe_connect;
                SqlDataReader reader = query.ExecuteReader();
                while (reader.Read())
                {
                    temp.Rows.Add(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString(), reader[7].ToString(), reader[8].ToString(), reader[9].ToString());
                }
                reader.Close();
                datatable1 = temp;
                bang_xe.DataSource = datatable1;
            }


            tb_bienso.Clear();
            tb_tenxe.Clear();
            tb_loaixe.Clear();
            tb_mauxe.Clear();
            tb_hangxe.Clear();
            tb_giathue.Clear();
            tb_tiencoc.Clear();
            tb_socho.Clear();
            comboBox_tenncc.Text = "";
            //SqlDataAdapter adapter = new SqlDataAdapter(@"Select *  from Xe", control_dash_board.pipe_connect);
            //DataTable dt = new DataTable();
            //adapter.Fill(dt);
            //bang_xe.DataSource = dt;
        }
        private void vehicles_uc_Load(object sender, EventArgs e)
        {

            // control.ket_noi();
            // LoadData();
            datatable1.Columns.Add("Biển số", typeof(string));
            datatable1.Columns.Add("Tên xe", typeof(string));
            datatable1.Columns.Add("Trạng thái xe", typeof(string));
            datatable1.Columns.Add("Loại xe", typeof(string));
            datatable1.Columns.Add("Màu xe", typeof(string));
            datatable1.Columns.Add("Số chỗ", typeof(string));
            datatable1.Columns.Add("Hãng xe", typeof(string));
            datatable1.Columns.Add("Giá thuê", typeof(string));
            datatable1.Columns.Add("Tiền cọc", typeof(string));
            datatable1.Columns.Add("Nhà cung cấp", typeof(string));

            LoadData();

            string query = "select ten_nha_cung_cap from Nha_Cung_Cap";
            SqlCommand cmd = new SqlCommand(query, control_dash_board.pipe_connect);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboBox_tenncc.Items.Add(reader["ten_nha_cung_cap"].ToString());
            }
            reader.Close();


        }

        private void suaxe_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu không có hàng nào được chọn
            if (bang_xe.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một hàng để sửa!");
                return;
            }
            try
            {

                // Lấy thông tin đã chỉnh sửa
                bienso = tb_bienso.Text.Trim();
                tenxe = tb_tenxe.Text;
                loaixe = tb_loaixe.Text;
                mauxe = tb_mauxe.Text;
                hangxe = tb_hangxe.Text;
                socho = tb_socho.Text;
                giathue = int.Parse(tb_giathue.Text);
                tiencoc = int.Parse(tb_tiencoc.Text);
                ten_ncc = comboBox_tenncc.Text;
                // Thực hiện truy vấn cập nhật thông tin
                // (Đảm bảo control_dash_board và pipe_connect đã được khởi tạo trước đó)
               // control.ket_noi();
                string updateQuery = @"UPDATE Xe SET ten_xe = @tenxe, loai_xe = @loaixe, mau_xe = @mauxe, hang_xe = @hangxe, so_cho = @socho, gia_thue = @giathue, tien_coc = @tiencoc 
                                       WHERE bien_so = @bienso";
                SqlCommand command = new SqlCommand(updateQuery, control_dash_board.pipe_connect);
                command.Parameters.AddWithValue("@bienso", bienso);
                command.Parameters.AddWithValue("@tenxe", tenxe);
                command.Parameters.AddWithValue("@loaixe", loaixe);
                command.Parameters.AddWithValue("@mauxe", mauxe);
                command.Parameters.AddWithValue("@hangxe", hangxe);
                command.Parameters.AddWithValue("@socho", socho);
                command.Parameters.AddWithValue("@giathue", giathue);
                command.Parameters.AddWithValue("@tiencoc", tiencoc);
            
                command.ExecuteNonQuery();

                // Hiển thị lại danh sách sau khi cập nhật
                LoadData();

                // Xóa dữ liệu trên các control và vô hiệu hóa nút sửa
                
                suaxe.Enabled = false;
            }
            catch
            {
                MessageBox.Show("Cập nhật dữ liệu không thành công");
            }

        }

        private void xoaxe_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu không có hàng nào được chọn
            try
            {
                if (bang_xe.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn một hàng để xóa!");
                    return;
                }

                string selectedId = bang_xe.SelectedRows[0].Cells["Biển số"].Value.ToString();
               // control.ket_noi();
                string deleteQuery = "DELETE FROM Xe WHERE bien_so = @bienso";
                SqlCommand command = new SqlCommand(deleteQuery, control_dash_board.pipe_connect);
                command.Parameters.AddWithValue("@bienso", selectedId);
                // Thực thi truy vấn xóa
                command.ExecuteNonQuery();

                LoadData();

            }
            catch
            {
                MessageBox.Show("Xóa dữ liệu không thành công");
            }
        }

        private void bang_xe_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có hàng nào được chọn hay không
            if (bang_xe.SelectedRows.Count > 0)
            {
                // Lấy dữ liệu từ hàng được chọn
                var selectedRow = bang_xe.SelectedRows[0];
                tb_bienso.Text = selectedRow.Cells["Biển số"].Value.ToString().Trim();
                tb_tenxe.Text = selectedRow.Cells["Tên xe"].Value.ToString();
                tb_loaixe.Text = selectedRow.Cells["Loại xe"].Value.ToString();
                tb_mauxe.Text = selectedRow.Cells["Màu xe"].Value.ToString();
                tb_hangxe.Text = selectedRow.Cells["Hãng xe"].Value.ToString();
                tb_socho.Text = selectedRow.Cells["Số chỗ"].Value.ToString();
                tb_giathue.Text = selectedRow.Cells["Giá thuê"].Value.ToString();
                tb_tiencoc.Text = selectedRow.Cells["Tiền cọc"].Value.ToString();
              
                comboBox_tenncc.Text = selectedRow.Cells["Nhà cung cấp"].Value.ToString();
                // Kích hoạt nút sửa
                suaxe.Enabled = true;
            }
        }

        private void them_xe_button_Click(object sender, EventArgs e)
        {
            try
            {

                bienso = tb_bienso.Text;
                tenxe = tb_tenxe.Text;
                loaixe = tb_loaixe.Text;
                mauxe = tb_mauxe.Text;
                socho = tb_socho.Text;
                hangxe = tb_hangxe.Text;
                giathue = int.Parse(tb_giathue.Text);
                tiencoc = int.Parse(tb_tiencoc.Text);

               // control.ket_noi();
                string trangthai = "1";
                string insertQuery = @"INSERT INTO Xe(bien_so, ten_xe, loai_xe, mau_xe, so_cho, hang_xe, gia_thue, tien_coc, trang_thai, ten_nha_cung_cap) 
                                       VALUES (@bienso, @tenxe, @loaixe, @mauxe, @socho, @hangxe, @giathue, @tiencoc, @trangthai, @ten_nha_cung_cap);";
                SqlCommand command = new SqlCommand(insertQuery, control_dash_board.pipe_connect);
                command.Parameters.AddWithValue("@bienso", bienso);
                command.Parameters.AddWithValue("@tenxe", tenxe);
                command.Parameters.AddWithValue("@loaixe", loaixe);
                command.Parameters.AddWithValue("@mauxe", mauxe);
                command.Parameters.AddWithValue("@socho", socho);
                command.Parameters.AddWithValue("@hangxe", hangxe);
                command.Parameters.AddWithValue("@giathue", giathue);
                command.Parameters.AddWithValue("@tiencoc", tiencoc);
                command.Parameters.AddWithValue("@trangthai", trangthai);
                command.Parameters.AddWithValue("@ten_nha_cung_cap", comboBox_tenncc.Text);
                command.ExecuteNonQuery();

                LoadData();
            }
            catch
            {
                MessageBox.Show("Chưa đủ điều kiện để thêm xe vào kho");
            }

        
        }

        
    }


}
