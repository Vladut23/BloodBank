using System.Collections.Generic;

namespace BloodBank.Model
{
    public class SeiMesi : ICriterioDiSospensione
    {
        private static int durataSospensioneInGiorni = 180;
        private static List<string> eventi = new List<string>
        {
            "Parto"
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
