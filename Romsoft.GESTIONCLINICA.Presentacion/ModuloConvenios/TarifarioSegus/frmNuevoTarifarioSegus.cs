using Romsoft.GESTIONCLINICA.Common;
using Romsoft.GESTIONCLINICA.Presentacion.ApiService;
using Romsoft.GESTIONCLINICA.Presentacion.Utilities;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.SEG_ROL;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.CVN_TARIFARIO_SEGUS;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.TIPO_ESTADO;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.CVN_CLASIFICACION_SEGUS;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.CVN_CLASIFICACION_SUSALUD;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.CVN_CLASIFICACION_SUSALUD_OD;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.CVN_TIPO_PRECIO;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.CON_CENTRO_COSTO;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.CON_CUENTA_CONTABLE;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.CVN_TARIFARIO_SEGUS_PARTICIPANTE;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.CVN_CATEGORIA_PAGO_PRECIO;
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

namespace Romsoft.GESTIONCLINICA.Presentacion.ModuloConvenios.TarifarioSegus
{
    public partial class frmNuevoTarifarioSegus : Form
    {
        public EstadoActual estadoActual;

        public frmNuevoTarifarioSegus()
        {
            InitializeComponent();
        }

        private void frmTarifarioSegus_Paint(object sender, PaintEventArgs e)
        {
            //cambia Color de borde  a los controles

            int AnchoBorde = 2;
            Pen ColorBorde = new Pen(Color.RoyalBlue); // Esto puede venir de una variable si necesitas un color cambiante
            e.Graphics.DrawRectangle(ColorBorde, panel1.Left - 1, panel1.Top - 1, panel1.Width + 1, panel1.Height + 1);

        }

        private void frmTarifarioSegus_Load(object sender, EventArgs e)
        {

            txtIdTarifa.Text = ComunFilter.f_id_tarifario_segus.ToString();


            //ClearControls();
            CargarComboEstado();
            CargarComboInterna();
            CargarComboSusalud();
            CargarComboSusaludOD();
            CargarComboTipoPrecio();
            CargarComboCentroCosto();
            CargarComboCtaContable();

            // Valida id para evaluar si es Nuevo o Actualización
            if (txtIdTarifa.Text == "0")
            {
                txtIdTarifa.Text = "0";
                this.estadoActual = EstadoActual.Nuevo;
                lblTituloUuario.Text = ".:: Agregar";

                btnNuevo.Visible = false;
                btnNuevoTarifa.Visible = false;

                cmbEstado.Text = "";
                cmbInterna.Text = "";
                cmbSusalud.Text = "";
                cmbOdontologo.Text = "";
                cmbTipoPrecio.Text = "";
                cmbCentroCosto.Text = "";
                cmbContable.Text = "";
            }
            else
            {
                this.estadoActual = EstadoActual.Editar;
                lblTituloUuario.Text = ".:: Editar";

                btnNuevo.Visible = true;
                btnNuevoTarifa.Visible = true;

                //Consulta por ID
                GetDatosTarifa();

            }




        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //Color de Borde De formulario
             //   Rectangle rect = new Rectangle(e.ClipRectangle.X,
               // e.ClipRectangle.Y, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1);
                //e.Graphics.DrawRectangle(Pens.Gray, rect);
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            ClearControls();

        }

        //Lista Estados
        private void CargarComboEstado()
        {
            try
            {
                var jsonResponse = new JsonResponse { Success = false };
                jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_Estado_GetAllFilters, new TIPO_ESTADODTO {tabla="Todos" }, ConstantesWindows.METHODPOST);

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

        
        //Lista Clasificacion
        private void CargarComboInterna()
        {
            try
            {
                var jsonResponse = new JsonResponse { Success = false };
                jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_CVN_CLASIFICACION_SEGUS_GetAllActives, "", ConstantesWindows.METHODPOST);

                if (jsonResponse.Success && !jsonResponse.Warning)
                {
                    var clasificacionListDTO = (List<CVN_CLASIFICACION_SEGUSDTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<CVN_CLASIFICACION_SEGUSDTO>()).GetType());
                    cmbInterna.ValueMember = "id_clasificacion_segus";
                    cmbInterna.DisplayMember = "t_descripcion";
                    cmbInterna.DataSource = clasificacionListDTO;

                    ////Autocompletado
                    //AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
                    //foreach (DataRow row in clasificacionListDTO.Count)
                    //{
                    //    coleccion.Add(Convert.ToString(row["t_descripcion"])); // columna de la consulta sql
                    //}
                    //cmbInterna.AutoCompleteCustomSource = coleccion;
                    //cmbInterna.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    //cmbInterna.AutoCompleteSource = AutoCompleteSource.CustomSource;


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

 
        //Lista Susalud
        private void CargarComboSusalud()
        {
            try
            {
                var jsonResponse = new JsonResponse { Success = false };
                jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_CVN_CLASIFICACION_SUSALUD_GetAllActives, "", ConstantesWindows.METHODPOST);

                if (jsonResponse.Success && !jsonResponse.Warning)
                {
                    var susaludListDTO = (List<CVN_CLASIFICACION_SUSALUDDTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<CVN_CLASIFICACION_SUSALUDDTO>()).GetType());
                    cmbSusalud.ValueMember = "id_clasificacion_susalud";
                    cmbSusalud.DisplayMember = "t_descripcion";
                    cmbSusalud.DataSource = susaludListDTO;

                    ////Autocompletado
                    //AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
                    //foreach (DataRow row in clasificacionListDTO.Count)
                    //{
                    //    coleccion.Add(Convert.ToString(row["t_descripcion"])); // columna de la consulta sql
                    //}
                    //cmbInterna.AutoCompleteCustomSource = coleccion;
                    //cmbInterna.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    //cmbInterna.AutoCompleteSource = AutoCompleteSource.CustomSource;


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

        //Lista Susalud OD
        private void CargarComboSusaludOD()
        {
            try
            {
                var jsonResponse = new JsonResponse { Success = false };
                jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_CVN_CLASIFICACION_SUSALUD_OD_GetAllActives, "", ConstantesWindows.METHODPOST);

                if (jsonResponse.Success && !jsonResponse.Warning)
                {
                    var susaludListDTO = (List<CVN_CLASIFICACION_SUSALUD_ODDTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<CVN_CLASIFICACION_SUSALUD_ODDTO>()).GetType());
                    cmbOdontologo.ValueMember = "id_clasificacion_susalud_od";
                    cmbOdontologo.DisplayMember = "t_descripcion";
                    cmbOdontologo.DataSource = susaludListDTO;

                    ////Autocompletado
                    //AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
                    //foreach (DataRow row in clasificacionListDTO.Count)
                    //{
                    //    coleccion.Add(Convert.ToString(row["t_descripcion"])); // columna de la consulta sql
                    //}
                    //cmbInterna.AutoCompleteCustomSource = coleccion;
                    //cmbInterna.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    //cmbInterna.AutoCompleteSource = AutoCompleteSource.CustomSource;


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

        //Lista Tipo Precio
        private void CargarComboTipoPrecio()
        {
            try
            {
                var jsonResponse = new JsonResponse { Success = false };
                jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_CVN_TIPO_PRECIO_GetAllActives, "", ConstantesWindows.METHODPOST);

                if (jsonResponse.Success && !jsonResponse.Warning)
                {
                    var precioListDTO = (List<CVN_TIPO_PRECIODTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<CVN_TIPO_PRECIODTO>()).GetType());
                    cmbTipoPrecio.ValueMember = "id_tipo_precio";
                    cmbTipoPrecio.DisplayMember = "t_descripcion";
                    cmbTipoPrecio.DataSource = precioListDTO;

                    ////Autocompletado
                    //AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
                    //foreach (DataRow row in clasificacionListDTO.Count)
                    //{
                    //    coleccion.Add(Convert.ToString(row["t_descripcion"])); // columna de la consulta sql
                    //}
                    //cmbInterna.AutoCompleteCustomSource = coleccion;
                    //cmbInterna.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    //cmbInterna.AutoCompleteSource = AutoCompleteSource.CustomSource;


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

        //Lista Centro Costo
        private void CargarComboCentroCosto()
        {
            try
            {
                var jsonResponse = new JsonResponse { Success = false };
                jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_CON_CENTRO_COSTO_GetAllActives, "", ConstantesWindows.METHODPOST);

                if (jsonResponse.Success && !jsonResponse.Warning)
                {
                    var precioListDTO = (List<CON_CENTRO_COSTODTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<CON_CENTRO_COSTODTO>()).GetType());
                    cmbCentroCosto.ValueMember = "id_centro_costo";
                    cmbCentroCosto.DisplayMember = "t_descripcion";
                    cmbCentroCosto.DataSource = precioListDTO;

                    ////Autocompletado
                    //AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
                    //foreach (DataRow row in clasificacionListDTO.Count)
                    //{
                    //    coleccion.Add(Convert.ToString(row["t_descripcion"])); // columna de la consulta sql
                    //}
                    //cmbInterna.AutoCompleteCustomSource = coleccion;
                    //cmbInterna.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    //cmbInterna.AutoCompleteSource = AutoCompleteSource.CustomSource;


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

        //Lista Cta Contable
        private void CargarComboCtaContable()
        {
            try
            {
                var jsonResponse = new JsonResponse { Success = false };
                jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_CON_CUENTA_CONTABLE_GetAllActives, "", ConstantesWindows.METHODPOST);

                if (jsonResponse.Success && !jsonResponse.Warning)
                {
                    var ctaContableListDTO = (List<CON_CUENTA_CONTABLEDTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<CON_CUENTA_CONTABLEDTO>()).GetType());
                    cmbContable.ValueMember = "id_cuenta_contable";
                    cmbContable.DisplayMember = "t_descripcion";
                    cmbContable.DataSource = ctaContableListDTO;

                    ////Autocompletado
                    //AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
                    //foreach (DataRow row in clasificacionListDTO.Count)
                    //{
                    //    coleccion.Add(Convert.ToString(row["t_descripcion"])); // columna de la consulta sql
                    //}
                    //cmbInterna.AutoCompleteCustomSource = coleccion;
                    //cmbInterna.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    //cmbInterna.AutoCompleteSource = AutoCompleteSource.CustomSource;


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


        private void ClearControls()
        {
            this.txtIdTarifa.Text = "0";
            this.txtCodigo.Text = string.Empty;
            this.txtCodSalud.Text = string.Empty;
            this.txtDescripcionEsp.Text = string.Empty;
            this.txtDescripcionIng.Text = string.Empty;
            this.txtObservacion.Text = string.Empty;
            this.txtUnidad.Text = string.Empty;
            this.txtNumAyudantes.Text = string.Empty;
            this.txtNumInstrumentista.Text = string.Empty;
            this.txtNumDias.Text = string.Empty;
            this.txtPorcentaje.Text = string.Empty;
            this.cmbEstado.Text = "";
            cmbInterna.Text = "";
            cmbCentroCosto.Text = "";
            cmbContable.Text = "";
            cmbOdontologo.Text = "";
            cmbSusalud.Text = "";


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

            if (string.IsNullOrEmpty(this.txtCodSalud.Text))
            {
                this.errValidator.SetError(this.txtCodSalud, "Ingresar Código Susalud.");
                result = false;
            }
            else
            {
                this.errValidator.SetError(this.txtCodSalud, string.Empty);
            }

            if (string.IsNullOrEmpty(this.txtDescripcionEsp.Text))
            {
                this.errValidator.SetError(this.txtDescripcionEsp, "Ingresar Descripción Español.");
                result = false;
            }
            else
            {
                this.errValidator.SetError(this.txtDescripcionEsp, string.Empty);
            }

            if (string.IsNullOrEmpty(this.cmbEstado.Text))
            {
                this.errValidator.SetError(this.cmbEstado, "Ingresar Estado del registro.");
                result = false;
            }
            else
            {
                this.errValidator.SetError(this.cmbEstado, string.Empty);
            }


            

            // Para Anular el registro
            if(cmbEstado.Text =="Inactivo")
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
                        jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_CVN_TARIFARIO_SEGUS_Add, GetTarifa(), ConstantesWindows.METHODPOST);
                        break;
                    case EstadoActual.Editar:
                        jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_CVN_TARIFARIO_SEGUS_Update, GetTarifa(), ConstantesWindows.METHODPOST);
                        break;
                    case EstadoActual.Eliminar:
                        jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_CVN_TARIFARIO_SEGUS_Delete, new CVN_TARIFARIO_SEGUSDTO { id_tarifario_segus = Convert.ToInt32(this.txtIdTarifa.Text), UsuarioCreacion = WindowsSession.UsuarioActual }, ConstantesWindows.METHODPOST);
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


        //Asigna datos para registro/ctualizar
        private CVN_TARIFARIO_SEGUSDTO GetTarifa()
        {

            return new CVN_TARIFARIO_SEGUSDTO
            {
                id_tarifario_segus = Convert.ToInt32(this.txtIdTarifa.Text),
                c_codigo = txtCodigo.Text,
                c_codigo_susalud = txtCodSalud.Text,
                t_descripcion_esp = txtDescripcionEsp.Text,
                t_descripcion_eng = txtDescripcionIng.Text,
                t_observacion = txtObservacion.Text.Trim(),
                id_clasificacion_segus = Convert.ToInt32(cmbInterna.SelectedValue),
                id_clasificacion_susalud = Convert.ToInt32(cmbSusalud.SelectedValue),
                id_clasificacion_susalud_od = Convert.ToInt32(cmbOdontologo.SelectedValue),
                id_centro_costo = Convert.ToInt32(cmbCentroCosto.SelectedValue),
                id_cuenta_contable = Convert.ToInt32(cmbCentroCosto.SelectedValue),
                id_tipo_precio = Convert.ToInt32(cmbTipoPrecio.SelectedValue),
                n_unidad = Convert.ToDecimal(txtUnidad.Text),
                n_ayudante = Convert.ToInt32(txtNumAyudantes.Text),
                n_instrumentista = Convert.ToInt32(txtNumInstrumentista.Text),
                n_dias = Convert.ToInt32(txtNumDias.Text),
                n_porcentaje = Convert.ToDecimal(txtPorcentaje.Text),
                f_estado = Convert.ToInt32(cmbEstado.SelectedValue),
                UsuarioCreacion = Convert.ToString(WindowsSession.UserIdActual), //WindowsSession.UsuarioActual,
                UsuarioModificacion = Convert.ToString(WindowsSession.UserIdActual), //WindowsSession.UsuarioActual,
                IdUsuarioActual = WindowsSession.UserIdActual,
                FechaCreacion =  DateTime.Now,
                FechaModificacion =DateTime.Now
            };
        }

        private CVN_TARIFARIO_SEGUSDTO GetTarifaConsulta()
        {

            return new CVN_TARIFARIO_SEGUSDTO
            {
                //id_tarifario_segus = Convert.ToInt32(this.txtIdTarifa.Text),
                c_codigo = txtCodigo.Text,
                c_codigo_susalud = txtCodSalud.Text,
            };
        }



        //Obtiene datos por el código de Tarifa/Detalles
        private void GetDatosTarifa()
        {
            if (txtIdTarifa.Text != "")
            {

                var jsonResponse = new JsonResponse { Success = false };

                //Consulta Cabecera
                jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_CVN_TARIFARIO_SEGUS_GetById, GetTarifa(), ConstantesWindows.METHODPOST);

                if (jsonResponse.Success && !jsonResponse.Warning)
                {
                    var tarifaListDTO = (List<CVN_TARIFARIO_SEGUSDTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<CVN_TARIFARIO_SEGUSDTO>()).GetType());
                    //this.ETUsuariobindingSource.DataSource = usuarioListDTO;
                    //--------------------------

                    for (int i = 0; i < tarifaListDTO.Count; i++)
                    {
                        txtIdTarifa.Text = tarifaListDTO[i].id_tarifario_segus.ToString();
                        txtCodigo.Text = string.IsNullOrEmpty(tarifaListDTO[i].c_codigo) ? string.Empty : tarifaListDTO[i].c_codigo.ToString();
                        txtCodSalud.Text= string.IsNullOrEmpty(tarifaListDTO[i].c_codigo_susalud) ? string.Empty : tarifaListDTO[i].c_codigo_susalud.ToString();
                        txtDescripcionEsp.Text = string.IsNullOrEmpty(tarifaListDTO[i].t_descripcion_esp) ? string.Empty : tarifaListDTO[i].t_descripcion_esp.ToString();
                        txtObservacion.Text = string.IsNullOrEmpty(tarifaListDTO[i].t_observacion) ? string.Empty : tarifaListDTO[i].t_observacion.ToString();
                        txtUnidad.Text = tarifaListDTO[i].n_unidad.ToString();
                        txtNumAyudantes.Text= tarifaListDTO[i].n_ayudante.ToString();
                        txtNumInstrumentista.Text = tarifaListDTO[i].n_instrumentista.ToString();
                        txtNumDias.Text= tarifaListDTO[i].n_dias.ToString();
                        txtPorcentaje.Text = tarifaListDTO[i].n_porcentaje.ToString();
                        cmbEstado.SelectedValue = Convert.ToInt32(tarifaListDTO[i].f_estado.ToString());
                        cmbSusalud.SelectedValue = Convert.ToInt32(tarifaListDTO[i].id_clasificacion_susalud.ToString());
                        cmbInterna.SelectedValue = Convert.ToInt32(tarifaListDTO[i].id_clasificacion_segus.ToString());
                        cmbOdontologo.SelectedValue = Convert.ToInt32(tarifaListDTO[i].id_clasificacion_susalud_od.ToString());
                        cmbTipoPrecio.SelectedValue = Convert.ToInt32(tarifaListDTO[i].id_tipo_precio.ToString());
                        cmbCentroCosto.SelectedValue = Convert.ToInt32(tarifaListDTO[i].id_centro_costo.ToString());
                        cmbContable.SelectedValue = Convert.ToInt32(tarifaListDTO[i].id_cuenta_contable.ToString());
                    }
                }
                else if (jsonResponse.Warning)
                {
                    Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, jsonResponse.Message);
                }



                //COnsulta Detalle Participantes
                jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_CVN_TARIFARIO_SEGUS_PARTICIPANTE_GetAllActivesFilters, GetTarifa(), ConstantesWindows.METHODPOST);
                if (jsonResponse.Success && !jsonResponse.Warning)
                {
                    var tarifaListDTO = (List<CVN_TARIFARIO_SEGUS_PARTICIPANTEDTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<CVN_TARIFARIO_SEGUS_PARTICIPANTEDTO>()).GetType());
                    //this.ETUsuariobindingSource.DataSource = usuarioListDTO;
                    //--------------------------

                    for (int i = 0; i < tarifaListDTO.Count; i++)
                    {
                        //txtIdTarifa.Text = tarifaListDTO[i].id_tarifario_segus.ToString();
                        //txtCodigo.Text = string.IsNullOrEmpty(tarifaListDTO[i].c_codigo) ? string.Empty : tarifaListDTO[i].c_codigo.ToString();

                        dgvListaOcupacion.Rows.Add(tarifaListDTO[i].id_tarifario_segus_participante.ToString(), tarifaListDTO[i].c_codigo.ToString(), tarifaListDTO[i].t_descripcion_esp.ToString());

                    }
                }
                else if (jsonResponse.Warning)
                {
                    Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, jsonResponse.Message);
                }


                //Consulta Detalle Tarifa
                jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_CVN_CATEGORIA_PAGO_PRECIO_GetAllActivesFilters, GetTarifa(), ConstantesWindows.METHODPOST);
                if (jsonResponse.Success && !jsonResponse.Warning)
                {
                    var PagoPrecioListDTO = (List<CVN_CATEGORIA_PAGO_PRECIODTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<CVN_CATEGORIA_PAGO_PRECIODTO>()).GetType());
                    //this.ETUsuariobindingSource.DataSource = usuarioListDTO;
                    //--------------------------

                    for (int i = 0; i < PagoPrecioListDTO.Count; i++)
                    {

                        dgvListaTarifa.Rows.Add(PagoPrecioListDTO[i].id_categoria_pago_precio.ToString(), PagoPrecioListDTO[i].c_codigo.ToString(), PagoPrecioListDTO[i].t_descripcion.ToString(), PagoPrecioListDTO[i].n_precio_sol.ToString(), PagoPrecioListDTO[i].n_precio_usd.ToString());

                    }
                }
                else if (jsonResponse.Warning)
                {
                    Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, jsonResponse.Message);
                }


            }



            if (txtIdTarifa.Text != "0")
            {
                this.estadoActual = EstadoActual.Editar;
                lblTituloUuario.Text = ".:: Editar";
            }


        }

        private void BarraTitulo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if(txtCodigo.Text != "")
            {
                GetDatosTarifa();
            }
            
            
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ComunFilter.f_id_tarifario_segus = Convert.ToInt32(txtIdTarifa.Text);

            TarifarioSegus.frmFiltroParticipantes frm = new TarifarioSegus.frmFiltroParticipantes();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                dgvListaOcupacion.Rows.Add(ComunFilter.id_tarifario_segus_participante,ComunFilter.codParticipante, ComunFilter.nomParticipante);

            }
        }

        private void dgvListaOcupacion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvListaOcupacion.Rows.Count > 0)
            {
                // Inactivo/Elimina
                if (dgvListaOcupacion.CurrentCell.ColumnIndex == 3)
                {
                    this.estadoActual = EstadoActual.Eliminar;

                    DialogResult oDlgRes;

                    var row = dgvListaOcupacion.CurrentRow;

                    var estadoA = row.Cells[3].Value.ToString();
                    var id_tarifario_segus_participante = row.Cells[0].Value.ToString();

                    if (estadoA != "Inactivo")
                    {
                        // Para eliminar
                        //UtilsComun.tipoRegistro = 2;

                        oDlgRes = MessageBox.Show("¿Está seguro que desea quitar el participante seleccionado ?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                        if (oDlgRes == DialogResult.Yes)
                        {
                            SaveDataParticipantes(Convert.ToInt32(id_tarifario_segus_participante));
                            //EliminaRegistro(Convert.ToInt32(id_tarifario_segus_participante));

                            dgvListaOcupacion.Rows.Remove(dgvListaOcupacion.Rows[e.RowIndex]);

                        }
                    }

                }
            }
        }

        //Elimna Detalle Participante
        private bool SaveDataParticipantes(int id_tarifario_segus_participante)
        {
            bool result = false;
            try
            {
                var jsonResponse = new JsonResponse { Success = false };
                switch (this.estadoActual)
                {
                    // Guardar
                    //case EstadoActual.Nuevo:
                    //    jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_CVN_TARIFARIO_SEGUS_PARTICIPANTE_Add, GetParticipante(), ConstantesWindows.METHODPOST);
                    //    break;
                    case EstadoActual.Eliminar:
                        jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_CVN_TARIFARIO_SEGUS_PARTICIPANTE_Delete, new CVN_TARIFARIO_SEGUS_PARTICIPANTEDTO { id_tarifario_segus_participante = Convert.ToInt32(id_tarifario_segus_participante), IdUsuarioActual = Convert.ToInt32(WindowsSession.UserIdActual) }, ConstantesWindows.METHODPOST);
                        break;
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
                    //DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, ex.Message);
            }
            return result;
        }

        //Elimna Detalle Tarifa
        private bool SaveDataTarifa(int id_categoria_pago_precio)
        {
            bool result = false;
            try
            {
                var jsonResponse = new JsonResponse { Success = false };
                switch (this.estadoActual)
                {
                    // Guardar
                    //case EstadoActual.Nuevo:
                    //    jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_CVN_TARIFARIO_SEGUS_PARTICIPANTE_Add, GetParticipante(), ConstantesWindows.METHODPOST);
                    //    break;
                    case EstadoActual.Eliminar:
                        jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_CVN_CATEGORIA_PAGO_PRECIO_Delete, new CVN_CATEGORIA_PAGO_PRECIODTO { id_categoria_pago_precio = Convert.ToInt32(id_categoria_pago_precio), IdUsuarioActual = Convert.ToInt32(WindowsSession.UserIdActual) }, ConstantesWindows.METHODPOST);
                        break;
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
                    //DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, ex.Message);
            }
            return result;
        }


        private void btnNuevoTarifa_Click(object sender, EventArgs e)
        {
            ComunFilter.f_id_tarifario_segus = Convert.ToInt32(txtIdTarifa.Text);

            TarifarioSegus.frmFiltroCategoriaPago frm = new TarifarioSegus.frmFiltroCategoriaPago();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                dgvListaTarifa.Rows.Add(ComunFilter.id_categoria_pago_precio,ComunFilter.cp_c_codigo,ComunFilter.cp_t_descripcion,ComunFilter.cp_n_precio_sol,ComunFilter.cp_n_precio_usd);

            }
        }

        private void dgvListaTarifa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvListaTarifa.Rows.Count > 0)
            {
                // Inactivo/Elimina
                if (dgvListaTarifa.CurrentCell.ColumnIndex == 5)
                {
                    this.estadoActual = EstadoActual.Eliminar;

                    DialogResult oDlgRes;

                    var row = dgvListaTarifa.CurrentRow;

                    var estadoA = row.Cells[5].Value.ToString();
                    var id_categoria_pago_precio = row.Cells[0].Value.ToString();

                    if (estadoA != "Inactivo")
                    {
                        // Para eliminar
                        //UtilsComun.tipoRegistro = 2;

                        oDlgRes = MessageBox.Show("¿Está seguro que desea quitar la tarifa seleccionada ?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                        if (oDlgRes == DialogResult.Yes)
                        {
                            SaveDataTarifa(Convert.ToInt32(id_categoria_pago_precio));
                            //EliminaRegistro(Convert.ToInt32(id_tarifario_segus_participante));

                            dgvListaTarifa.Rows.Remove(dgvListaTarifa.Rows[e.RowIndex]);

                        }
                    }

                }
            }
        }
    }
 
    
}
