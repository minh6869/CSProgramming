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
    public partial class home : UserControl
    {
        DataTable data_table_bang_cho_thue = new DataTable();

        control_dash_board control = new control_dash_board();
        public home()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


        private void load_bang_cho_thue()
        {
                DataTable temp = new DataTable();
            using(SqlCommand query = new SqlCommand())
            {
                string bien_so, cccd_khach, cccd_nv, dia_diem;
                DateTime ngay_thue,ngay_tra_du_kien;
                int so_ngay_thue = 0;
                query.Connection = control_dash_board.pipe_connect;
                query.CommandText = $@"SELECT * FROM Bang_Thue_Xe";
                //string cmd = $@"SELECT * FROM Bang_Thue_Xe";
                //SqlDataAdapter adapter = new SqlDataAdapter(cmd,control_dash_board.pipe_connect);
                //adapter.Fill(temp);
                SqlDataReader reader = query.ExecuteReader();
                while (reader.Read())
                {
                    bien_so = reader["bien_so"].ToString();
                    cccd_khach = reader["cccd_khach"].ToString();
                    cccd_nv = reader["cccd_nv"].ToString();
                    dia_diem = reader["dia_diem_trao_xe"].ToString();
                    ngay_thue = DateTime.Parse(reader["ngay_thue"].ToString());
                    so_ngay_thue = int.Parse(reader["so_ngay_thue"].ToString());
                    ngay_tra_du_kien = ngay_thue.AddDays(so_ngay_thue);
                    Console.WriteLine(ngay_thue);
                    Console.WriteLine(DateTime.Now);
                    //temp.Rows.Add(ngay_thue);
                    SqlCommand query1 = new SqlCommand();
                    query1.Connection = control_dash_board.pipe_connect;
                    query1.CommandText = $@"SELECT  Xe.ten_xe,
                                                    Xe.so_cho,
                                                    Xe.bien_so,
                                                    Khach_Hang.ho_ten as ho_ten_khach,
                                                    Khach_Hang.sdt as sdt_khach,
                                                    Nhan_Vien.ho_ten as ho_ten_nv
                                            FROM Xe, Khach_Hang, Nhan_Vien
                                            WHERE Xe.bien_so = '{bien_so}' 
                                            AND Khach_Hang.cccd_khach = '{cccd_khach}'
                                            AND Nhan_Vien.cccd_nv = '{cccd_nv}'";
                    SqlDataReader reader1 = query1.ExecuteReader();
                    while(reader1.Read())
                    {
                        data_table_bang_cho_thue.Rows.Add(reader1[0].ToString(), reader1[1].ToString(), reader1[2].ToString(), reader1[3].ToString(), reader1[4].ToString(), reader1[5].ToString(),dia_diem,ngay_thue.ToString("dd/MM/yyyy"),so_ngay_thue,ngay_tra_du_kien.ToString("dd/MM/yyyy"));
                    }
                    reader1.Close();
                }
                reader.Close();
                //reader.Close();
            }





            bang_cho_thue.DataSource = data_table_bang_cho_thue;
        }

        private void home_Load(object sender, EventArgs e)
        {
            control.ket_noi();
            // bang_cho_thue.DataSource = data_table_bang_cho_thue;
            data_table_bang_cho_thue.Columns.Add("Tên xe",typeof(string));
            data_table_bang_cho_thue.Columns.Add("Số chỗ", typeof(string));
            data_table_bang_cho_thue.Columns.Add("Biển xe", typeof(string));
            data_table_bang_cho_thue.Columns.Add("Họ tên khách", typeof(string));
            data_table_bang_cho_thue.Columns.Add("Số điện thoại khách", typeof(string));
            data_table_bang_cho_thue.Columns.Add("Họ tên nhân viên cho thuê", typeof(string));
            data_table_bang_cho_thue.Columns.Add("Địa điểm cho thuê xe", typeof(string));
            data_table_bang_cho_thue.Columns.Add("Ngày Thuê", typeof(string));
            data_table_bang_cho_thue.Columns.Add("Số Ngày Thuê", typeof(int));
            data_table_bang_cho_thue.Columns.Add("Ngày trả dự kiến", typeof(string));

            load_bang_cho_thue();


        }


    }
}
