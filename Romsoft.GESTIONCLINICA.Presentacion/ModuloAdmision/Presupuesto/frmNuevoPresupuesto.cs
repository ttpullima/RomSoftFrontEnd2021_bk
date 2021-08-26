using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Romsoft.GESTIONCLINICA.Presentacion.ModuloFacturacion.Prefacturacion;

namespace Romsoft.GESTIONCLINICA.Presentacion.ModuloAdmision.Presupuesto
{
    public partial class frmNuevoPresupuesto : Form
    {
        public frmNuevoPresupuesto()
        {
            InitializeComponent();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnProducto_Click(object sender, EventArgs e)
        {
           
        }

        private void BtnOrdenGuia_Click(object sender, EventArgs e)
        {
            Presupuesto.frmPlantillaPresupuesto frm = new Presupuesto.frmPlantillaPresupuesto();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                // 0 = Consulta Todos
                //    InitialLoad(0);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Presupuesto.frmFiltroTarifarioSegus frm = new Presupuesto.frmFiltroTarifarioSegus();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                // 0 = Consulta Todos
                //    InitialLoad(0);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ModuloConsulta.Paciente.frmObtenerPaciente frm = new ModuloConsulta.Paciente.frmObtenerPaciente();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                // 0 = Consulta Todos
                //    InitialLoad(0);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ModuloConsulta.Diagnostico.frmObtenerDiagnostico frm = new ModuloConsulta.Diagnostico.frmObtenerDiagnostico();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                // 0 = Consulta Todos
                //    InitialLoad(0);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ModuloAdmision.Presupuesto.frmObservacion frm = new ModuloAdmision.Presupuesto.frmObservacion();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                // 0 = Consulta Todos
                //    InitialLoad(0);
            }
        }
    }
}
