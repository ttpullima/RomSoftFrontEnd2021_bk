using Romsoft.GESTIONCLINICA.Common;
using Romsoft.GESTIONCLINICA.Presentacion.ApiService;
using Romsoft.GESTIONCLINICA.Presentacion.Utilities;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.CVN_CATEGORIA_PAGO;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.TIPO_ESTADO;
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

namespace Romsoft.GESTIONCLINICA.Presentacion.ModuloConvenios.CategoriaPago
{
    public partial class frmNuevoCategoriaPago : Form
    {
        public EstadoActual estadoActual;

        public frmNuevoCategoriaPago()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                if (SaveData())
                {
                    this.estadoActual = EstadoActual.Normal;
                }
            }
        }

        private bool ValidateData()
        {
            bool result = true;

            if (string.IsNullOrEmpty(this.txtCodigo.Text))
            {
                this.errValidator.SetError(this.txtCodigo, "Ingresar Código.");
                result = false;
            }
            else
            {
                this.errValidator.SetError(this.txtCodigo, string.Empty);
            }

            if (string.IsNullOrEmpty(this.txtDescripcionEsp.Text))
            {
                this.errValidator.SetError(this.txtDescripcionEsp, "Ingresar Descripción.");
                result = false;
            }
            else
            {
                this.errValidator.SetError(this.txtDescripcionEsp, string.Empty);
            }

            if (string.IsNullOrEmpty(this.txtServicio.Text))
            {
                this.errValidator.SetError(this.txtServicio, "Ingresar valor servicio.");
                result = false;
            }
            else
            {
                this.errValidator.SetError(this.txtServicio, string.Empty);
            }

            if (string.IsNullOrEmpty(this.cmbEstado.Text))
            {
                this.errValidator.SetError(this.cmbEstado, "Ingresar Estado.");
                result = false;
            }
            else
            {
                this.errValidator.SetError(this.cmbEstado, string.Empty);
            }


            // Para Anular el registro
            if (cmbEstado.Text == "Inactivo")
            {
                this.estadoActual = EstadoActual.Eliminar;
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
                        jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_CVN_CATEGORIA_PAGO_Add, GetCategoriaPago(), ConstantesWindows.METHODPOST);
                        break;
                    case EstadoActual.Editar:
                        jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_CVN_CATEGORIA_PAGO_Update, GetCategoriaPago(), ConstantesWindows.METHODPOST);
                        break;
                    case EstadoActual.Eliminar:
                        jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_CVN_CATEGORIA_PAGO_Delete, new CVN_CATEGORIA_PAGODTO { id_categoria_pago = Convert.ToInt32(this.txtIdCategoria.Text), UsuarioCreacion = WindowsSession.UsuarioActual, IdUsuarioActual = WindowsSession.UserIdActual }, ConstantesWindows.METHODPOST);
                        break;
                }

                if (jsonResponse.Success)
                {
                    if (jsonResponse.Warning)
                    {
                        result = false;
                        Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, jsonResponse.Message);
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
                    Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, jsonResponse.Message);
                    DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, ex.Message);
            }
            return result;
        }




        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void frmNuevoCategoriaPago_Paint(object sender, PaintEventArgs e)
        {
            //cambia Color de borde  a los controles
            string colorBordeControl = ConstantesWindows.ColorBodeControles;

            int AnchoBorde = 2;
            Pen ColorBorde = new Pen(Color.RoyalBlue); // Esto puede venir de una variable si necesitas un color cambiante
            e.Graphics.DrawRectangle(ColorBorde, panel1.Left - 1, panel1.Top - 1, panel1.Width + 1, panel1.Height + 1);
        }

        private void frmNuevoCategoriaPago_Load(object sender, EventArgs e)
        {


           txtIdCategoria.Text = ComunFilter.cp_id_categoria_pago.ToString();

            //ClearControls();
            CargarComboEstado();
            
            // Valida id para evaluar si es Nuevo o Actualización
            if (txtIdCategoria.Text == "0")
            {
                txtIdCategoria.Text = "0";
                this.estadoActual = EstadoActual.Nuevo;
                cmbEstado.Text = "";
            }
            else
            {
                this.estadoActual = EstadoActual.Editar;
                GetDatosCategoriaPago();
            }

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

        //Obtiene datos por el id
        private void GetDatosCategoriaPago()
        {
            if (txtIdCategoria.Text != "0")
            {

                var jsonResponse = new JsonResponse { Success = false };

                jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_CVN_CATEGORIA_PAGO_GetById, GetCategoriaPago(), ConstantesWindows.METHODPOST);

                if (jsonResponse.Success && !jsonResponse.Warning)
                {
                    var catpagoListDTO = (List<CVN_CATEGORIA_PAGODTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<CVN_CATEGORIA_PAGODTO>()).GetType());
                    //this.ETUsuariobindingSource.DataSource = usuarioListDTO;
                    //--------------------------

                    for (int i = 0; i < catpagoListDTO.Count; i++)
                    {
                        txtCodigo.Text = string.IsNullOrEmpty(catpagoListDTO[i].c_codigo) ? string.Empty : catpagoListDTO[i].c_codigo.ToString();
                        txtDescripcionEsp.Text = string.IsNullOrEmpty(catpagoListDTO[i].t_descripcion) ? string.Empty : catpagoListDTO[i].t_descripcion.ToString();
                        txtObservacion.Text = string.IsNullOrEmpty(catpagoListDTO[i].t_observacion) ? string.Empty : catpagoListDTO[i].t_observacion.ToString();
                        dtFechaInicio.Text = catpagoListDTO[i].d_fecha_i_vigencia.ToString();
                        dtFechaFin.Text = catpagoListDTO[i].d_fecha_f_vigencia.ToString();
                        txtServicio.Text = catpagoListDTO[i].n_factor_servicio.ToString();
                        txtProcedimiento.Text = catpagoListDTO[i].n_factor_procedimiento.ToString();
                        txtFarmacia.Text = catpagoListDTO[i].n_dscto_farmacia.ToString();
                        cmbEstado.SelectedValue = Convert.ToInt32(catpagoListDTO[i].f_estado.ToString());

                    }
                }
                else if (jsonResponse.Warning)
                {
                    Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, jsonResponse.Message);
                }
            }
        }

        //Asigna datos para registro/ctualizar
        private CVN_CATEGORIA_PAGODTO GetCategoriaPago()
        {

            return new CVN_CATEGORIA_PAGODTO
            {
                ///
                id_categoria_pago = Convert.ToInt32(txtIdCategoria.Text),
                c_codigo = txtCodigo.Text.Trim(),
                t_observacion = txtObservacion.Text.Trim(),
                t_descripcion = txtDescripcionEsp.Text.Trim(),
                d_fecha_i_vigencia = dtFechaInicio.Value,
                d_fecha_f_vigencia = dtFechaFin.Value,
                n_factor_servicio = Convert.ToDecimal(txtServicio.Text),
                n_factor_procedimiento = Convert.ToDecimal(txtProcedimiento.Text),
                n_dscto_farmacia = Convert.ToDecimal(txtFarmacia.Text),
                f_estado = Convert.ToInt32(cmbEstado.SelectedValue),
                UsuarioCreacion = WindowsSession.UsuarioActual,
                UsuarioModificacion = WindowsSession.UsuarioActual,
                IdUsuarioActual = WindowsSession.UserIdActual,
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now
            };
        }

        private void txtServicio_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtProcedimiento_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtFarmacia_KeyPress(object sender, KeyPressEventArgs e)
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
