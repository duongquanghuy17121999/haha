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
namespace week2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection conn;

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void disconnect()
        {
            conn.Close();
            conn.Dispose();
            conn = null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(@"Data Source=ANDONGNHI\SQLEXPRESS;Initial Catalog=school;Integrated Security=True");
            conn.Open();
            HienThi();
            binding();
            //disconnect();
        }

        public void HienThi()
        {
            string sqlSelect = "SELECT * FROM student";
            SqlCommand cmd = new SqlCommand(sqlSelect, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sqlInsert = "INSERT INTO student VALUES (@hoten,@ngaysinh,@gioitinh,@email)";
            SqlCommand cmd = new SqlCommand(sqlInsert, conn);
            //cmd.Parameters.AddWithValue("maso", textBox3.Text);
            cmd.Parameters.AddWithValue("hoten", textBox1.Text);
            cmd.Parameters.AddWithValue("ngaysinh", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("gioitinh", radioButton1.Checked? true : false);
            cmd.Parameters.AddWithValue("email", textBox2.Text);
            cmd.ExecuteNonQuery();
            HienThi();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sqlDelete = "DELETE FROM student where maso=@maso";
            SqlCommand cmd = new SqlCommand(sqlDelete, conn);
            cmd.Parameters.AddWithValue("maso", textBox3.Text);
            cmd.Parameters.AddWithValue("hoten", textBox1.Text);
            cmd.Parameters.AddWithValue("ngaysinh", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("gioitinh", radioButton1.Checked ? true : false);
            cmd.Parameters.AddWithValue("email", textBox2.Text);
            cmd.ExecuteNonQuery();
            HienThi();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sqlEdit = "UPDATE student SET hoten=@hoten,ngaysinh=@ngaysinh,gioitinh=@gioitinh,email=@email where maso=@maso";
            SqlCommand cmd = new SqlCommand(sqlEdit, conn);
            cmd.Parameters.AddWithValue("maso", textBox3.Text);
            cmd.Parameters.AddWithValue("hoten", textBox1.Text);
            cmd.Parameters.AddWithValue("ngaysinh", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("gioitinh", radioButton1.Checked ? true : false);
            cmd.Parameters.AddWithValue("email", textBox2.Text);
            cmd.ExecuteNonQuery();
            HienThi();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string sqlDelete = "DELETE FROM student where maso=@maso";
            SqlCommand cmd = new SqlCommand(sqlDelete, conn);
            cmd.Parameters.AddWithValue("maso", textBox3.Text);
            cmd.Parameters.AddWithValue("hoten", textBox1.Text);
            cmd.Parameters.AddWithValue("ngaysinh", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("gioitinh", radioButton1.Checked ? true : false);
            cmd.Parameters.AddWithValue("email", textBox2.Text);
            cmd.ExecuteNonQuery();
            HienThi();
        }

        private void binding()
        {
            textBox1.DataBindings.Clear();
            textBox1.DataBindings.Add("Text", dataGridView1.DataSource, "hoten");
            textBox2.DataBindings.Clear();
            textBox2.DataBindings.Add("Text", dataGridView1.DataSource, "email");
            textBox3.DataBindings.Clear();
            textBox3.DataBindings.Add("Text", dataGridView1.DataSource, "maso");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            

        }
    }
}
