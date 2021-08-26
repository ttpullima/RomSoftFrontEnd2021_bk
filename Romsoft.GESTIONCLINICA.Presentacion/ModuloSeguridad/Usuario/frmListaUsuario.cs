using Newtonsoft.Json;
using Romsoft.GESTIONCLINICA.Common;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.SEG_USUARIO;
using Romsoft.GESTIONCLINICA.Presentacion.ApiService;
using Romsoft.GESTIONCLINICA.Presentacion.Core;
using Romsoft.GESTIONCLINICA.Presentacion.Helpers;
using Romsoft.GESTIONCLINICA.Presentacion.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Romsoft.GESTIONCLINICA.Presentacion.ModuloSeguridad.Usuario
{
    public partial class frmListaUsuario : Form
    {
        
        public int intTipoConsulta = 0;

        public frmListaUsuario()
        {
            InitializeComponent();
        }


        private void frmListaUsuario_Load(object sender, EventArgs e)
        {
            // 0 = Consulta todos
            InitialLoad(0);

        }

        private void dgvListaUsuarios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;

            if (dgv.Columns[e.ColumnIndex].Name == "estadoDataGridViewTextBoxColumn")  //columna Esatado a evaluar
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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void InitialLoad(int intTipoConsulta)
        {

            try
            {
                //Muestra Todo
                if (intTipoConsulta == 0)
                {

             
                    var jsonResponse = new JsonResponse { Success = false };
                    PaginationParameter paginationParameters = new PaginationParameter { AmountRows = 1000, CurrentPage = 0, OrderBy = "", Start = 0, WhereFilter = "WHERE U.estado IN ('Activo','Inactivo')" };
                    jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_Usuario_GetAllPaging, paginationParameters, ConstantesWindows.METHODPOST);

                    if (jsonResponse.Success && !jsonResponse.Warning)
                    {
                        var usuarioListDTO = (List<SEG_USUARIODTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<SEG_USUARIODTO>()).GetType());
                        this.ETUsuariobindingSource.DataSource = usuarioListDTO;
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
                    
                    jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_Usuario_GetAllFilters, GetUsuarioFitro(), ConstantesWindows.METHODPOST);

                    if (jsonResponse.Success && !jsonResponse.Warning)
                    {
                        var usuarioListDTO = (List<SEG_USUARIODTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<SEG_USUARIODTO>()).GetType());
                        this.ETUsuariobindingSource.DataSource = usuarioListDTO;
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
        private SEG_USUARIODTO GetUsuarioFitro()
        {
            return new SEG_USUARIODTO
            {
                id_rol = ComunFilter.f_usuario_IdTipoUsers,
                apellidos =ComunFilter.f_usuario_Apellidos,
                usuario=ComunFilter.f_usuario_LoginName,
                nro_documento = ComunFilter.f_usuario_DNI,
                estado =ComunFilter.f_usuario_Estado,
            };
        }

        private void dgvListaUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvListaUsuarios.Rows.Count > 0)
            {

                // Editar
                if (dgvListaUsuarios.CurrentCell.ColumnIndex == 17)
                {
                    // Para actualizar
                    //UtilsComun.tipoRegistro = 1;

                    var row = dgvListaUsuarios.CurrentRow;
                    Usuario.frmNuevoUsuario frm = new Usuario.frmNuevoUsuario();
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
                if (dgvListaUsuarios.CurrentCell.ColumnIndex == 18)
                {
                    DialogResult oDlgRes;


                    var row = dgvListaUsuarios.CurrentRow;

                    var estadoA = row.Cells[11].Value.ToString();
                    var idusuario = row.Cells[0].Value.ToString();

                    if (estadoA != "Inactivo")
                    {
                        // Para eliminar
                        //UtilsComun.tipoRegistro = 2;

                        oDlgRes = MessageBox.Show("¿Está seguro que desea anular el Usuario seleccionado ?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                        if (oDlgRes == DialogResult.Yes)
                        {
                            EliminaRegistro(Convert.ToInt32(idusuario));
                            //Volver a consultar
                            InitialLoad(0);
                        }
                    }
                    else
                    {
                        Mensaje.ShowMessageAlert(this.ParentForm, ConstantesWindows.TituloMensaje, "Usuario ya se encuentra con estado Inactivo");
                    }



                }
            }
        }


        private void EliminaRegistro(int idUsuario)
        {
            bool result = false;
            try
            {
                var jsonResponse = new JsonResponse { Success = false };

                jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_Usuario_Delete, new SEG_USUARIODTO { id_usuario = idUsuario, UsuarioCreacion = WindowsSession.UsuarioActual, FechaModificacion = DateTime.Now }, ConstantesWindows.METHODPOST);

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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Usuario.frmNuevoUsuario frm = new Usuario.frmNuevoUsuario();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                // 0 = Consulta Todos
                InitialLoad(0);
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            Usuario.frmFiltroUsuario frm = new Usuario.frmFiltroUsuario();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                // 1 = Consulta por filtro
                InitialLoad(1);
            }
        }
    }
}
