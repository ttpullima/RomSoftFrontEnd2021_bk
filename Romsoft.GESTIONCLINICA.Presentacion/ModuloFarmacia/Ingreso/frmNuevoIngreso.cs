using Romsoft.GESTIONCLINICA.Common;
using Romsoft.GESTIONCLINICA.Presentacion.ApiService;
using Romsoft.GESTIONCLINICA.Presentacion.Utilities;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.ADM_PROFESIONAL;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.TIPO_ESTADO;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.ADM_GENERO;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.ADM_DOCUMENTO_IDENTIDAD;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.ADM_ESPECIALIDAD;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.ADM_TIPO_PROFESIONAL;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.ADM_CONDICION_PROFESIONAL;
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

namespace Romsoft.GESTIONCLINICA.Presentacion.ModuloFarmacia.Ingreso
{
    public partial class frmNuevoIngreso : Form
    {
        public frmNuevoIngreso()
        {
            InitializeComponent();
        }

   
       

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
       

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnProducto_Click(object sender, EventArgs e)
        {
            Ingreso.frmFiltroProducto frm = new Ingreso.frmFiltroProducto();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                // 0 = Consulta Todos
              //  InitialLoad(0);
            }
        }

        private void BtnOrdenGuia_Click(object sender, EventArgs e)
        {
            Ingreso.frmFiltroOrdenGuia frm = new Ingreso.frmFiltroOrdenGuia();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                // 0 = Consulta Todos
                //  InitialLoad(0);
            }
        }

        private void BtnProveedor_Click(object sender, EventArgs e)
        {
            Ingreso.frmFiltroProveedor frm = new Ingreso.frmFiltroProveedor();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                // 0 = Consulta Todos
                //  InitialLoad(0);
            }
        }
    }
}
