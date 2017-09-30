using System.Collections.Generic;

namespace BloodBank.Model
{
    public class GruppoAB : GruppoSanguigno
    {
        public GruppoAB(FattoreRh fattoreRh)
        {
            FattoreRh = fattoreRh;
        }

        public override List<GruppoSanguigno> GetGruppiCompatibili()
        {
            List<GruppoSanguigno> compatibili = new List<GruppoSanguigno>();
            if (FattoreRh == FattoreRh.negativo)
            {
                compatibili.Add(GruppoSanguignoFactory.GetGruppoSanguigno("0-"));
                compatibili.Add(GruppoSanguignoFactory.GetGruppoSanguigno("A-"));
                compatibili.Add(GruppoSanguignoFactory.GetGruppoSanguigno("B-"));
                compatibili.Add(GruppoSanguignoFactory.GetGruppoSanguigno("AB-"));
            }
            else
            {
                compatibili.Add(GruppoSanguignoFactory.GetGruppoSanguigno("0-"));
                compatibili.Add(GruppoSanguignoFactory.GetGruppoSanguigno("0+"));
                compatibili.Add(GruppoSanguignoFactory.GetGruppoSanguigno("A-"));
                compatibili.Add(GruppoSanguignoFactory.GetGruppoSanguigno("A+"));
                compatibili.Add(GruppoSanguignoFactory.GetGruppoSanguigno("B-"));
                compatibili.Add(GruppoSanguignoFactory.GetGruppoSanguigno("B+"));
                compatibili.Add(GruppoSanguignoFactory.GetGruppoSanguigno("AB-"));
                compatibili.Add(GruppoSanguignoFactory.GetGruppoSanguigno("AB+"));
            }
            return compatibili;
        }

        public bool IsCompatibile(GruppoSanguigno gruppo)
        {
            return GetGruppiCompatibili().Contains(gruppo);
        }

        public override bool Equals(object other)
        {
            if (!(other is GruppoAB))
                return false;
            GruppoAB g = (GruppoAB)other;
            return g != null && g.FattoreRh == FattoreRh;
        }

        public override int GetHashCode()
        {
            if (FattoreRh == FattoreRh.positivo)
                return 4;
            else return 5;
        }

        public override string ToString()
        {
            if (FattoreRh == FattoreRh.positivo)
                return "AB+";
            else
                return "AB-";
        }
    }
}
