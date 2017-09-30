using System;

namespace BloodBank.Model
{
    public class Indirizzo
    {
        private string _città;
        private string _provincia;
        private string _cap;
        private string _via;
        private int _numeroCivico;
        private string _nazione;

        public Indirizzo(string città, string provincia, string cap, string via, int numeroCivico, string nazione)
        {
            if (String.IsNullOrEmpty(città) || String.IsNullOrEmpty(provincia) || String.IsNullOrEmpty(cap) || String.IsNullOrEmpty(nazione) || String.IsNullOrEmpty(via) || numeroCivico < 0)
                throw new ArgumentException("Errore nel costruttore di Indirizzo");
            Città = città;
            Provincia = provincia;
            Cap = cap;
            Via = via;
            NumeroCivico = numeroCivico;
            Nazione = nazione;
        }

        public string Città
        {
            get
            {
                return _città;
            }

            set
            {
                _città = value;
            }
        }

        public string Provincia
        {
            get
            {
                return _provincia;
            }

            set
            {
                _provincia = value;
            }
        }

        public string Cap
        {
            get
            {
                return _cap;
            }

            set
            {
                _cap = value;
            }
        }

        public string Via
        {
            get
            {
                return _via;
            }

            set
            {
                _via = value;
            }
        }

        public int NumeroCivico
        {
            get
            {
                return _numeroCivico;
            }

            set
            {
                _numeroCivico = value;
            }
        }

        public string Nazione
        {
            get
            {
                return _nazione;
            }

            set
            {
                _nazione = value;
            }
        }

    }
}
