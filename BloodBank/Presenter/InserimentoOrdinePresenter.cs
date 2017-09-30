using System;
using BloodBank.View;
using System.Windows.Forms;
using BloodBank.Model;

namespace BloodBank.Presenter
{
    public class InserimentoOrdinePresenter : Presenter
    {
        private InserimentoOrdineForm inserimentoOrdineForm;

        public InserimentoOrdinePresenter(InserimentoOrdineForm inserimentoOrdineForm)
        {
            this.inserimentoOrdineForm = inserimentoOrdineForm;
            inserimentoOrdineForm.Load += onLoad;
            inserimentoOrdineForm.Controls["_buttonEvadi"].Click += onButtonClick;
            inserimentoOrdineForm.Controls["_buttonAnnulla"].Click += onButtonClick;
        }

        private void onLoad(object sender, EventArgs e)
        {
            ComboBox comboOspedali = (inserimentoOrdineForm.Controls["_comboBoxOspedali"] as ComboBox);
            foreach (Ospedale o in Modello.Ospedali)
                comboOspedali.Items.Add(o.Nome);
            ComboBox comboPriorita = (inserimentoOrdineForm.Controls["_comboBoxPriorita"] as ComboBox);
            foreach (IndicePriorita indice in Enum.GetValues(typeof(IndicePriorita)))
                comboPriorita.Items.Add(indice);
            ComboBox comboTipologia = (inserimentoOrdineForm.Controls["_comboBoxTipologia"] as ComboBox);
            foreach (Tipologia t in Enum.GetValues(typeof(Tipologia)))
                comboTipologia.Items.Add(t);
        }

        private void onButtonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Name == "_buttonEvadi")
            {
                if ((inserimentoOrdineForm.Controls["_comboBoxOspedali"] as ComboBox).SelectedIndex < 0)
                {
                    MessageBox.Show("Scegliere l'ospedale!", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    inserimentoOrdineForm.Controls["_comboBoxOspedali"].Focus();
                    return;
                }
                string ospedale = (string)(inserimentoOrdineForm.Controls["_comboBoxOspedali"] as ComboBox).SelectedItem;

                DateTime dataOrdine = (inserimentoOrdineForm.Controls["_dateTimePickerData"] as DateTimePicker).Value.Date;

                if ((inserimentoOrdineForm.Controls["_comboBoxPriorita"] as ComboBox).SelectedIndex < 0)
                {
                    MessageBox.Show("Scegliere l'indice di priorità!", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    inserimentoOrdineForm.Controls["_comboBoxPriorita"].Focus();
                    return;
                }
                IndicePriorita indice = (IndicePriorita)(inserimentoOrdineForm.Controls["_comboBoxPriorita"] as ComboBox).SelectedItem;

                if ((inserimentoOrdineForm.Controls["_comboBoxTipologia"] as ComboBox).SelectedIndex < 0)
                {
                    MessageBox.Show("Scegliere la tipologia!", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    inserimentoOrdineForm.Controls["_comboBoxTipologia"].Focus();
                    return;
                }
                Tipologia tipologia = (Tipologia)(inserimentoOrdineForm.Controls["_comboBoxTipologia"] as ComboBox).SelectedItem;

                if ((inserimentoOrdineForm.Controls["_comboBoxGruppoSanguigno"] as ComboBox).SelectedIndex < 0)
                {
                    MessageBox.Show("Scegliere il gruppo sanguigno!", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    inserimentoOrdineForm.Controls["_comboBoxGruppoSanguigno"].Focus();
                    return;
                }
                string gruppoSanguigno = (inserimentoOrdineForm.Controls["_comboBoxGruppoSanguigno"] as ComboBox).SelectedItem as string;

                int sacche = Int32.Parse(inserimentoOrdineForm.Controls["_textBoxNumeroSacche"].Text);
                if (sacche <= 0)
                {
                    MessageBox.Show("Inserire numero sacche!", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    inserimentoOrdineForm.Controls["_textBoxNumeroSacche"].Focus();
                    return;
                }

                bool esitoInserimento = Modello.InserisciOrdine(new Ordine(ospedale, dataOrdine, tipologia, GruppoSanguignoFactory.GetGruppoSanguigno(gruppoSanguigno), sacche, indice, Modello.OperatoreCorrente));
                if (esitoInserimento)
                {
                    MessageBox.Show("Ordine evaso con successo", "Esito", MessageBoxButtons.OK);
                    inserimentoOrdineForm.Close();
                }
                else
                {
                    MessageBox.Show("Ordine inserito in lista d'attesa", "Esito", MessageBoxButtons.OK);
                    inserimentoOrdineForm.Close();
                }
            }
            else if (button.Name == "_buttonAnnulla")
            {
                inserimentoOrdineForm.Close();
            }
        }

        protected override void OnModelChanged(object sender, EventArgs e)
        {
            //
        }
    }
}