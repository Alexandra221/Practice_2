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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)

        {

             if (radioButton1.Checked == true) //администратор

              {
                  try //проверка на корректрость данных
                  {

                      MySqlConnection con = new MySqlConnection(@"server = 127.0.0.1; userid = root; password = 1984; database = air1; port=3306");//соединение с бд
                      MySqlDataAdapter users = new MySqlDataAdapter($"Select Count(*) From users Where email= '{textBox1.Text}' and password = '{textBox2.Text}'", con);
                      DataTable dt = new DataTable();
                      users.Fill(dt);


                      if (dt.Rows[0][0].ToString() == "1") //переход на главную форму при выборе авторизации и заполненных полей с логином и паролем
                      {

                          {
                              this.Hide();
                              main2 main2 = new main2();
                              main2.Show();
                          }
                      }

                  }
                  catch (FormatException)//проверка на корректрость данных
                  {
            MessageBox.Show("Некорректные данные!");

            }
             catch (MySqlException)//проверка соединения с бд
             {
                 MessageBox.Show("Возникли неполадки с базой данных");

             }

             if (radioButton2.Checked == true) //пользователь

             {
                 //try //проверка на корректрость данных
                 {

                     MySqlConnection con = new MySqlConnection(@"server = 127.0.0.1; userid = root; password = 1984; database = air1; port=3306");//соединение с бд
                     MySqlDataAdapter users = new MySqlDataAdapter($"Select Count(*) From users Where email= '{textBox1.Text}' and password = '{textBox2.Text}'", con);
                     DataTable dt = new DataTable();
                     users.Fill(dt);


                     if (dt.Rows[0][0].ToString() == "1") //переход на главную форму при выборе авторизации и заполненных полей с логином и паролем
                     {

                         {
                             this.Hide();
                             main2 main2 = new main2();
                             main2.Show();
                         }
                     }

                 }


                 }
         }
     }

     private void button2_Click(object sender, EventArgs e)
     {
         reg reg = new reg();
         reg.ShowDialog(this);
         reg.Dispose();
     }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            users users = new users();
            users.Show();
        }
    }
    }

            
        
        
