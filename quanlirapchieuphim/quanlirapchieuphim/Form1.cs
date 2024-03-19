using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace quanlirapchieuphim
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        string conn = @"Data Source=(local);Initial Catalog=quanlichieuphim;Integrated Security=True";
        SqlConnection connect = null;

        private void ket_noi()
        {
            try
            {
                if (connect == null)
                    connect = new SqlConnection(conn);
                if (connect.State == ConnectionState.Closed)
                    connect.Open();
                
            }
            catch
            {
                MessageBox.Show("ket noi that bai");
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ket_noi();
            using(SqlCommand query = new SqlCommand())
            {
                query.CommandType = CommandType.Text;
                query.Connection = connect;
                query.CommandText = "SELECT ten_phim FROM bo_phim";
                SqlDataReader reader = query.ExecuteReader();
                string tenphim;
                while(reader.Read())
                {
                    tenphim = reader["ten_phim"].ToString();
                    ten_phim_combo.Items.Add(tenphim);
                }
                reader.Close();
            }

            
        }
        private Button getbutton(string i)
        {
            Button test = button1 ;
            string name = "but" + i;
            foreach(Button button in this.Controls.Find(name, true))
            {
                Console.Write(button.Name);
                test = button;
                break;
            }
            return test;
            


        }

        private void ten_phim_combo_SelectedValueChanged(object sender, EventArgs e)
        {
            string tenphim = ten_phim_combo.SelectedItem.ToString();
            loi_chao_label.Text = "chào mừng bạn đến với phòng chiếu phim: " + tenphim;
            using (SqlCommand query = new SqlCommand())
            {
                query.CommandType = CommandType.Text;
                query.Connection = connect;
                query.CommandText = "SELECT * FROM bo_phim WHERE ten_phim = N'" + tenphim + "'";
                SqlDataReader reader = query.ExecuteReader();
                while(reader.Read())
                {
                    for (int i = 1; i <= 36; i++)
                    {
                        string status = reader[i].ToString();
                        if(status == "0")
                        {
                            //Console.WriteLine(status);
                            //Console.WriteLine(i);
                            //Console.WriteLine(getbutton(i.ToString()));
                            getbutton(i.ToString()).BackColor = Color.Red;
                        }
                         
                    }
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }


        
    }
}
