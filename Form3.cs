﻿using MySql.Data.MySqlClient;
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
    public partial class Form3 : BaseForm
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void ClearTextBoxes()
        {
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Please fill all fields!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearTextBoxes();
                return;
            }

            using (MySqlConnection c = GetConnection())
            {
                c.Open();
                string query = "SELECT * FROM loginids.ids WHERE Email = @Email AND Password = @Password";
                using (MySqlCommand cmd = new MySqlCommand(query, c))
                {
                    cmd.Parameters.AddWithValue("@Email", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Password", textBox3.Text);
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            ClearTextBoxes();
                            ShowForm(new Form5());
                        }
                        else
                        {
                            MessageBox.Show("Login Failed", "Failed", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                            ClearTextBoxes();
                            textBox4.Focus();
                        }
                    }
                }
                c.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3.ActiveForm.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                textBox3.UseSystemPasswordChar = false;
            }
            else
            {
                textBox3.UseSystemPasswordChar = true;
            }
        }
    }
}
