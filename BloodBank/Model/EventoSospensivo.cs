using System;

namespace BloodBank.Model
{
    public class EventoSospensivo
    {
        private string _nome;
        private DateTime _dataInizio;
        private DateTime _dataFine;
        private ICriterioDiSospensione _criterioDiSospensione;

        public EventoSospensivo(string nome, DateTime dataFine)
        {
            _nome = nome;
            _dataFine = dataFine;
            _criterioDiSospensione = CriterioDiSospensioneFactory.GetCriterioDiSospensione(nome);
        }

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        public DateTime DataInizio
        {
            get { return _dataInizio; }
            set { _dataInizio = value; }
        }

        public DateTime DataFine
        {
            get { return _dataFine; }
            set { _dataFine = value; }
        }

        public ICriterioDiSospensione CriterioDiSospensione
        {
            get { return _criterioDiSospensione; }
            set { _criterioDiSospensione = value; }
        }

    }
}
