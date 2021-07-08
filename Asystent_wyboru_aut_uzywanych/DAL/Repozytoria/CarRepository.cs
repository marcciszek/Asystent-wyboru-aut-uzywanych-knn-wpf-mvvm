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
        #region SKLADOWE SELECT
        private const string SELECT_FIRST_CARS = "SELECT cars.ID_car, cars_linguistic.brand, cars_linguistic.model,";
        private const string SELECT_SECOND_LINE = "cars_linguistic.body_type, cars_linguistic.fuel_type, cars_numerical.year_of_production,";
        private const string SELECT_THIRD_LINE = "cars_numerical.price, cars_numerical.power, cars_numerical.mileage,";
        private const string SELECT_FOURTH_LINE = "cars_linguistic.gearbox_type, cars_linguistic.repaired";
        private const string SELECT_CONDITION = "FROM cars_numerical, cars_linguistic, cars WHERE cars.ID_car_lin = cars_linguistic.id_car_lin";
        private const string SELECT_CONDITION_SECOND_LINE = "AND cars.ID_car_num = cars_numerical.ID_car_num;";
        private const string SELECT_CONDITION_SECOND_LINE_WITHOUT_END = "AND cars.ID_car_num = cars_numerical.ID_car_num";
        #endregion
        //Polaczone zapytanie
        private static string SELECT_ALL_CARS_DATA = $"{SELECT_FIRST_CARS} {SELECT_SECOND_LINE} {SELECT_THIRD_LINE} {SELECT_FOURTH_LINE} {SELECT_CONDITION} {SELECT_CONDITION_SECOND_LINE}";
        private static string SELECT_CARS_DATA = $"{SELECT_FIRST_CARS} {SELECT_SECOND_LINE} {SELECT_THIRD_LINE} {SELECT_FOURTH_LINE} {SELECT_CONDITION} {SELECT_CONDITION_SECOND_LINE_WITHOUT_END}";

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
    }
}
