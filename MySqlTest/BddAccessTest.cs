using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MySqlTest
{
    public static class BddAccessTest
    {
        public static int SQLAvecRetourInt(string commande)
        {
            string connectionString =
                @"Server=mysql-allanlerouge.alwaysdata.net;Port=3306;Database=allanlerouge_test;Uid=154607_test;Password=commelesang;CHARSET=utf8;";

            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand command = connection.CreateCommand();
            MySqlDataReader reader;

            string StringID = "";
            int IntegerID;
            try
            {
                connection.Open();
                command.CommandText = commande;
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    StringID = reader[0].ToString();
                }

                Int32.TryParse(StringID, out IntegerID);
                if (IntegerID != -1)
                {
                    connection.Close();
                    return IntegerID;
                }
                connection.Close();
            }
            catch (Exception ex)
            {
            }
            return -1;
        }

        public static string SQLAvecRetourString(string commande)
        {
            string connectionString =
                @"Server=mysql-allanlerouge.alwaysdata.net;Port=3306;Database=allanlerouge_test;Uid=154607_test;Password=commelesang;CHARSET=utf8;";

            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand command = connection.CreateCommand();
            MySqlDataReader reader;

            string result = "fail";
            try
            {
                connection.Open();
                command.CommandText = commande;
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result = reader[0].ToString();
                }

                connection.Close();
            }
            catch (Exception ex)
            {
            }
            return result;
        }

        public static void SQLSansRetour(string commande)
        {
            string connectionString =
                @"Server=mysql-allanlerouge.alwaysdata.net;Port=3306;Database=allanlerouge_test;Uid=154607_test;Password=commelesang;CHARSET=utf8;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand command = connection.CreateCommand();
            try
            {
                connection.Open();
                command.CommandText = commande;
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
            }
            connection.Close();
        }

        public static string TestSimple(int id)
        {
            SQLSansRetour("INSERT INTO table_test (id,data1,data2,data3) VALUES (" + id + ",'data1_" + id + "','data2_" + id + "','data3_" + id + "')");
            int ID = SQLAvecRetourInt("SELECT id FROM table_test WHERE data1='data1_" + id + "'");

            return ID.ToString();
        }

        public static string TestComplet(int id, string data1, string data2, string data3)
        {
            SQLSansRetour("INSERT INTO table_test (id,data1,data2,data3) VALUES (" + id + ", '" + data1 + "', '" + data2 + "', '" + data3 + "')");
            return SQLAvecRetourString("SELECT data1 FROM table_test WHERE id=" + id);
        }
    }
}
