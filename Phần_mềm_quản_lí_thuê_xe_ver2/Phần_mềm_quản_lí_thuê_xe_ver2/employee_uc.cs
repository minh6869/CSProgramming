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
    public partial class employee_uc : UserControl
    {
        DataTable data_table_bang_nv = new DataTable();

        public employee_uc()
        {
            InitializeComponent();
            data_table_bang_nv.Columns.Add("Số CMND Nhân Viên", typeof(string));
            data_table_bang_nv.Columns.Add("Họ Tên Nhân Viên", typeof(string));
            data_table_bang_nv.Columns.Add("Số Điện Thoại", typeof(string));
            data_table_bang_nv.Columns.Add("Email Nhân Viên", typeof(string));
            data_table_bang_nv.Columns.Add("Giới Tính", typeof(string));
            data_table_bang_nv.Columns.Add("Địa chỉ", typeof(string));
            data_table_bang_nv.Columns.Add("Ngày Sinh", typeof(string));
        }
        private void load_bang_nv()
        {
            using(SqlCommand query = new SqlCommand())
            {
                query.CommandText = @"SELECT * FROM Nhan_Vien";
                query.Connection = control_dash_board.pipe_connect;
                SqlDataReader reader  = query.ExecuteReader();
                while(reader.Read())
                {
                    data_table_bang_nv.Rows.Add(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString());
                }
                bang_nhan_vien.DataSource = data_table_bang_nv;
            }
        }


        private void employee_uc_Load(object sender, EventArgs e)
        {
            load_bang_nv();
        }
    }
}
