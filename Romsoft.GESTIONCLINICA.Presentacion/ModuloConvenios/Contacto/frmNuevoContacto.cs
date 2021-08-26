using Romsoft.GESTIONCLINICA.Common;
using Romsoft.GESTIONCLINICA.Presentacion.ApiService;
using Romsoft.GESTIONCLINICA.Presentacion.Utilities;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.CON_CONTACTO;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.TIPO_ESTADO;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.CON_TIPO_CONTACTO;
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

namespace Romsoft.GESTIONCLINICA.Presentacion.ModuloConvenios.Contacto
{
    public partial class frmNuevoContacto : Form
    {
        public EstadoActual estadoActual;

        public frmNuevoContacto()
        {
            InitializeComponent();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
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

            if (string.IsNullOrEmpty(this.TxtCodigoSunat.Text))
            {
                this.errValidator.SetError(this.TxtCodigoSunat, "Ingresar Código Identificación");
                result = false;
            }
            else
            {
                this.errValidator.SetError(this.TxtCodigoSunat, string.Empty);
            }

            /*
            if (string.IsNullOrEmpty(this.TxtApellidos.Text))
            {
                this.errValidator.SetError(this.TxtApellidos, "Ingresar Descripción.");
                result = false;
            }
            else
            {
                this.errValidator.SetError(this.TxtApellidos, string.Empty);
            }*/

            if (string.IsNullOrEmpty(this.CbTipoContacto.Text ))
            {
                this.errValidator.SetError(this.CbTipoContacto, "Ingresar El Tipo Contacto.");
                result = false;
            }
            else
            {
                this.errValidator.SetError(this.CbTipoContacto, string.Empty);
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
                        jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_CON_CONTACTO_Add, GetContacto(), ConstantesWindows.METHODPOST);
                        break;
                    case EstadoActual.Editar:
                        jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_CON_CONTACTO_Update, GetContacto(), ConstantesWindows.METHODPOST);
                        break;
                    case EstadoActual.Eliminar:
                        jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_CON_CONTACTO_Delete, new CON_CONTACTODTO { id_contacto = Convert.ToInt32(this.txtId.Text), UsuarioCreacion = WindowsSession.UsuarioActual, IdUsuarioActual = WindowsSession.UserIdActual }, ConstantesWindows.METHODPOST);
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


        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void frmNuevoContacto_Paint(object sender, PaintEventArgs e)
        {
            //cambia Color de borde  a los controles
            string colorBordeControl = ConstantesWindows.ColorBodeControles;

            int AnchoBorde = 2;
            Pen ColorBorde = new Pen(Color.RoyalBlue); // Esto puede venir de una variable si necesitas un color cambiante
            e.Graphics.DrawRectangle(ColorBorde, panel1.Left - 1, panel1.Top - 1, panel1.Width + 1, panel1.Height + 1);
        }

        private void frmNuevoContacto_Load(object sender, EventArgs e)
        {


           txtId.Text = ComunFilter.cp_id_contacto.ToString();

            //ClearControls();
            CargarComboEstado();
            CargarComboTipoContacto();
            // Valida id para evaluar si es Nuevo o Actualización
            if (txtId.Text == "0")
            {
                txtId.Text = "0";
                this.estadoActual = EstadoActual.Nuevo;
                lblTituloUuario.Text = "Agregar";

                cmbEstado.Text = "";
            }
            else
            {
                this.estadoActual = EstadoActual.Editar;
                lblTituloUuario.Text = "Modificar";
                
                GetDatosContacto();
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

        //Lista Estados
        private void CargarComboTipoContacto()
        {
            try
            {
                var jsonResponse = new JsonResponse { Success = false };
                //jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_TipoContacto_GetAllActives, new CON_TIPO_CONTACTODTO { tabla = "Todos" }, ConstantesWindows.METHODPOST);
                jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_TipoContacto_GetAllActives, new CON_TIPO_CONTACTODTO { }, ConstantesWindows.METHODPOST);

                if (jsonResponse.Success && !jsonResponse.Warning)
                {
                    var tipoContactoListDTO = (List<CON_TIPO_CONTACTODTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<CON_TIPO_CONTACTODTO>()).GetType());
                    CbTipoContacto.ValueMember = "id_tipo_contacto";
                    CbTipoContacto.DisplayMember = "t_descripcion";
                    CbTipoContacto.DataSource = tipoContactoListDTO;
                    CbTipoContacto.SelectedIndex = -1;
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
        private void GetDatosContacto()
        {
            if (txtId.Text != "0")
            {

                var jsonResponse = new JsonResponse { Success = false };

                jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_CON_CONTACTO_GetById, GetContactoId(), ConstantesWindows.METHODPOST);

                if (jsonResponse.Success && !jsonResponse.Warning)
                {
                    var contactoListDTO = (List<CON_CONTACTODTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<CON_CONTACTODTO>()).GetType());
                    //this.ETUsuariobindingSource.DataSource = usuarioListDTO;
                    //--------------------------

                    for (int i = 0; i < contactoListDTO.Count; i++)
                    {
                        txtCodigo.Text = string.IsNullOrEmpty(contactoListDTO[i].c_codigo) ? string.Empty : contactoListDTO[i].c_codigo.ToString();
                        int x = contactoListDTO[i].id_tipo_contacto;     //) ? "0" : contactoListDTO[i].id_tipo_contacto.ToString();
                        CbTipoContacto.SelectedValue = Convert.ToInt32(x);
                        TxtCodigoSunat.Text = string.IsNullOrEmpty(contactoListDTO[i].c_codigo_sunat) ? string.Empty : contactoListDTO[i].c_codigo_sunat.ToString();
                        TxtApellidos.Text = string.IsNullOrEmpty(contactoListDTO[i].t_apellidos) ? string.Empty : contactoListDTO[i].t_apellidos.ToString();
                        TxtNombres.Text = string.IsNullOrEmpty(contactoListDTO[i].t_nombres) ? string.Empty : contactoListDTO[i].t_nombres.ToString();
                        TxtRazonSocial.Text = string.IsNullOrEmpty(contactoListDTO[i].t_razon_social) ? string.Empty : contactoListDTO[i].t_razon_social.ToString();
                        TxtRazonComercial.Text = string.IsNullOrEmpty(contactoListDTO[i].t_razon_comercial) ? string.Empty : contactoListDTO[i].t_razon_comercial.ToString();
                        TxtObservacion.Text = string.IsNullOrEmpty(contactoListDTO[i].t_observacion) ? string.Empty : contactoListDTO[i].t_observacion.ToString();
                        TxtDireccion.Text = string.IsNullOrEmpty(contactoListDTO[i].t_direccion) ? string.Empty : contactoListDTO[i].t_direccion.ToString();
                        TxtContacto.Text = string.IsNullOrEmpty(contactoListDTO[i].t_contacto) ? string.Empty : contactoListDTO[i].t_contacto.ToString();
                        TxtActividadEconomica.Text = string.IsNullOrEmpty(contactoListDTO[i].t_actividad_economica) ? string.Empty : contactoListDTO[i].t_actividad_economica.ToString();
                        TxtTelefono1.Text = string.IsNullOrEmpty(contactoListDTO[i].c_telefono1) ? string.Empty : contactoListDTO[i].c_telefono1.ToString();
                        TxtTelefono2.Text = string.IsNullOrEmpty(contactoListDTO[i].c_telefono2) ? string.Empty : contactoListDTO[i].c_telefono2.ToString();
                        TxtEMail.Text = string.IsNullOrEmpty(contactoListDTO[i].t_email_ffee) ? string.Empty : contactoListDTO[i].t_email_ffee.ToString();
                        TxtDiasCredito.Text = contactoListDTO[i].n_dias_credito.ToString();
                        ChkEsGarante.Checked = contactoListDTO[i].n_flag_garante.Equals(1);
                        ChkEsContratante.Checked = contactoListDTO[i].n_flag_contratante.Equals(1);
                        ChkEsProveedor.Checked = contactoListDTO[i].n_flag_proveedor.Equals(1);
                        ChkHabido.Checked = contactoListDTO[i].n_flag_habido.Equals(1);
                        cmbEstado.SelectedValue = Convert.ToInt32(contactoListDTO[i].f_estado.ToString());

                    }
                }
                else if (jsonResponse.Warning)
                {
                    Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, jsonResponse.Message);
                }
            }
        }

        //Asigna datos para registro/ctualizar
        private CON_CONTACTODTO GetContacto()
        {

            return new CON_CONTACTODTO
            {
                ///
                id_contacto = Convert.ToInt32(txtId.Text),
                id_tipo_contacto = Convert.ToInt32(CbTipoContacto.SelectedValue.ToString()),
                c_codigo = txtCodigo.Text.Trim(),
                c_codigo_sunat = TxtCodigoSunat.Text.Trim(),
                t_apellidos = TxtApellidos.Text.ToUpper().Trim(),
                t_nombres = TxtNombres.Text.ToUpper().Trim(),
                t_razon_social = TxtRazonSocial.Text.ToUpper().Trim(),
                t_razon_comercial = TxtRazonComercial.Text.ToUpper().Trim(),
                t_observacion = TxtObservacion.Text.Trim(),
                t_direccion = TxtDireccion.Text.Trim(),
                t_contacto = TxtContacto.Text.Trim(),
                t_actividad_economica = TxtActividadEconomica.Text.Trim(),
                c_telefono1 = TxtTelefono1.Text.Trim(),
                c_telefono2 = TxtTelefono2.Text.Trim(),
                t_email_ffee = TxtEMail.Text.Trim(),
                n_dias_credito = Convert.ToInt32(TxtDiasCredito.Text),
                n_flag_garante = ChkEsGarante.Checked ? 1 : 0 , 
                n_flag_contratante = ChkEsContratante.Checked ? 1 : 0,
                n_flag_proveedor = ChkEsProveedor.Checked ? 1 : 0,
                n_flag_habido = ChkHabido.Checked ? 1 : 0,
                f_estado = Convert.ToInt32(cmbEstado.SelectedValue),
                UsuarioCreacion = WindowsSession.UsuarioActual,        /*WindowsSession.UsuarioActual,*/
                id_usuarioCreacion = WindowsSession.UserIdActual,    /*WindowsSession.UsuarioActual,*/
                IdUsuarioActual = WindowsSession.UserIdActual,
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now
            };
        }

        private CON_CONTACTODTO GetContactoId()
        {

            return new CON_CONTACTODTO
            {
                ///
                id_contacto = Convert.ToInt32(txtId.Text),

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
