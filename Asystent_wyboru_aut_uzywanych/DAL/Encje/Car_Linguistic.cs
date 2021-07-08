using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

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
        public string Select_In_Database()
        {
            return $"body_type LIKE '{vehicle_type}' AND gearbox_type LIKE '{gearbox_type}' AND model LIKE '{model}' AND brand LIKE '{brand}' AND fuel_type LIKE '{fuel_type}' AND repaired LIKE '{damage}'";
        }
        public string Select_In_Database_List()
        {
            string select_conditions = "";
            if(this.vehicle_type == null && this.gearbox_type == null && this.fuel_type == null && this.damage == null && this.brand == null && this.model == null)
            {
                select_conditions = ";";
            }
            if (this.vehicle_type != null)
            {
                select_conditions+= $" AND cars_linguistic.body_type LIKE '{vehicle_type}'";
            }
            if (this.gearbox_type != null)
            {
                select_conditions += $" AND cars_linguistic.gearbox_type='{gearbox_type}'";
            }
            if (this.fuel_type != null)
            {
                select_conditions += $" AND cars_linguistic.fuel_type LIKE '{fuel_type}'";
            }
            if (this.damage != null)
            {
                select_conditions += $" AND cars_linguistic.repaired LIKE '{damage}'";
            }
            if (this.brand != null)
            {
                select_conditions += $" AND cars_linguistic.brand LIKE '{brand}'";
                if (this.model != null)
                {
                    select_conditions += $" AND cars_linguistic.model LIKE '{model}'";
                }
            }
            select_conditions += ";";
            return select_conditions;
        }
        #endregion
    }
}
