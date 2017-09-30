using BloodBank.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Presenter
{
    
    public abstract class Presenter
    {
        private Modello _modello;

       
        
        public Modello Modello
        {
            get { return _modello; }
            set
            {
                if (value != _modello)
                {
                    if (_modello != null)
                    {
                        //  Deregistrazione
                        _modello.Changed -= OnModelChanged;
                    }
                    _modello = value;

                    if (_modello != null)
                    {
                        //  Registrazione
                        _modello.Changed += OnModelChanged;
                        OnModelChanged(_modello, EventArgs.Empty);
                    }
                }
            }
        }

        protected abstract void OnModelChanged(object sender, EventArgs e);
    }
     
}
