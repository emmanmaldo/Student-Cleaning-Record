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
    public partial class Form3 : Form
    {
        private string server;
        private string database;
        private string uid;
        private string password;
        MySqlConnection connection;
        public int TotalStudent = 0;
        public Form3()
        {
            InitializeComponent();
            server = "localhost";
            database = "studentrecord";
            uid = "root";
            password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            button2.Enabled = false;
            txtName.Enabled = true;
            txtYrSect.Enabled = true;

            connection = new MySqlConnection(connectionString);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Form form1 = new Form1();
            form1.Show();
            this.Close();
        }

        private void btnStudentList_Click(object sender, EventArgs e)
        {

            Form form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string studentId = txtId.Text.ToString();
                clearData();
                string query1 = "SELECT * FROM studentRegistral where id = '" + studentId + "' ";
                string query2 = "SELECT * FROM LOG where id = '" + studentId + "' order by no desc ";
                //Open connection
                connection.Close();
                connection.Open();
                //Create Command
                MySqlCommand cmd1 = new MySqlCommand(query1, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader1 = cmd1.ExecuteReader();

                //Read the data and store them in the list
                Boolean found = false;
                while (dataReader1.Read())
                {
                    found = true;
                    txtName.Text = dataReader1["lastname"].ToString() + ", " + dataReader1["firstname"].ToString() + " " + dataReader1["middlename"].ToString();
                    txtYrSect.Text = dataReader1["yearSection"].ToString();
                    string rendered = "";
                    string required = "";
                    if( int.Parse(dataReader1["renderedHour"].ToString()) < 10)
                    {
                        rendered += "0" + dataReader1["renderedHour"].ToString()+":";
                    }
                    else
                    {
                        rendered +=  dataReader1["renderedHour"].ToString()+":";
                    }
                    if (int.Parse(dataReader1["renderedMin"].ToString()) < 10)
                    {

                        rendered += "0" + dataReader1["renderedMin"].ToString() + ":";
                    }
                    else
                    {

                        rendered += dataReader1["renderedMin"].ToString() + ":";
                    }
                    if (int.Parse(dataReader1["renderedSec"].ToString()) < 10)
                    {

                        rendered += "0" + dataReader1["renderedSec"].ToString();
                    }
                    else
                    {

                        rendered += dataReader1["renderedSec"].ToString();
                    }
                    if (int.Parse(dataReader1["requiredHour"].ToString()) < 10)
                    {

                        required += "0" + dataReader1["requiredHour"].ToString() + ":";
                    }
                    else
                    {

                        required += dataReader1["requiredHour"].ToString() + ":";
                    }
                    if (int.Parse(dataReader1["requiredMin"].ToString()) < 10)
                    {

                        required += "0" + dataReader1["requiredMin"].ToString() + ":";
                    }
                    else
                    {

                        required += dataReader1["requiredMin"].ToString() + ":";
                    }

                    if (int.Parse(dataReader1["requiredSec"].ToString()) < 10)
                    {

                        required += "0" + dataReader1["requiredSec"].ToString();
                    }
                    else
                    {

                        required += dataReader1["requiredSec"].ToString() ;
                    }
                    txtRendered.Text = rendered;
                    txtRequired.Text = required;
                    
                }
                //close Data Reader
                dataReader1.Close();
                if (found == true)
                {
                    button2.Enabled = true;
                    MySqlCommand cmd2 = new MySqlCommand(query2, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader2 = cmd2.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader2.Read())
                    {
                        string logIn = "";
                        string logOut = "";
                        string TimeRendered = "";
                        if (int.Parse(dataReader2["logInHour"].ToString()) < 10)
                        {
                            logIn += "0" + dataReader2["logInHour"].ToString() + ":";
                        }
                        else {
                            logIn += dataReader2["logInHour"].ToString() + ":";
                        }
                        if (int.Parse(dataReader2["logInMin"].ToString()) < 10)
                        {
                            logIn += "0" + dataReader2["logInMin"].ToString() + ":";
                        }
                        else {
                            logIn += dataReader2["logInMin"].ToString() + ":";
                        }
                        if (int.Parse(dataReader2["logInSec"].ToString()) < 10)
                        {
                            logIn += "0" + dataReader2["logInSec"].ToString();
                        }
                        else {
                            logIn += dataReader2["logInSec"].ToString();
                        }
                        //LOG OUT

                        if (int.Parse(dataReader2["logOutHour"].ToString()) < 10)
                        {
                            logOut += "0" + dataReader2["logOutHour"].ToString() + ":";
                        }
                        else {
                            logOut += dataReader2["logOutHour"].ToString() + ":";
                        }
                        if (int.Parse(dataReader2["logOutMin"].ToString()) < 10)
                        {
                            logOut += "0" + dataReader2["logOutMin"].ToString() + ":";
                        }
                        else {
                            logOut += dataReader2["logOutMin"].ToString() + ":";
                        }
                        if (int.Parse(dataReader2["logOutSec"].ToString()) < 10)
                        {
                            logOut += "0" + dataReader2["logOutSec"].ToString();
                        }
                        else {
                            logOut += dataReader2["logOutSec"].ToString();
                        }
                        //LOG OUT

                        if (int.Parse(dataReader2["renderedHour"].ToString()) < 10)
                        {
                            TimeRendered += "0" + dataReader2["renderedHour"].ToString() + ":";
                        }
                        else {
                            TimeRendered += dataReader2["renderedHour"].ToString() + ":";
                        }
                        if (int.Parse(dataReader2["renderedMin"].ToString()) < 10)
                        {
                            TimeRendered += "0" + dataReader2["renderedMin"].ToString() + ":";
                        }
                        else {
                            TimeRendered += dataReader2["renderedMin"].ToString() + ":";
                        }
                        if (int.Parse(dataReader2["renderedSec"].ToString()) < 10)
                        {
                            TimeRendered += "0" + dataReader2["renderedSec"].ToString();
                        }
                        else {
                            TimeRendered += dataReader2["renderedSec"].ToString();
                        }
                        listBox1.Items.Add(logIn); 
                        listBox2.Items.Add(logOut);
                        listBox3.Items.Add(TimeRendered);
                        string date = dataReader2["logInDate"].ToString();
                        date = date.Substring(0, 10);
                        listBox4.Items.Add(date);
                    }
                    //close Data Reader
                    dataReader2.Close();
                }

                //close Connection
                connection.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());

            }
        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBox4.SelectedIndex;
            listBox2.SelectedIndex = index;
            listBox3.SelectedIndex = index;
            listBox1.SelectedIndex = index;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            int index = listBox1.SelectedIndex;
            listBox2.SelectedIndex = index;
            listBox3.SelectedIndex = index;
            listBox4.SelectedIndex = index;
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            int index = listBox2.SelectedIndex;
            listBox1.SelectedIndex = index;
            listBox3.SelectedIndex = index;
            listBox4.SelectedIndex = index;
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

            int index = listBox3.SelectedIndex;
            listBox2.SelectedIndex = index;
            listBox1.SelectedIndex = index;
            listBox4.SelectedIndex = index;
        }

        public void clearData()
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string studentId = txtId.Text.ToString();
            string query3 = "DELETE FROM studentRegistral where id = '" + studentId + "' ";
            string query4 = "DELETE FROM log where id = '" + studentId + "' ";

            connection.Close();
            connection.Open();
            //Create Command
            MySqlCommand cmd3 = new MySqlCommand(query3, connection);
            MySqlCommand cmd4 = new MySqlCommand(query4, connection);
            if (MessageBox.Show("Are you sure to delete data?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //Create a data reader and Execute the command
                cmd3.ExecuteNonQuery();
                cmd4.ExecuteNonQuery();
                clearData1();
                MessageBox.Show("Student profile and all of it's record was deleted successfully.");
            }
        }

        public void clearData1()
        {
            txtId.Clear();
            txtName.Clear();
            txtYrSect.Clear();
            txtRendered.Clear();
            txtRequired.Clear();
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            clearData1();
            button2.Enabled = false;
        }


    }
}
