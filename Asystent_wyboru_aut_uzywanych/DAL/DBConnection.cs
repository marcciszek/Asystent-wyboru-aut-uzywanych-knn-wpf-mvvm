using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace Asystent_wyboru_aut_uzywanych.DAL
{
    class DBConnection
    {
        private MySqlConnectionStringBuilder stringBuilder = new MySqlConnectionStringBuilder();

        private static DBConnection instance = null;

        public static DBConnection Instance
        {
            get
            {
                if (instance == null)
                    instance = new DBConnection();
                return instance;
            }
        }

        public MySqlConnection Connection => new MySqlConnection(stringBuilder.ToString());

        private DBConnection()
        {
            stringBuilder.UserID = Properties.Settings.Default.userID;
            stringBuilder.Server = Properties.Settings.Default.server;
            stringBuilder.Database = Properties.Settings.Default.database;
            stringBuilder.Port = Properties.Settings.Default.port;
            stringBuilder.Password = Properties.Settings.Default.paswd;
        }
    }
}
