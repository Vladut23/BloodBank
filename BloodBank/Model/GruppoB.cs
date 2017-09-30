using System.Collections.Generic;

namespace BloodBank.Model
{
    public class GruppoB : GruppoSanguigno
    {
        public GruppoB(FattoreRh fattoreRh)
        {
            FattoreRh = fattoreRh;
        }

        public override List<GruppoSanguigno> GetGruppiCompatibili()
        {
            List<GruppoSanguigno> compatibili = new List<GruppoSanguigno>();
            if (FattoreRh == FattoreRh.negativo)
            {
                compatibili.Add(GruppoSanguignoFactory.GetGruppoSanguigno("0-"));
                compatibili.Add(GruppoSanguignoFactory.GetGruppoSanguigno("B-"));
            }
            else
            {
                compatibili.Add(GruppoSanguignoFactory.GetGruppoSanguigno("0-"));
                compatibili.Add(GruppoSanguignoFactory.GetGruppoSanguigno("0+"));
                compatibili.Add(GruppoSanguignoFactory.GetGruppoSanguigno("B-"));
                compatibili.Add(GruppoSanguignoFactory.GetGruppoSanguigno("B+"));
            }
            return compatibili;
        }

        public bool IsCompatibile(GruppoSanguigno gruppo)
        {
            return GetGruppiCompatibili().Contains(gruppo);
        }

        public override bool Equals(object other)
        {
            if (!(other is GruppoB))
                return false;
            GruppoB g = (GruppoB)other;
            return g != null && g.FattoreRh == FattoreRh;
        }

        public override int GetHashCode()
        {
            if (FattoreRh == FattoreRh.positivo)
                return 6;
            else return 7;
        }

        public override string ToString()
        {
            if (FattoreRh == FattoreRh.positivo)
                return "B+";
            else
                return "B-";
        }

    }
}
