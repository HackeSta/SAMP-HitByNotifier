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
        private static List<string> setting_name = new List<string>();
        private static List<string> setting_values = new List<string>();
        private static string dbFullPath = Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.LocalApplicationData), "SAMP-HitByNotifier");
        private static string dbName = "database.db";
        public static void Initalise()  //Gets and stores all data from the database
        {
            DumpDatabase();
            dbConnection = new SQLiteConnection("Data Source=" + Path.Combine(dbFullPath, dbName) + ";Version=3;");
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
            dbCommand.CommandText = "select * from settings";
            reader = dbCommand.ExecuteReader();
            while(reader.Read())
            {
                setting_name.Add(reader.GetString(1));
                setting_values.Add(reader.GetString(2));
            }
            dbConnection.Close();
        }
        private static void DumpDatabase(bool overwrite = false)
        {
            if (!Directory.Exists(dbFullPath)) Directory.CreateDirectory(dbFullPath);
            if (!File.Exists(Path.Combine(dbFullPath, dbName))) File.WriteAllBytes(Path.Combine(dbFullPath, dbName), Properties.Resources.database);
            else if (overwrite) File.WriteAllBytes(Path.Combine(dbFullPath, dbName), Properties.Re);
        }

     
        public static string GetMessage(int weapon_id)  //Returns the message for a gun hit
        {
            string message = messages[weapon_ids.IndexOf(weapon_id)];
            return message;

        }




    }
}
