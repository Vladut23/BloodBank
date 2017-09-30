using System.Collections.Generic;

namespace BloodBank.Model
{
    public class UnAnno : ICriterioDiSospensione
    {
        private static int durataSospensioneInGiorni = 360;
        private static List<string> eventi = new List<string>
        {
            "Rientro da paesi a rischio",
            "Assunzione di droghe leggeri"
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
