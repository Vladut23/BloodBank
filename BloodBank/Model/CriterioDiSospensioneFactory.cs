using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Model
{
    public static class CriterioDiSospensioneFactory
    {
        private static List<ICriterioDiSospensione> _criteriDiSospensione =  new List<ICriterioDiSospensione>()
        {new UnMese(), new QuattroMesi(), new SeiMesi(), new UnAnno(), new Permanente()};
        

        public static ICriterioDiSospensione GetCriterioDiSospensione(string evento)
        {
            if (String.IsNullOrEmpty(evento))
                throw new ArgumentException("Errore nel passaggio del criterio di sospensione");

            foreach (ICriterioDiSospensione criterio in _criteriDiSospensione)
                if (criterio.getEventiSospensivi().Contains(evento))
                    return criterio;

            throw new ArgumentException("Errore nel passaggio dell'evento di sospensione");
        }

        public static List<string> GetListaEventiSospensivi()
        {
            List<string> eventi = new List<string>();
            foreach (ICriterioDiSospensione criterio in _criteriDiSospensione)
                foreach (string evento in criterio.getEventiSospensivi())
                    eventi.Add(evento);

            return eventi;
        }

    }
}
