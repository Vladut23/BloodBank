using System;
using System.Collections.Generic;

namespace BloodBank.Model
{
    public class Operatore
    {
        private string _username = null;
        private string _password = null;
        private string _nome = null;
        private string _cognome = null;
        private string _telefono = null;
       

        public Operatore(string username, string password, string nome, string cognome)
        {
            if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password) || String.IsNullOrEmpty(nome) || String.IsNullOrEmpty(cognome))
                throw new ArgumentException("Errore nel passaggio dei parametri in Operatore");
            Username = username;
            Password = password;
            Nome = nome;
            Cognome = cognome;
        }
        
        public string Username
        {
            get
            {
                return _username;
            }

            set
            {
                _username = value;
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }

            set
            {
                _password = value;
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
    }
}
