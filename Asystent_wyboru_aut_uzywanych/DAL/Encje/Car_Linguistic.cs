using System;
using System.Collections.Generic;
using System.Text;

namespace Asystent_wyboru_aut_uzywanych.DAL.Encje
{
    class Car_Linguistic
    {
        #region Parametry
        public string vehicle_type { get; set; }
        public string gearbox_type { get; set; }
        public string fuel_type { get; set; }
        public string brand { get; set; }
        public string model { get; set; }
        public string damage { get; set; }

        #endregion

        #region Konstruktory
        public Car_Linguistic(string vehicle_type, string gearbox_type, string fuel_type, string brand, string model, string damage)
        {
            this.vehicle_type = vehicle_type;
            this.gearbox_type = gearbox_type;
            this.fuel_type = fuel_type;
            this.brand = brand;
            this.model = model;
            this.damage = damage;
        }
        #endregion

        #region Metody
        public string Insert_To_Database()
        {
            return $"('{this.vehicle_type}', '{this.gearbox_type}', '{this.model}', '{this.fuel_type}', '{this.brand}', '{this.damage}')";
        }
        #endregion
    }
}
