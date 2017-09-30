using System.Collections.Generic;

namespace BloodBank.Model
{
    public class UnMese : ICriterioDiSospensione
    {
        private static int durataSospensioneInGiorni = 30 ;
        private static List<string> eventi = new List<string>
        {
            "Intervento Odontoiatrico",
            "Cure con antibiotici",
            "Influenza",
            "Vaccinazione"
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
