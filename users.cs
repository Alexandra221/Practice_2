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
    public partial class users : Form
    {
        public users()
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
                    MySqlCommand command = new MySqlCommand("insert into client(id, surname, name, patronymic, date, section, phone, mail)" +
                    " values (@id, @surname, @name, @patronymic, @date, @section, @phone, @mail)")
                    {
                        Connection = con//команда для заполнения
                    };

                    command.Parameters.AddWithValue("id", textBox1.Text);
                    command.ExecuteNonQuery();//выполнение команды
                    users_Load(sender, e);

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


        private void users_Load(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection
            {
                ConnectionString = @"server = 127.0.0.1; userid = root; password = 1984; database = air; port=3306"
            }; // connection для настройки подключения к БД
            DataSet ds = new DataSet();


            MySqlDataAdapter ad = new MySqlDataAdapter("Select id as Data, countryid as Login_time, iatacode as Logout_time, name as Time_spent_of_system, countries_id as Crash_reason from airports", con);// параметры- команда для выполнения + connection
            ad.Fill(ds, "Table"); // заполнение DataSet данными из БД
            dataGridView1.DataSource = ds.Tables[0];
            //Log.Logger("Открытие формы");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                try
                {
                    string connectionString = @"Data Source = localhost; Initial Catalog = air1; User Id = root; Password = 1984; Integrated Security = True";

                    using (MySqlConnection mySqlCon = new MySqlConnection(connectionString))
                    {

                        var select = $"Select id as Data, countryid as Login_time, iatacode as Logout_time, name as Time_spent_of_system, countries_id as Crash_reason from airports  WHERE data = '{textBox1.Text}'";

                        var c = new MySqlConnection(connectionString);
                        var dataAdapter = new MySqlDataAdapter(select, c);
                        var commandBuilder = new MySqlCommandBuilder(dataAdapter);
                        var ds = new DataSet();
                        dataAdapter.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];

                    }
                }
                catch (MySqlException)
                {
                    MessageBox.Show("Вознилка ошибка при просмотре базы данных");
                }
            }
        }
    }
}
