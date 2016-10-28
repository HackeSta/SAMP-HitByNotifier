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
        #region Lists
        private static List<string> messages;
        private static List<string> weapon_names;
        private static List<int> weapon_ids;
        private static List<string> setting_name;
        private static List<string> setting_values;
        #endregion
        private static string dbFullPath = Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.LocalApplicationData), "SAMP-HitByNotifier");
        private static string dbName = "database.db";
        private static string color, interval;
        public static void Initalise()  //Gets and stores all data from the database
        {
            messages = new List<string>();
            weapon_names = new List<string>();
            weapon_ids = new List<int>();
            setting_name = new List<string>();
            setting_values = new List<string>();
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
            reader.Close();
            dbConnection.Close();
           
            dbConnection.Dispose();
            dbCommand.Dispose();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if(Convert.ToInt32(setting_values[0]) < Convert.ToInt32(Properties.Resources.version_number))
            {
                DumpDatabase(true);
            }
            color = setting_values[1];
            interval = setting_values[2];
        }
        private static void DumpDatabase(bool overwrite = false)
        {
            if (!Directory.Exists(dbFullPath)) Directory.CreateDirectory(dbFullPath);
            if (!File.Exists(Path.Combine(dbFullPath, dbName))) File.WriteAllBytes(Path.Combine(dbFullPath, dbName), Properties.Resources.database);
            if (overwrite)
            {
                
                File.Delete(Path.Combine(dbFullPath, dbName));
                File.WriteAllBytes(Path.Combine(dbFullPath, dbName), Properties.Resources.database);
                Initalise();
            }
        }

     
        public static string GetMessage(int weapon_id)  //Returns the message for a gun hit
        {
            string message = messages[weapon_ids.IndexOf(weapon_id)];
            return message;

        }

        public static string Color
        {
            get
            {
                return setting_values[1];
            }
            set
            {
                color = value;
            }

        }

        public static int Interval
        {
            get
            {
                return Convert.ToInt32(setting_values[2]);
            }
            set
            {
                interval = value.ToString();
            }
        }

            

        public static void Close()
        {
            dbConnection = new SQLiteConnection("Data Source=" + Path.Combine(dbFullPath, dbName) + ";Version=3;");
            dbConnection.Open();
            dbCommand = dbConnection.CreateCommand();
            string command = "Update settings set val = '" + color + "' where name = 'color'";
            dbCommand.CommandText = command;
            dbCommand.ExecuteNonQuery();
            dbCommand.Reset();
            command = "Update settings set val = '" + interval + "' where name = 'interval'";
            dbCommand.CommandText = command;
            dbCommand.ExecuteNonQuery();
            dbConnection.Close();
            dbCommand.Dispose();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }




    }
}
