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

namespace Romsoft.GESTIONCLINICA.Presentacion.ModuloAdmision.Profesional
{
    public partial class frmNuevoProfesional : Form
    {
        public EstadoActual estadoActual;

        public frmNuevoProfesional()
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

            if (string.IsNullOrEmpty(this.txtApellidos.Text))
            {
                this.errValidator.SetError(this.txtApellidos, "Ingresar Apellidos.");
                result = false;
            }
            else
            {
                this.errValidator.SetError(this.txtApellidos, string.Empty);
            }
            if (string.IsNullOrEmpty(this.txtNombres.Text))
            {
                this.errValidator.SetError(this.txtNombres, "Ingresar Nombres.");
                result = false;
            }
            else
            {
                this.errValidator.SetError(this.txtApellidos, string.Empty);
            }
            if (string.IsNullOrEmpty(this.cmbEspecialidad.Text))
            {
                this.errValidator.SetError(this.cmbEspecialidad, "Ingresar Especialidad.");
                result = false;
            }
            else
            {
                this.errValidator.SetError(this.cmbEspecialidad, string.Empty);
            }
            if (string.IsNullOrEmpty(this.cmbTipoProfesional.Text))
            {
                this.errValidator.SetError(this.cmbTipoProfesional, "Ingresar Tipo Profesional.");
                result = false;
            }
            else
            {
                this.errValidator.SetError(this.cmbTipoProfesional, string.Empty);
            }
            if (string.IsNullOrEmpty(this.cmbCondicion.Text))
            {
                this.errValidator.SetError(this.cmbCondicion, "Ingresar Condición.");
                result = false;
            }
            else
            {
                this.errValidator.SetError(this.cmbCondicion, string.Empty);
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
            //if (cmbEstado.Text == "Inactivo")
            //{
            //    this.estadoActual = EstadoActual.Eliminar;
            //}

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
                        jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_ADM_PROFESIONAL_Add, GetProfesional(), ConstantesWindows.METHODPOST);
                        break;
                    case EstadoActual.Editar:
                        jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_ADM_PROFESIONAL_Update, GetProfesional(), ConstantesWindows.METHODPOST);
                        break;
                    case EstadoActual.Eliminar:
                        jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_ADM_PROFESIONAL_Delete, new ADM_PROFESIONALDTO { id_profesional = Convert.ToInt32(this.txtIdProfesional.Text), UsuarioCreacion = WindowsSession.UsuarioActual, IdUsuarioActual = WindowsSession.UserIdActual }, ConstantesWindows.METHODPOST);
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

        //private void frmNuevoCategoriaPago_Paint(object sender, PaintEventArgs e)
        //{
        //    //cambia Color de borde  a los controles
        //    string colorBordeControl = ConstantesWindows.ColorBodeControles;

        //    int AnchoBorde = 2;
        //    Pen ColorBorde = new Pen(Color.RoyalBlue); // Esto puede venir de una variable si necesitas un color cambiante
        //    e.Graphics.DrawRectangle(ColorBorde, panel1.Left - 1, panel1.Top - 1, panel1.Width + 1, panel1.Height + 1);
        //}

        private void frmNuevoCategoriaPago_Load(object sender, EventArgs e)
        {


           txtIdProfesional.Text = ComunFilter.cp_id_categoria_pago.ToString();

            //ClearControls();
            //CargarComboEstado();
            
            // Valida id para evaluar si es Nuevo o Actualización
            if (txtIdProfesional.Text == "0")
            {
                txtIdProfesional.Text = "0";
                this.estadoActual = EstadoActual.Nuevo;
                lblTituloUuario.Text = "Nuevo Profesional";

                cmbEstado.Text = "";
            }
            else
            {
                this.estadoActual = EstadoActual.Editar;
                lblTituloUuario.Text = "Actualiza Datos Profesional";
                
                GetDatosProfesional();
            }

        }


        //Lista Estados
        //private void CargarComboEstado()
        //{
        //    try
        //    {
        //        var jsonResponse = new JsonResponse { Success = false };
        //        jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_Estado_GetAllFilters, new TIPO_ESTADODTO { tabla = "Todos" }, ConstantesWindows.METHODPOST);

        //        if (jsonResponse.Success && !jsonResponse.Warning)
        //        {
        //            var estadoListDTO = (List<TIPO_ESTADODTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<TIPO_ESTADODTO>()).GetType());
        //            cmbEstado.ValueMember = "Id_estado";
        //            cmbEstado.DisplayMember = "estado";
        //            cmbEstado.DataSource = estadoListDTO;
        //        }
        //        else if (jsonResponse.Warning)
        //        {
        //            Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, jsonResponse.Message);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, ex.Message);
        //    }
        //}

        //Obtiene datos por el id
        //private void GetDatosCategoriaPago()
        //{
        //    if (txtIdCategoria.Text != "0")
        //    {

        //        var jsonResponse = new JsonResponse { Success = false };

        //        jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_CVN_CATEGORIA_PAGO_GetById, GetCategoriaPago(), ConstantesWindows.METHODPOST);

        //        if (jsonResponse.Success && !jsonResponse.Warning)
        //        {
        //            var catpagoListDTO = (List<ADM_PROFESIONALDTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<ADM_PROFESIONALDTO>()).GetType());
        //            //this.ETUsuariobindingSource.DataSource = usuarioListDTO;
        //            //--------------------------

        //            for (int i = 0; i < catpagoListDTO.Count; i++)
        //            {
        //                txtCodigo.Text = string.IsNullOrEmpty(catpagoListDTO[i].c_codigo) ? string.Empty : catpagoListDTO[i].c_codigo.ToString();
        //              //  txtDescripcionEsp.Text = string.IsNullOrEmpty(catpagoListDTO[i].t_descripcion) ? string.Empty : catpagoListDTO[i].t_descripcion.ToString();
        //                txtObservacion.Text = string.IsNullOrEmpty(catpagoListDTO[i].t_observacion) ? string.Empty : catpagoListDTO[i].t_observacion.ToString();
        //              //  dtFechaInicio.Text = catpagoListDTO[i].d_fecha_i_vigencia.ToString();
        //             //   dtFechaFin.Text = catpagoListDTO[i].d_fecha_f_vigencia.ToString();
        //             //   txtServicio.Text = catpagoListDTO[i].n_factor_servicio.ToString();
        //            //    txtProcedimiento.Text = catpagoListDTO[i].n_factor_procedimiento.ToString();
        //             //   txtFarmacia.Text = catpagoListDTO[i].n_dscto_farmacia.ToString();
        //                cmbEstado.SelectedValue = Convert.ToInt32(catpagoListDTO[i].f_estado.ToString());

        //            }
        //        }
        //        else if (jsonResponse.Warning)
        //        {
        //            Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, jsonResponse.Message);
        //        }
        //    }
        //}

        //Asigna datos para registro/ctualizar
        private ADM_PROFESIONALDTO GetProfesional()
        {
            var d = Convert.ToInt32(txtIdProfesional.Text);
            return new ADM_PROFESIONALDTO
            {
                id_profesional = Convert.ToInt32(txtIdProfesional.Text),
                c_codigo = txtCodigo.Text.Trim(),
                t_apellidos = txtApellidos.Text.Trim(),
                t_nombres = txtNombres.Text.Trim(),
                t_medico = txtProfesional.Text.Trim(),
                t_direccion = txtDireccion.Text.Trim(),
                t_observacion = txtObservacion.Text.Trim(),
                d_fecha_nace = dtpFechaNac.Value,
                id_genero = Convert.ToInt32(cmbSexo.SelectedValue),
                id_tipo_documento = Convert.ToInt32(cmbDocumentoIdentidad.SelectedValue),
                c_numero_documento = txtNumeroDocumento.Text.Trim(),
                id_especialidad = Convert.ToInt32(cmbEspecialidad.SelectedValue),
                c_nro_especialidad = txtNumeroEspecialidad.Text.Trim(),
                id_tipo_profesional = Convert.ToInt32(cmbTipoProfesional.SelectedValue),
                c_colegiatura = txtNumeroColegiatura.Text.Trim(),
                id_condicion_profesional = Convert.ToInt32(cmbCondicion.SelectedValue),
                c_telefono_1 = txtTelefono1.Text.Trim(),
                c_telefono_2 = txtTelefono2.Text.Trim(),
                f_estado = Convert.ToInt32(cmbEstado.SelectedValue),
                id_user_modifica = WindowsSession.UserIdActual,
                id_user_registro = WindowsSession.UserIdActual,
                d_fecha_modifica = DateTime.Now,
                d_fecha_registro = DateTime.Now
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

        private void frmNuevoProfesional_Paint(object sender, PaintEventArgs e)
        {
            //cambia Color de borde  a los controles
            string colorBordeControl = ConstantesWindows.ColorBodeControles;

            int AnchoBorde = 2;
            Pen ColorBorde = new Pen(Color.RoyalBlue); // Esto puede venir de una variable si necesitas un color cambiante
            e.Graphics.DrawRectangle(ColorBorde, panel1.Left - 1, panel1.Top - 1, panel1.Width + 1, panel1.Height + 1);

        }

        private void frmNuevoProfesional_Load(object sender, EventArgs e)
        {

            txtIdProfesional.Text = ComunFilter.profesional_id.ToString();

            //ClearControls();
            CargarComboEstado();
            CargarComboSexo();
            CargarComboDocumento();
            CargarComboEspecialidad();
            CargarComboTipoProfesional();
            CargarComboCondicionProfesional();
            // Valida id para evaluar si es Nuevo o Actualización
            if (txtIdProfesional.Text == "0")
            {
                txtIdProfesional.Text = "0";
                this.estadoActual = EstadoActual.Nuevo;
                cmbEstado.Text = "";
            }
            else
            {
                this.estadoActual = EstadoActual.Editar;
                GetDatosProfesional();
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

        private void CargarComboSexo()
        {
            try
            {
                var jsonResponse = new JsonResponse { Success = false };
                jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_ADM_GENEROL_GetAllActives, new ADM_GENERODTO {}, ConstantesWindows.METHODPOST);

                if (jsonResponse.Success && !jsonResponse.Warning)
                {
                    var generoListDTO = (List<ADM_GENERODTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<ADM_GENERODTO>()).GetType());
                    cmbSexo.ValueMember = "id_genero";
                    cmbSexo.DisplayMember = "t_descripcion";
                    cmbSexo.DataSource = generoListDTO;
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

        private void CargarComboDocumento()
        {
            try
            {
                var jsonResponse = new JsonResponse { Success = false };
                jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_ADM_DOCUMENTO_IDENTIDAD_GetAllActives, new ADM_DOCUMENTO_IDENTIDADDTO { }, ConstantesWindows.METHODPOST);

                if (jsonResponse.Success && !jsonResponse.Warning)
                {
                    var documentoListDTO = (List<ADM_DOCUMENTO_IDENTIDADDTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<ADM_DOCUMENTO_IDENTIDADDTO>()).GetType());
                    cmbDocumentoIdentidad.ValueMember = "id_documento_identidad";
                    cmbDocumentoIdentidad.DisplayMember = "t_descripcion";
                    cmbDocumentoIdentidad.DataSource = documentoListDTO;
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

        private void CargarComboEspecialidad()
        {
            try
            {
                var jsonResponse = new JsonResponse { Success = false };
                jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_ADM_ESPECIALIDAD_GetAllActives, new ADM_ESPECIALIDADDTO { }, ConstantesWindows.METHODPOST);

                if (jsonResponse.Success && !jsonResponse.Warning)
                {
                    var especialidadListDTO = (List<ADM_ESPECIALIDADDTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<ADM_ESPECIALIDADDTO>()).GetType());
                    cmbEspecialidad.ValueMember = "id_especialidad";
                    cmbEspecialidad.DisplayMember = "t_descripcion";
                    cmbEspecialidad.DataSource = especialidadListDTO;
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

        private void CargarComboTipoProfesional()
        {
            try
            {
                var jsonResponse = new JsonResponse { Success = false };
                jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_ADM_TIPO_PROFESIONAL_GetAllActives, new ADM_TIPO_PROFESIONALDTO { }, ConstantesWindows.METHODPOST);

                if (jsonResponse.Success && !jsonResponse.Warning)
                {
                    var tipoprofListDTO = (List<ADM_TIPO_PROFESIONALDTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<ADM_TIPO_PROFESIONALDTO>()).GetType());
                    cmbTipoProfesional.ValueMember = "id_tipo_profesional";
                    cmbTipoProfesional.DisplayMember = "t_descripcion";
                    cmbTipoProfesional.DataSource = tipoprofListDTO;
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

        private void CargarComboCondicionProfesional()
        {
            try
            {
                var jsonResponse = new JsonResponse { Success = false };
                jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_ADM_CONDICION_PROFESIONAL_GetAllActives, new ADM_CONDICION_PROFESIONALDTO { }, ConstantesWindows.METHODPOST);

                if (jsonResponse.Success && !jsonResponse.Warning)
                {
                    var condprofListDTO = (List<ADM_CONDICION_PROFESIONALDTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<ADM_CONDICION_PROFESIONALDTO>()).GetType());
                    cmbCondicion.ValueMember = "id_condicion_profesional";
                    cmbCondicion.DisplayMember = "t_descripcion";
                    cmbCondicion.DataSource = condprofListDTO;
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
        private void GetDatosProfesional()
        {
            if (txtIdProfesional.Text != "0")
            {

                var jsonResponse = new JsonResponse { Success = false };

                jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_ADM_PROFESIONAL_GetById, GetProfesional(), ConstantesWindows.METHODPOST);

                if (jsonResponse.Success && !jsonResponse.Warning)
                {
                    var ProfListDTO = (List<ADM_PROFESIONALDTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<ADM_PROFESIONALDTO>()).GetType());
                    //this.ETUsuariobindingSource.DataSource = usuarioListDTO;
                    //--------------------------

                    for (int i = 0; i < ProfListDTO.Count; i++)
                    {
                        txtCodigo.Text = string.IsNullOrEmpty(ProfListDTO[i].c_codigo) ? string.Empty : ProfListDTO[i].c_codigo.ToString();
                        txtApellidos.Text = string.IsNullOrEmpty(ProfListDTO[i].t_apellidos) ? string.Empty : ProfListDTO[i].t_apellidos.ToString();
                        txtNombres.Text = string.IsNullOrEmpty(ProfListDTO[i].t_nombres) ? string.Empty : ProfListDTO[i].t_nombres.ToString();
                        txtProfesional.Text = string.IsNullOrEmpty(ProfListDTO[i].t_medico) ? string.Empty : ProfListDTO[i].t_medico.ToString();
                        txtDireccion.Text = string.IsNullOrEmpty(ProfListDTO[i].t_direccion) ? string.Empty : ProfListDTO[i].t_direccion.ToString();
                        dtpFechaNac.Text = ProfListDTO[i].d_fecha_nace.ToString();
                        cmbSexo.SelectedValue = Convert.ToInt32(ProfListDTO[i].id_genero.ToString());
                        cmbDocumentoIdentidad.SelectedValue = Convert.ToInt32(ProfListDTO[i].id_tipo_documento.ToString());
                        txtNumeroDocumento.Text = string.IsNullOrEmpty(ProfListDTO[i].c_numero_documento) ? string.Empty : ProfListDTO[i].c_numero_documento.ToString();
                        cmbEspecialidad.SelectedValue = Convert.ToInt32(ProfListDTO[i].id_especialidad.ToString());
                        txtNumeroEspecialidad.Text = string.IsNullOrEmpty(ProfListDTO[i].c_nro_especialidad) ? string.Empty : ProfListDTO[i].c_nro_especialidad.ToString();
                        cmbTipoProfesional.SelectedValue = Convert.ToInt32(ProfListDTO[i].id_tipo_profesional.ToString());
                        txtNumeroColegiatura.Text = string.IsNullOrEmpty(ProfListDTO[i].c_colegiatura) ? string.Empty : ProfListDTO[i].c_colegiatura.ToString();
                        cmbCondicion.SelectedValue = Convert.ToInt32(ProfListDTO[i].id_condicion_profesional.ToString());
                        txtTelefono1.Text = string.IsNullOrEmpty(ProfListDTO[i].c_telefono_1) ? string.Empty : ProfListDTO[i].c_telefono_1.ToString();
                        txtTelefono2.Text = string.IsNullOrEmpty(ProfListDTO[i].c_telefono_2) ? string.Empty : ProfListDTO[i].c_telefono_2.ToString();
                        cmbEstado.SelectedValue = Convert.ToInt32(ProfListDTO[i].f_estado.ToString());
                        txtObservacion.Text = string.IsNullOrEmpty(ProfListDTO[i].t_observacion) ? string.Empty : ProfListDTO[i].t_observacion.ToString();
                    }
                }
                else if (jsonResponse.Warning)
                {
                    Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, jsonResponse.Message);
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

      
    }
}
