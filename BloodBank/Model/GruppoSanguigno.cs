using System.Collections.Generic;

namespace BloodBank.Model
{
    public abstract class GruppoSanguigno
    {
        private FattoreRh _fattoreRh;

        public FattoreRh FattoreRh
        {
            get
            {
                return _fattoreRh;
            }

            set
            {
                _fattoreRh = value;
            }
        }

        public abstract List<GruppoSanguigno> GetGruppiCompatibili();
    }
}
