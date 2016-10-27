using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace SAMP_HitByNotifier
{
    class DatabaseManager
    {
        public static SQLiteConnection dbConnection = new SQLiteConnection("Data Source=database.db;Version=3;");

        private static SQLiteCommand dbCommand = dbConnection.CreateCommand();
        private static List<string> messages = new List<string>();
        private static List<string> weapon_names = new List<string>();
        private static List<int> weapon_ids = new List<int>();
        public static void Initalise()  //Gets and stores all data from the database
        {
            dbConnection.Open();
            string command = "select * from Messages";
            dbCommand.CommandText = command;
            SQLiteDataReader reader = dbCommand.ExecuteReader();
            while (reader.Read())
            {
                weapon_ids.Add(reader.GetInt32(1));
                weapon_names.Add(reader.GetString(2));
                messages.Add(reader.GetString(3));
            }
            reader.Close();
            dbConnection.Close();
        }
        public static string GetMessage(int weapon_id)  //Returns the message for a gun hit
        {
           string message = messages[weapon_ids.IndexOf(weapon_id)];
            return message;

        }

      

    }
}
