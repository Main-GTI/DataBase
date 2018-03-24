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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            //string connstr = ConfigurationManager.ConnectionStrings["connectionString"].ToString(); //读取连接字符串
            string myConnString = "Data Source=DESKTOP-PM78S8E\SQLEXPRESS;Initial Catalog=memberlist;Persist Security Info=True;User ID=sa;Password=***********";

            SqlConnection sqlConnection = new SqlConnection(myConnString);  //实例化连接对象
            sqlConnection.Open();

            string sql = "select userid,password from usertable where userid = '" + username + "' and password = '" + password + "'";             //编写SQL命令
            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.HasRows)
            {
                MessageBox.Show("登陆成功");
                Form2 form2 = new Form2();
                form2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("账号或密码错误，请重试");
            }
            sqlConnection.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
