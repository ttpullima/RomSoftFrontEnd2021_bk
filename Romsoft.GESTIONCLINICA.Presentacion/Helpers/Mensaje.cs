namespace Romsoft.GESTIONCLINICA.Presentacion.Helpers
{
    using System.Windows.Forms;
    public class Mensaje
    {
        public static void ShowMessageAlert(Form form, string title, string message)
        {
            MessageBox.Show(form, message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static DialogResult ShowMessageConfirm(Form form, string title, string message)
        {
            return MessageBox.Show(form, message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        }
    }

}
