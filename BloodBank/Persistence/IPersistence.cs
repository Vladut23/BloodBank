using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBank.Model;

namespace BloodBank.Persistence
{
    public interface IPersistence
    {
        List<Donatore> GetDonatori();
        List<Ospedale> GetOspedali();
        List<Operatore> GetOperatori();
        ListaAttesa GetListaDiAttesa();
        Dictionary<Tuple<Tipologia, GruppoSanguigno>, List<SaccaContenitrice>> GetSacche();
        void RendiPersistente(Modello modello);
    }
}
