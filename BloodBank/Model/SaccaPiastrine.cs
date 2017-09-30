using System;

namespace BloodBank.Model
{
    public class SaccaPiastrine : SaccaContenitrice
    {
        private static readonly int volumeSacca = 200;
        private static readonly int validitaGiorni = 5;

        public SaccaPiastrine(string codiceSacca, string cfDonatore, GruppoSanguigno gruppoSanguigno, DateTime dataCreazione)
        {
            if (String.IsNullOrEmpty(codiceSacca) || String.IsNullOrEmpty(cfDonatore) || gruppoSanguigno == null )
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
