using System;
using BloodBank.View;
using System.Windows.Forms;

namespace BloodBank.Presenter
{
    public class EliminaDonatorePresenter : Presenter
    {
        private EliminaDonatoreForm eliminaDonatoreForm;

        public EliminaDonatorePresenter(EliminaDonatoreForm eliminaDonatoreForm)
        {
            this.eliminaDonatoreForm = eliminaDonatoreForm;
            eliminaDonatoreForm.Load += OnLoad;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            MessageBox.Show("Funzionalità del sistema non ancora implementata", "Informazione",
                                   MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        protected override void OnModelChanged(object sender, EventArgs e)
        {
           //
        }
    }
}