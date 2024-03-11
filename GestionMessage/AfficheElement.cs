using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionMessage
{
    //
    // Permet d'initialiser l'accessibilité des champs
    //
    partial class Fn_Message
    {
        //
        // affichage d'un groupe message
        //
        private void AucunGroupeMessage(bool valeur)
        {
            if (valeur)
            {
                // champ
                Cb_ChercheGroupeMessage.Enabled = false;
                Tb_LabelGroupeMessage.Enabled = false;
                // Bouton
                Btn_EnregistrerGroupeMessage.Enabled = false;
                Btn_ModifierGroupeMessage.Enabled = false;
                Btn_SupprimerGroupeMessage.Enabled = false;
                Btn_NouveauGroupeMessage.Enabled = true;
            }
            else
            {
                // champ
                Cb_ChercheGroupeMessage.Enabled = true;
                Tb_LabelGroupeMessage.Enabled = true;
                // Bouton
                Btn_EnregistrerGroupeMessage.Enabled = false;
                Btn_ModifierGroupeMessage.Enabled = true;
                Btn_SupprimerGroupeMessage.Enabled = true;
                Btn_NouveauGroupeMessage.Enabled = true;
            }
            Btn_SupprimerGroupeMessage.Text = "Supprimer";
        }
        //
        // edition d'un groupe message
        //
        private void editeGroupeMessage()
        {
            // champ
            Cb_ChercheGroupeMessage.Enabled = false;
            Tb_LabelGroupeMessage.Enabled = true;
            // Bouton
            Btn_NouveauGroupeMessage.Enabled = false;
            Btn_EnregistrerGroupeMessage.Enabled = true;
            Btn_ModifierGroupeMessage.Enabled = false;
            Btn_SupprimerGroupeMessage.Enabled = true;
            Btn_SupprimerGroupeMessage.Text = "Annuler";
        }
    }
}
