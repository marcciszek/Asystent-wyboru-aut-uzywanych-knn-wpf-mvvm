using System;
using System.Collections.Generic;
using System.Text;

namespace Asystent_wyboru_aut_uzywanych.Model
{
    using DAL.Repozytoria;
    class Model
    {
        #region konstruktory

        #endregion
        public bool Dodawanie_auta()
        {
            RepozytoriumAuta.DodajAuto();
            return true;
        }
    }
}
