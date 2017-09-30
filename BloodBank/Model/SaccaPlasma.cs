using System;

namespace BloodBank.Model
{
    public class SaccaPlasma : SaccaContenitrice
    {
        private static readonly int volumeSacca = 700;
        private static readonly int validitaGiorni = 730;

        public SaccaPlasma(string codiceSacca, string cfDonatore, GruppoSanguigno gruppoSanguigno, DateTime dataCreazione)
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
