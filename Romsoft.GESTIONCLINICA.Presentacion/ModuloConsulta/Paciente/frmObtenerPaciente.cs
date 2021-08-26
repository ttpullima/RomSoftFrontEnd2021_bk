using Romsoft.GESTIONCLINICA.Presentacion.Core;
using System;
using System.Windows.Forms;


namespace Romsoft.GESTIONCLINICA.Presentacion.ModuloConsulta.Paciente
{
    public partial class frmObtenerPaciente : Form
    {
        public frmObtenerPaciente()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
