using Newtonsoft.Json;
using Romsoft.GESTIONCLINICA.Common;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.ADM_UBIGEO;
using Romsoft.GESTIONCLINICA.Presentacion.ApiService;
using Romsoft.GESTIONCLINICA.Presentacion.Core;
using Romsoft.GESTIONCLINICA.Presentacion.Helpers;
using Romsoft.GESTIONCLINICA.Presentacion.Utilities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Romsoft.GESTIONCLINICA.Presentacion.ModuloAdmision.HistoriaClinica
{
    public partial class frmFiltroUbigeo : Form
    {
        public frmFiltroUbigeo()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InitialLoad(int intTipoConsulta)
        {

            try
            {
                ComunFilter.f_descripcionUbigeo = "";

                //Muestra Todo
                if (intTipoConsulta == 0)
                {
                    ComunFilter.ValorRequest = "0";

                    var jsonResponse = new JsonResponse { Success = false };
                    //PaginationParameter paginationParameters = new PaginationParameter { AmountRows = 1000, CurrentPage = 0, OrderBy = "", Start = 0, WhereFilter = "WHERE U.estado IN ('Activo','Inactivo')" };
                    jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_ADM_UBIGEO_GetAllActives, GetUbigeoFiltro(), ConstantesWindows.METHODPOST);

                    if (jsonResponse.Success && !jsonResponse.Warning)
                    {
                        var ubigeoListDTO = (List<ADM_UBIGEODTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<ADM_UBIGEODTO>()).GetType());
                        this.ETUbigeobindingSource.DataSource = ubigeoListDTO;
                        //this.usuarioBindingNavigator.BindingSource = this.usuarioBindingSource;
                    }
                    else if (jsonResponse.Warning)
                    {
                        Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, jsonResponse.Message);
                    }
                }

                //Muestra Todo por filtro
                if (intTipoConsulta == 1)
                {


                    var jsonResponse = new JsonResponse { Success = false };

                    jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_ADM_UBIGEO_GetAllFilters, GetUbigeoFiltro(), ConstantesWindows.METHODPOST);

                    if (jsonResponse.Success && !jsonResponse.Warning)
                    {
                        var ubigeoListDTO = (List<ADM_UBIGEODTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<ADM_UBIGEODTO>()).GetType());
                        this.ETUbigeobindingSource.DataSource = ubigeoListDTO;
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
        private ADM_UBIGEODTO GetUbigeoFiltro()
        {
            return new ADM_UBIGEODTO
            {
                ValorBusqueda = ComunFilter.ValorRequest,
            };
        }

        private void frmFiltroUbigeo_Load(object sender, EventArgs e)
        {
            InitialLoad(0);
        }

        private void txtFiltro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txtFiltro.Text.Length > 0)
                {
                    ComunFilter.ValorRequest = txtFiltro.Text;
                    //Búsqueda
                    InitialLoad(1);
                }
                else
                {
                    MessageBox.Show("Ingrese un valor a Buscar", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtFiltro.Focus();
                }
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ComunFilter.f_descripcionUbigeo.Length > 0 || ComunFilter.f_descripcionDomicilio != null)
            {
                DialogResult = DialogResult.OK;

                this.Close();
            }
            else
            {
                MessageBox.Show("Debe Seleccionar un registro", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvUbigeo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvUbigeo.Rows.Count > 0)
            {
                if (ComunFilter.f_tipoUbigeo == 1)
                {
                    ComunFilter.f_idUbigeoNacimiento = Convert.ToInt32(dgvUbigeo.CurrentRow.Cells[0].Value.ToString());
                    ComunFilter.f_descripcionUbigeo = (dgvUbigeo.CurrentRow.Cells[1].Value.ToString()) + ", " + (dgvUbigeo.CurrentRow.Cells[2].Value.ToString()) + ", " + (dgvUbigeo.CurrentRow.Cells[3].Value.ToString()) + ", " + (dgvUbigeo.CurrentRow.Cells[4].Value.ToString()); //id_ubigeo
                }

                if (ComunFilter.f_tipoUbigeo == 2)
                {
                    ComunFilter.f_idUbigeoDomicilio = Convert.ToInt32(dgvUbigeo.CurrentRow.Cells[0].Value.ToString());
                    ComunFilter.f_descripcionDomicilio = (dgvUbigeo.CurrentRow.Cells[1].Value.ToString()) + ", " + (dgvUbigeo.CurrentRow.Cells[2].Value.ToString()) + ", " + (dgvUbigeo.CurrentRow.Cells[3].Value.ToString()) + ", " + (dgvUbigeo.CurrentRow.Cells[4].Value.ToString()); //id_ubigeo
                }

            }
        }
    }
}
