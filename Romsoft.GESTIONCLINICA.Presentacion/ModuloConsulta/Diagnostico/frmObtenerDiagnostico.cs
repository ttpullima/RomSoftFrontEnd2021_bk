using Romsoft.GESTIONCLINICA.Common;
using Romsoft.GESTIONCLINICA.Presentacion.ApiService;
using Romsoft.GESTIONCLINICA.Presentacion.Utilities;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.ADM_CIE10;
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


namespace Romsoft.GESTIONCLINICA.Presentacion.ModuloConsulta.Diagnostico
{
    public partial class frmObtenerDiagnostico : Form
    {
        public frmObtenerDiagnostico()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(this.txtFiltro.Text))
                {
                    this.errValidator.SetError(this.txtFiltro, "Ingresar Valor para Búsqueda.");

                }
                else
                {

                    //Muestra Todo por filtro

                    var jsonResponse = new JsonResponse { Success = false };

                    jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_ADM_CIE10_GetAllFilters, GetCie10(), ConstantesWindows.METHODPOST);

                    if (jsonResponse.Success && !jsonResponse.Warning)
                    {
                        var tarifaListDTO = (List<ADM_CIE10DTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<ADM_CIE10DTO>()).GetType());
                        this.ETCie10bindingSource.DataSource = tarifaListDTO;
                        //this.usuarioBindingNavigator.BindingSource = this.usuarioBindingSource;
                    }
                    else if (jsonResponse.Warning)
                    {
                        Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, jsonResponse.Message);
                    }

                }


            }
            catch (Exception ex)
            {
                Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, ex.Message);
            }
        }

        //Asigna Datos para el Filtro
        private ADM_CIE10DTO GetCie10()
        {
            return new ADM_CIE10DTO
            {
                valorReq = txtFiltro.Text.Trim(),
            };
        }

        private void dgvCie10_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvCie10_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCie10.Rows.Count > 0)
            {
                ComunFilter.cie10_id_cie10 = Convert.ToInt32(dgvCie10.CurrentRow.Cells[0].Value.ToString()); //Id
                ComunFilter.cie10_c_codigo = dgvCie10.CurrentRow.Cells[1].Value.ToString(); //Codigo
                ComunFilter.ci10_t_descripcion = dgvCie10.CurrentRow.Cells[2].Value.ToString(); //Descripcion

                DialogResult = DialogResult.OK;

                this.Close();
            }
        }

        private void txtFiltro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (string.IsNullOrEmpty(this.txtFiltro.Text))
                {
                    this.errValidator.SetError(this.txtFiltro, "Ingresar valor a buscar.");
                }
                else
                {
                    this.errValidator.SetError(this.txtFiltro, string.Empty);

                    btnBuscar.PerformClick();
                }



            }
        }
    }
}
