using System.Collections.Generic;

namespace BloodBank.Model
{
    public interface ICriterioDiSospensione
    {
        int getDurataSospensioneIngiorni();

        List<string> getEventiSospensivi();
    }
}
