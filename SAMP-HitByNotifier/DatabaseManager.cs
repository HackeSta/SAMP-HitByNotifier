using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

namespace SAMP_HitByNotifier
{
    class DatabaseManager
    {
        public static SQLiteConnection dbConnection;

        private static SQLiteCommand dbCommand;
        private static List<string> messages = new List<string>();
        private static List<string> weapon_names = new List<string>();
        private static List<int> weapon_ids = new List<int>();
        public static void Initalise()  //Gets and stores all data from the database
        {
            DumpDatabase();
            dbConnection = new SQLiteConnection("Data Source=database.db;Version=3;");
            dbConnection.Open();
            dbCommand = dbConnection.CreateCommand();
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
        private static void DumpDatabase()
        {
            var dbFullPath = "database.db";//your path
            //whatever your logic is

            File.WriteAllBytes(dbFullPath, Properties.Resources.database);
        }
        public static string GetMessage(int weapon_id)  //Returns the message for a gun hit
        {
           string message = messages[weapon_ids.IndexOf(weapon_id)];
            return message;

        }

      

    }
}
