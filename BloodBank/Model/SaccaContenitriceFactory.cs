using BloodBank.Model;
using System;

namespace BloodBank.Model
{
    public static class SaccaContenitriceFactory
    {
        private static int indiceSaccaSangue = 0;
        private static int indiceSaccaPlasma = 0;
        private static int indiceSaccaPiastrine = 0;

        public static SaccaContenitrice getSaccaContenitrice(Tipologia tipologia, string cfDonatore, GruppoSanguigno gruppoSanguigno, DateTime dataCreazione)
        {
            string codiceSacca = null;

            
            if (tipologia == Tipologia.sangue)
            {
                indiceSaccaSangue++;
                codiceSacca = "SAN" + indiceSaccaSangue.ToString("D5");
                return new SaccaSangue(codiceSacca, cfDonatore, gruppoSanguigno, dataCreazione);
            }
            if (tipologia == Tipologia.plasma)
            {
                indiceSaccaPlasma++;
                codiceSacca = "PLA" + indiceSaccaPlasma.ToString("D5");
                return new SaccaPlasma(codiceSacca, cfDonatore, gruppoSanguigno, dataCreazione);
            }
            if (tipologia == Tipologia.piastrine)
            {
                indiceSaccaPiastrine++;
                codiceSacca = "PIA" + indiceSaccaPiastrine.ToString("D5");
                return new SaccaPiastrine(codiceSacca, cfDonatore, gruppoSanguigno, dataCreazione);
            }
            return null;
        }
    }
}