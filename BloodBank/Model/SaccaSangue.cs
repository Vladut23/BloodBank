using System;

namespace BloodBank.Model
{
    public class SaccaSangue : SaccaContenitrice
    {
        private static readonly int volumeSacca = 450;
        private static readonly int validitaGiorni = 49;

        public SaccaSangue(string codiceSacca, string cfDonatore, GruppoSanguigno gruppoSanguigno, DateTime dataCreazione)
        {
            if (String.IsNullOrEmpty(codiceSacca) || String.IsNullOrEmpty(cfDonatore) || gruppoSanguigno == null)
                throw new ArgumentException("Errore passaggio parametri nella sacca contenitrice");
            CodiceSacca = codiceSacca;
            CFDonatore = cfDonatore;
            GruppoSanguigno = gruppoSanguigno;
            DataCreazione = dataCreazione;
        }
        public override DateTime GetDataScadenza()
        {
            return DataCreazione.AddDays(validitaGiorni);
        }
    }
}
