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

namespace air
{
    public partial class reg : Form
    {
        public reg()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             {
                  try //проверка на корректность данных
                  {
                      MySqlConnection con = new MySqlConnection(@"server = 127.0.0.1; userid = root; password = 1984; database = air1; port=3306"); //соединение с бд
                      con.Open();//соединение с бд
                      MySqlCommand command = new MySqlCommand("insert into users(email, firstnam, lastname, officeid, birthdate, password)" +
                      " values (@email, @firstnam, @lastname, @officeid, @birthdate, @password)")
                      {
                          Connection = con//команда для заполнения
                      };

                      command.Parameters.AddWithValue("email", textBox1.Text);
                      command.Parameters.AddWithValue("firstnam", textBox2.Text);
                      command.Parameters.AddWithValue("lastname", textBox3.Text);
                      command.Parameters.AddWithValue("officeid", textBox4.Text);
                      command.Parameters.AddWithValue("birthdate", textBox5.Text);
                      command.Parameters.AddWithValue("password", textBox6.Text);
                      command.ExecuteNonQuery();//выполнение команды
                      reg_Load(sender, e);

                  }
                  catch (MySqlException)
            {
                MessageBox.Show("Некорректные данные!");

            }
             catch (MySql.Data.Types.MySqlConversionException)
             {
                 MessageBox.Show("Нет соединения ");

             }
         }
     }


            private void reg_Load(object sender, EventArgs e)
             {

            }
        }
    }

