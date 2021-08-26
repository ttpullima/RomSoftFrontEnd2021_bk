using Romsoft.GESTIONCLINICA.Common;
using Romsoft.GESTIONCLINICA.Presentacion.ApiService;
using Romsoft.GESTIONCLINICA.Presentacion.Utilities;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.ADM_OCUPACION;
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

namespace Romsoft.GESTIONCLINICA.Presentacion.ModuloTablas.Ocupacion
{
    public partial class frmListaOcupacion : Form
    {
        public frmListaOcupacion()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListaOcupacion_Load(object sender, EventArgs e)
        {
            //Filtro todos
            InitialLoad(0);
        }


        private void InitialLoad(int intTipoConsulta)
        {

            try
            {
                //Muestra Todo
                if (intTipoConsulta == 0)
                {


                    var jsonResponse = new JsonResponse { Success = false };
                    jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_Ocupacion_GetAllFilters, new ADM_OCUPACIONDTO { id_ocupacion=0, c_codigo="", t_descripcion="",f_estado=0} , ConstantesWindows.METHODPOST);

                    if (jsonResponse.Success && !jsonResponse.Warning)
                    {
                        var usuarioListDTO = (List<ADM_OCUPACIONDTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<ADM_OCUPACIONDTO>()).GetType());
                        this.ETOcupacionbindingSource.DataSource = usuarioListDTO;
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

                    jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_Ocupacion_GetAllFilters, GetOcuapcionFitro(), ConstantesWindows.METHODPOST);

                    if (jsonResponse.Success && !jsonResponse.Warning)
                    {
                        var usuarioListDTO = (List<ADM_OCUPACIONDTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<ADM_OCUPACIONDTO>()).GetType());
                        this.ETOcupacionbindingSource.DataSource = usuarioListDTO;
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
        private ADM_OCUPACIONDTO GetOcuapcionFitro()
        {
            return new ADM_OCUPACIONDTO
            {
                id_ocupacion = ComunFilter.ocupacion_id,
                c_codigo = ComunFilter.ocupacion_c_codigo,
                t_descripcion = ComunFilter.ocupacion_t_descripcion,
                f_estado = ComunFilter.ocupacion_f_estado,
                
            };
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Ocupacion.frmNuevoOcupacion frm = new Ocupacion.frmNuevoOcupacion();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                // 0 = Consulta Todos
                InitialLoad(0);
            }
        }

        private void btnFiltro_Click(object sender, EventArgs e)
        {
            Ocupacion.frmFiltroOcupacion frm = new Ocupacion.frmFiltroOcupacion();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                // 1 = Consulta por filtro
                InitialLoad(1);
            }
        }

        //cambia color columna Estado
        private void dgvListaOcupacion_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;

            if (dgv.Columns[e.ColumnIndex].Name == "festadoDataGridViewTextBoxColumn")  //columna Estado a evaluar
            {
                if (e.Value.ToString().Contains("Inactivo"))
                {
                    e.CellStyle.ForeColor = Color.Red;
                }
                if (e.Value.ToString().Contains("Activo"))
                {
                    e.CellStyle.ForeColor = Color.CornflowerBlue;
                }
            }
        }

        private void dgvListaOcupacion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvListaOcupacion.Rows.Count > 0)
            {

                // Editar
                if (dgvListaOcupacion.CurrentCell.ColumnIndex == 9)
                {
                    // Para actualizar
                    //UtilsComun.tipoRegistro = 1;

                    var row = dgvListaOcupacion.CurrentRow;
                    Ocupacion.frmNuevoOcupacion frm = new Ocupacion.frmNuevoOcupacion();
                    var txtid = frm.Controls["txtid"];
                    var id = row.Cells[0].Value.ToString();
                    frm.txtid.Text = id;

                    //UtilsComun.tipoRegistro = 1;

                    if (frm.ShowDialog() == DialogResult.OK)
                    {

                        InitialLoad(0);
                    }
                }

                // Inactivo/Elimina
                if (dgvListaOcupacion.CurrentCell.ColumnIndex == 10)
                {
                    DialogResult oDlgRes;


                    var row = dgvListaOcupacion.CurrentRow;

                    var estadoA = row.Cells[4].Value.ToString();
                    var idOcupacion = row.Cells[0].Value.ToString();

                    if (estadoA != "Inactivo")
                    {
                        // Para eliminar
                        //UtilsComun.tipoRegistro = 2;

                        oDlgRes = MessageBox.Show("¿Está seguro que desea anular el Usuario seleccionado ?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                        if (oDlgRes == DialogResult.Yes)
                        {
                            EliminaRegistro(Convert.ToInt32(idOcupacion));
                            //Volver a consultar
                            InitialLoad(0);
                        }
                    }
                    else
                    {
                        Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, "Ocupación ya se encuentra con estado Inactivo");
                    }



                }
            }
        }

        //Cambia de estado al registo
        private void EliminaRegistro(int idOcupacion)
        {
            bool result = false;
            try
            {
                var jsonResponse = new JsonResponse { Success = false };

                jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_Ocupacion_Delete, new ADM_OCUPACIONDTO { id_ocupacion = idOcupacion, IdUsuarioActual = WindowsSession.UserIdActual, FechaModificacion = DateTime.Now }, ConstantesWindows.METHODPOST);

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
            catch (Exception)
            {

                throw;
            }


        }

    }
}
