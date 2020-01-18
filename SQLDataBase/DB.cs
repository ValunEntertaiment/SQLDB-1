using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace _112
{
    class DB
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

        public static void Load(ListBox listBox, List<string> id, bool page)
        {
            listBox.Items.Clear();
            id.Clear();
            String query;
            if (page)
            {
                query = "SELECT `FirstName`, `MiddleName`, `LastName`, `id` FROM worldskills.clients";
            }
            else
            {
                query = "SELECT `FirstName`, `MiddleName`, `LastName`, `id` FROM worldskills.agents;";
            }
            MySqlCommand mysql = new MySqlCommand(query,baza);
            mysql.CommandTimeout = 200;
            try
            {
                MySqlDataReader reader = mysql.ExecuteReader();
                while (reader.Read())
                {
                    listBox.Items.Add(reader[0].ToString() + " " + reader[1].ToString() + " " + reader[2].ToString());
                    id.Add(reader[3].ToString());
                }
                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Вызвано исключение " + e.Message + "\nЗапрос " + query);
            }
            
        } //загрузка БД на экран

        public static void input(string qwe)
        {
            MySqlCommand call = new MySqlCommand(qwe, baza);
            try
            {
                call.ExecuteNonQuery();
            }
            catch (Exception e)
            {
               MessageBox.Show("Вызвано исключение "+e.Message+"\nЗапрос "+qwe);
            }
        } //загрузка инфы в БД из csv файла

        public static String[] Select(string id,bool page)
        {
            String query;
            byte n;
            if (page)
            {
                query = String.Format("SELECT `FirstName`,`MiddleName`,`LastName`,`Phone`,`Email` FROM worldskills.clients WHERE id ='{0}'", id);
                n = 5;
            }
            else
            {
                query = String.Format("SELECT `FirstName`,`MiddleName`,`LastName`,`DealShare` FROM worldskills.agents WHERE id ='{0}'", id);
                n = 4;
            }
            String[] x = new string[n];
            MySqlCommand mysql = new MySqlCommand(query, baza);
            mysql.CommandTimeout = 200;
            try
            {
                MySqlDataReader reader = mysql.ExecuteReader();
                reader.Read();
                for (int i = 0; i < n; i++)
                {
                    x[i] = reader[i].ToString();
                }
                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Вызвано исключение " + e.Message + "\nЗапрос " + query);
            }
            return x;
        } //выделение и работа с элементом БД

        public static void UpDate(String[] name,string id,bool page)
        {
            string query;
            if (page)
            {
                query = String.Format("UPDATE `worldskills`.`clients` SET `FirstName` = '{0}', `MiddleName` = '{1}', `LastName` = '{2}', `Phone` = '{3}', `Email` = '{4}' WHERE (`id` = '{5}');", name[0], name[1], name[2], name[3], name[4], id);
            }
            else
            {
                query = String.Format("UPDATE `worldskills`.`agents` SET `FirstName` = '{0}', `MiddleName` = '{1}', `LastName` = '{2}', `DealShare` = '{3}' WHERE (`id` = '{4}');", name[0], name[1], name[2], name[3], id);
            }
            MySqlCommand mysql = new MySqlCommand(query, baza);
            mysql.CommandTimeout = 200;
            try
            {
                mysql.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("Вызвано исключение " + e.Message + "\nЗапрос " + query);
            }
        } //изменение элемента БД

        public static void Delete(string id,bool page)
        {
            string query;
            if (page)
            {
                query = String.Format("DELETE FROM `worldskills`.`clients` WHERE (`id` = '{0}')", id);
            }
            else
            {
                query = String.Format("DELETE FROM `worldskills`.`agents` WHERE (`id` = '{0}')", id);
            }
            MySqlCommand mysql = new MySqlCommand(query, baza);
            mysql.CommandTimeout = 200;
            try
            {
                mysql.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("Вызвано исключение " + e.Message + "\nЗапрос " + query);
            }
        } //Удаление элемента БД

        public static void Create(String[] name, bool page)
        {
            string query;
            if (page)
            {
                query = String.Format("INSERT INTO `worldskills`.`clients` (`id`, `FirstName`, `MiddleName`, `LastName`, `Phone`, `Email`) VALUES('0', '{0}', '{1}', '{2}', '{3}', '{4}');", name[0], name[1], name[2], name[3], name[4]);
            }
            else
            {
                query = String.Format("INSERT INTO `worldskills`.`agents` (`id`, `FirstName`, `MiddleName`, `LastName`, `DealShare`) VALUES('0', '{0}', '{1}', '{2}', '{3}');", name[0], name[1], name[2], name[3]);
            }
            MySqlCommand mysql = new MySqlCommand(query, baza);
            mysql.CommandTimeout = 200;
            try
            {
                mysql.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("Вызвано исключение " + e.Message + "\nЗапрос " + query);
            }
        } //Создание элемента БД

        public static int LevenshteinDistance(string string1, string string2)
        {
            if (string1 == null) throw new ArgumentNullException("string1");
            if (string2 == null) throw new ArgumentNullException("string2");
            int diff;
            int[,] m = new int[string1.Length + 1, string2.Length + 1];

            for (int i = 0; i <= string1.Length; i++) { m[i, 0] = i; }
            for (int j = 0; j <= string2.Length; j++) { m[0, j] = j; }

            for (int i = 1; i <= string1.Length; i++)
            {
                for (int j = 1; j <= string2.Length; j++)
                {
                    diff = (string1[i - 1] == string2[j - 1]) ? 0 : 1;

                    m[i, j] = Math.Min(Math.Min(m[i - 1, j] + 1, 
                                                m[i, j - 1] + 1), 
                                                m[i - 1, j - 1] + diff);
                }
            }
            return m[string1.Length, string2.Length];
        } //организация поисковика
    }
}