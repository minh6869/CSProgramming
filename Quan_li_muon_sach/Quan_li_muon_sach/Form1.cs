using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Quan_li_muon_sach
{
    public partial class Form1 : Form
    {
        string connect = @"Data Source=ZHISHU\SQLEXPRESS;Initial Catalog=QuanLiMuonTraSach;
                           Integrated Security=True;MultipleActiveResultSets=True";
        SqlConnection sqlconnect = null;
        List<string> list = new List<string>();
        List<string> list_sv = new List<string>();
        List<string> list_ma_sach = new List<string>();
        //List<string> virtual_list = new List<string>();
        DataTable data_table_muon_tra = new DataTable();
        
        

        public Form1()
        {
            InitializeComponent();

        }

        private void Connect()
        {
            try
            {
                if (sqlconnect == null)
                {
                    sqlconnect = new SqlConnection(connect);
                }
                if (sqlconnect.State == ConnectionState.Closed)
                {
                    sqlconnect.Open();
                    MessageBox.Show("kết nối thành công");
                }
            }
            catch
            {
                Console.WriteLine("Ket noi that bai");
            }
        }
        //
        // load tên các loại sách vào tab mượn trả
        //
        private void load_ten_sach()
        {
            if (ten_sv_combobox.Text == "")
            {
                using (var query = new SqlCommand())
                {
                    List<string> list_temp = new List<string>();
                    query.CommandType = CommandType.Text;
                    query.Connection = sqlconnect;
                    query.CommandText = $"SELECT DISTINCT(SACH.ten_sach) from SACH";
                    SqlDataReader reader = query.ExecuteReader();
                    string ten_sach;
                    while (reader.Read())
                    {
                        ten_sach = reader["ten_sach"].ToString();
                        list_temp.Add(ten_sach);
                    }
                    reader.Close();
                    list = list_temp;
                    ten_sach_combobox.DataSource = list;
                }
                Console.WriteLine("Cap nhat thanh cong ten_sach");
            }
        }
        private void load_ma_sach()
        {
           using(var query = new SqlCommand())
           {
                List<string> list_temp = new List<string>();
                query.CommandType = CommandType.Text;
                query.Connection = sqlconnect;
                query.CommandText = $"SELECT ma_sach FROM SACH";
                SqlDataReader reader = query.ExecuteReader();
                string ma_sach;
                while(reader.Read())
                {
                    ma_sach = reader["ma_sach"].ToString();
                    list_temp.Add(ma_sach);
                }
                reader.Close();
                list_ma_sach = list_temp;
                ma_sach_combobox.DataSource = list_ma_sach;
           }
            ten_sach_combobox.Text = "";
        }

        private void load_ten_sinh_vien()
        {
            using (var query = new SqlCommand())
            {
                List <string> list_temp = new List<string>();
                query.CommandType = CommandType.Text;
                query.Connection = sqlconnect;
                query.CommandText = $"SELECT ho_ten_sinh_vien FROM BANG_MUON_TRA";
                SqlDataReader reader = query.ExecuteReader();
                string ten_sinh_vien;
                while (reader.Read())
                {
                    ten_sinh_vien = reader["ho_ten_sinh_vien"].ToString();
                    list_temp.Add(ten_sinh_vien);
                }
                reader.Close();
                list_sv = list_temp;
                ten_sv_combobox.DataSource = list_sv;
            }
            ten_sv_combobox.Text = "";
        }

        private void load_muon_tra()
        {
            try
            {
                using (var query = new SqlCommand())
                {
                    data_table_muon_tra.Clear();
                    DataTable table_temp = data_table_muon_tra;
                    query.CommandType = CommandType.Text;
                    query.Connection = sqlconnect;
                    query.CommandText = $"SELECT * FROM BANG_MUON_TRA";
                    SqlDataReader reader = query.ExecuteReader();
                    string stt, ho_ten, ten_sach, ma_sach, ngay_muon, ngay_tra_du_kien, ngay_tra_thuc_te,so_ngay_muon, thanh_tien;
                    //string stt, ho_ten, ten_sach, ma_sach;
                    //DateTime ngay_muon, ngay_tra;
                    //int thanh_tien;
                    int count = 0;
                    while(reader.Read())
                    {
                        count++;
                        stt = count.ToString();
                        ho_ten = reader["ho_ten_sinh_vien"].ToString();
                        ten_sach = reader["ten_sach"].ToString();
                        ma_sach = reader["ma_sach"].ToString();
                        ngay_muon = reader["ngay_muon"].ToString();
                        DateTime ngay_muon_temp = DateTime.Parse(ngay_muon);
                        ngay_muon = ngay_muon_temp.ToString("dd/MM/yyyy");
                        ngay_tra_du_kien = reader["ngay_tra"].ToString();
                        DateTime ngay_tra_du_kien_temp = DateTime.Parse(ngay_tra_du_kien);
                        ngay_tra_du_kien = ngay_tra_du_kien_temp.ToString("dd/MM/yyyy");
                        ngay_tra_thuc_te = "";
                        so_ngay_muon = (ngay_tra_du_kien_temp - ngay_muon_temp).Days.ToString();
                        thanh_tien = reader["thanh_tien"].ToString();
                        table_temp.Rows.Add(stt, ho_ten, ten_sach, ma_sach, ngay_muon, ngay_tra_du_kien, ngay_tra_thuc_te,so_ngay_muon, thanh_tien);
                        //bang_muon_tra.Rows.Add(stt, ho_ten, ten_sach, ma_sach, ngay_muon, ngay_tra, thanh_tien);
                    }
                    reader.Close();
                    data_table_muon_tra = table_temp;
                    bang_muon_tra.DataSource = data_table_muon_tra;
                }
            }
            catch 
            {
                Console.WriteLine("Load bang muon tra khong thanh cong");
            }
        }

        private string check_status_book(string ten_sach, string ma_sach)
        {
            string status;
            using (var query = new SqlCommand())
            {
                query.CommandType = CommandType.Text;
                query.Connection = sqlconnect;
                query.CommandText = $@"SELECT SACH.trang_thai FROM SACH
                                    WHERE N'{ten_sach}' = SACH.ten_sach
                                    AND N'{ma_sach}' = SACH.ma_sach";

                if (query.ExecuteScalar() == null)
                    status = "NULL";
                else
                    status = query.ExecuteScalar().ToString();
                
            }
            return status;
                
        }


        public string chuanhoa(string s)
        {
            string[] words = s.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string ans = "";
            ans += words[0] = words[0][0].ToString().ToUpper() + words[0].Substring(1).ToLower();
            for (int i = 1; i < words.Length; i++)
            {
                words[i] = words[i][0].ToString().ToUpper() + words[i].Substring(1).ToLower();
                ans += " " + words[i];
            }
            return ans;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            bang_sach.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã Sách", Name = "MaSach" });
            bang_sach.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tên Sách", Name = "TenSach" });
            bang_sach.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //
            data_table_muon_tra.Columns.Add("STT", typeof(string));
            data_table_muon_tra.Columns.Add("Họ tên sinh viên", typeof(string));
            data_table_muon_tra.Columns.Add("Tên sách", typeof(string));
            data_table_muon_tra.Columns.Add("Mã sách", typeof(string));
            data_table_muon_tra.Columns.Add("Ngày mượn", typeof(string));
            data_table_muon_tra.Columns.Add("Ngày trả dự kiến", typeof(string));
            data_table_muon_tra.Columns.Add("ngày trả thực tế", typeof(string));
            data_table_muon_tra.Columns.Add("số ngày mượn", typeof(int));
            data_table_muon_tra.Columns.Add("Thành tiền", typeof(string));



            //
            //bang_muon_tra.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "STT", Name = "stt" });
            //bang_muon_tra.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Họ tên sinh viên", Name = "ht" });
            //bang_muon_tra.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tên sách", Name = "ts" });
            //bang_muon_tra.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã sách", Name = "ms" });
            //bang_muon_tra.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Ngày mượn", Name = "nm" });
            //bang_muon_tra.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Ngày trả dự kiến", Name = "ntdk" });
            //bang_muon_tra.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Ngày trả thực tế", Name = "nttt" });
            //bang_muon_tra.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Số ngày mượn", Name = "snm" });
            //bang_muon_tra.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Thành tiền", Name = "tt" });
            bang_muon_tra.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //
            // hiển thị thông tin bang cac loại sách có trong thư viện
            //
            Connect();
            using (var query = new SqlCommand())
            {
                query.CommandType = CommandType.Text;
                query.Connection = sqlconnect;
                query.CommandText = $"SELECT ma_sach,ten_sach FROM SACH WHERE trang_thai = 'enable'";
                SqlDataReader reader = query.ExecuteReader();
                string ma_sach, ten_sach;
                while (reader.Read())
                {
                    ma_sach = reader["ma_sach"].ToString();
                    ten_sach = reader["ten_sach"].ToString();
                    bang_sach.Rows.Add(ma_sach, ten_sach);
                }
                reader.Close();
            }
            //
            // load tên các loại sách vào tab mượn trả
            //
            //list_ma_sach.Add(" ");
            load_ten_sach();
            //
            // load danh sach muon tra
            //
            load_muon_tra();
            //
            // load ten sinh vien dang muon sach
            //
            load_ten_sinh_vien();
            
        }
        private void them_button_Click(object sender, EventArgs e)
        {
            if(ma_sach_textbox.Text != "" && ten_sach_textbox.Text != "")
            {
                try
                {
                    using (var query = new SqlCommand())
                    {
                        query.CommandType = CommandType.Text;
                        query.Connection = sqlconnect;
                        string ma_sach = ma_sach_textbox.Text;
                        string ten_sach = ten_sach_textbox.Text;
                        query.CommandText = $"INSERT INTO SACH (ma_sach, ten_sach, trang_thai)" +
                                            $" VALUES (N'{ma_sach}',N'{ten_sach}', 'enable')";
                        query.ExecuteNonQuery();
                        bang_sach.Rows.Add(ma_sach, ten_sach);
                        ma_sach_textbox.Text = "";
                        ten_sach_textbox.Text = "";
                        load_ten_sach();
                        Console.WriteLine("Day thanh cong");
                    }    
                }
                catch (Exception) 
                {
                    Console.Write("Day that bai");
                }
            }
        }







        private void ma_sach_combobox_SelectedValueChanged(object sender, EventArgs e)
        {
            if(ma_sach_combobox.SelectedItem != null)
            {
                using (var query = new SqlCommand())
                {
                    query.Connection = sqlconnect;
                    string ma_sach = ma_sach_combobox.SelectedItem.ToString();
                    query.CommandText = $@"SELECT ten_sach FROM SACH
                                           WHERE N'{ma_sach}' = ma_sach";
                    string ten_sach = query.ExecuteScalar().ToString();
                    ten_sach_combobox.Text = ten_sach;
                }

            }
        }



        private void ten_sach_combobox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (ten_sach_combobox.SelectedItem != null)
            {
                using (var query = new SqlCommand())
                {
                    List<string> list_temp = new List<string>();
                    query.CommandType = CommandType.Text;
                    query.Connection = sqlconnect;
                    string ten_sach = ten_sach_combobox.SelectedItem.ToString();
                    query.CommandText = $"SELECT ma_sach FROM SACH WHERE ten_sach = N'{ten_sach}' ";
                    SqlDataReader reader = query.ExecuteReader();           
                    string ma_sach = "";
                    while (reader.Read())
                    {
                        ma_sach = reader["ma_sach"].ToString();
                        list_temp.Add(ma_sach);
                    }
                    reader.Close();
                    list_ma_sach = list_temp;
                    ma_sach_combobox.DataSource = list_ma_sach;
                }
                ma_sach_combobox.Text = "";
                Console.WriteLine("hihihihihihihii");
            }    
            
        }
     

        private void ten_sach_combobox_DataSourceChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Dữ liệu nguồn đã thay đổi!");
        }
        private void muon_button_Click(object sender, EventArgs e)
        {
            if(ten_sv_combobox.Text != "" && ma_sach_combobox.Text != "" && ten_sach_combobox.Text != "")
            {
                string ten_sinh_vien;
                DateTime ngay_muon, ngay_tra;
                ten_sinh_vien = ten_sv_combobox.Text;
                ngay_muon = ngay_muon_picker.Value;
                ngay_tra = ngay_tra_picker.Value;
                string status = check_status_book(ten_sach_combobox.Text, ma_sach_combobox.Text);

                Console.WriteLine(status);

                if (status == "enable")
                {
                    Console.WriteLine(status);
                    Console.WriteLine(ngay_muon_picker.Value.ToString());
                    Console.WriteLine(DateTime.Now.ToString());
                }
                else if (status == "disable")
                {
                    Console.WriteLine(status);
                }
                else if (status == "null")
                {
                    List<string> virtual_list = new List<string>();
                    virtual_list.Clear();
                    virtual_list.Add("");
                    ma_sach_combobox.DataSource = virtual_list;
                    ma_sach_combobox.Text = "";
                    ten_sach_combobox.Text = "";
                    MessageBox.Show("Hiện tại sách này không có trong cơ sở dữ liệu!");
                }


            }
                
                load_muon_tra();
        }

        private void tra_button_Click(object sender, EventArgs e)
        {
            

        }

        private void tab_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tab.SelectedIndex == 1)
            {
                load_ma_sach();
                ten_sv_combobox.Text = "";
                ten_sach_combobox.Text = "";
                ten_sach_combobox.SelectedValue = " ";
                ma_sach_combobox.Text = "";

                

            }
        }

        private void bang_muon_tra_DataSourceChanged(object sender, EventArgs e)
        {
            Console.WriteLine("thay doi du lieu cua bang_muon_tra");
        }

       
    }
}
