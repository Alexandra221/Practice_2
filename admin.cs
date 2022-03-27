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
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e) //кнопка добавления данных
        {
            {
                try //проверка на корректность данных
                {
                    MySqlConnection con = new MySqlConnection(@"server = 127.0.0.1; userid = root; password = 1984; database = air1; port=3306"); //соединение с бд
                    con.Open();//соединение с бд
                    MySqlCommand command = new MySqlCommand("insert into schedules(id, date, time, aircraftid, routeid, flightnumberection, economyprice, confirmed)" +
                    " values (@id, @date, @time, @aircraftid, @routeid, @flightnumberection, @economyprice, @confirmed)")
                    {
                        Connection = con//команда для заполнения
                    };

                    command.Parameters.AddWithValue("id", textBox2.Text);
                    command.Parameters.AddWithValue("date", textBox3.Text);
                    command.Parameters.AddWithValue("time", textBox4.Text);
                    command.Parameters.AddWithValue("aircraftid", textBox5.Text);
                    command.Parameters.AddWithValue("routeid", textBox6.Text);
                    command.Parameters.AddWithValue("flightnumber", textBox7.Text);
                    command.Parameters.AddWithValue("economyprice", textBox8.Text);
                    command.Parameters.AddWithValue("confirmed", textBox9.Text);
                    command.ExecuteNonQuery();//выполнение команды
                    admin_Load(sender, e);

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

        private void admin_Load(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection
            {
                ConnectionString = @"server = 127.0.0.1; userid = root; password = 1984; database = air1; port=3306"
            }; // connection для настройки подключения к БД
            DataSet ds = new DataSet();


            MySqlDataAdapter ad = new MySqlDataAdapter("Select id as id, date as date, time as time, aircraftid as aircraftid, routeid as routeid, flightnumber as flightnumber, economyprice as economyprice, confirmed as confirmed from schedules ", con);// параметры- команда для выполнения + connection
            ad.Fill(ds, "Table"); // заполнение DataSet данными из БД
            dataGridView1.DataSource = ds.Tables[0];
            //Log.Logger("Открытие формы");
        }

        private void button4_Click(object sender, EventArgs e)// кнопка удаления
        {
            try
            {
                MySqlConnection con = new MySqlConnection(@"server = 127.0.0.1; userid = root; password = 1984; database = air1; port=3306");
                con.Open();//соединение с бд
                MySqlCommand command = new MySqlCommand("delete from admin where id = @delet")
                {
                    Connection = con//команда для заполнения
                };
                command.Parameters.AddWithValue("delet", textBox11.Text);
                command.ExecuteNonQuery();//
                admin_Load(sender, e);
            }
            catch (MySqlException)
            {
                MessageBox.Show("Некорректные данные");
            }
        }

        private void button2_Click(object sender, EventArgs e) //поиск данных
        {
            for (int i = 0; i < dataGridView1.RowCount; i++) //пербор строк в dataGridView1
            {
                dataGridView1.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                        if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(textBox1.Text)) //возвращает значение, записанное в текстовое поле 
                        {
                            dataGridView1.Rows[i].Selected = true;//указывает на выбранную строку
                            break;
                        }
                //Log.Logger("Добавление данных");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) //фильтрация данных по ID
        {
            if (comboBox1.SelectedIndex == 0)
            {
                try
                {
                    string connectionString = @"Data Source = localhost; Initial Catalog = air1; User Id = root; Password = 1984; Integrated Security = True";

                    using (MySqlConnection mySqlCon = new MySqlConnection(connectionString))
                    {

                        var select = $"Select id as id, date as date, time as time, aircraftid as aircraftid, routeid as routeid, flightnumber as flightnumber,economyprice as economyprice, confirmed as confirmed from schedules  WHERE id = '{textBox1.Text}'";

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

            if (comboBox1.SelectedIndex == 1)
            {
                try
                {
                    string connectionString = @"Data Source = localhost; Initial Catalog = air1; User Id = root; Password = 1984; Integrated Security = True";

                    using (MySqlConnection mySqlCon = new MySqlConnection(connectionString))
                    {

                        var select = $"Select id as id, date as date, time as time, aircraftid as aircraftid, routeid as routeid, flightnumber as flightnumber,economyprice as economyprice, confirmed as confirmed from schedules  WHERE id = '{textBox1.Text}'";

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

                if (comboBox1.SelectedIndex == 2)
                {
                    try
                    {
                        string connectionString = @"Data Source = localhost; Initial Catalog = air1; User Id = root; Password = 1984; Integrated Security = True";

                        using (MySqlConnection mySqlCon = new MySqlConnection(connectionString))
                        {

                            var select = $"Select id as id, date as date, time as time, aircraftid as aircraftid, routeid as routeid, flightnumber as flightnumber,economyprice as economyprice, confirmed as confirmed from schedules  WHERE id = '{textBox1.Text}'";

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
}

    

