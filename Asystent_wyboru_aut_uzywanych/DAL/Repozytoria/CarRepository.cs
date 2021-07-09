using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace Asystent_wyboru_aut_uzywanych.DAL.Repozytoria
{
    using DAL.Encje;
    using System.Windows;

    //Repozytorium dla laczenych rekordow Car_Ling i Car_Num
    //-> Spina te rekordy po id w calosc, w celu wyswietlania dostepynch aut
    class CarRepository
    {
        /*SELECT cars.ID_car, cars_linguistic.brand, cars_linguistic.model,
        cars_linguistic.body_type, cars_linguistic.fuel_type, cars_numerical.year_of_production,
        cars_numerical.price, cars_numerical.power, cars_numerical.mileage,
        cars_linguistic.gearbox_type, cars_linguistic.repaired
        FROM cars_numerical, cars_linguistic, cars
        WHERE cars.ID_car_lin = cars_linguistic.id_car_lin
        AND cars.ID_car_num = cars_linguistic.ID_car_lin;*/
        #region ZAPYTANIA
        #region ZAPYTANIA DO SELECT
        private const string SELECT_FIRST_CARS = "SELECT cars.ID_car, cars_linguistic.brand, cars_linguistic.model,";
        private const string SELECT_SECOND_LINE = "cars_linguistic.body_type, cars_linguistic.fuel_type, cars_numerical.year_of_production,";
        private const string SELECT_THIRD_LINE = "cars_numerical.price, cars_numerical.power, cars_numerical.mileage,";
        private const string SELECT_FOURTH_LINE = "cars_linguistic.gearbox_type, cars_linguistic.repaired";
        private const string SELECT_CONDITION = "FROM cars_numerical, cars_linguistic, cars WHERE cars.ID_car_lin = cars_linguistic.id_car_lin";
        private const string SELECT_CONDITION_SECOND_LINE = "AND cars.ID_car_num = cars_numerical.ID_car_num;";
        private const string SELECT_CONDITION_SECOND_LINE_WITHOUT_END = "AND cars.ID_car_num = cars_numerical.ID_car_num";
        //Polaczone zapytanie
        private static string SELECT_ALL_CARS_DATA = $"{SELECT_FIRST_CARS} {SELECT_SECOND_LINE} {SELECT_THIRD_LINE} {SELECT_FOURTH_LINE} {SELECT_CONDITION} {SELECT_CONDITION_SECOND_LINE}";
        private static string SELECT_CARS_DATA = $"{SELECT_FIRST_CARS} {SELECT_SECOND_LINE} {SELECT_THIRD_LINE} {SELECT_FOURTH_LINE} {SELECT_CONDITION} {SELECT_CONDITION_SECOND_LINE_WITHOUT_END}";
        #endregion
        #region ZAPYTANIA DO DELETE
        private static string SELECT_ID_NUM = "SELECT cars.ID_car_num FROM cars WHERE cars.ID_car = ";
        private static string SELECT_ID_LIN = "SELECT cars.ID_car_lin FROM cars WHERE cars.ID_car = ";
        private static string SELECT_COUNT_LIN = "SELECT count(*) FROM cars WHERE ID_car_lin = ";
        //Zapytanie DELETE
        private static string DELETE_LIN = "DELETE FROM cars_linguistic WHERE ID_car_lin = ";
        private static string DELETE_NUM = "DELETE FROM cars_numerical WHERE ID_car_num = ";
        private static string DELETE_CAR = "DELETE FROM cars WHERE ID_car = ";
        #endregion
        #endregion

        public static List<Car> Get_all_cars()
        {
            List<Car> cars = new List<Car>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command_get_all_cars = new MySqlCommand(SELECT_ALL_CARS_DATA, connection);
                try
                {
                    connection.Open();
                    var reader = command_get_all_cars.ExecuteReader();
                    while (reader.Read())
                    {
                        cars.Add(new Car(reader));
                    };
                    connection.Close();
                }
                catch (Exception)
                {
                }
            }
            return cars;
        }

        public static List<Car> Search_For_Cars(Car_Linguistic car_lin)
        {
            List<Car> cars = new List<Car>();
            using(var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command_get_specific_cars = new MySqlCommand($"{SELECT_CARS_DATA} {car_lin.Select_In_Database_List()}", connection);
                try
                {
                    connection.Open();
                    var reader = command_get_specific_cars.ExecuteReader();
                    while (reader.Read())
                    {
                        cars.Add(new Car(reader));
                    };
                    connection.Close();
                }
                catch (Exception)
                {
                }
            }
            return cars;
        }

        public static bool Remove_Car(Car car)
        {
            int id_car_ling = 0, id_car_num = 0, number_of_lin_records = 0;
            using (var connection = DBConnection.Instance.Connection)
            {
                //Pobranie ID numerycznego i lingiwstycznego
                MySqlCommand command_num = new MySqlCommand($"{SELECT_ID_NUM} {car.ID}", connection);
                MySqlCommand command_lin = new MySqlCommand($"{SELECT_ID_LIN} {car.ID}", connection);
                try
                {
                    connection.Open();
                    id_car_ling = Convert.ToInt32(command_lin.ExecuteScalar());
                    id_car_num = Convert.ToInt32(command_num.ExecuteScalar());
                    connection.Close();
                }
                catch (Exception)
                {
                    return false;
                }
                //Sprawdzenie ile aut uzywa tej samej wartosci lingwistycznej
                MySqlCommand command_check_lin = new MySqlCommand($"{SELECT_COUNT_LIN} {id_car_ling}", connection);
                try
                {
                    connection.Open();
                    number_of_lin_records = Convert.ToInt32(command_check_lin.ExecuteScalar());
                    connection.Close();
                }
                catch (Exception)
                {
                    return false;
                }

                if (id_car_num != 0 && id_car_ling != 0 && number_of_lin_records == 1)
                {
                    MySqlCommand command_delete_car = new MySqlCommand($"{DELETE_CAR} {car.ID}", connection);
                    MySqlCommand command_delete_num = new MySqlCommand($"{DELETE_NUM} {id_car_num}", connection);
                    MySqlCommand command_delete_lin = new MySqlCommand($"{DELETE_LIN} {id_car_ling}", connection);
                    try
                    {
                        connection.Open();
                        command_delete_car.ExecuteNonQuery();
                        command_delete_num.ExecuteNonQuery();
                        command_delete_lin.ExecuteNonQuery();
                        connection.Close();
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
                else if( id_car_num != 0 && id_car_ling != 0 && number_of_lin_records > 1)
                {
                    MySqlCommand command_delete_car = new MySqlCommand($"{DELETE_CAR} {car.ID}", connection);
                    MySqlCommand command_delete_num = new MySqlCommand($"{DELETE_NUM} {id_car_num}", connection);
                    try
                    {
                        connection.Open();
                        command_delete_car.ExecuteNonQuery();
                        command_delete_num.ExecuteNonQuery();
                        connection.Close();
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
