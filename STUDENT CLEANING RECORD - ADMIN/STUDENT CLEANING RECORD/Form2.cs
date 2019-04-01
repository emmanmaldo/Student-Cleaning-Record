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
    public partial class Form2 : Form
    {
        private string server;
        private string database;
        private string uid;
        private string password;
        MySqlConnection connection;
        public int TotalStudent = 0;
        public static string SetValueForStudentId = ""; 
        public Form2()
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

        private void Form2_Load(object sender, EventArgs e)
        {

            try
            {
                string query = "SELECT * FROM studentRegistral order by lastname, firstname, middlename";
                //Open connection
                connection.Close();
                connection.Open();
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                TotalStudent = 0;
                while (dataReader.Read())
                {
                    TotalStudent++;
                    listBox1.Items.Add(dataReader["id"]);
                    listBox2.Items.Add(dataReader["Lastname"]+", "+dataReader["firstname"]+" "+dataReader["middlename"] );
                    listBox3.Items.Add(dataReader["yearsection"]);
                    string required = "";
                    string rendered = "";
                    if(int.Parse((dataReader["renderedHour"]).ToString()) < 10 )
                    {
                        rendered += "0" + (dataReader["renderedHour"]).ToString()+":";
                    }
                    else
                    {
                        rendered += (dataReader["renderedHour"]).ToString() + ":";

                    }

                    if (int.Parse((dataReader["renderedMin"]).ToString()) < 10)
                    {
                        rendered += "0" + (dataReader["renderedMin"]).ToString() + ":";

                    }
                    else
                    {

                        rendered += (dataReader["renderedMin"]).ToString() + ":";
                    }

                    if (int.Parse((dataReader["renderedSec"]).ToString()) < 10)
                    {
                        rendered += "0" + (dataReader["renderedSec"]).ToString();

                    }
                    else
                    {

                        rendered += (dataReader["renderedSec"]).ToString();
                    }


                    if (int.Parse((dataReader["requiredHour"]).ToString()) < 10)
                    {
                        required += "0" + (dataReader["requiredHour"]).ToString() + ":";

                    }
                    else
                    {

                        required += (dataReader["requiredHour"]).ToString() + ":";
                    }
                    if (int.Parse((dataReader["requiredMin"]).ToString()) < 10)
                    {
                        required += "0" + (dataReader["requiredMin"]).ToString() + ":";

                    }
                    else
                    {

                        required += (dataReader["requiredMin"]).ToString() + ":";
                    }
                    if (int.Parse((dataReader["requiredSec"]).ToString()) < 10)
                    {
                        required += "0" + (dataReader["requiredSec"]).ToString();

                    }
                    else
                    {

                        required += (dataReader["requiredSec"]).ToString() ;
                    }
                    listBox4.Items.Add(rendered);
                    listBox5.Items.Add(required);
                }

                //

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

        private void DataGridView2_NewRowNeeded(object sender, DataGridViewRowEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index =  listBox1.SelectedIndex;
            listBox2.SelectedIndex = index;
            listBox3.SelectedIndex = index;
            listBox4.SelectedIndex = index;
            listBox5.SelectedIndex = index;
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBox3.SelectedIndex;
            listBox2.SelectedIndex = index;
            listBox1.SelectedIndex = index;
            listBox4.SelectedIndex = index;
            listBox5.SelectedIndex = index;

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBox2.SelectedIndex;
            listBox1.SelectedIndex = index;
            listBox3.SelectedIndex = index;
            listBox4.SelectedIndex = index;
            listBox5.SelectedIndex = index;
        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBox4.SelectedIndex;
            listBox2.SelectedIndex = index;
            listBox3.SelectedIndex = index;
            listBox1.SelectedIndex = index;
            listBox5.SelectedIndex = index;

        }

        private void listBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

            int index = listBox5.SelectedIndex;
            listBox2.SelectedIndex = index;
            listBox3.SelectedIndex = index;
            listBox4.SelectedIndex = index;
            listBox1.SelectedIndex = index;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form1 = new Form1();
            form1.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

                clearData();
            try
            {
                string query = "SELECT * FROM studentRegistral WHERE requiredHour <= '0' && requiredMin <= '0' && requiredSec <= '0' order by lastname, firstname, middlename  ";
                //Open connection
                connection.Close();
                connection.Open();
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                int rowIndex = new Int32();
                while (dataReader.Read())
                {
                    listBox1.Items.Add(dataReader["id"]);
                    listBox2.Items.Add(dataReader["Lastname"] + ", " + dataReader["firstname"] + " " + dataReader["middlename"]);
                    listBox3.Items.Add(dataReader["yearsection"]);
                    string required = "";
                    string rendered = "";
                    if (int.Parse((dataReader["renderedHour"]).ToString()) < 10)
                    {
                        rendered += "0" + (dataReader["renderedHour"]).ToString() + ":";
                    }
                    else
                    {
                        rendered += (dataReader["renderedHour"]).ToString() + ":";

                    }

                    if (int.Parse((dataReader["renderedMin"]).ToString()) < 10)
                    {
                        rendered += "0" + (dataReader["renderedMin"]).ToString() + ":";

                    }
                    else
                    {

                        rendered += (dataReader["renderedMin"]).ToString() + ":";
                    }

                    if (int.Parse((dataReader["renderedSec"]).ToString()) < 10)
                    {
                        rendered += "0" + (dataReader["renderedSec"]).ToString();

                    }
                    else
                    {

                        rendered += (dataReader["renderedSec"]).ToString();
                    }


                    if (int.Parse((dataReader["requiredHour"]).ToString()) < 10)
                    {
                        required += "0" + (dataReader["requiredHour"]).ToString() + ":";

                    }
                    else
                    {

                        required += (dataReader["requiredHour"]).ToString() + ":";
                    }
                    if (int.Parse((dataReader["requiredMin"]).ToString()) < 10)
                    {
                        required += "0" + (dataReader["requiredMin"]).ToString() + ":";

                    }
                    else
                    {

                        required += (dataReader["requiredMin"]).ToString() + ":";
                    }
                    if (int.Parse((dataReader["requiredSec"]).ToString()) < 10)
                    {
                        required += "0" + (dataReader["requiredSec"]).ToString();

                    }
                    else
                    {

                        required += (dataReader["requiredSec"]).ToString();
                    }
                    listBox4.Items.Add(rendered);
                    listBox5.Items.Add(required);
                }

                //

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
        public void clearData()
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            listBox5.Items.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                clearData();
                string query = "SELECT * FROM studentRegistral order by lastname, firstname, middlename";
                //Open connection
                connection.Close();
                connection.Open();
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                TotalStudent = 0;
                while (dataReader.Read())
                {
                    TotalStudent++;
                    listBox1.Items.Add(dataReader["id"]);
                    listBox2.Items.Add(dataReader["Lastname"] + ", " + dataReader["firstname"] + " " + dataReader["middlename"]);
                    listBox3.Items.Add(dataReader["yearsection"]);
                    string required = "";
                    string rendered = "";
                    if (int.Parse((dataReader["renderedHour"]).ToString()) < 10)
                    {
                        rendered += "0" + (dataReader["renderedHour"]).ToString() + ":";
                    }
                    else
                    {
                        rendered += (dataReader["renderedHour"]).ToString() + ":";

                    }

                    if (int.Parse((dataReader["renderedMin"]).ToString()) < 10)
                    {
                        rendered += "0" + (dataReader["renderedMin"]).ToString() + ":";

                    }
                    else
                    {

                        rendered += (dataReader["renderedMin"]).ToString() + ":";
                    }

                    if (int.Parse((dataReader["renderedSec"]).ToString()) < 10)
                    {
                        rendered += "0" + (dataReader["renderedSec"]).ToString();

                    }
                    else
                    {

                        rendered += (dataReader["renderedSec"]).ToString();
                    }


                    if (int.Parse((dataReader["requiredHour"]).ToString()) < 10)
                    {
                        required += "0" + (dataReader["requiredHour"]).ToString() + ":";

                    }
                    else
                    {

                        required += (dataReader["requiredHour"]).ToString() + ":";
                    }
                    if (int.Parse((dataReader["requiredMin"]).ToString()) < 10)
                    {
                        required += "0" + (dataReader["requiredMin"]).ToString() + ":";

                    }
                    else
                    {

                        required += (dataReader["requiredMin"]).ToString() + ":";
                    }
                    if (int.Parse((dataReader["requiredSec"]).ToString()) < 10)
                    {
                        required += "0" + (dataReader["requiredSec"]).ToString();

                    }
                    else
                    {

                        required += (dataReader["requiredSec"]).ToString();
                    }
                    listBox4.Items.Add(rendered);
                    listBox5.Items.Add(required);
                }

                //

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

        private void button4_Click(object sender, EventArgs e)
        {
            clearData();
            try
            {
                string query = "SELECT * FROM studentRegistral WHERE requiredHour > '0' || requiredMin >'0' || requiredSec > '0' order by lastname, firstname, middlename  ";
                //Open connection
                connection.Close();
                connection.Open();
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                int rowIndex = new Int32();
                while (dataReader.Read())
                {
                    listBox1.Items.Add(dataReader["id"]);
                    listBox2.Items.Add(dataReader["Lastname"] + ", " + dataReader["firstname"] + " " + dataReader["middlename"]);
                    listBox3.Items.Add(dataReader["yearsection"]);
                    string required = "";
                    string rendered = "";
                    if (int.Parse((dataReader["renderedHour"]).ToString()) < 10)
                    {
                        rendered += "0" + (dataReader["renderedHour"]).ToString() + ":";
                    }
                    else
                    {
                        rendered += (dataReader["renderedHour"]).ToString() + ":";

                    }

                    if (int.Parse((dataReader["renderedMin"]).ToString()) < 10)
                    {
                        rendered += "0" + (dataReader["renderedMin"]).ToString() + ":";

                    }
                    else
                    {

                        rendered += (dataReader["renderedMin"]).ToString() + ":";
                    }

                    if (int.Parse((dataReader["renderedSec"]).ToString()) < 10)
                    {
                        rendered += "0" + (dataReader["renderedSec"]).ToString();

                    }
                    else
                    {

                        rendered += (dataReader["renderedSec"]).ToString();
                    }


                    if (int.Parse((dataReader["requiredHour"]).ToString()) < 10)
                    {
                        required += "0" + (dataReader["requiredHour"]).ToString() + ":";

                    }
                    else
                    {

                        required += (dataReader["requiredHour"]).ToString() + ":";
                    }
                    if (int.Parse((dataReader["requiredMin"]).ToString()) < 10)
                    {
                        required += "0" + (dataReader["requiredMin"]).ToString() + ":";

                    }
                    else
                    {

                        required += (dataReader["requiredMin"]).ToString() + ":";
                    }
                    if (int.Parse((dataReader["requiredSec"]).ToString()) < 10)
                    {
                        required += "0" + (dataReader["requiredSec"]).ToString();

                    }
                    else
                    {

                        required += (dataReader["requiredSec"]).ToString();
                    }
                    listBox4.Items.Add(rendered);
                    listBox5.Items.Add(required);
                }

                //

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

        private void label4_Click(object sender, EventArgs e)
        {
            
        }

        private void btnStudentList_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

            Form form3 = new Form3();
            form3.Show();
            this.Hide();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            string studentId = listBox1.Text.ToString();
            string query3 = "DELETE FROM studentRegistral where id = '" + studentId + "' ";
            string query4 = "DELETE FROM log where id = '" + studentId + "' ";

            connection.Close();
            connection.Open();
            //Create Command
            MySqlCommand cmd3 = new MySqlCommand(query3, connection);
            MySqlCommand cmd4 = new MySqlCommand(query4, connection);
            if (MessageBox.Show("Are you sure to delete this data?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //Create a data reader and Execute the command
                cmd3.ExecuteNonQuery();
                cmd4.ExecuteNonQuery();
                MessageBox.Show("Student profile and all of it's record was deleted successfully.");
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
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            SetValueForStudentId = listBox1.Text.ToString();
            Form formupdate = new update();
            formupdate.Show();
            this.Hide();
        }
    }
}
