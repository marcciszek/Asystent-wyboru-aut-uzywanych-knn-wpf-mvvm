using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace Asystent_wyboru_aut_uzywanych.ViewModel
{
    using BaseClass;
    using DAL.Encje;
    using DAL.Repozytoria;
    using Model;
    using Model.History;
    

    class PredictHistoryViewModel : ViewModelBase
    {
        #region definicje prywatne
        #endregion

        #region parametry
        private ObservableCollection<Sample> search_history = new ObservableCollection<Sample>();
        public ObservableCollection<Sample> Search_History
        {
            get
            {
                return search_history;
            }
            set
            {
                search_history = value;
                onPropertyChanged(nameof(Search_History));
            }
        }
        private ObservableCollection<Car> result_details = new ObservableCollection<Car>();
        public ObservableCollection<Car> Result_Details
        {
            get
            {
                return result_details;
            }
            set
            {
                result_details = value;
                onPropertyChanged(nameof(Result_Details));
            }
        }
        private Sample selected_result = null;

        public Sample Selected_Result
        {
            get
            {
                return selected_result;
            }
            set
            {
                selected_result = value;
                result_details = FileHandling.Read_Result(selected_result);
                onPropertyChanged(nameof(Selected_Result));
            }
        }
        #endregion

        #region metody

        #endregion

        #region konstruktory
        public PredictHistoryViewModel(CarsModel carModel, ListModel listModel, PredictModel predictModel)
        {
            search_history = FileHandling.Read_History();
        }
        #endregion
    }
}
