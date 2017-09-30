using System.Collections.Generic;

namespace BloodBank.Model
{
    public class GruppoA : GruppoSanguigno
    {
        public GruppoA(FattoreRh fattoreRh)
        {
            FattoreRh = fattoreRh;
        }

        public override List<GruppoSanguigno> GetGruppiCompatibili()
        {
            List<GruppoSanguigno> compatibili = new List<GruppoSanguigno>();
            if (FattoreRh == FattoreRh.negativo)
            {
                compatibili.Add(GruppoSanguignoFactory.GetGruppoSanguigno("0-"));
                compatibili.Add(GruppoSanguignoFactory.GetGruppoSanguigno("A+"));
            }
            else
            {
                compatibili.Add(GruppoSanguignoFactory.GetGruppoSanguigno("0-"));
                compatibili.Add(GruppoSanguignoFactory.GetGruppoSanguigno("0+"));
                compatibili.Add(GruppoSanguignoFactory.GetGruppoSanguigno("A-"));
                compatibili.Add(GruppoSanguignoFactory.GetGruppoSanguigno("A+"));
            }
            return compatibili;
        }

        public bool IsCompatibile(GruppoSanguigno gruppo)
        {
            return GetGruppiCompatibili().Contains(gruppo);
        }

        public override bool Equals(object other)
        {
            if (!(other is GruppoA))
                return false;
            GruppoA g = (GruppoA)other;
            return g != null && g.FattoreRh == FattoreRh;
        }

        public override int GetHashCode()
        {
            if (FattoreRh == FattoreRh.positivo)
                return 2;
            else return 3;
        }

        public override string ToString()
        {
            if (FattoreRh == FattoreRh.positivo)
                return "A+";
            else
                return "A-";
        }

    }
}
