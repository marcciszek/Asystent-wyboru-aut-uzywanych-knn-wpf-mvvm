using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace Asystent_wyboru_aut_uzywanych.DAL.Repozytoria
{
    using DAL.Encje;
    using System.Windows;

    class KNNRepository
    {
        #region ZAPYTANIA
        private const string SELECT_MAX_PRICE = "Select Max(Price) FROM Cars_numerical";
        private const string SELECT_MAX_POWER = "Select Max(Power) FROM Cars_numerical";
        private const string SELECT_MAX_MILEAGE = "Select Max(Mileage) FROM Cars_numerical";
        private const string SELECT_MAX_YEAR = "Select Max(year_of_production) FROM Cars_numerical";

        private const string SELECT_MIN_PRICE = "Select Min(Price) FROM Cars_numerical";
        private const string SELECT_MIN_POWER = "Select Min(Power) FROM Cars_numerical";
        private const string SELECT_MIN_MILEAGE = "Select Min(Mileage) FROM Cars_numerical";
        private const string SELECT_MIN_YEAR = "Select Min(year_of_production) FROM Cars_numerical";
        #endregion
        #region METODY
        internal static Car_Numerical Find_Max_Values()
        {
            Car_Numerical car = new Car_Numerical(0, 0, 0, 0);
            int max_price, max_power, max_mileage, max_year;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command_max_price = new MySqlCommand(SELECT_MAX_PRICE, connection);
                MySqlCommand command_max_power = new MySqlCommand(SELECT_MAX_POWER, connection);
                MySqlCommand command_max_mileage = new MySqlCommand(SELECT_MAX_MILEAGE, connection);
                MySqlCommand command_max_year = new MySqlCommand(SELECT_MAX_YEAR, connection);
                try
                {
                    connection.Open();
                    max_price = Convert.ToInt32(command_max_price.ExecuteScalar());
                    max_power = Convert.ToInt32(command_max_power.ExecuteScalar());
                    max_mileage = Convert.ToInt32(command_max_mileage.ExecuteScalar());
                    max_year = Convert.ToInt32(command_max_year.ExecuteScalar());
                    car.Price = max_price;
                    car.Power = max_power;
                    car.Mileage = max_mileage;
                    car.Age = max_year;
                    connection.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("error getting max values");
                }
            }
            return car;
        }

        internal static Car_Numerical Find_Min_Values()
        {
            Car_Numerical car = new Car_Numerical(0, 0, 0, 0);
            int min_price, min_power, min_mileage, min_year;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command_min_price = new MySqlCommand(SELECT_MIN_PRICE, connection);
                MySqlCommand command_min_power = new MySqlCommand(SELECT_MIN_POWER, connection);
                MySqlCommand command_min_mileage = new MySqlCommand(SELECT_MIN_MILEAGE, connection);
                MySqlCommand command_min_year = new MySqlCommand(SELECT_MIN_YEAR, connection);
                try
                {
                    connection.Open();
                    min_price = Convert.ToInt32(command_min_price.ExecuteScalar());
                    min_power = Convert.ToInt32(command_min_power.ExecuteScalar());
                    min_mileage = Convert.ToInt32(command_min_mileage.ExecuteScalar());
                    min_year = Convert.ToInt32(command_min_year.ExecuteScalar());
                    car.Price = min_price;
                    car.Power = min_power;
                    car.Mileage = min_mileage;
                    car.Age = min_year;
                    connection.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("error getting min values");
                }
            }
            return car;
        }
        #endregion
    }
}
