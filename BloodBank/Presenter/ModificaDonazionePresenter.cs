using System;
using BloodBank.View;
using BloodBank.Model;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BloodBank.Presenter
{
    public class ModificaDonazionePresenter : Presenter
    {
        private ModificaDonazioneForm modificaDonazioneForm;
       

        public ModificaDonazionePresenter(ModificaDonazioneForm modificaDonazioneForm)
        {
            this.modificaDonazioneForm = modificaDonazioneForm;
            modificaDonazioneForm.Load += OnLoad;
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