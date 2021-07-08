﻿using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows;
namespace Asystent_wyboru_aut_uzywanych.DAL.Repozytoria
{
    using DAL.Encje;
    class CarsRepository
    {
        #region Zapytania
        private const string ADD_CAR_LING = "INSERT INTO `cars_linguistic`(`body_type`, `gearbox_type`, `model`, `fuel_type`, `brand`, `repaired`) VALUES";
        private const string ADD_CAR_NUM = "INSERT INTO `cars_numerical`(`price`, `power`, `mileage`, `year_of_production`) VALUES";
        private const string ADD_CAR = "INSERT INTO `cars`(`ID_car_lin`, `ID_car_num`) VALUES";
        private const string CHECK_IF_EXIST = "SELECT COUNT(*) FROM `cars_linguistic` WHERE ";
        private const string GET_ID_EXISTING = "SELECT ID_car_lin FROM `cars_linguistic` WHERE ";
        private const string GET_LAST_ID = "SELECT last_insert_id()";
        private const string REMOVE_WHEN_ERROR_LING = "DELETE FROM `cars_linguistic` WHERE ID_car_lin LIKE";
        #endregion

        #region Metody
        public static bool Add_car(Car_Numerical car_num, Car_Linguistic car_lin)
        {
            int id_car_ling, id_car_num;
            int add_numerical_result = 0;
            bool stan = false;
            using (var connection = DBConnection.Instance.Connection)
            {

                //Sprawdzenie czy istnieje juz rekord w cars_linguistic
                if (Check_if_record_exists(car_lin))
                {
                    id_car_ling = Get_Existing_ID(car_lin);
                }
                else
                {
                    //Dodanie rekordu do cars_linguistic
                    MySqlCommand command_ling = new MySqlCommand($"{ADD_CAR_LING} {car_lin.Insert_To_Database()}", connection);
                    MySqlCommand command_ling_get_id = new MySqlCommand(GET_LAST_ID, connection);
                    try
                    {
                        connection.Open();
                        command_ling.ExecuteNonQuery();
                        id_car_ling = Convert.ToInt32(command_ling_get_id.ExecuteScalar());
                        connection.Close();
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
                //Dodanie rekordu do cars_numerical
                MySqlCommand command_num_add = new MySqlCommand($"{ADD_CAR_NUM} {car_num.Insert_To_Database()}", connection);
                MySqlCommand command_num_get_id = new MySqlCommand(GET_LAST_ID, connection);
                try
                {
                    connection.Open();
                    add_numerical_result = Convert.ToInt32(command_num_add.ExecuteNonQuery());
                    id_car_num = Convert.ToInt32(command_num_get_id.ExecuteScalar());
                    connection.Close();
                }
                catch (Exception)
                {
                    MySqlCommand command_remove_when_error_ling = new MySqlCommand($"{REMOVE_WHEN_ERROR_LING} {id_car_ling}");
                    return false;
                }
                //Dodanie laczacego rekordu do cars
                string car_id_num_ling = $"('{id_car_ling}', '{id_car_num}')";
                MySqlCommand command_cars_add = new MySqlCommand($"{ADD_CAR} {car_id_num_ling}", connection);
                try
                {
                    connection.Open();
                    command_cars_add.ExecuteNonQuery();
                    stan = true;
                    connection.Close();
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return stan;
        }



        //Sprawdzenie czy rekord istnieje w bazie
        private static bool Check_if_record_exists(Car_Linguistic car_lin)
        {
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command_check = new MySqlCommand($"{CHECK_IF_EXIST} {car_lin.Select_In_Database()}", connection);
                try
                {
                    connection.Open();
                    int existing_rows = Convert.ToInt32(command_check.ExecuteScalar());
                    connection.Close();
                    if (existing_rows != 0)
                    {
                        return true;
                    }
                    else return false;
                }
                catch (Exception) { return false; }
            }
        }

        //Pobierz ID istniejacego w bazie rekordu
        private static int Get_Existing_ID(Car_Linguistic car_lin)
        {
            using (var connection = DBConnection.Instance.Connection)
            {
                int existing_car_id = 0;
                MySqlCommand command_get_id = new MySqlCommand($"{GET_ID_EXISTING} {car_lin.Select_In_Database()}", connection);
                try
                {
                    connection.Open();
                    existing_car_id = Convert.ToInt32(command_get_id.ExecuteScalar());
                    connection.Close();
                }
                catch (Exception)
                {
                    existing_car_id = 0;
                }
                return existing_car_id;
            }
        }
        #endregion
    }
}
