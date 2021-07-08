using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asystent_wyboru_aut_uzywanych.DAL.Encje
{
    public class Car
    {
        public int ID { get; set; }
        public int Price { get; set; }
        public int Power { get; set; }
        public int Mileage { get; set; }
        public int Age { get; set; }
        public string vehicle_type { get; set; }
        public string gearbox_type { get; set; }
        public string fuel_type { get; set; }
        public string brand { get; set; }
        public string model { get; set; }
        public string damage { get; set; }

        public Car(int ID, int Price, int Power, int Mileage, int Age, string vehicle_type, string gearbox_type, string fuel_type, string brand, string model, string damage)
        {
            this.ID = ID;
            this.Price = Price;
            this.Power = Power;
            this.Mileage = Mileage;
            this.Age = Age;
            this.vehicle_type = vehicle_type;
            this.gearbox_type = gearbox_type;
            this.fuel_type = fuel_type;
            this.brand = brand;
            this.model = model;
            this.damage = damage;
        }
        public Car(MySqlDataReader reader)
        {
            this.ID = int.Parse(reader[0].ToString());
            this.Price = int.Parse(reader[6].ToString());
            this.Power = int.Parse(reader[7].ToString());
            this.Mileage = int.Parse(reader[8].ToString());
            this.Age = int.Parse(reader[5].ToString());
            this.vehicle_type = reader[3].ToString();
            this.gearbox_type = reader[9].ToString();
            this.fuel_type = reader[4].ToString();
            this.brand = reader[1].ToString();
            this.model = reader[2].ToString();
            this.damage = reader[10].ToString();
        }
    }
}
