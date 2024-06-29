using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_s_Project_Clinic_Consultation_Appointment_System
{
    public partial class Form4 : BaseForm
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox5.Text) || string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Please fill all fields!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearTextBoxes();
                return;
            }

            using (MySqlConnection c = GetConnection())
            {
                c.Open();
                string query = "INSERT INTO ids VALUES(@Email, @Password, @Username)";
                using (MySqlCommand cmd = new MySqlCommand(query, c))
                {
                    cmd.Parameters.AddWithValue("@Username", textBox5.Text);
                    cmd.Parameters.AddWithValue("@Email", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Password", textBox1.Text);
                    int a = cmd.ExecuteNonQuery();
                    if (a > 0)
                    { 
                        ClearTextBoxes();
                        ShowForm(new Form5());
                    }
                    else
                    {
                        MessageBox.Show("Data is not inserted","Error",MessageBoxButtons.RetryCancel,MessageBoxIcon.Error);
                        ClearTextBoxes();
                        textBox5.Focus();
                    }
                }
            }
        }

        private void ClearTextBoxes()
        {
            textBox5.Text = "";
            textBox2.Text = "";
            textBox1.Text = "";
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
            textBox5.Focus();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                textBox1.UseSystemPasswordChar = false;
            }
            else
            {
                textBox1.UseSystemPasswordChar = true;
            }
        }
    }
}
