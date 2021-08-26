using Romsoft.GESTIONCLINICA.Common;
using Romsoft.GESTIONCLINICA.Presentacion.ApiService;
using Romsoft.GESTIONCLINICA.Presentacion.Utilities;
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
using Romsoft.GESTIONCLINICA.DTO.TABLAS.TIPO_ESTADO;

namespace Romsoft.GESTIONCLINICA.Presentacion.ModuloTablas.Ocupacion
{
    public partial class frmFiltroOcupacion : Form
    {
        public frmFiltroOcupacion()
        {
            InitializeComponent();
        }

        private void frmFiltroOcupacion_Load(object sender, EventArgs e)
        {
            CargarComboEstado();
            cmbEstado.Text = "";
        }

        //Lista Estados
        private void CargarComboEstado()
        {
            try
            {
                var jsonResponse = new JsonResponse { Success = false };
                jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_Estado_GetAllFilters, new TIPO_ESTADODTO { tabla = "Todos" }, ConstantesWindows.METHODPOST);

                if (jsonResponse.Success && !jsonResponse.Warning)
                {
                    var estadoListDTO = (List<TIPO_ESTADODTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<TIPO_ESTADODTO>()).GetType());
                    cmbEstado.ValueMember = "Id_estado";
                    cmbEstado.DisplayMember = "estado";
                    cmbEstado.DataSource = estadoListDTO;
                }
                else if (jsonResponse.Warning)
                {
                    Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, jsonResponse.Message);
                }
            }
            catch (Exception ex)
            {
                Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, ex.Message);
            }
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            if (txtId.Text.Length > 0)
            {
                ComunFilter.ocupacion_id = Convert.ToInt32(txtId.Text);
            }
            else
            {
                ComunFilter.ocupacion_id = 0;
            }

            if (txtCodigo.Text.Length > 0)
            {
                ComunFilter.ocupacion_c_codigo = txtCodigo.Text;
            }
            else
            {
                ComunFilter.ocupacion_c_codigo = "0";
            }

            if (txtDescripcion.Text.Length > 0)
            {
                ComunFilter.ocupacion_t_descripcion = txtDescripcion.Text;
            }
            else
            {
                ComunFilter.ocupacion_t_descripcion = "0";
            }

            if (cmbEstado.Text.Length > 0)
            {
                ComunFilter.ocupacion_f_estado = Convert.ToInt32(cmbEstado.SelectedValue.ToString());
            }
            else
            {
                ComunFilter.ocupacion_f_estado = 0;
            }

            DialogResult = DialogResult.OK;

            this.Close();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //Color de Borde De formulario
            Rectangle rect = new Rectangle(e.ClipRectangle.X,
            e.ClipRectangle.Y, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1);
            e.Graphics.DrawRectangle(Pens.Gray, rect);
        }
    }
}
