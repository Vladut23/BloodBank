using System.Collections.Generic;

namespace BloodBank.Model
{
    public class Permanente : ICriterioDiSospensione
    {
        private static int durataSospensioneInGiorni = int.MaxValue;
        private static List<string> eventi = new List<string>
        {
            "Positività per test HIV",
            "Epatite B",
            "Epatite C",
            "Malatie croniche",
            "Assunzione droghe pesanti"
        };

        public int getDurataSospensioneIngiorni()
        {
            return durataSospensioneInGiorni;
        }

        public List<string> getEventiSospensivi()
        {
            return eventi;
        }
    }
}
