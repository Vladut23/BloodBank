using System.Collections.Generic;

namespace BloodBank.Model
{
    public class Gruppo0 : GruppoSanguigno
    {
        public Gruppo0(FattoreRh fattoreRh)
        { 
            FattoreRh = fattoreRh;
        }

        public override List<GruppoSanguigno> GetGruppiCompatibili()
        {
            List<GruppoSanguigno> compatibili = new List<GruppoSanguigno>();
            if (FattoreRh == FattoreRh.negativo)
            {
                compatibili.Add(GruppoSanguignoFactory.GetGruppoSanguigno("0-"));
            }
            else
            {
                compatibili.Add(GruppoSanguignoFactory.GetGruppoSanguigno("0-"));
                compatibili.Add(GruppoSanguignoFactory.GetGruppoSanguigno("0+"));
            }
            return compatibili;
        }

        public bool IsCompatibile(GruppoSanguigno gruppo)
        {
            return GetGruppiCompatibili().Contains(gruppo);
        }

        public override int GetHashCode()
        {
            if (FattoreRh == FattoreRh.positivo)
                return 0;
            else return 1;
        }

        public override bool Equals(object other)
        {
            if (!(other is Gruppo0))
                return false;
            Gruppo0 g = (Gruppo0)other;
            return g != null && g.FattoreRh == FattoreRh;
        }

        public override string ToString()
        {
            if (FattoreRh == FattoreRh.positivo)
                return "0+";
            else
                return "0-";
        }
    }
}
