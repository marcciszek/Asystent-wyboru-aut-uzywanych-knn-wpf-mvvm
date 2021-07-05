using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace Asystent_wyboru_aut_uzywanych.DAL.Repozytoria
{
    class RepozytoriumAuta
    {
        #region ZAPYTANIA
        private const string DODAJ_AUTO = "INSERT INTO `cars_linguistic`(`body_type`, `gearbox_type`, `model`, `fuel_type`, `brand`, `repaired`) VALUES";
        #endregion


        public static bool DodajAuto()
        {
            bool stan = false;
            using (var connection = DBConnection.Instance.Connection)
            {

                MySqlCommand command = new MySqlCommand($"{DODAJ_AUTO} {"('kombi', 'manual', 'mondeo', 'diesel', 'ford', 'no')"}", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                stan = true;
                connection.Close();
            }
            return stan;
        }
    }
}
