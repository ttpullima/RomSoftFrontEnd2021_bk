using Romsoft.GESTIONCLINICA.Common;
using Romsoft.GESTIONCLINICA.Presentacion.ApiService;
using Romsoft.GESTIONCLINICA.Presentacion.Utilities;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.ADM_PROFESIONAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Romsoft.GESTIONCLINICA.Presentacion.Helpers;
using Romsoft.GESTIONCLINICA.Presentacion.Core;

namespace Romsoft.GESTIONCLINICA.Presentacion.ModuloConvenios.Petitorio
{
    public partial class frmListaPetitorio : Form
    {
        public int intTipoConsulta = 0;

        public frmListaPetitorio()
        {
            
        }

        private void PctSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ModuloConvenios.Petitorio.frmNuevoPetitorio frm = new ModuloConvenios.Petitorio.frmNuevoPetitorio();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                // 0 = Consulta Todos
                //InitialLoad(0);
            }
        }

        private void frmListaPetitorio_Load(object sender, EventArgs e)
        {

        }
    }
}
