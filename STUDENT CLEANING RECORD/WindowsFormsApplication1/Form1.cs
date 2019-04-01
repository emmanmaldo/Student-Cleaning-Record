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

namespace WindowsFormsApplication1
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

            int hr= DateTime.Now.Hour;
            int min = DateTime.Now.Minute;
            int sec = DateTime.Now.Second;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int hr = DateTime.Now.Hour;
                int min = DateTime.Now.Minute;
                int sec = DateTime.Now.Second;

                string query1 = "SELECT * FROM LOG WHERE id = '" + txtId.Text + "' and logoutDate = '0000-00-00 00:00:00'";
                //Open connection
                connection.Close();
                connection.Open();
                //Create Command
                MySqlCommand cmd1 = new MySqlCommand(query1, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader1 = cmd1.ExecuteReader();
                Boolean logedIn = false;
                //Read the data and store them in the list
                while (dataReader1.Read())
                {
                    logedIn = true;
                }

                //close Data Reader
                dataReader1.Close();
                if (logedIn == false)
                {
                    string query2 = "INSERT INTO LOG (id, loginHour, logInMin, logInSec) values ('" + txtId.Text + "','" + hr + "','" + min + "','" + sec + "' )";
                    //Open connection
                    connection.Close();
                    connection.Open();
                    //Create Command
                    MySqlCommand cmd2 = new MySqlCommand(query2, connection);
                    cmd2.ExecuteReader();
                    string msg = "";
                    if( hr < 10 ) { msg += "0" + hr +":"; } else { msg += hr+":"; }
                    if( min < 10) { msg += "0" + min+":"; } else { msg += min + ":"; }
                    if (sec < 10) { msg += "0" + sec; } else { msg += sec; }
                    MessageBox.Show("You are officialy loged in. Now go and clean your respectively area.\n Time: "+msg);
                    
                }
                else
                {
                    MessageBox.Show("You already loged in. Please log it out first...");
                }
                //close Connection
                connection.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());

            }
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string query1 = "SELECT * FROM studentRegistral  WHERE ID = '" + txtId.Text + "'";
                //Open connection
                connection.Close();
                connection.Open();
                //Create Command
                MySqlCommand cmd1 = new MySqlCommand(query1, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader1 = cmd1.ExecuteReader();

                //Read the data and store them in the list
                button1.Enabled = false;
                button2.Enabled = false;
                while (dataReader1.Read())
                {
                    if (txtId.Text == dataReader1["id"].ToString())
                    {
                        button1.Enabled = true;
                        button2.Enabled = true;
                    }
                }

                //close Data Reader
                dataReader1.Close();

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
                int hr = DateTime.Now.Hour;
                int min = DateTime.Now.Minute;
                int sec = DateTime.Now.Second;
                string query1 = "SELECT * FROM LOG WHERE id = '"+txtId.Text+ "' and logoutDate = '0000-00-00 00:00:00'";
                //Open connection
                connection.Close();
                connection.Open();
                //Create Command
                MySqlCommand cmd1 = new MySqlCommand(query1, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader1 = cmd1.ExecuteReader();
                int c = 0;
                string no = "0";
                int db_hr = 0;
                int db_min = 0;
                int db_sec = 0;
                //Read the data and store them in the list
                while (dataReader1.Read())
                {
                    c++;
                    no = dataReader1["no"].ToString();
                    db_hr = int.Parse(dataReader1["loginHour"].ToString());
                    db_min = int.Parse(dataReader1["logInMin"].ToString());
                    db_sec = int.Parse(dataReader1["logInSec"].ToString());
                }
                //close Data Reader
                dataReader1.Close();
                if ( no != "0" )
                {
                    //Calculate Date 
                    int diff_hr = hr - db_hr;
                    int diff_min = min - db_min;
                    int diff_sec = sec - db_sec;
                    diff_sec += 60;
                    diff_min -= 1;
                    diff_min += 60;
                    diff_hr -= 1;
                    while (diff_sec >= 60)
                    {
                        diff_min++;
                        diff_sec -= 60;
                    }
                    while (diff_min >= 60)
                    {
                        diff_hr++;
                        diff_min -= 60; 
                    }
                    string query2 = "UPDATE LOG SET LOGOUTDATE = CURRENT_TIMESTAMP , logOutHour = '"+hr+"', logOutMin = '"+min+"', logOutSec = '"+sec+"' , renderedHour = '"+diff_hr+"', renderedMin = '"+ diff_min+"', renderedSec = '"+diff_sec+"' where id = '" + txtId.Text + "' and no = '" + no + "'";
                    MySqlCommand cmd2 = new MySqlCommand(query2, connection);
                    MySqlDataReader dataReader2 = cmd2.ExecuteReader();

                    //close Data Reader
                    dataReader2.Close();

                    string query3 = "SELECT * FROM studentregistral where id = '" + txtId.Text + "'";
                    MySqlCommand cmd3 = new MySqlCommand(query3, connection);
                    MySqlDataReader dataReader3 = cmd3.ExecuteReader();
                    int rqrHr = 0;
                    int rqrMin = 0;
                    int rqrSec = 0;
                    int rndHr = 0;
                    int rndMin = 0;
                    int rndSec = 0;
                    while (dataReader3.Read())
                    {
                        rqrHr = int.Parse(dataReader3["requiredHour"].ToString()) - diff_hr;
                        rqrMin = int.Parse(dataReader3["requiredMin"].ToString()) - diff_min;
                        rqrSec = int.Parse(dataReader3["requiredSec"].ToString()) - diff_sec;


                        rndHr = int.Parse(dataReader3["renderedHour"].ToString()) + diff_hr;
                        rndMin = int.Parse(dataReader3["renderedMin"].ToString()) + diff_min;
                        rndSec = int.Parse(dataReader3["renderedSec"].ToString()) + diff_sec;

                    }
                    //CORRECT THE REQUIRED TIME 
                    if (rqrSec < 0)
                    {
                        rqrSec += 60;
                        rqrMin-= 1;
                    }
                    if( rqrMin < 0)
                    {
                        rqrMin += 60;
                        rqrHr-= 1;
                    }
                    if( rqrHr < 0)
                    {
                        rqrHr += 0;
                    }

                    while(  rndSec >=60)
                    {
                        rndMin++;
                        rndSec -= 60;

                    }
                    while( rndMin >= 60)
                    {
                        rndHr++;
                        rndMin -= 60;

                    }
                    //close Data Reader
                    dataReader3.Close();
                    //UPDATE STUDENT RECORD
                    string query4 = "UPDATE studentRegistral SET requiredHour = '"+rqrHr+"', requiredMin = '"+rqrMin+"', requiredSec = '"+rqrSec+"', renderedHour ='"+rndHr+"', renderedMin = '"+rndMin+"', renderedSec = '"+rndSec+"' where id  ='"+txtId.Text+"'";
                    MySqlCommand cmd4 = new MySqlCommand(query4, connection);
                    MySqlDataReader dataReader4 = cmd4.ExecuteReader();

                    //close Data Reader
                    dataReader4.Close();
                    string msg = " ";
                    string msg2 = " ";
                    if( diff_hr > 0)
                    {
                        msg += diff_min + " hour(s) ,";
                    }
                    if( diff_min > 0)
                    {
                        msg +=diff_min + "minute(s) and";
                    }
                    if( diff_sec > 0)
                    {
                        msg += diff_sec + " seconds";
                    }
                    if( rndHr > 0)
                    {
                        msg2 += rndHr + " hour(s), ";
                    }
                    if( rndMin > 0)
                    {
                        msg2 += rndMin + " minute(s) and ";
                    }
                    if( rndSec > 0)
                    {
                        msg2 += rndSec + " second(s).";
                    }
                    MessageBox.Show("You are successfully loged out.\n \n Worked Time: "+msg+"\n Total Worked Time: "+msg2 );
                }
                else
                {
                    MessageBox.Show("Sorry you can not log out now because you did not loged in");
                }
                //close Connection
                connection.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());

            }
        }
    }
}
