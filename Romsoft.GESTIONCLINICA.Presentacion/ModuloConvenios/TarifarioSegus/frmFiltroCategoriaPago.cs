using Newtonsoft.Json;
using Romsoft.GESTIONCLINICA.Common;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.CVN_CATEGORIA_PAGO;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.CVN_CATEGORIA_PAGO_PRECIO;
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

namespace Romsoft.GESTIONCLINICA.Presentacion.ModuloConvenios.TarifarioSegus
{
    public partial class frmFiltroCategoriaPago : Form
    {
        public EstadoActual estadoActual;
        public frmFiltroCategoriaPago()
        {
            InitializeComponent();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //Color de Borde De formulario
            Rectangle rect = new Rectangle(e.ClipRectangle.X,
            e.ClipRectangle.Y, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1);
            e.Graphics.DrawRectangle(Pens.Gray, rect);
        }

        private void frmFiltroCategoriaPago_Load(object sender, EventArgs e)
        {

            this.estadoActual = EstadoActual.Nuevo;

            //Llena combo
            CargarCatPago();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void ConsultaInicial()
        //{
        //    try
        //    {
        //        //Muestra Todo por filtro

        //        var jsonResponse = new JsonResponse { Success = false };

        //        jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_CVN_CATEGORIA_PAGO_GetAllActives, "", ConstantesWindows.METHODPOST);

        //        if (jsonResponse.Success && !jsonResponse.Warning)
        //        {
        //            var tarifaListDTO = (List<CVN_CATEGORIA_PAGODTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<CVN_CATEGORIA_PAGODTO>()).GetType());
        //            this.ETListaCtegoriaPagobindingSource.DataSource = tarifaListDTO;
        //            //this.usuarioBindingNavigator.BindingSource = this.usuarioBindingSource;
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

        //Lista combo
        private void CargarCatPago()
        {
            try
            {
                var jsonResponse = new JsonResponse { Success = false };
                jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_CVN_CATEGORIA_PAGO_GetAllActives, "", ConstantesWindows.METHODPOST);

                if (jsonResponse.Success && !jsonResponse.Warning)
                {
                    var tarifaListDTO = (List<CVN_CATEGORIA_PAGODTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<CVN_CATEGORIA_PAGODTO>()).GetType());
                    cmbCatPago.ValueMember = "id_categoria_pago";
                    cmbCatPago.DisplayMember = "t_descripcion";
                    cmbCatPago.DataSource = tarifaListDTO;
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


        //private void dgvListaCategoriaPago_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{


        //    if (dgvListaCategoriaPago.Rows.Count > 0)
        //    {
        //        ComunFilter.cp_c_codigo = dgvListaCategoriaPago.CurrentRow.Cells[0].Value.ToString(); //Codigo
        //        ComunFilter.cp_t_descripcion = dgvListaCategoriaPago.CurrentRow.Cells[1].Value.ToString(); //Descripción
        //        ComunFilter.id_tarifario_segus = Convert.ToInt32(dgvListaCategoriaPago.CurrentRow.Cells[2].Value.ToString()); //id_tarifario_segus
        //        ComunFilter.cp_n_precio_sol = Convert.ToDecimal(txtsoles.Text);
        //        ComunFilter.cp_n_precio_usd = Convert.ToDecimal(txtdolares.Text);

        //        if (SaveData())
        //        {
        //            this.estadoActual = EstadoActual.Normal;

        //            DialogResult = DialogResult.OK;

        //            this.Close();
        //        }
        //    }
        //}

        private bool ValidateData()
        {
            bool result = true;

            if (string.IsNullOrEmpty(this.cmbCatPago.Text))
            {
                this.errValidator.SetError(this.cmbCatPago, "Ingresar Categoria.");
                result = false;
            }
            else
            {
                this.errValidator.SetError(this.cmbCatPago, string.Empty);
            }

            if (string.IsNullOrEmpty(this.txtsoles.Text))
            {
                this.errValidator.SetError(this.txtsoles, "Ingresar importe Soles.");
                result = false;
            }
            else
            {
                this.errValidator.SetError(this.txtsoles, string.Empty);
            }

            if (string.IsNullOrEmpty(this.txtdolares.Text))
            {
                this.errValidator.SetError(this.txtdolares, "Ingresar importe Dólares.");
                result = false;
            }
            else
            {
                this.errValidator.SetError(this.txtdolares, string.Empty);
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
                        jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_CVN_CATEGORIA_PAGO_PRECIO_Add, GetCatPagoPrecio(), ConstantesWindows.METHODPOST);

                        // obtiene el último id registrado
                        ComunFilter.id_categoria_pago_precio = Convert.ToInt32(jsonResponse.Data);

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
        private CVN_CATEGORIA_PAGO_PRECIODTO GetCatPagoPrecio()
        {

            return new CVN_CATEGORIA_PAGO_PRECIODTO
            {

                id_tarifario_segus =ComunFilter.f_id_tarifario_segus,
                id_categoria_pago =ComunFilter.id_tarifario_segus,
                c_codigo=ComunFilter.cp_c_codigo,
                t_descripcion=ComunFilter.cp_t_descripcion,
                n_precio_sol = Convert.ToDecimal(txtsoles.Text),
                n_precio_usd = Convert.ToDecimal(txtdolares.Text),
                UsuarioCreacion = Convert.ToString(WindowsSession.UserIdActual), //WindowsSession.UsuarioActual,
                UsuarioModificacion = Convert.ToString(WindowsSession.UserIdActual), //WindowsSession.UsuarioActual,
                IdUsuarioActual = WindowsSession.UserIdActual,
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now
            };
        }

        private void txtsoles_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtdolares_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                ComunFilter.cp_c_codigo = "0";//dgvListaCategoriaPago.CurrentRow.Cells[0].Value.ToString(); //Codigo
                ComunFilter.cp_t_descripcion = cmbCatPago.Text; //dgvListaCategoriaPago.CurrentRow.Cells[1].Value.ToString(); //Descripción
                ComunFilter.id_tarifario_segus =Convert.ToInt32(cmbCatPago.SelectedValue); //Convert.ToInt32(dgvListaCategoriaPago.CurrentRow.Cells[2].Value.ToString()); //id_tarifario_segus
                ComunFilter.cp_n_precio_sol = Convert.ToDecimal(txtsoles.Text);
                ComunFilter.cp_n_precio_usd = Convert.ToDecimal(txtdolares.Text);

                if (SaveData())
                {
                    this.estadoActual = EstadoActual.Normal;

                    DialogResult = DialogResult.OK;

                    this.Close();
                }
            }
        }
    }
}
