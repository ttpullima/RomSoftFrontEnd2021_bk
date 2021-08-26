using Newtonsoft.Json;
using Romsoft.GESTIONCLINICA.Common;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.ADM_ATENCION;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.ADM_DOCUMENTO_IDENTIDAD;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.ADM_FORMA_PAGODTO;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.FAC_DOCUMENTO_PAGO;
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

namespace Romsoft.GESTIONCLINICA.Presentacion.ModuloFacturacion.Prefacturacion
{
    public partial class frmPrefacturacion : Form
    {
        public EstadoActual estadoActual;

        public frmPrefacturacion()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmPrefacturacion_Load(object sender, EventArgs e)
        {
            if (ComunFilter.f_idAtencion == 0)
            {
                this.estadoActual = EstadoActual.Nuevo;

            }
            else
            {
                this.estadoActual = EstadoActual.Nuevo;

                CargarComboMoneda();
                CargarComboDocumento();
                CargarComprobante();
                CargarFormaPago();

                GetDatosAtencion(ComunFilter.f_idAtencion);
            }
        }

        private void CargarComboMoneda()
        {
            try
            {
                var jsonResponse = new JsonResponse { Success = false };
                jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_CVN_MONEDA_GetAllActives, new DTO.TABLAS.CVN_MONEDA.CVN_MONEDADTO { }, ConstantesWindows.METHODPOST);

                if (jsonResponse.Success && !jsonResponse.Warning)
                {
                    var motivoaltalListDTO = (List<DTO.TABLAS.CVN_MONEDA.CVN_MONEDADTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<DTO.TABLAS.CVN_MONEDA.CVN_MONEDADTO>()).GetType());
                    CboMoneda.ValueMember = "id_moneda";
                    CboMoneda.DisplayMember = "t_descripcion";
                    CboMoneda.DataSource = motivoaltalListDTO;
                    CboMoneda.SelectedIndex = -1;


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
                    cboDocumentoIdentidad.ValueMember = "id_documento_identidad";
                    cboDocumentoIdentidad.DisplayMember = "t_descripcion";
                    cboDocumentoIdentidad.DataSource = documentoListDTO;
                    cboDocumentoIdentidad.SelectedValue = -1;
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

        private void CargarComprobante()
        {
            try
            {
                var jsonResponse = new JsonResponse { Success = false };
                jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_FAC_DOCUMENTO_PAGO_GetAllFilters, new FAC_DOCUMENTO_PAGORequest { c_dato ="E" }, ConstantesWindows.METHODPOST);

                if (jsonResponse.Success && !jsonResponse.Warning)
                {
                    var documentoListDTO = (List<FAC_DOCUMENTO_PAGODTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<FAC_DOCUMENTO_PAGODTO>()).GetType());
                    cboComprobante.ValueMember = "id_documento_pago";
                    cboComprobante.DisplayMember = "t_descripcion";
                    cboComprobante.DataSource = documentoListDTO;
                    cboComprobante.SelectedValue = -1;
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

        private void CargarFormaPago()
        {
            try
            {
                var jsonResponse = new JsonResponse { Success = false };
                jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_ADM_FORMA_PAGO_GetAllFilters, new ADM_FORMA_PAGOResDTO { }, ConstantesWindows.METHODPOST);

                if (jsonResponse.Success && !jsonResponse.Warning)
                {
                    var documentoListDTO = (List<ADM_FORMA_PAGOResDTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<ADM_FORMA_PAGOResDTO>()).GetType());
                    cboFormaPago.ValueMember = "id_forma_pago";
                    cboFormaPago.DisplayMember = "t_descripcion";
                    cboFormaPago.DataSource = documentoListDTO;
                    cboFormaPago.SelectedValue = -1;
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

        //Obtiene datos por el ID Atención
        private void GetDatosAtencion(int idAtencion)
        {


            var jsonResponse = new JsonResponse { Success = false };

            //Consulta Cabecera//
            jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_ADM_ATENCION_Pending, new ADM_ATENCION_PendingRequest {  id_atencion = ComunFilter.f_idAtencion,c_tipo_pendiente= ComunFilter.f_tipo_pendiente, c_tipo_facturacion= ComunFilter.f_tipo_facturacion, c_idioma= ComunFilter.f_idioma, id_usuario= WindowsSession.UserIdActual }, ConstantesWindows.METHODPOST);

            if (jsonResponse.Success && !jsonResponse.Warning)
            {
                var atencionListDTO = (List<ADM_ATENCION_PendingResponseDTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<ADM_ATENCION_PendingResponseDTO>()).GetType());
                this.ETPref.DataSource = atencionListDTO;
                //--------------------------

                for (int i = 0; i < atencionListDTO.Count; i++)
                {
                    CboMoneda.SelectedValue = Convert.ToInt32(atencionListDTO[i].id_moneda.ToString());
                    dtFechaEmision.Text = atencionListDTO[i].d_fecha_registro.ToString("dd/MM/yyyy");
                    cboComprobante.SelectedValue = Convert.ToInt32(atencionListDTO[i].id_documento_pago.ToString());
                    cboFormaPago.SelectedValue = Convert.ToInt32(atencionListDTO[i].id_forma_pago.ToString());
                    cboDocumentoIdentidad.SelectedValue = Convert.ToInt32(atencionListDTO[i].id_documento_identidad.ToString());
                    txtNumDocumento.Text = string.IsNullOrEmpty(atencionListDTO[i].c_documento_identidad) ? string.Empty : atencionListDTO[i].c_documento_identidad.ToString();
                    txtUsuario.Text = WindowsSession.UserIdActual.ToString();
                    txtAdquiriente.Text = string.IsNullOrEmpty(atencionListDTO[i].t_adquiriente) ? string.Empty : atencionListDTO[i].t_adquiriente.ToString();
                    txtDireccion.Text = string.IsNullOrEmpty(atencionListDTO[i].t_direccion) ? string.Empty : atencionListDTO[i].t_direccion.ToString();
                    txtEmail.Text = ""; //string.IsNullOrEmpty(atencionListDTO[i].t_email) ? string.Empty : atencionListDTO[i].t_email.ToString(); ;
                    txtNombrePaciente.Text= string.IsNullOrEmpty(atencionListDTO[i].t_paciente) ? string.Empty : atencionListDTO[i].t_paciente.ToString();
                    //
                    txtValorNoGravado.Text = Convert.ToString(atencionListDTO[i].n_no_grabado.ToString());
                    txtVAlorGrabado.Text = Convert.ToString(atencionListDTO[i].n_gravado.ToString());
                    txtImpuesto.Text = Convert.ToString(atencionListDTO[i].n_impuesto.ToString());
                    txtTotal.Text = Convert.ToString(atencionListDTO[i].n_total.ToString());

                }
            }
            else if (jsonResponse.Warning)
            {
                Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, jsonResponse.Message);
            }

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

            if (string.IsNullOrEmpty(this.CboMoneda.Text))
            {
                this.errValidator.SetError(this.CboMoneda, "Seleccione tipo moneda.");
                result = false;
            }
            else
            {
                this.errValidator.SetError(this.cboComprobante, string.Empty);
            }

            if (string.IsNullOrEmpty(this.cboComprobante.Text))
            {
                this.errValidator.SetError(this.cboComprobante, "Seleccione tipo comprobante.");
                result = false;
            }
            else
            {
                this.errValidator.SetError(this.cboFormaPago, string.Empty);
            }

            if (string.IsNullOrEmpty(this.cboFormaPago.Text))
            {
                this.errValidator.SetError(this.cboFormaPago, "Seleccione forma de pago.");
                result = false;
            }
            else
            {
                this.errValidator.SetError(this.cboDocumentoIdentidad, string.Empty);
            }

            if (string.IsNullOrEmpty(this.cboDocumentoIdentidad.Text))
            {
                this.errValidator.SetError(this.cboDocumentoIdentidad, "Seleccione tipo documento.");
                result = false;
            }
            else
            {
                this.errValidator.SetError(this.cboDocumentoIdentidad, string.Empty);
            }

            if (string.IsNullOrEmpty(this.txtNumDocumento.Text))
            {
                this.errValidator.SetError(this.txtNumDocumento, "ingrese nro documento.");
                result = false;
            }
            else
            {
                this.errValidator.SetError(this.txtNumDocumento, string.Empty);
            }



            if (string.IsNullOrEmpty(this.txtUsuario.Text))
            {
                this.errValidator.SetError(this.txtUsuario, "Ingrese usuario.");
                result = false;
            }
            else
            {
                this.errValidator.SetError(this.txtUsuario, string.Empty);
            }

            if (string.IsNullOrEmpty(txtNombrePaciente.Text))
            {
                this.errValidator.SetError(this.txtNombrePaciente, "Ingrese paciente.");
                result = false;
            }
            else
            {
                this.errValidator.SetError(this.txtNombrePaciente, string.Empty);
            }

            if (string.IsNullOrEmpty(txtAdquiriente.Text))
            {
                this.errValidator.SetError(this.txtAdquiriente, "Ingrese adquiriente.");
                result = false;
            }
            else
            {
                this.errValidator.SetError(this.txtAdquiriente, string.Empty);
            }
            if(dataGridView1.Rows.Count < 0)
            {
                Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, "No existe registros en el detalle.");
                result = false;
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
                        jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_FAC_COMPROBANTE_Add, GetComprobante(), ConstantesWindows.METHODPOST);
                        break;
                    case EstadoActual.Editar:
                        //jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_ADM_ATENCION_Update, GetAtencion(), ConstantesWindows.METHODPOST);
                        break;
                    case EstadoActual.Eliminar:
                        //jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_ADM_ATENCION_Delete, new ADM_PACIENTEDTO { id_plan_seguro = Convert.ToInt32(this.txtplanSegus.Text), UsuarioCreacion = WindowsSession.UsuarioActual }, ConstantesWindows.METHODPOST);
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

                    //Cierra formulario si el copago = 0
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
        private FAC_COMPROBANTEReqDTO GetComprobante()
        {
            FAC_COMPROBANTEReqDTO list = new FAC_COMPROBANTEReqDTO();
            var detellaComprobante = new List<FAC_COMPROBANTE_DetalleDTO>();


            //list.Add(new FAC_COMPROBANTEReqDTO()
            //{
            list.id_documento_pago = Convert.ToInt32(cboComprobante.SelectedValue);
            list.id_atencion = Convert.ToInt32(ComunFilter.f_idAtencion);
            list.id_tipo_documento = Convert.ToInt32(cboDocumentoIdentidad.SelectedValue);
            list.c_numero_de_documento = txtNumDocumento.Text;
            list.t_direccion = txtDireccion.Text;
            list.t_paciente = txtNombrePaciente.Text;
            list.d_fecha_emis = dtFechaEmision.Value;
            list.id_condicion_pago = Convert.ToInt32(cboFormaPago.SelectedValue);
            list.id_moneda = Convert.ToInt32(CboMoneda.SelectedValue);
            list.n_porcen_igv = 0;
            list.n_porcen_descu = 0;
            list.n_total_bruto = 0;
            list.n_total_descuento = 0;
            list.n_total_anticipo = 0;
            list.n_total_gravada = Convert.ToDecimal(txtVAlorGrabado.Text);
            list.n_total_no_gravada = Convert.ToDecimal(txtValorNoGravado.Text);
            list.n_total_icbper = 0;
            list.n_total_impuesto = Convert.ToDecimal(txtImpuesto.Text);
            list.n_total_neto = 0;
            list.t_observacion = "";
            list.id_user_registro = Convert.ToInt32(WindowsSession.UserIdActual);

            //});

            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                detellaComprobante.Add(new FAC_COMPROBANTE_DetalleDTO
                {

                    id_tarifario_segus = Convert.ToInt32(dr.Cells[21].Value.ToString()),
                    t_tarifario_segus = Convert.ToString(dr.Cells[2].Value.ToString()),
                    c_codigo_segus = Convert.ToString(dr.Cells[1].Value.ToString()),
                    id_clasificacion_segus = Convert.ToInt32(dr.Cells[20].Value.ToString()),
                    t_clasificacion_segus = Convert.ToString(dr.Cells[0].Value.ToString()),
                    n_precio = Convert.ToDecimal(dr.Cells[3].Value.ToString()),
                    n_cantidad = Convert.ToDecimal(dr.Cells[5].Value.ToString()),
                    n_subtotal = Convert.ToDecimal(dr.Cells[26].Value.ToString()),
                    n_descuento = Convert.ToDecimal(dr.Cells[4].Value.ToString()),
                    n_total = Convert.ToDecimal(dr.Cells[6].Value.ToString()),
                });
            }

            return list;

            //return new FAC_COMPROBANTEReqDTO
            //{
            //    id_documento_pago = Convert.ToInt32(cboComprobante.SelectedValue),
            //    id_atencion = Convert.ToInt32(ComunFilter.f_idAtencion),
            //    id_tipo_documento = Convert.ToInt32(cboDocumentoIdentidad.SelectedValue),
            //    c_numero_de_documento = txtNumDocumento.Text,
            //    t_direccion = txtDireccion.Text,
            //    t_paciente = txtNombrePaciente.Text,
            //    d_fecha_emis = dtFechaEmision.Value,
            //    id_condicion_pago = Convert.ToInt32(cboFormaPago.SelectedValue),
            //    id_moneda = Convert.ToInt32(CboMoneda.SelectedValue),
            //    n_porcen_igv = 0,
            //    n_porcen_descu = 0,
            //    n_total_bruto = 0,
            //    n_total_descuento = 0,
            //    n_total_anticipo = 0,
            //    n_total_gravada = Convert.ToDecimal(txtVAlorGrabado.Text),
            //    n_total_no_gravada = Convert.ToDecimal(txtValorNoGravado.Text),
            //    n_total_icbper = 0,
            //    n_total_impuesto = Convert.ToDecimal(txtImpuesto.Text),
            //    n_total_neto = 0,
            //    t_observacion = "",
            //    id_user_registro = Convert.ToInt32(WindowsSession.UserIdActual),

            //    DetalleComprobante =  new FAC_COMPROBANTE_DetalleDTO
            //    {
            //        id_tarifario_segus = Convert.ToInt32(dr.Cells[21].Value.ToString()),
            //        t_tarifario_segus = Convert.ToString(dr.Cells[2].Value.ToString()),
            //        c_codigo_segus = Convert.ToString(dr.Cells[1].Value.ToString()),
            //        id_clasificacion_segus = Convert.ToInt32(dr.Cells[20].Value.ToString()),
            //        t_clasificacion_segus = Convert.ToString(dr.Cells[0].Value.ToString()),
            //        n_precio = Convert.ToDecimal(dr.Cells[3].Value.ToString()),
            //        n_cantidad = Convert.ToDecimal(dr.Cells[5].Value.ToString()),
            //        n_subtotal = Convert.ToDecimal(dr.Cells[26].Value.ToString()),
            //        n_descuento = Convert.ToDecimal(dr.Cells[4].Value.ToString()),
            //        n_total = Convert.ToDecimal(dr.Cells[6].Value.ToString())


            //    }
            //};
        }

    }

}
