using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Xml.Serialization;

namespace Asystent_wyboru_aut_uzywanych.Model.History
{
    using DAL.Encje;
    static class FileHandling
    {
        public static void Write_History_Files(ObservableCollection<Car> Cars, Car sample)
        {
            string date = DateTime.Now.ToString(@"dd\-MM\-yyyy H\.mm");
            XmlSerializer results_history = new XmlSerializer(typeof(ObservableCollection<Car>));
            try
            {
                using (StreamWriter writer = new StreamWriter($"results/xmls/result_{date}.xml"))
                {
                    results_history.Serialize(writer, Cars);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Błąd zapisu do pliku");
            }
            try
            {
                using (FileStream fs = new FileStream("results/results_history.txt", FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter writer = new StreamWriter(fs))
                    {
                        writer.WriteLine($"{date};{sample.ToWrite()}");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Błąd zapisu do pliku");
            }
        }
        public static ObservableCollection<Sample> Read_History()
        {
            ObservableCollection<Sample> Search_history = new ObservableCollection<Sample>();
            try
            {
                using (StreamReader reader = new StreamReader("results/results_history.txt"))
                {
                    string sample;
                    
                    while((sample = reader.ReadLine()) != null)
                    {
                        Sample history_element = new Sample();
                        string[] sample_elements;
                        sample_elements = sample.Split(';');
                        history_element.ID = sample_elements[0];
                        //Przygotowanie sample_element[1] do stworzenia elementu Car
                        sample_elements[1] = sample_elements[1].Replace("(", " ");
                        sample_elements[1] = sample_elements[1].Replace(")", " ");
                        sample_elements[1] = sample_elements[1].Trim();
                        //veh_type, fuel_type, year, min, max, moc, przebieg, skrzynia, uszkodzenia
                        //Ustawienie parametru Sample.Sample_car
                        history_element.Car = sample_elements[1];
                        Search_history.Add(history_element);
                    }
                }
            }
            catch(Exception)
            {
                
            }
            return Search_history;
        }
        public static ObservableCollection<Car> Read_Result(Sample selected_result)
        {
            ObservableCollection<Car> cars = new ObservableCollection<Car>();
            XmlSerializer results_history = new XmlSerializer(typeof(ObservableCollection<Car>));
            using(StreamReader reader = new StreamReader($"results/xmls/result_{selected_result.ID}.xml"))
            {
                cars = results_history.Deserialize(reader) as ObservableCollection<Car>;
            }
            return cars;
        }
    }
}
