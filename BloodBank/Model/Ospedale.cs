using System;
using System.Collections.Generic;

namespace BloodBank.Model
{
    public class Ospedale
    {
        private Indirizzo _indirizzo;
        private string _nome;
        private string _telefono;
        private string _email;
        private string _nomeResponsabile;
        private List<Ordine> _listaOrdini;

        public Ospedale(string nome, string telefono, string email, string nomeResponsabile, Indirizzo indirizzo)
        {
            Indirizzo = indirizzo;
            Nome = nome;
            Telefono = telefono;
            Email = email;
            NomeResponsabile = nomeResponsabile;
            ListaOrdini = new List<Ordine>();
        }

        public Indirizzo Indirizzo
        {
            get
            {
                return _indirizzo;
            }

            set
            {
                if (value == null)
                    throw new ArgumentException("Indirizzo non valido");
                _indirizzo = value;
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
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException("Inserire il nome dell'ospedale");
                _nome = value;
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
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException("Inserire il numero di telefono dell'ospedale");
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
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException("Inserire l'e-mail dell'ospedale");
                _email = value;
            }
        }

        public string NomeResponsabile
        {
            get
            {
                return _nomeResponsabile;
            }

            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException("Inserire il responsabile dell'ospedale");
                _nomeResponsabile = value;
            }
        }

        public List<Ordine> ListaOrdini
        {
            get
            {
                return _listaOrdini;
            }

            set
            {
                if (value == null)
                    throw new ArgumentException("Lista ordini non valida");
                _listaOrdini = value;
            }
        }

    }
}
