using System;
using BloodBank.View;
using System.Windows.Forms;

namespace BloodBank.Presenter
{
    public class ModificaOrdinePresenter : Presenter
    {
        private ModificaOrdineForm modificaOrdineForm;

        public ModificaOrdinePresenter(ModificaOrdineForm modificaOrdineForm)
        {
            this.modificaOrdineForm = modificaOrdineForm;
            modificaOrdineForm.Load += OnLoad;
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