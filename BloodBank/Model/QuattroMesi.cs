using System.Collections.Generic;

namespace BloodBank.Model
{
    public class QuattroMesi : ICriterioDiSospensione
    {
        private static int durataSospensioneInGiorni = 120;
        private static List<string> eventi = new List<string>
        {
            "Piercing",
            "Tatuaggio",
            "Rapporti sessuali a rischio",
            "Interventi chirurgici",
            "Agopuntura",
            "Endoscopia"
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
