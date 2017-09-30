using System;
using System.Collections.Generic;

namespace BloodBank.Model
{
    public class Responsabile : Operatore
    {
      

        public Responsabile(string username, string password, string nome, string cognome) : base(username, password, nome, cognome)
        {
            
        }

        public void AggiungiOperatore(List<Operatore> listaOperatori, Operatore operatore)
        {
            if (operatore == null)
                throw new ArgumentException("Errore nell'aggiunta dell'operatore");
            listaOperatori.Add(operatore);
        }

        public void EliminaOperatore(List<Operatore> listaOperatori, Operatore operatore)
        {
            if (operatore == null)
                throw new ArgumentException("Errore nell'eliminazione dell'operatore");
            listaOperatori.Remove(operatore);
        }

        public void ModificaOperatore(List<Operatore> listaOperatori, Operatore operatore, string password, string nome, string cognome, string telefono)
        {
            if (operatore == null)
                throw new ArgumentException("Errore nella modifica dell'operatore");
            foreach (Operatore o in listaOperatori)
                if (o.Equals(operatore))
                {
                    o.Nome = nome;
                    o.Cognome = cognome;
                    o.Password = password;
                    o.Telefono = telefono;
                }
        }
    }
}
