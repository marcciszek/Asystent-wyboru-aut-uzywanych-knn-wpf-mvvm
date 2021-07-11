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
        private HistoryModel historyModel = null;
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

        #endregion

        #region metody

        #endregion

        #region konstruktory
        public PredictHistoryViewModel(CarsModel carModel, ListModel listModel, PredictModel predictModel, HistoryModel historyModel)
        {
            this.historyModel = historyModel;
            search_history = FileHandling.Read_History();
        }
        #endregion
    }
}
