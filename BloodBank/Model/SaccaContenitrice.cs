using System;

namespace BloodBank.Model
{
    public abstract class SaccaContenitrice
    {
        private string _codiceSacca;
        private string _CFDonatore;
        private GruppoSanguigno _gruppoSanguigno;
        private DateTime _dataCreazione;

        public string CodiceSacca
        {
            get
            {
                return _codiceSacca;
            }

            set
            {
                _codiceSacca = value;
            }
        }

        public string CFDonatore
        {
            get
            {
                return _CFDonatore;
            }

            set
            {
                _CFDonatore = value;
            }
        }

        public GruppoSanguigno GruppoSanguigno
        {
            get
            {
                return _gruppoSanguigno;
            }

            set
            {
                _gruppoSanguigno = value;
            }
        }

        public DateTime DataCreazione
        {
            get
            {
                return _dataCreazione;
            }

            set
            {
                _dataCreazione = value;
            }
        }


        public abstract DateTime GetDataScadenza();
    }
}
