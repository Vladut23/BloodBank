using System;
using BloodBank.View;
using System.Windows.Forms;

namespace BloodBank.Presenter
{
    public class ModificaOperatorePresenter : Presenter
    {
        private ModificaOperatoreForm modificaOperatoreForm;

        public ModificaOperatorePresenter(ModificaOperatoreForm modificaOperatoreForm)
        {
            this.modificaOperatoreForm = modificaOperatoreForm;
            modificaOperatoreForm.Load += OnLoad;
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