using System;
using BloodBank.View;
using System.Windows.Forms;

namespace BloodBank.Presenter
{
    public class EliminaDonazionePresenter : Presenter
    {
        private EliminaDonazioneForm eliminaDonazioneForm;

        public EliminaDonazionePresenter(EliminaDonazioneForm eliminaDonazioneForm)
        {
            this.eliminaDonazioneForm = eliminaDonazioneForm;
            eliminaDonazioneForm.Load += OnLoad;
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