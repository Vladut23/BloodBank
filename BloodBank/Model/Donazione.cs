using System;

namespace BloodBank.Model
{
    public class Donazione
    {
        private DateTime _dataPrelievo;
        private Tipologia _tipologia;
        private string _usernameOperatore;

        public Donazione(DateTime dataPrelievo, Tipologia tipologia, string usernameOperatore)
        {
            if (dataPrelievo == null )
                throw new ArgumentException("Errore nella creazione della donazione");
            DataPrelievo = dataPrelievo;
            Tipologia = tipologia;
            UsernameOperatore = usernameOperatore;
        }

        public DateTime DataPrelievo
        {
            get
            {
                return _dataPrelievo;
            }

            set
            {
                if (value == null)
                    throw new ArgumentException("Errore data prelievo");
                _dataPrelievo = value;
            }
        }

        public Tipologia Tipologia
        {
            get
            {
                return _tipologia;
            }

            set
            {
                _tipologia = value;
            }
        }

        public string UsernameOperatore
        {
            get
            {
                return _usernameOperatore;
            }

            set
            {
                _usernameOperatore = value;
            }
        }
    }
}
