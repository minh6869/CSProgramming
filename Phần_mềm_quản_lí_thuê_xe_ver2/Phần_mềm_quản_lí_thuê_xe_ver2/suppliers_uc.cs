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

namespace Phần_mềm_quản_lí_thuê_xe_ver2
{
    public partial class suppliers_uc : UserControl
    {

        string tenncc, sodt, diachi;
        DataTable datatable1;
        control_dash_board control = new control_dash_board();

        public suppliers_uc()
        {
            InitializeComponent();
            datatable1 = new DataTable();
            datatable1.Columns.Add("Tên nhà cung cấp");
            datatable1.Columns.Add("Số điện thoại");
            datatable1.Columns.Add("Địa chỉ");
            sua_ncc_button.Enabled = false;
            //control.ket_noi();
        }

        private void LoadData()
        {
            //control.ket_noi();
            datatable1.Clear();
            using(SqlCommand query = new SqlCommand())
            {
                query.CommandText = @"SELECT * FROM Nha_Cung_Cap";
                query.Connection = control_dash_board.pipe_connect;
                SqlDataReader reader = query.ExecuteReader();
                while(reader.Read())
                {
                    datatable1.Rows.Add(reader[0].ToString(), reader[1].ToString(), reader[2].ToString());
                }
                reader.Close();
                bang_nha_cung_cap.DataSource = datatable1;
            }
            //SqlDataAdapter adapter = new SqlDataAdapter("Select * from Nha_Cung_Cap", control_dash_board.pipe_connect);
            //DataTable dt = new DataTable();
            //adapter.Fill(dt);
            //bang_nha_cung_cap.DataSource = dt;

        }
        private void suppliers_uc_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void xoa_ncc_button_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu không có hàng nào được chọn
            if (bang_nha_cung_cap.SelectedCells[0].Value != null)
            {

                if (bang_nha_cung_cap.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn một hàng để xóa!");
                    return;
                }

                string selectedId = bang_nha_cung_cap.SelectedRows[0].Cells["Tên nhà cung cấp"].Value.ToString();
                control.ket_noi();
                string deleteQuery = "delete from Nha_Cung_Cap where ten_nha_cung_cap = @tenncc";
                SqlCommand command = new SqlCommand(deleteQuery, control_dash_board.pipe_connect);
                command.Parameters.AddWithValue("@tenncc", selectedId);
                // Thực thi truy vấn xóa
                command.ExecuteNonQuery();

                LoadData();
            }
           
        }

        private void sua_ncc_button_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu không có hàng nào được chọn
            if (bang_nha_cung_cap.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một hàng để sửa!");
                return;
            }

            // Lấy thông tin đã chỉnh sửa
            tenncc = ten_ncc.Text;
            sodt = sodt_ncc.Text;
            diachi = diachi_ncc.Text;

            // Thực hiện truy vấn cập nhật thông tin
            // (Đảm bảo control_dash_board và pipe_connect đã được khởi tạo trước đó)
            control.ket_noi();
            string updateQuery = "update Nha_Cung_Cap set sdt = @sodt, dia_chi = @diachi where ten_nha_cung_cap = @tenncc";
            SqlCommand command = new SqlCommand(updateQuery, control_dash_board.pipe_connect);
            command.Parameters.AddWithValue("@tenncc", tenncc);
            command.Parameters.AddWithValue("@sodt", sodt);
            command.Parameters.AddWithValue("@diachi", diachi);
            command.ExecuteNonQuery();

            // Hiển thị lại danh sách sau khi cập nhật
            LoadData();

            // Xóa dữ liệu trên các control và vô hiệu hóa nút sửa
            ten_ncc.Clear();
            sodt_ncc.Clear();
            diachi_ncc.Clear();
            sua_ncc_button.Enabled = false;

        }

        private void bang_nha_cung_cap_Click(object sender, EventArgs e)
        {
            if (bang_nha_cung_cap.SelectedCells[0].Value != null)
            {
                if (bang_nha_cung_cap.SelectedRows.Count > 0)
                {
                    // Lấy dữ liệu từ hàng được chọn
                    var selectedRow = bang_nha_cung_cap.SelectedRows[0];
                    ten_ncc.Text = selectedRow.Cells["Tên nhà cung cấp"].Value.ToString();
                    sodt_ncc.Text = selectedRow.Cells["Số điện thoại"].Value.ToString();
                    diachi_ncc.Text = selectedRow.Cells["Địa chỉ"].Value.ToString();

                    // Kích hoạt nút sửa
                    sua_ncc_button.Enabled = true;
                }
            }    
            // Kiểm tra xem có hàng nào được chọn hay không
        }

        private void them_ncc_button_Click(object sender, EventArgs e)
        {
            //if()
            try
            {
                tenncc = ten_ncc.Text;
                sodt = sodt_ncc.Text;
                diachi = diachi_ncc.Text;
                control.ket_noi();
                string insertQuery = "insert into Nha_Cung_Cap(ten_nha_cung_cap, sdt, dia_chi) values (@tenncc, @sodt, @diachi)";
                SqlCommand command = new SqlCommand(insertQuery,control_dash_board.pipe_connect); 
                command.Parameters.AddWithValue("@tenncc", tenncc);
                command.Parameters.AddWithValue("@sodt", sodt);
                command.Parameters.AddWithValue("@diachi", diachi);

                command.ExecuteNonQuery();

                ten_ncc.Clear();
                sodt_ncc.Clear();
                diachi_ncc.Clear();

                LoadData();

            }
            catch
            {
                MessageBox.Show("Nhà cung cấp không hợp lệ!");
            }
        }

       
    }
}
