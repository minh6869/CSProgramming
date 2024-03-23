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
    public partial class customer_uc : UserControl
    {
        DataTable data_table_bang_khach = new DataTable();
        public customer_uc()
        {
            InitializeComponent();
        }

        private void customer_uc_Load(object sender, EventArgs e)
        {
            data_table_bang_khach.Columns.Add("Số CMND Khách", typeof(string));
            data_table_bang_khach.Columns.Add("Họ Tên Khách", typeof(string));
            data_table_bang_khach.Columns.Add("Số Điện Thoại", typeof(string));
            data_table_bang_khach.Columns.Add("Email Khách", typeof(string));
            data_table_bang_khach.Columns.Add("Giới Tính", typeof(string));
            data_table_bang_khach.Columns.Add("Địa chỉ", typeof(string));
            data_table_bang_khach.Columns.Add("Ngày Sinh", typeof(string));
            load_bang_khach();

        }

        private void load_bang_khach()
        {
            using (SqlCommand query = new SqlCommand())
            {
                query.CommandText = @"SELECT * FROM Khach_Hang";
                query.Connection = control_dash_board.pipe_connect;
                SqlDataReader reader = query.ExecuteReader();
                while(reader.Read())
                {
                    data_table_bang_khach.Rows.Add(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(),reader[6].ToString());
                }
                reader.Close();
                bang_khach.DataSource = data_table_bang_khach;
            }
        }
    }
}
