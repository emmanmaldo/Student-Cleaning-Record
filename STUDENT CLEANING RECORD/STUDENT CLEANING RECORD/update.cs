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
    public partial class update : Form
    {
        private string server;
        private string database;
        private string uid;
        private string password;
        MySqlConnection connection;
        public update()
        {
            InitializeComponent();
            server = "localhost";
            database = "studentrecord";
            uid = "root";
            password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            textBox5.Enabled = false;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;

            connection = new MySqlConnection(connectionString);

            string studentId = Form2.SetValueForStudentId;
            string query1 = "SELECT * FROM studentRegistral where id = '" + studentId + "' ";

            //Open connection
            connection.Close();
            connection.Open();
            //Create Command
            MySqlCommand cmd1 = new MySqlCommand(query1, connection);
            //and Execute the command
            MySqlDataReader dataReader1 = cmd1.ExecuteReader();

            Boolean found = false;
            while (dataReader1.Read())
            {
                found = true;
                textBox5.Text = dataReader1["id"].ToString();
                textBox1.Text = dataReader1["lastname"].ToString();
                textBox2.Text = dataReader1["firstname"].ToString();
                textBox3.Text = dataReader1["middlename"].ToString();
                textBox4.Text = dataReader1["yearSection"].ToString();
            }
            dataReader1.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
                {
                    string query = "UPDATE studentRegistral SET lastname = '" + textBox1.Text + "', firstname = '" + textBox2.Text + "', middlename = '" + textBox3.Text + "', yearsection = '" + textBox4.Text + "' WHERE id = '" + textBox5.Text + "'";
                    //Open connection
                    connection.Close();
                    connection.Open();
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    //Create a data reader and Execute the command
                    cmd.ExecuteReader();
                    MessageBox.Show("Student profile was updated successfully!");
                    Form form2 = new Form2();
                    Pleasewait pleaseWait = new Pleasewait();

                    // Display form modelessly
                    pleaseWait.Show();

                    //  ALlow main UI thread to properly display please wait form.
                    Application.DoEvents();

                    // Show or load the main form.
                    form2.Show();
                    this.Hide();
                    pleaseWait.Hide();
                    
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form form2 = new Form2();
            Pleasewait pleaseWait = new Pleasewait();

            // Display form modelessly
            pleaseWait.Show();

            //  ALlow main UI thread to properly display please wait form.
            Application.DoEvents();

            // Show or load the main form.
            form2.Show();
            pleaseWait.Hide();

            //close Connection
            connection.Close();
        }

    }
}
