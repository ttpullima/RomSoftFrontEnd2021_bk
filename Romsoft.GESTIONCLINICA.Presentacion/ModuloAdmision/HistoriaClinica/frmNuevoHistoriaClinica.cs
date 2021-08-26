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
using Romsoft.GESTIONCLINICA.DTO.TABLAS.ADM_ESTADO_CIVIL;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.ADM_GRUPO_SANGUINEO;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.ADM_OCUPACION;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.ADM_PACIENTE;

namespace Romsoft.GESTIONCLINICA.Presentacion.ModuloAdmision.HistoriaClinica
{
    public partial class frmNuevoHistoriaClinica : Form
    {
        public EstadoActual estadoActual;
        public frmNuevoHistoriaClinica()
        {
            InitializeComponent();
        }


        private void CargarComboSexo()
        {
            try
            {
                var jsonResponse = new JsonResponse { Success = false };
                jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_ADM_GENEROL_GetAllActives, new ADM_GENERODTO { }, ConstantesWindows.METHODPOST);

                if (jsonResponse.Success && !jsonResponse.Warning)
                {
                    var generoListDTO = (List<ADM_GENERODTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<ADM_GENERODTO>()).GetType());
                    cboSexo.ValueMember = "id_genero";
                    cboSexo.DisplayMember = "t_descripcion";
                    cboSexo.DataSource = generoListDTO;
                    cboSexo.SelectedValue = -1;
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
                    cboTDocumento.ValueMember = "id_documento_identidad";
                    cboTDocumento.DisplayMember = "t_descripcion";
                    cboTDocumento.DataSource = documentoListDTO;
                    cboTDocumento.SelectedValue = -1;
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

        private void CargarComboEstadoCivil()
        {
            try
            {
                var jsonResponse = new JsonResponse { Success = false };
                jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_ADM_ESTADO_CIVIL_GetAllActives, new ADM_ESTADO_CIVILDTO { }, ConstantesWindows.METHODPOST);

                if (jsonResponse.Success && !jsonResponse.Warning)
                {
                    var estadocivilListDTO = (List<ADM_ESTADO_CIVILDTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<ADM_ESTADO_CIVILDTO>()).GetType());
                    cboEstadoCivil.ValueMember = "id_estado_civil";
                    cboEstadoCivil.DisplayMember = "t_descripcion";
                    cboEstadoCivil.DataSource = estadocivilListDTO;
                    cboEstadoCivil.SelectedValue = -1;
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

        private void CargarComboGrupoSanguineo()
        {
            try
            {
                var jsonResponse = new JsonResponse { Success = false };
                jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_ADM_GRUPO_SANGUINEO_GetAllActives, new ADM_ESTADO_CIVILDTO { }, ConstantesWindows.METHODPOST);

                if (jsonResponse.Success && !jsonResponse.Warning)
                {
                    var gruposanguineoListDTO = (List<ADM_GRUPO_SANGUINEODTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<ADM_GRUPO_SANGUINEODTO>()).GetType());
                    cboGrupoSanguineo.ValueMember = "id_grupo_sanguineo";
                    cboGrupoSanguineo.DisplayMember = "t_descripcion";
                    cboGrupoSanguineo.DataSource = gruposanguineoListDTO;
                    cboGrupoSanguineo.SelectedValue = -1;
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

        private void CargarComboOcupacion()
        {
            try
            {
                var jsonResponse = new JsonResponse { Success = false };
                jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_Ocupacion_GetAllActives, new ADM_OCUPACIONDTO { }, ConstantesWindows.METHODPOST);

                if (jsonResponse.Success && !jsonResponse.Warning)
                {
                    var ocupacionListDTO = (List<ADM_OCUPACIONDTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<ADM_OCUPACIONDTO>()).GetType());
                    cboOcupacion.ValueMember = "id_ocupacion";
                    cboOcupacion.DisplayMember = "t_descripcion";
                    cboOcupacion.DataSource = ocupacionListDTO;
                    cboOcupacion.SelectedValue = -1;
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

            if (string.IsNullOrEmpty(this.txtAPaterno.Text))
            {
                this.errValidator.SetError(this.txtAPaterno, "Ingresar Apellido Paterno.");
                result = false;
            }
            else
            {
                this.errValidator.SetError(this.txtAPaterno, string.Empty);
            }

            if (string.IsNullOrEmpty(this.txtAMaterno.Text))
            {
                this.errValidator.SetError(this.txtAMaterno, "Ingresar Apellido Materno.");
                result = false;
            }
            else
            {
                this.errValidator.SetError(this.txtAMaterno, string.Empty);
            }

            if (string.IsNullOrEmpty(this.txtNombres.Text))
            {
                this.errValidator.SetError(this.txtNombres, "Ingresar Nombre.");
                result = false;
            }
            else
            {
                this.errValidator.SetError(this.txtNombres, string.Empty);
            }

            if (string.IsNullOrEmpty(this.cboSexo.Text))
            {
                this.errValidator.SetError(this.cboSexo, "Ingresar Sexo.");
                result = false;
            }
            else
            {
                this.errValidator.SetError(this.cboSexo, string.Empty);
            }


            if (string.IsNullOrEmpty(this.cboEstadoCivil.Text))
            {
                this.errValidator.SetError(this.cboEstadoCivil, "Ingresar Estado Civil");
                result = false;
            }
            else
            {
                this.errValidator.SetError(this.cboEstadoCivil, string.Empty);
            }

            if (string.IsNullOrEmpty(this.cboTDocumento.Text))
            {
                this.errValidator.SetError(this.cboTDocumento, "Ingresar Tipo de Documento");
                result = false;
            }
            else
            {
                this.errValidator.SetError(this.cboTDocumento, string.Empty);
            }

            if (string.IsNullOrEmpty(this.txtNumeroDocumento.Text))
            {
                this.errValidator.SetError(this.txtNumeroDocumento, "Ingresar Nro de Documento.");
                result = false;
            }
            else
            {
                this.errValidator.SetError(this.txtNumeroDocumento, string.Empty);
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
                        jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_ADM_PACIENTE_Add, GetPaciente(), ConstantesWindows.METHODPOST);
                        break;
                    case EstadoActual.Editar:
                        jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_ADM_PACIENTE_Update, GetPaciente(), ConstantesWindows.METHODPOST);
                        break;
                    case EstadoActual.Eliminar:
                        //jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_ADM_PACIENTE_Delete, new ADM_PACIENTEDTO { id_plan_seguro = Convert.ToInt32(this.txtplanSegus.Text), UsuarioCreacion = WindowsSession.UsuarioActual }, ConstantesWindows.METHODPOST);
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



        private void frmHistoriaClinica_Load(object sender, EventArgs e)
        {
            lblHistoriaClinica.Text = ComunFilter.f_NumHistoriaClinica.ToString();
            CargarComboSexo();
            CargarComboDocumento();
            CargarComboEstadoCivil();
            CargarComboGrupoSanguineo();
            CargarComboOcupacion();

            // Valida id para evaluar si es Nuevo o Actualización
            if (lblHistoriaClinica.Text == "" || lblHistoriaClinica.Text == "0")
            {
                this.estadoActual = EstadoActual.Nuevo;
                ComunFilter.f_id_paciente = 0;
                lblHistoriaClinica.Text = "0";
                this.estadoActual = EstadoActual.Nuevo;
                lblTituloPaciente.Text = "Agregar Historia Clínica";


                //cmbEstado.Text = "";
                cboSexo.Text = "";
                cboTDocumento.Text = "";
                cboEstadoCivil.Text = "";
                cboGrupoSanguineo.Text = "";
                cboOcupacion.Text = "";

            }
            else
            {

                this.estadoActual = EstadoActual.Editar;
                lblTituloPaciente.Text = "Consultar Modificar Historia Clínica";

                //btnNuevo.Visible = true;

                //Consulta por ID
                GetDatosPaciente();

                int edad = ValidationManager.CalcularEdad(dtFechaNacimiento.Value, DateTime.Now);
                txtEdad.Text = edad.ToString();

            }

        }

        //Obtiene datos por el ID Paciente
        private void GetDatosPaciente()
        {
            if (lblHistoriaClinica.Text != "" || lblHistoriaClinica.Text != "0")
            {

                var jsonResponse = new JsonResponse { Success = false };

                //Consulta Cabecera
                jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_ADM_PACIENTE_GetById, GetPaciente(), ConstantesWindows.METHODPOST);

                if (jsonResponse.Success && !jsonResponse.Warning)
                {
                    var pacienteListDTO = (List<ADM_PACIENTEDTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<ADM_PACIENTEDTO>()).GetType());
                    //this.ETUsuariobindingSource.DataSource = usuarioListDTO;
                    //--------------------------

                    for (int i = 0; i < pacienteListDTO.Count; i++)
                    {
                        txtAPaterno.Text = string.IsNullOrEmpty(pacienteListDTO[i].t_apellido_paterno) ? string.Empty : pacienteListDTO[i].t_apellido_paterno.ToString();
                        txtAMaterno.Text = string.IsNullOrEmpty(pacienteListDTO[i].t_apellido_materno) ? string.Empty : pacienteListDTO[i].t_apellido_materno.ToString();
                        txtNombres.Text = string.IsNullOrEmpty(pacienteListDTO[i].t_nombres) ? string.Empty : pacienteListDTO[i].t_nombres.ToString();
                        dtFechaNacimiento.Text = pacienteListDTO[i].d_fecha_nacimiento.ToString();
                        cboSexo.SelectedValue = Convert.ToInt32(pacienteListDTO[i].id_genero.ToString());
                        cboEstadoCivil.SelectedValue = Convert.ToInt32(pacienteListDTO[i].id_estado_civil.ToString());
                        cboTDocumento.SelectedValue = Convert.ToInt32(pacienteListDTO[i].id_documento_identidad.ToString());
                        txtNumeroDocumento.Text = string.IsNullOrEmpty(pacienteListDTO[i].c_documento_identidad) ? string.Empty : pacienteListDTO[i].c_documento_identidad.ToString();
                        txtEdad.Text = "0";
                        cboGrupoSanguineo.SelectedValue = Convert.ToInt32(pacienteListDTO[i].id_grupo_sanguineo.ToString());
                        cboOcupacion.SelectedValue = Convert.ToInt32(pacienteListDTO[i].id_ocupacion.ToString());
                        txtReferenciaOcupacion.Text = string.IsNullOrEmpty(pacienteListDTO[i].t_ocupacion) ? string.Empty : pacienteListDTO[i].t_ocupacion.ToString();
                        txtEmail.Text = string.IsNullOrEmpty(pacienteListDTO[i].t_email_paciente) ? string.Empty : pacienteListDTO[i].t_email_paciente.ToString();
                        txtTelefonoCasa.Text = string.IsNullOrEmpty(pacienteListDTO[i].c_p_fono_casa) ? string.Empty : pacienteListDTO[i].c_p_fono_casa.ToString();
                        txtCelularCorporativo.Text = string.IsNullOrEmpty(pacienteListDTO[i].c_p_fono_corporativo) ? string.Empty : pacienteListDTO[i].c_p_fono_corporativo.ToString();
                        txtCelularPersonal.Text = string.IsNullOrEmpty(pacienteListDTO[i].c_p_fono_personal) ? string.Empty : pacienteListDTO[i].c_p_fono_personal.ToString();
                        txtNacimiento.Text = string.IsNullOrEmpty(pacienteListDTO[i].des_ubigeo_nacimiento) ? string.Empty : pacienteListDTO[i].des_ubigeo_nacimiento.ToString();
                        ComunFilter.f_idUbigeoNacimiento = Convert.ToInt32(pacienteListDTO[i].id_ubigeo_nacimiento.ToString());
                        txtdomicilio.Text = string.IsNullOrEmpty(pacienteListDTO[i].des_ubigeo_domicilio) ? string.Empty : pacienteListDTO[i].des_ubigeo_domicilio.ToString();
                        ComunFilter.f_idUbigeoDomicilio = Convert.ToInt32(pacienteListDTO[i].id_ubigeo_domicilio.ToString());
                        txtReferencia.Text = string.IsNullOrEmpty(pacienteListDTO[i].t_referencia) ? string.Empty : pacienteListDTO[i].t_referencia.ToString();
                        txtDireccion.Text = string.IsNullOrEmpty(pacienteListDTO[i].t_direccion) ? string.Empty : pacienteListDTO[i].t_direccion.ToString();
                        txtResponsable.Text = string.IsNullOrEmpty(pacienteListDTO[i].t_responsable) ? string.Empty : pacienteListDTO[i].t_responsable.ToString();
                        txtResponsableEmail.Text = string.IsNullOrEmpty(pacienteListDTO[i].t_email_responsable) ? string.Empty : pacienteListDTO[i].t_email_responsable.ToString();
                        txtResponsableCasa.Text = string.IsNullOrEmpty(pacienteListDTO[i].c_r_fono_casa) ? string.Empty : pacienteListDTO[i].c_r_fono_casa.ToString();
                        txtResponsableCelular.Text = string.IsNullOrEmpty(pacienteListDTO[i].c_r_fono_personal) ? string.Empty : pacienteListDTO[i].c_r_fono_personal.ToString();
                    }
                }
                else if (jsonResponse.Warning)
                {
                    Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, jsonResponse.Message);
                }


            }

            //if (lblHistoriaClinica.Text != "0")
            //{
            //    this.estadoActual = EstadoActual.Editar;
            //    lblTituloPaciente.Text = ".:: Editar";
            //}


        }

        //Asigna datos para registro/ctualizar
        private ADM_PACIENTEDTO GetPaciente()
        {

            return new ADM_PACIENTEDTO
            {
                id_paciente = Convert.ToInt32(ComunFilter.f_id_paciente),
                n_historia_clinica = Convert.ToInt32(lblHistoriaClinica.Text),
                t_apellido_paterno = txtAPaterno.Text.ToUpper().Trim(),
                t_apellido_materno = txtAMaterno.Text.ToUpper().Trim(),
                t_nombres = txtNombres.Text.ToUpper().Trim(),
                t_paciente = txtAPaterno.Text.ToUpper().Trim() + " " + txtAMaterno.Text.ToUpper().Trim() + " " + txtNombres.Text.ToUpper().Trim(),
                d_fecha_nacimiento = dtFechaNacimiento.Value,
                id_genero = Convert.ToInt32(cboSexo.SelectedValue),
                id_estado_civil = Convert.ToInt32(cboEstadoCivil.SelectedValue),
                id_documento_identidad = Convert.ToInt32(cboTDocumento.SelectedValue),
                c_documento_identidad = txtNumeroDocumento.Text.Trim(),
                id_grupo_sanguineo = Convert.ToInt32(cboGrupoSanguineo.SelectedValue),
                id_ocupacion = Convert.ToInt32(cboOcupacion.SelectedValue),
                t_ocupacion = txtReferenciaOcupacion.Text.ToUpper().Trim(),
                t_email_paciente = txtEmail.Text.ToUpper().Trim(),
                c_p_fono_casa = txtTelefonoCasa.Text.Trim(),
                c_p_fono_personal = txtCelularPersonal.Text.Trim(),
                c_p_fono_corporativo = txtCelularCorporativo.Text.Trim(),
                id_ubigeo_nacimiento = Convert.ToInt32(ComunFilter.f_idUbigeoNacimiento),
                id_ubigeo_domicilio = Convert.ToInt32(ComunFilter.f_idUbigeoDomicilio),
                t_referencia = txtReferencia.Text.ToUpper().Trim(),
                t_direccion = txtDireccion.Text.ToUpper().Trim(),
                t_responsable = txtResponsable.Text.ToUpper().Trim(),
                t_email_responsable = txtResponsableEmail.Text.Trim(),
                c_r_fono_casa = txtResponsableCasa.Text.Trim(),
                c_r_fono_personal = txtResponsableCelular.Text.Trim(),
                f_estado = 1,
                UsuarioCreacion = Convert.ToString(WindowsSession.UserIdActual), //WindowsSession.UsuarioActual,
                UsuarioModificacion = Convert.ToString(WindowsSession.UserIdActual), //WindowsSession.UsuarioActual,
                id_usuarioCreacion = WindowsSession.UserIdActual,
                id_usuarioModifica = WindowsSession.UserIdActual,
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now
            };
        }

        //Asigna datos para consulta dni
        private ADM_PACIENTE_CONSULTADTO GetConsultaDni()
        {
            return new ADM_PACIENTE_CONSULTADTO
            {
                dni = txtNumeroDocumento.Text.Trim()
            };
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUbigeoNacimiento_Click(object sender, EventArgs e)
        {
            ComunFilter.f_tipoUbigeo = 1;

            HistoriaClinica.frmFiltroUbigeo frm = new HistoriaClinica.frmFiltroUbigeo();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtNacimiento.Text = ComunFilter.f_descripcionUbigeo;
            }
        }

        private void btnUbigeoDomicilio_Click(object sender, EventArgs e)
        {
            ComunFilter.f_tipoUbigeo = 2;

            HistoriaClinica.frmFiltroUbigeo frm = new HistoriaClinica.frmFiltroUbigeo();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtdomicilio.Text = ComunFilter.f_descripcionDomicilio;
            }
        }

        private void btnIntegracionSiteds_Click(object sender, EventArgs e)
        {
            string nroDocumento = txtNumeroDocumento.Text.Trim();

            if((cboTDocumento.Text=="DNI") && (nroDocumento.Length==8))
            {
                var jsonResponse = new JsonResponse { Success = false };

                //Consulta Cabecera
                jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_ADM_PACIENTE_GetByDni, GetConsultaDni(), ConstantesWindows.METHODPOST);

                if (jsonResponse.Success && !jsonResponse.Warning)
                {

                    var pacienteListDTO = (ADM_PACIENTE_CONSULTADTO)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new ADM_PACIENTE_CONSULTADTO()).GetType());

                    ////--------------------------
                    if (pacienteListDTO.paterno.ToString().Length > 0)
                    {
                        if (MessageBox.Show("VALIDAR DATOS : " + "\n\n" + "\nApellidos y Nombres: " + pacienteListDTO.paterno + " " + pacienteListDTO.materno + " , " + pacienteListDTO.nombres + "\nDirección: " + pacienteListDTO.domicilio + "\n\n¿Datos son correctos?", "Validación DNI", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            //for (int i = 0; i < pacienteListDTO.Count; i++)
                            //{
                                txtAPaterno.Text = string.IsNullOrEmpty(pacienteListDTO.paterno) ? string.Empty : pacienteListDTO.paterno.ToString();
                                txtAMaterno.Text = string.IsNullOrEmpty(pacienteListDTO.materno) ? string.Empty : pacienteListDTO.materno.ToString();
                                txtNombres.Text = string.IsNullOrEmpty(pacienteListDTO.nombres) ? string.Empty : pacienteListDTO.nombres.ToString();
                                txtDireccion.Text = string.IsNullOrEmpty(pacienteListDTO.domicilio) ? string.Empty : pacienteListDTO.domicilio.ToString();
                            //}
                        }
                    }
                    else
                    {
                        Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, "DNI No existe Servicios.pladdes.org");
                    }


                }
                else if (jsonResponse.Warning)
                {
                    Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, jsonResponse.Message);
                }

            }
        }

        private void btnGuardarAtencion_Click(object sender, EventArgs e)
        {
            this.Close();

            HistoriaClinica.frmAtencion frm = new HistoriaClinica.frmAtencion();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                // 0 = Consulta Todos
                //    InitialLoad(0);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdSeleccionar = new OpenFileDialog();
            ofdSeleccionar.Filter = "Imagenes|*.jpg; *.png";
            ofdSeleccionar.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            ofdSeleccionar.Title = "Seleccionar Imagen";

            if (ofdSeleccionar.ShowDialog() == DialogResult.OK)
            {
                pctFoto.Image = Image.FromFile(ofdSeleccionar.FileName);
            }
        }


        private void dtFechaNacimiento_ValueChanged(object sender, EventArgs e)
        {
            int edad = ValidationManager.CalcularEdad(dtFechaNacimiento.Value, DateTime.Now);
            txtEdad.Text = edad.ToString();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSiteds_Click(object sender, EventArgs e)
        {
            ComunFilter.sit_origenConsulta = "HistoriaClinica"; //para origen de consulta

            HistoriaClinica.frmFiltroSiteds frm = new HistoriaClinica.frmFiltroSiteds();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                // 0 = Consulta Todos
                //    InitialLoad(0);

                if (MessageBox.Show("VALIDAR DATOS : " + "\n\n" + "\nApellidos y Nombres: " + ComunFilter.sit_AP_PATERNO + " " + ComunFilter.sit_AP_MATERNO + " , " + ComunFilter.sit_NOMBRES + "\nFecha Nacimiento: " + ComunFilter.sit_FEC_NACIMIENTO.ToString("dd/MM/yyyy") + "\nNro. Documento: "  + ComunFilter.sit_NUM_DOCUMENTO + "\n\n¿Datos son correctos?", "Validación DNI", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    txtAPaterno.Text = ComunFilter.sit_AP_PATERNO;
                    txtAMaterno.Text = ComunFilter.sit_AP_MATERNO;
                    txtNombres.Text = ComunFilter.sit_NOMBRES;
                    dtFechaNacimiento.Value = ComunFilter.sit_FEC_NACIMIENTO;
                    cboTDocumento.SelectedValue = Convert.ToInt32(ComunFilter.sit_COD_DOCUMENTO.Trim());
                    txtNumeroDocumento.Text = ComunFilter.sit_NUM_DOCUMENTO;
                    //txtEdad.Text = ComunFilter.sit_NUM_EDAD;
                    cboSexo.SelectedValue = Convert.ToInt32(ComunFilter.sit_SEXO);
                }

                

            }
        }
    }
}
