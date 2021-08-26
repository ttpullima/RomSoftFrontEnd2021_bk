using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Romsoft.GESTIONCLINICA.Presentacion.ModuloFarmacia.Egreso
{
    public partial class frmDevolverDispensacion : Form
    {
        public frmDevolverDispensacion()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Esta Seguro de devolver", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
    }
}
