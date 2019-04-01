using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace STUDENT_CLEANING_RECORD
{
    public partial class Form1 : Form
    {
        private string server;
        private string database;
        private string uid;
        private string password;
        MySqlConnection connection;
        public Form1()
        {
            InitializeComponent();
            server = "localhost";
            database = "studentrecord";
            uid = "root";
            password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnStudentList_Click(object sender, EventArgs e)
        {
            Form form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT * FROM studentRegistral";
                //Open connection
                connection.Close();
                connection.Open();
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                txtLastname.Enabled = true;
                txtFirstname.Enabled = true;
                txtMiddlename.Enabled = true;
                txtYearSect.Enabled = true;
                while (dataReader.Read())
                {
                    if(txtId.Text == dataReader["id"].ToString())
                    {
                        MessageBox.Show("Student is already registered in database.");
                        txtLastname.Enabled = false;
                        txtFirstname.Enabled = false;
                        txtMiddlename.Enabled = false;
                        txtYearSect.Enabled = false;
                        break;
                    }
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                connection.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtId.Text != "" && txtLastname.Text != "" && txtFirstname.Text != "" && txtMiddlename.Text != "" && txtYearSect.Text != ""  && txtHour.Text != "")
                {
                    string query = "INSERT INTO studentRegistral (id,lastname,firstname,middlename,yearsection, requiredHour) values ('" + txtId.Text + "','" + txtLastname.Text + "','" + txtFirstname.Text + "','" + txtMiddlename.Text + "','" + txtYearSect.Text + "','"+txtHour.Text+"')";
                    //Open connection
                    connection.Close();
                    connection.Open();
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    //Confirms data in the field
                    if (MessageBox.Show("Is ID number correct?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        //Create a data reader and Execute the command
                        cmd.ExecuteReader();
                        MessageBox.Show("Student was successfully added to database.");
                        txtLastname.Text = "";
                        txtFirstname.Text = "";
                        txtMiddlename.Text = "";
                        txtYearSect.Text = "";
                        txtId.Text = "";
                    }
                    //close Connection
                    connection.Close();
                }
                else
                {
                    MessageBox.Show("Please fill all fields to processed.");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form form3 = new Form3();
            form3.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtHour_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtYearSect_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMiddlename_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFirstname_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLastname_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
