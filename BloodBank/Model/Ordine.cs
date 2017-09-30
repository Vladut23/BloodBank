using System;
using System.Collections.Generic;

namespace BloodBank.Model
{

    public class Ordine
    {
        private int _numeroSacche;
        private DateTime _data;
        private Tipologia _tipologia;
        private Operatore _operatore;
        private GruppoSanguigno _gruppoSanguigno;
        private List<string> _listaSacche;
        private IndicePriorita _indicePriorita;
        private string _nomeOspedale;

        public Ordine(string nomeOspedale, DateTime data, Tipologia tipologia, GruppoSanguigno gruppoSanguigno, int numeroSacche, IndicePriorita indicePriorita, Operatore operatore)
        {
            this._numeroSacche = numeroSacche;
            Data = data;
            Tipologia = tipologia;
            Operatore = operatore;
            GruppoSanguigno = gruppoSanguigno;
            IndicePriorita = indicePriorita;
            ListaSacche = new List<string>();
            NomeOspedale = nomeOspedale;
        }

        public int NumeroSacche
        {
            get
            {
                return _numeroSacche;
            }

            set
            {
                if (value < 0 )
                    throw new ArgumentException("Numero sacche negativo");
                _numeroSacche = value;
            }
        }

        public DateTime Data
        {
            get
            {
                return _data;
            }

            set
            {
                if (value == null)
                    throw new ArgumentException("Inserire la data");
                _data = value;
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


        public Operatore Operatore
        {
            get
            {
                return _operatore;
            }

            set
            {
                if (value == null)
                    throw new ArgumentException("Inserire un operatore");
                _operatore = value;
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
                if (value == null)
                    throw new ArgumentException("Inserire un gruppo sanguigno");
                _gruppoSanguigno = value;
            }
        }

        public IndicePriorita IndicePriorita
        {
            get
            {
                return _indicePriorita;
            }

            set
            {
                _indicePriorita = value;
            }
        }

        public string NomeOspedale
        {
            get
            {
                return _nomeOspedale;
            }

            set
            {
                _nomeOspedale = value;
            }
        }

        public List<string> ListaSacche
        {
            get
            {
                return _listaSacche;
            }

            set
            {
                _listaSacche = value;
            }
        }
    }
}
