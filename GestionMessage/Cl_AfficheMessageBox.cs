namespace GestionMessage
{
    public partial class Cl_AfficheMessageBox
    {
        //
        // En cas d'erreur afficher un message puis fermeture de l'application
        //
        public static void MessageErreur(string Message)
        {
            MessageBox.Show(Message, "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Environment.Exit(0);
        }
        //
        // Affiche un message d'alerte
        //
        public static void MessageAlerte(string Message)
        {
            MessageBox.Show(Message, "ALERTE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        //
        // Affiche un message d'information
        //
        public static void MessageInformation(string Message)
        {
            MessageBox.Show(Message, "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
