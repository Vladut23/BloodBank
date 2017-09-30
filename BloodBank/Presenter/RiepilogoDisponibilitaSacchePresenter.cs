using System;
using BloodBank.View;
using BloodBank.Model;
using System.Windows.Forms;

namespace BloodBank.Presenter
{
    public class RiepilogoDisponibilitaSacchePresenter : Presenter
    {
        private RiepilogoDisponibilitaSaccheForm riepilogoDisponibilitaSaccheForm;

        public RiepilogoDisponibilitaSacchePresenter(RiepilogoDisponibilitaSaccheForm riepilogoDisponibilitaSaccheForm)
        {
            this.riepilogoDisponibilitaSaccheForm = riepilogoDisponibilitaSaccheForm;
            riepilogoDisponibilitaSaccheForm.Load += OnLoad;
            riepilogoDisponibilitaSaccheForm.Controls["_buttonEsci"].Click += OnButtonClick;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            DataGridView dataGrid = riepilogoDisponibilitaSaccheForm.Controls["dataGridView1"] as DataGridView;

            if (dataGrid.RowCount > 0)
            {
                dataGrid.Rows.Clear();
                dataGrid.Refresh();
            }

            foreach (var value in Enum.GetValues(typeof(Tipologia)))
            {
                foreach (GruppoSanguigno g in GruppoSanguignoFactory.GetListaGruppi())
                {
                    
                    dataGrid.Rows.Add(value.ToString(), g, Modello.Sacche[Tuple.Create((Tipologia)value, g)].Count);
                }
            }
        }

        private void OnButtonClick(object sender, EventArgs e)
        {
            riepilogoDisponibilitaSaccheForm.Close();
        }

        protected override void OnModelChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }
    }
}