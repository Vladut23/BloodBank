using System;
using System.Collections.Generic;

namespace BloodBank.Model
{
    public class ListaAttesa
    {
        private Dictionary<Tuple<Tipologia, GruppoSanguigno>, List<Ordine>> _ordini;

        public ListaAttesa()
        {
            Ordini = new Dictionary<Tuple<Tipologia, GruppoSanguigno>, List<Ordine>>();
            foreach (var value in Enum.GetValues(typeof(Tipologia)))
            {
                Ordini.Add(Tuple.Create((Tipologia)value, GruppoSanguignoFactory.GetGruppoSanguigno("0-")), new List<Ordine>());
                Ordini.Add(Tuple.Create((Tipologia)value, GruppoSanguignoFactory.GetGruppoSanguigno("0+")), new List<Ordine>());
                Ordini.Add(Tuple.Create((Tipologia)value, GruppoSanguignoFactory.GetGruppoSanguigno("A-")), new List<Ordine>());
                Ordini.Add(Tuple.Create((Tipologia)value, GruppoSanguignoFactory.GetGruppoSanguigno("A+")), new List<Ordine>());
                Ordini.Add(Tuple.Create((Tipologia)value, GruppoSanguignoFactory.GetGruppoSanguigno("B-")), new List<Ordine>());
                Ordini.Add(Tuple.Create((Tipologia)value, GruppoSanguignoFactory.GetGruppoSanguigno("B+")), new List<Ordine>());
                Ordini.Add(Tuple.Create((Tipologia)value, GruppoSanguignoFactory.GetGruppoSanguigno("AB-")), new List<Ordine>());
                Ordini.Add(Tuple.Create((Tipologia)value, GruppoSanguignoFactory.GetGruppoSanguigno("AB+")), new List<Ordine>());
            }
        }
        
        public Dictionary<Tuple<Tipologia, GruppoSanguigno>, List<Ordine>> Ordini
        {
            get
            {
                return _ordini;
            }

            set
            {
                _ordini = value;
            }
        }

        public void AggiungiOrdinePerPriorita(Ordine ordine)
        {
            Ordini[Tuple.Create(ordine.Tipologia, ordine.GruppoSanguigno)].Add(ordine);
            Ordini[Tuple.Create(ordine.Tipologia, ordine.GruppoSanguigno)].Sort( (x, y) => {
                if (x.IndicePriorita.CompareTo(y.IndicePriorita) != 0)
                    return x.IndicePriorita.CompareTo(y.IndicePriorita);
                else
                    return x.Data.CompareTo(y.Data); } );
        }

        public void RimuoviOrdine(Ordine ordine)
        {
            Ordini[Tuple.Create(ordine.Tipologia, ordine.GruppoSanguigno)].Remove(ordine);
        }
    }
}
