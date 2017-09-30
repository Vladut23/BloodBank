using System;
using BloodBank.View;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace BloodBank.Presenter
{
    public class InserimentoOperatorePresenter : Presenter
    {
        private InserimentoOperatoreForm inserimentoOperatoreForm;

        public InserimentoOperatorePresenter(InserimentoOperatoreForm inserimentoOperatoreForm)
        {
            this.inserimentoOperatoreForm = inserimentoOperatoreForm;
            inserimentoOperatoreForm.Controls["_buttonSalva"].Click += onButtonClick;
            inserimentoOperatoreForm.Controls["_buttonAnnulla"].Click += onButtonClick;
        }

        private void onButtonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Name == "_buttonSalva")
            {
                string nome = inserimentoOperatoreForm.Controls["_textBoxNome"].Text;
                string cognome = inserimentoOperatoreForm.Controls["_textBoxCognome"].Text;
                string telefono = inserimentoOperatoreForm.Controls["_textBoxTelefono"].Text;
                if (!Regex.Match(telefono, @"^[0-9]{8,12}$").Success)
                {
                    MessageBox.Show("Telefono non valido!", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    inserimentoOperatoreForm.Controls["_textBoxTelefono"].Focus();
                    return;
                }
                string username = inserimentoOperatoreForm.Controls["_textBoxUsername"].Text;
                string password = inserimentoOperatoreForm.Controls["_textBoxPassword"].Text;
                Modello.InserisciOperatore(new Model.Operatore(username, password, nome, cognome));
                inserimentoOperatoreForm.Close();
            }
            else if (button.Name == "_buttonAnnulla")
            {
                inserimentoOperatoreForm.Close();
            }
        }

        protected override void OnModelChanged(object sender, EventArgs e)
        {
            //
        }
    }
}