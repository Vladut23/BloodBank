using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Model
{
    public static class GruppoSanguignoFactory
    {
        private static Dictionary<string, GruppoSanguigno> _gruppiSanguigni = new Dictionary<string, GruppoSanguigno>();

        public static GruppoSanguigno GetGruppoSanguigno(String gruppo)
        {
            if (String.IsNullOrEmpty(gruppo))
                throw new ArgumentException("Errore nel passaggio del tipo di gruppo sanguigno");

            if (!_gruppiSanguigni.ContainsKey(gruppo))
            {
                _gruppiSanguigni.Add(gruppo, createGruppo(gruppo));
            }
            return _gruppiSanguigni[gruppo];
        }

        public static List<GruppoSanguigno> GetListaGruppi()
        {
            return _gruppiSanguigni.Values.ToList<GruppoSanguigno>();
        }

        private static GruppoSanguigno createGruppo(string gruppo)
        {
            switch (gruppo)
            {
                case "0-":
                    return new Gruppo0(FattoreRh.negativo);
                case "0+":
                    return new Gruppo0(FattoreRh.positivo);
                case "A-":
                    return new GruppoA(FattoreRh.negativo);
                case "A+":
                    return new GruppoA(FattoreRh.positivo);
                case "B-":
                    return new GruppoB(FattoreRh.negativo);
                case "B+":
                    return new GruppoB(FattoreRh.positivo);
                case "AB-":
                    return new GruppoAB(FattoreRh.negativo);
                case "AB+":
                    return new GruppoAB(FattoreRh.positivo);
                default:
                    throw new ArgumentException("Errore nel passaggio della stringa gruppo");

            }
        }
    }
}
