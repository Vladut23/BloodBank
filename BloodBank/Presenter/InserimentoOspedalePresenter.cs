using System;
using BloodBank.View;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BloodBank.Presenter
{
    public class InserimentoOspedalePresenter : Presenter
    {
        private InserimentoOspedaleForm inserimentoOspedaleForm;

        public InserimentoOspedalePresenter(InserimentoOspedaleForm inserimentoOspedaleForm)
        {
            this.inserimentoOspedaleForm = inserimentoOspedaleForm;
            inserimentoOspedaleForm.Controls["_buttonSalva"].Click += onButtonClick;
            inserimentoOspedaleForm.Controls["_buttonAnnulla"].Click += onButtonClick;
        }

        private void onButtonClick(object sender, EventArgs e)
        {
            string nomeOspedale = inserimentoOspedaleForm.Controls["_textBoxNome"].Text;
            string responsabile = inserimentoOspedaleForm.Controls["_textBoxResponsabile"].Text;
            string telefono = inserimentoOspedaleForm.Controls["_textBoxTelefono"].Text;
            if (!Regex.Match(telefono, @"^[0-9]{8,12}$").Success)
            {
                MessageBox.Show("Telefono non valido!", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                inserimentoOspedaleForm.Controls["_textBoxTelefono"].Focus();
                return;
            }
            string email = inserimentoOspedaleForm.Controls["_textBoxEmail"].Text;
            if (!Regex.Match(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Success)
            {
                MessageBox.Show("Email non valido!", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                inserimentoOspedaleForm.Controls["_textBoxEmail"].Focus();
                return;
            }
            string via = inserimentoOspedaleForm.Controls["_textBoxVia"].Text;
            int numero = Int32.Parse(inserimentoOspedaleForm.Controls["_textBoxNumero"].Text);
            string CAP = inserimentoOspedaleForm.Controls["_textBoxCAP"].Text;
            if (!Regex.Match(CAP, @"^[0-9]{5}$").Success)
            {
                MessageBox.Show("CAP non valido!", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                inserimentoOspedaleForm.Controls["_textBoxCAP"].Focus();
                return;
            }
            string citta = inserimentoOspedaleForm.Controls["_textBoxCitta"].Text;
            string provincia = inserimentoOspedaleForm.Controls["_textBoxProvincia"].Text;

            Modello.InserisciOspedale(new Model.Ospedale(nomeOspedale, telefono, email, responsabile,
                                        new Model.Indirizzo(citta, provincia, CAP, via, numero, "Italia")));
            inserimentoOspedaleForm.Close();
        }

        protected override void OnModelChanged(object sender, EventArgs e)
        {
            //
        }
    }
}