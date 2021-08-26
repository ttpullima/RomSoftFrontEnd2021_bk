using Newtonsoft.Json;
using Romsoft.GESTIONCLINICA.Common;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.CVN_BENEFICIO;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.CVN_MONEDA;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.CVN_PLAN_SEGURO_DETALLE;
using Romsoft.GESTIONCLINICA.Presentacion.ApiService;
using Romsoft.GESTIONCLINICA.Presentacion.Core;
using Romsoft.GESTIONCLINICA.Presentacion.Helpers;
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

namespace Romsoft.GESTIONCLINICA.Presentacion.ModuloConvenios.PlanSeguro
{
    public partial class frmFiltroBeneficio : Form
    {
        public EstadoActual estadoActual;

        public frmFiltroBeneficio()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void frmFiltroBeneficio_Load(object sender, EventArgs e)
        {
            this.estadoActual = EstadoActual.Nuevo;

            //Llena combo
            CargarBeneficio();
            //Carga Moneda
            CargarMoneda();

            cmbBeneficio.Text = "";
            cmbMoneda.Text = "";
        }


        private void CargarBeneficio()
        {
            try
            {
                var jsonResponse = new JsonResponse { Success = false };
                jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_CVN_BENEFICIO_GetAllActives, "", ConstantesWindows.METHODPOST);

                if (jsonResponse.Success && !jsonResponse.Warning)
                {
                    var beneficioListDTO = (List<CVN_BENEFICIODTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<CVN_BENEFICIODTO>()).GetType());
                    cmbBeneficio.ValueMember = "id_beneficio";
                    cmbBeneficio.DisplayMember = "t_descripcion";
                    cmbBeneficio.DataSource = beneficioListDTO;
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

        private void CargarMoneda()
        {
            try
            {
                var jsonResponse = new JsonResponse { Success = false };
                jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_CVN_MONEDA_GetAllActives, "", ConstantesWindows.METHODPOST);

                if (jsonResponse.Success && !jsonResponse.Warning)
                {
                    var monedaListDTO = (List<CVN_MONEDADTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<CVN_MONEDADTO>()).GetType());
                    cmbMoneda.ValueMember = "id_moneda";
                    cmbMoneda.DisplayMember = "t_descripcion";
                    cmbMoneda.DataSource = monedaListDTO;
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

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {

                ComunFilter.ps_id_plan_seguro_detalle = 0;
                ComunFilter.ps_codigo = "";
                ComunFilter.ps_beneficio = cmbBeneficio.Text;
                ComunFilter.ps_moneda = cmbMoneda.Text;
                ComunFilter.ps_copago_fijo = Convert.ToDecimal(txtCopagoFijo.Text);
                ComunFilter.ps_copago_variable = Convert.ToDecimal(txtCopagoVariable.Text);
                ComunFilter.ps_copago_farmacia = Convert.ToDecimal(txtPagoFarmacia.Text);



                if (SaveData())
                {
                    this.estadoActual = EstadoActual.Normal;

                    DialogResult = DialogResult.OK;

                    this.Close();
                }

            }
        }

        private bool ValidateData()
        {
            bool result = true;

            if (string.IsNullOrEmpty(this.cmbBeneficio.Text))
            {
                this.errValidator.SetError(this.cmbBeneficio, "Ingresar Beneficio.");
                result = false;
            }
            else
            {
                this.errValidator.SetError(this.cmbBeneficio, string.Empty);
            }

            if (string.IsNullOrEmpty(this.cmbMoneda.Text))
            {
                this.errValidator.SetError(this.cmbMoneda, "Ingresar Moneda.");
                result = false;
            }
            else
            {
                this.errValidator.SetError(this.cmbMoneda, string.Empty);
            }


            if (string.IsNullOrEmpty(this.txtCopagoFijo.Text))
            {
                this.errValidator.SetError(this.txtCopagoFijo, "Ingresar valor Copago");
                result = false;
            }
            else
            {
                this.errValidator.SetError(this.txtCopagoFijo, string.Empty);
            }

            if (string.IsNullOrEmpty(this.txtCopagoVariable.Text))
            {
                this.errValidator.SetError(this.txtCopagoVariable, "Ingresar valor variable.");
                result = false;
            }
            else
            {
                this.errValidator.SetError(this.txtCopagoVariable, string.Empty);
            }


            if (string.IsNullOrEmpty(this.txtPagoFarmacia.Text))
            {
                this.errValidator.SetError(this.txtPagoFarmacia, "Ingresar valor farmacia.");
                result = false;
            }
            else
            {
                this.errValidator.SetError(this.txtPagoFarmacia, string.Empty);
            }

            return result;
        }

        private bool SaveData()
        {
            bool result = false;
            try
            {
                var jsonResponse = new JsonResponse { Success = false };
                switch (this.estadoActual)
                {
                    // Guardar
                    case EstadoActual.Nuevo:
                        jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_CVN_PLAN_SEGURO_DETALLE_Add, GetPlanDetalle(), ConstantesWindows.METHODPOST);

                        // obtiene el último id registrado
                        ComunFilter.ps_id_plan_seguro_detalle = Convert.ToInt32(jsonResponse.Data);

                        break;
                        //case EstadoActual.Eliminar:
                        //    jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_CVN_TARIFARIO_SEGUS_PARTICIPANTE_Delete, new CVN_TARIFARIO_SEGUSDTO { id_tarifario_segus = Convert.ToInt32(this.txtIdTarifa.Text), UsuarioCreacion = WindowsSession.UsuarioActual }, ConstantesWindows.METHODPOST);
                        //    break;
                }

                if (jsonResponse.Success)
                {
                    if (jsonResponse.Warning)
                    {
                        result = false;
                        //Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, jsonResponse.Message);
                    }
                    else
                    {
                        result = true;
                    }
                }
                else
                {
                    result = false;
                    Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, jsonResponse.Message);
                }

                if (result)
                {
                    //this.Close();
                    //Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, jsonResponse.Message);
                    DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, ex.Message);
            }
            return result;
        }


        //Asigna datos para registro/ctualizar
        private CVN_PLAN_SEGURO_DETALLEDTO GetPlanDetalle()
        {

            return new CVN_PLAN_SEGURO_DETALLEDTO
            {

                id_plan_seguro = ComunFilter.ps_id_plan_seguro,
                id_beneficio = Convert.ToInt32(cmbBeneficio.SelectedValue),
                id_moneda = Convert.ToInt32(cmbMoneda.SelectedValue),
                n_copago_fijo = Convert.ToDecimal(txtCopagoFijo.Text),
                n_copago_variable = Convert.ToDecimal(txtCopagoVariable.Text),
                n_copago_variable_farmacia = Convert.ToDecimal(txtPagoFarmacia.Text),
                f_estado = 1,
                UsuarioCreacion = Convert.ToString(WindowsSession.UserIdActual), //WindowsSession.UsuarioActual,
                UsuarioModificacion = Convert.ToString(WindowsSession.UserIdActual), //WindowsSession.UsuarioActual,
                IdUsuarioActual = WindowsSession.UserIdActual,
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now
            };
        }

        private void txtCopagoFijo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // solo 1 punto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtCopagoVariable_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // solo 1 punto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtPagoFarmacia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // solo 1 punto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
