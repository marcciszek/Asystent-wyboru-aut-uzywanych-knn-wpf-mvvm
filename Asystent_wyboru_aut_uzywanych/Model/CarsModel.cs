using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Asystent_wyboru_aut_uzywanych.Model
{
    using DAL.Repozytoria;
    using DAL.Encje;
    class CarsModel
    {
        #region tablice stałych
        //Tablica marek samochodów
        /// <summary>
        ///Najpierw tworzymy statyczna tablice string z modelami danej marki
        ///Nastepnie tworzymy pozycje w slowniku wedlug schematu <string, string[]>
        ///                          gdzie odpowiednio:      nazwa marki, tablica modeli
        /// </summary>
        public static string[] models_alfa = new string[] { "147", "156", "159", "4C", "Brera", "Gulia", "Giulietta", "GT", "MiTo", "Stelvio"};
        public static string[] models_audi = new string[] { "A1", "A2", "A3", "A4", "A5", "A6", "A7", "A8", "R8", "Q2", "Q3", "Q5", "Q7", "Q8", "TT"};
        public static string[] models_bmw = new string[] { "Seria 1", "Seria 2", "Seria 3", "Seria 4", "Seria 5", "Seria 6", "Seria 7", "Seria 8", "X1", "X2", "X3", "X4", "X5", "X6", "X7", "Z3", "Z4", "i3", "i8"};
        public static string[] models_chevrolet = new string[] { "Aveo", "Camaro", "Captiva", "Corvette", "Lacetti", "Malibu", "Spark", "Volt" };
        public static string[] models_citroen = new string[] {"C-Elysee", "C1", "C2", "C3", "C4", "C5", "C6", "C8", "DS3", "DS4", "DS5"};
        public static string[] models_dacia = new string[] { "Duster", "Sandero", "Lodgy", "Logan" };
        public static string[] models_fiat = new string[] { "500", "500L", "500XL", "Brava", "Bravo", "Doblo", "Grande Punto", "Linea", "Punto", "Stilo", "Siena", "Tipo" };
        public static string[] models_ford = new string[] { "B-MAX", "C-MAX", "S-MAX", "Cougar", "Escort", "Fiesta", "Focus", "GT", "Kuga", "Mondeo", "Mustang", "Puma", "Sierra", "Transit"};
        public static string[] models_honda = new string[] { "Accord", "City", "Civic", "CR-V", "CRX", "HR-V", "Integra", "Jazz", "Legend", "NSX", "Prelude", "S2000" };
        public static string[] models_hyundai = new string[] { "Accent", "Coupe", "Elantra", "Getz", "i10", "i20", "i30", "i40", "Ioniq", "ix35", "ix55", "Santa Fe", "Tucson", "Veloster" };
        public static string[] models_jeep = new string[] { "Cherokee", "Gladiator", "Grand Cherokee", "Renegade", "Wrangler" };
        public static string[] models_Kia = new string[] { "Carens", "Ceed", "Cerato", "Magentis", "Niro", "Optima", "Pro ceed", "Rio", "Sorento", "Sportage", "Stringer", "Venga", "Xceed" };
        public static string[] models_Lexus = new string[] { "CT", "ES", "GS", "IS", "LC", "LS", "NX", "RX", "RC-F" };
        public static string[] models_MINI = new string[] { "Cabrio", "Clubman", "Clubvan", "Cooper", "Countryman", "One", "Roadster" };
        public static string[] models_Mazda = new string[] { "3", "5", "6", "CX-3", "CX-30", "CX-5", "CX-7", "MX-3", "MX-5", "MX-6", "Premacy", "RX-7", "RX-8" };
        public static string[] models_Mercedes = new string[] { "Klasa A", "Klasa B", "Klasa C", "Klasa E", "Klasa G", "Klasa S", "Klasa GLA", "Klasa GLC", "Klasa GLE", "Viano", "Vito", "AMG GT" };
        public static string[] models_Mitsubishi = new string[] { "3000GT", "ASX", "Carisma", "Colt", "Eclipse", "Galant", "Lancer", "Outlander", "Pajero", "Space star" };
        public static string[] models_Nissan = new string[] { "200SX", "350Z", "370Z", "Almera", "Altima", "GT-R", "Juke", "Leaf", "Micra", "Note", "Prairie", "Primera", "Qashqai", "Skyline", "Rogue" };
        public static string[] models_Opel = new string[] { "Adam", "Ampera", "Antara", "Astra", "Calibra", "Combo", "Corsa", "CrossLand", "Grandland X", "Insignia", "Kadett", "Karl", "Meriva", "Mokka", "Omega", "Signum", "Vectra", "Vivaro", "Zafira" };
        public static string[] models_Peugeot = new string[] { "107", "2008", "206", "207", "208", "3008", "307", "308", "4007", "406", "407", "5008", "508", "605", "607", "807", "RCZ" };
        public static string[] models_Renault = new string[] { "Avantime", "Captur", "Clio", "Ellypse", "Espace", "Fluence", "Grand Espace", "Kadjar", "Koleos", "Laguna", "Megana", "Scenic", "Talisman", "Thalia", "Twingo", "Zoe" };
        public static string[] models_SEAT = new string[] { "Altea", "Ateca", "Cordoba", "Exeo", "Ibiza", "Leon", "Toledo" };
        public static string[] models_Skoda = new string[] { "Citigo", "Fabia", "Felicia", "Kamiq", "Karoq", "Kodiaq", "Octavia", "Rapid", "Roomster", "Scala", "Superb", "Yeti" };
        public static string[] models_Subaru = new string[] { "BRZ", "Forester", "Impreza", "Legacy", "XV" };
        public static string[] models_Suzuki = new string[] { "Alto", "Baleno", "Grand Vitara", "Jimmy", "Splash", "Switf", "SX4", "Vitara" };
        public static string[] models_Toyota = new string[] { "Aurir", "Avensis", "Aygo", "C-HR", "Camry", "Celica", "Corolla", "GT 86", "Highlander", "Hilux", "Mirai", "MR2", "Prius", "ProAce", "RAV 4", "Supra", "Tacoma", "Verso", "Yaris" };
        public static string[] models_volkswagen = new string[] { "Amarok", "Arteon", "Beetle", "Bora", "Caddy", "Golf", "ID.3", "ID.4", "Jetta", "Lupo", "Passat", "Phaeton", "Polo", "Scirocco", "Sharan", "T-Cross", "T-Roc", "Tiguan", "Touareg", "Touran", "up!" };
        public static string[] models_Volvo = new string[] { "S40", "S60", "S70", "S80", "S90", "V40", "V50", "V60", "V70", "V90", "XC40", "XC60", "XC70", "XC90" };

        public Dictionary<string, string[]> brands = new Dictionary<string, string[]>
        {
            {"Alfa Romeo", models_alfa },
            {"Audi", models_audi },
            {"BMW", models_bmw },
            {"Chevrolet", models_chevrolet },
            {"Citroen", models_citroen },
            {"Dacia", models_dacia },
            {"Fiat", models_fiat},
            {"Ford", models_ford },
            {"Honda", models_honda },
            {"Hyundai", models_hyundai },
            {"Jeep", models_jeep },
            {"KIA", models_Kia },
            {"Lexus", models_Lexus },
            { "MINI", models_MINI },
            {"Mazda", models_Mazda },
            {"Mercedes Benz", models_Mercedes },
            {"Mitsubishi", models_Mitsubishi },
            {"Nissan", models_Nissan },
            {"Opel", models_Opel },
            {"Peugeot", models_Peugeot },
            {"Renault", models_Renault },
            {"SEAT", models_SEAT },
            {"Skoda", models_Skoda },
            {"Subaru", models_Subaru },
            {"Suzuki", models_Suzuki },
            {"Toyota", models_Toyota },
            {"Volkswagen", models_volkswagen },
            {"Volvo", models_Volvo }
        };

        //Tablice nadwozi, skrzyn, paliwa i uszkodzen
        public string[] vehicle_type = new string[] { "sedan", "coupe", "cabrio", "kompakt", "kombi", "suv", "bus", "other" };
        public string[] gearbox_type = new string[] { "manual", "automatic" };
        public string[] fuel_type = new string[] { "diesel", "petrol", "lpg", "hybrid", "electric", "cng", "other" };
        public string[] damage = new string[] { "yes", "no" };

        #endregion
        public bool Add_car(Car_Numerical car_num, Car_Linguistic car_lin)
        {
            bool stan;
            stan = CarsRepository.Add_car(car_num, car_lin);
            return stan;
        }
    }
}
