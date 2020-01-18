using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace _112.Logining
{
    class Lib
    {
        public static MySqlConnection baza = new MySqlConnection("server=localhost; user=root; password=MySql; database=worldskills"); //подключение к БД


        public static void OB()
        {
            baza.Open();
        } //open base

        public static void OC()
        {
            baza.Close();
        } //close base

        public static void Create(string Login, string Password)
        {
            string query = String.Format("INSERT INTO `worldskills`.`logining` (`id`, `Login`, `Password`) VALUES ('0', '{0}', '{1}');", Login, Password);
            
            MySqlCommand mysql = new MySqlCommand(query, baza);

            //mysql.CommandTimeout = 200;
            try
            {
                mysql.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("Вызвано исключение " + e.Message + "\nЗапрос " + query);
            }
        } //Создание элемента БД
    }
}
