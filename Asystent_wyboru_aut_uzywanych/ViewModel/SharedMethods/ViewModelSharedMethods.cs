using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Asystent_wyboru_aut_uzywanych.ViewModel.SharedMethods
{
    using Asystent_wyboru_aut_uzywanych.Model;
    static class ViewModelSharedMethods
    {
        public static ObservableCollection<string> Update_models_list(string brand, ObservableCollection<string> models)
        {
            CarsModel carModel = new CarsModel();
            if (models.Count != 0)
            {
                models.Clear();
            }
            if (brand != null)
            {
                foreach (var model in carModel.brands[brand])
                {
                    models.Add(model);
                }
            }
            return models;
        }
    }
}
