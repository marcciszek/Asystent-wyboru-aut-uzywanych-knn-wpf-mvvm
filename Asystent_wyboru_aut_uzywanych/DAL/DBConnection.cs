using System;
using System.Collections.Generic;
using System.Security;
using System.Text;
using MySql.Data.MySqlClient;
using System.Net;

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


        public MySqlConnection Connection_pwd(SecureString password)
        {
            string passwd = new NetworkCredential("", password).Password;
            stringBuilder.Password = passwd;
            return new MySqlConnection(stringBuilder.ToString());
        }

        public MySqlConnection Connection_login(SecureString password, string login)
        {
            string passwd = new NetworkCredential("", password).Password;
            stringBuilder.Password = passwd;
            stringBuilder.UserID = login;
            return new MySqlConnection(stringBuilder.ToString());
        }

        
        private DBConnection()
        {
            stringBuilder.UserID = Properties.Settings.Default.userID;
            stringBuilder.Server = Properties.Settings.Default.server;
            stringBuilder.Database = Properties.Settings.Default.database;
            stringBuilder.Port = Properties.Settings.Default.port;
            stringBuilder.Password = Properties.Settings.Default.paswd;
        }
        public void change_pwd(string passwd)
        {
            stringBuilder.Password = passwd;
        }
        public void change_login(string login)
        {
            stringBuilder.Password = login;
        }
    }
}
