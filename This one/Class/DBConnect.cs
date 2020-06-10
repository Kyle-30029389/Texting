using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

namespace TextingApp
{
    class DBConnect
    {
        private MySqlConnection connection;

        //Constructor
        public DBConnect()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            string connectionString;
            connectionString = "SERVER=" + "fogartyy.co.nz" + ";" + "DATABASE=" +
            "texting" + ";" + "UID=" + "texting" + ";" + "PASSWORD=" + "4jaddArS9Frh6WKL" + ";";

            connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        //MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        //MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                //MessageBox.Show(ex.Message);
                return false;
            }
        }


        static string ComputeSha256Hash(string rawData, string salt)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(salt + rawData));

                // Convert byte array to a string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        static string ComputeSalt(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        //Insert statement
        public void InsertUserData(RegisterClass reg)
        {
            Random rand = new Random();
            int num = rand.Next();
            string salty = num.ToString();
            string salt = ComputeSalt(salty);
            string userpassword = ComputeSha256Hash(reg.Password, salt);
            string query = $"INSERT INTO userdata (name, username, email, age, hash, salt) VALUES('{reg.Name}', '{reg.Username}', '{reg.Email}', '{reg.Age}', '{userpassword}', '{salt}')";

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        public void MakePost(string message)
        {

            string query = $"INSERT INTO message_data (author, message) VALUES('{App.Id}', '{message}')";
            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        public List<PostStructure> DisplayPost()
        {
            string query = "SELECT message_data.author, userdata.username, message_data.message, message_data.time FROM message_data LEFT JOIN userdata ON message_data.author = userdata.Id; ";

            //Create a list to store the result
            List<PostStructure> list = new List<PostStructure>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    list.Add(new PostStructure() { UserName = $"{dataReader["username"]}", Message = $"{dataReader["message"]}", Time = $"{dataReader["time"]}" });
                }


                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                return list;
            }
        }


        public List<string> Login(LoginClass log)
        {
            List<string> error = new List<string>();
            string query = $"SELECT * FROM userdata WHERE username = '{log.Username}' ";
            string hash;
            string Id;
            string salt;

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.HasRows == true)
                {
                    dataReader.Read();
                    hash = Convert.ToString(dataReader["hash"]);
                    Id = Convert.ToString(dataReader["id"]);
                    salt = Convert.ToString(dataReader["salt"]);
                    dataReader.Close();   //do operation.
                                          //close Connection
                    this.CloseConnection();
                    string EnteredPassword = ComputeSha256Hash(log.Password, salt);
                    if (EnteredPassword == hash)
                    {
                        App.Id = Id;
                        App.username = log.Username;
                        return error;

                    }
                    else
                    {
                        error.Add("Invalid Password");
                        return error;
                    }
                }
                else
                {
                    this.CloseConnection();
                    error.Add("Invalid Username");
                    return error;
                }
            }
            else
            {
                this.CloseConnection();
                error.Add("Cannot connect to servers");
                return error;
            }


        }

        //Update statement
        public void Update()
        {

            string query = "UPDATE tableinfo SET name='Joe', age='22' WHERE name='John Smith'";

            //Open connection
            if (this.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Delete statement
        public void Delete()
        {
            string query = "DELETE FROM tableinfo WHERE name='John Smith'";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }



        //Count statement
        public int Count()
        {
            string query = "SELECT Count(*) FROM tableinfo";
            int Count = -1;

            //Open Connection
            if (this.OpenConnection() == true)
            {
                //Create Mysql Command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //ExecuteScalar will return one value
                Count = int.Parse(cmd.ExecuteScalar() + "");

                //close Connection
                this.CloseConnection();

                return Count;
            }
            else
            {
                return Count;
            }
        }

        
    }

    class PostStructure
    {
        public string UserName { get; set; }
        public string Message { get; set; }
        public string Time { get; set; }
    }
}
