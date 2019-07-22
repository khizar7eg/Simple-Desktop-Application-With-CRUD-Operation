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


namespace StudentEnrollment
{
    public partial class EnrollmentMenu : Form
    {
       //Update Your Connection String
        public string constring = "Data Source=HP-ELITEBOOK-84\\SQLEXPRESS;Initial Catalog=StudentEnrollment;User ID=sa;Password=madmax";
        SqlCommand cmd;
        SqlDataAdapter adapt;
        
        public EnrollmentMenu()
        {
            InitializeComponent();
        }
       

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            this.Hide();
            form.FormClosed += new FormClosedEventHandler(delegate { Close(); });
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            if ( textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "")
            {
                string q = "Insert into Enrollment (Student_ID, First_Name, Last_Name, Gender, DOB, Address, Department, Program) values ('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + textBox5.Text.ToString() + "','" + textBox6.Text.ToString() + "','" + textBox7.Text.ToString() + "','" + textBox8.Text.ToString() + "')";
                SqlCommand cms = new SqlCommand(q, con);
                cms.ExecuteNonQuery();
                MessageBox.Show("Data is Saved");
                ClearData();
            }
            else
            {
                MessageBox.Show("Please Enter Details.");
            }  
        }

        //Display Data in DataGridView  
        private void DisplayData()
        {
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select * from Enrollment", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        //Clear Data  
        private void ClearData()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
        } 




        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constring);
            DisplayData();
            con.Close();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
         
        }
        //Update Record 
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "")
            {
                SqlConnection con = new SqlConnection(constring);
                cmd = new SqlCommand("Update Enrollment set First_Name=@first_name,Last_Name=@last_name,Gender=@gender,DOB=@dob,Address=@address,Department=@department,Program=@program where Student_ID=@student_id", con);
                con.Open();
                cmd.Parameters.AddWithValue("@Student_ID", textBox1.Text);
                cmd.Parameters.AddWithValue("@First_Name", textBox2.Text);
                cmd.Parameters.AddWithValue("@Last_Name", textBox3.Text);
                cmd.Parameters.AddWithValue("@Gender", textBox4.Text);
                cmd.Parameters.AddWithValue("@DOB", textBox5.Text);
                cmd.Parameters.AddWithValue("@Address", textBox6.Text);
                cmd.Parameters.AddWithValue("@Department", textBox7.Text);
                cmd.Parameters.AddWithValue("@Program", textBox8.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated Successfully");
                con.Close();
                DisplayData();
                ClearData();
            }
            else
            {
                MessageBox.Show("Please Select the Record to Update");
            }  
        }
        //Delete Record 
        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constring);
            if (textBox1.Text != "")
            {
                cmd = new SqlCommand("Delete Enrollment where Student_ID=@student_id", con);
                con.Open();
                cmd.Parameters.AddWithValue("@Student_ID", textBox1.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Deleted Successfully!");
                DisplayData();
                ClearData();
            }
            else
            {
                MessageBox.Show("Please Select Record to Delete");
            } 
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox9.Text))
            {
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            }
            else
            {
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("First_Name='{0}'", textBox9.Text);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ClearData();
            DisplayData();
        }





    }
}
