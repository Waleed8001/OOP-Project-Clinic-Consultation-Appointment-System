/*using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OOP_s_Project_Clinic_Consultation_Appointment_System
{
    public partial class Form5 : BaseForm
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form5.ActiveForm.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                string con = "server=localhost;uid=root;pwd=W#0324@aleed;database=loginids";
                MySqlConnection c = new MySqlConnection();
                c.ConnectionString = con;
                c.Open();
                string query = "INSERT INTO patient_detail VALUES(@Name, @Age, @gender, @disease)";
                MySqlCommand cmd = new MySqlCommand(query, c);
                cmd.Parameters.AddWithValue("@Name", textBox1.Text);
                cmd.Parameters.AddWithValue("@Age", textBox2.Text);
                if (radioButton1.Checked == true)
                {
                    string Male = "M";
                    cmd.Parameters.AddWithValue("@gender", Male);
                }
                else if (radioButton2.Checked == true)
                {
                    string Female = "F";
                    cmd.Parameters.AddWithValue("@gender", Female);
                }
                else
                {
                    MessageBox.Show("Please select gender !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                cmd.Parameters.AddWithValue("@disease", comboBox1.SelectedItem);
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Data Inserted");
                }
                else
                {
                    MessageBox.Show("Data is not inserted");
                }
                c.Close();
            }
            else
            {
                MessageBox.Show("Please fill all fields!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
        }
    }
}*/

/*using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace OOP_s_Project_Clinic_Consultation_Appointment_System
{
    public partial class Form5 : BaseForm
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Please fill all fields!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (MySqlConnection c = GetConnection())
            {
                c.Open();
                string query = "INSERT INTO patient_detail VALUES(@Name, @Age, @gender, @disease)";
                using (MySqlCommand cmd = new MySqlCommand(query, c))
                {
                    cmd.Parameters.AddWithValue("@Name", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Age", textBox2.Text);
                    if (radioButton1.Checked == true)
                    {
                        string Male = "M";
                        cmd.Parameters.AddWithValue("@gender", Male);
                    }
                    else if (radioButton2.Checked == true)
                    {
                        string Female = "F";
                        cmd.Parameters.AddWithValue("@gender", Female);
                    }
                    else
                    {
                        MessageBox.Show("Please select gender !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    cmd.Parameters.AddWithValue("@disease", comboBox1.SelectedItem.ToString());
                    int result = cmd.ExecuteNonQuery();
                    MessageBox.Show(result > 0 ? "Data Inserted" : "Data is not inserted");
                }
            }
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OOP_s_Project_Clinic_Consultation_Appointment_System
{
    public partial class Form5 : BaseForm
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form5.ActiveForm.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && (radioButton1.Checked == true || radioButton2.Checked == true))
            {
                try
                {
                    using (MySqlConnection c = GetConnection())
                    {
                        c.Open();
                        string query = "INSERT INTO patient_detail VALUES(@Name, @Age, @gender, @disease)";
                        MySqlCommand cmd = new MySqlCommand(query, c);
                        cmd.Parameters.AddWithValue("@Name", textBox1.Text);
                        cmd.Parameters.AddWithValue("@Age", textBox2.Text);
                        if (radioButton1.Checked == true)
                        {
                            cmd.Parameters.AddWithValue("@gender", "M");
                        }
                        else if (radioButton2.Checked == true)
                        {
                            cmd.Parameters.AddWithValue("@gender", "F");
                        }
                        else
                        {
                            MessageBox.Show("Please select gender !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            
                        }
                        cmd.Parameters.AddWithValue("@disease", comboBox1.SelectedItem.ToString());

                        int a = cmd.ExecuteNonQuery();
                        if (a > 0)
                        {
                            MessageBox.Show("Data Inserted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            using (MySqlConnection c2 = GetConnection2())
                            {
                                c2.Open();
                                string query2 = "SELECT Name,Timing FROM loginids.doctor_and_timing WHERE Speciality = @Speciality  ";
                                using (MySqlCommand cmd2 = new MySqlCommand(query2, c2))
                                {
                                    cmd2.Parameters.AddWithValue("@Speciality", comboBox1.SelectedItem);
                                    MySqlDataAdapter ad = new MySqlDataAdapter(cmd2);
                                    DataTable table = new DataTable();
                                    ad.Fill(table);
                                    dataGridView1.DataSource = table;
                                }
                                c2.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Data is not inserted");
                        }
                        c.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please fill all fields!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
