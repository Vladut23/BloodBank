using System;
using System.Collections.Generic;

namespace BloodBank.Model
{
    public enum Sesso
    {
        M,
        F
    }

    public class Donatore
    {
        private string _codiceFiscale;
        private string _nome;
        private string _cognome;
        private string _telefono;
        private string _email;
        private DateTime _dataDiNascita;
        private float _peso;
        private Indirizzo _indirizzo;
        private Sesso _sesso;
        private GruppoSanguigno _gruppoSanguigno;
        private List<EventoSospensivo> _eventiSospensivi;
        private List<Donazione> _donazioni;


        public Donatore(string codiceFiscale, string nome, string cognome, string telefono, string email, DateTime dataDiNascita, float peso, Indirizzo indirizzo, Sesso sesso, GruppoSanguigno gruppoSanguigno)
        {
            CodiceFiscale = codiceFiscale;
            Nome = nome;
            Cognome = cognome;
            Telefono = telefono;
            Email = email;
            DataDiNascita = dataDiNascita;
            Peso = peso;
            Indirizzo = indirizzo;
            Sesso = sesso;
            GruppoSanguigno = gruppoSanguigno;
            EventiSospensivi = new List<EventoSospensivo>();
            Donazioni = new List<Donazione>();
        }

        public string CodiceFiscale
        {
            get
            {
                return _codiceFiscale;
            }

            set
            {
                _codiceFiscale = value;
            }
        }

        public string Nome
        {
            get
            {
                return _nome;
            }

            set
            {
                _nome = value;
            }
        }

        public string Cognome
        {
            get
            {
                return _cognome;
            }

            set
            {
                _cognome = value;
            }
        }

        public string Telefono
        {
            get
            {
                return _telefono;
            }

            set
            {
                _telefono = value;
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }

            set
            {
                _email = value;
            }
        }

        public DateTime DataDiNascita
        {
            get
            {
                return _dataDiNascita;
            }

            set
            {
                _dataDiNascita = value;
            }
        }

        public float Peso
        {
            get
            {
                return _peso;
            }

            set
            {
                _peso = value;
            }
        }

        public Indirizzo Indirizzo
        {
            get
            {
                return _indirizzo;
            }

            set
            {
                _indirizzo = value;
            }
        }

        public Sesso Sesso
        {
            get
            {
                return _sesso;
            }

            set
            {
                _sesso = value;
            }
        }

        internal GruppoSanguigno GruppoSanguigno
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

        public List<EventoSospensivo> EventiSospensivi
        {
            get
            {
                return _eventiSospensivi;
            }

            set
            {
                _eventiSospensivi = value;
            }
        }

        public List<Donazione> Donazioni
        {
            get
            {
                return _donazioni;
            }

            set
            {
                _donazioni = value;
            }
        }



        private bool IsAbilitatoADonare()
        {
            bool result = true;
            foreach (EventoSospensivo e in EventiSospensivi)
            {
                if (e.DataFine.AddDays(e.CriterioDiSospensione.getDurataSospensioneIngiorni()).CompareTo(DateTime.Now) > 0)
                {
                    result = false;
                    break;
                }
            }
            int numPiastPlasma = 0;
            int numSangue = 0;

            foreach (Donazione d in Donazioni)
            {
                if (d.Tipologia == Tipologia.sangue && d.DataPrelievo >= DateTime.Now.AddDays(-365))
                    numSangue++;
                if(d.Tipologia == Tipologia.plasma && d.DataPrelievo >= DateTime.Now.AddDays(-365))
                    numPiastPlasma++;
                if (d.Tipologia == Tipologia.piastrine && d.DataPrelievo >= DateTime.Now.AddDays(-365))
                    numPiastPlasma++;
            }

            if (numSangue > 4 || numPiastPlasma > 6 || (numPiastPlasma + numSangue) > 6)
                result = false;
            return result;
        }

        public bool IsAbilitatoADonareSangue()
        {
            if(IsAbilitatoADonare() == false)
                return false;
            Donazione donazione = Donazioni[0];

            foreach(Donazione d in Donazioni)
            {
                if (d.DataPrelievo > donazione.DataPrelievo)
                    donazione = d;
            }

            Tipologia tipologia = donazione.Tipologia;
            if(tipologia == Tipologia.sangue)
            {
                if (donazione.DataPrelievo.AddDays(90) < DateTime.Now)
                    return true;
            }else
            {
                if (donazione.DataPrelievo.AddDays(14) < DateTime.Now)
                    return true;
            }
            return false;
        }

        public bool IsAbilitatoADonarePlasmaPiastrine()
        {
            if (IsAbilitatoADonare() == false)
                return false;
            Donazione donazione = Donazioni[0];

            foreach (Donazione d in Donazioni)
            {
                if (d.DataPrelievo > donazione.DataPrelievo)
                    donazione = d;
            }

            Tipologia tipologia = donazione.Tipologia;
            if (tipologia == Tipologia.sangue)
            {
                if (donazione.DataPrelievo.AddDays(30) < DateTime.Now)
                    return true;
            }
            else
            {
                if (donazione.DataPrelievo.AddDays(14) < DateTime.Now)
                    return true;
            }
            return false;
        }
    }
}
