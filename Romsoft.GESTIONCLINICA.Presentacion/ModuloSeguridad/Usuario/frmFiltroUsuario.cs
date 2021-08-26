using Romsoft.GESTIONCLINICA.Common;
using Romsoft.GESTIONCLINICA.Presentacion.ApiService;
using Romsoft.GESTIONCLINICA.Presentacion.Utilities;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.SEG_ROL;
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

namespace Romsoft.GESTIONCLINICA.Presentacion.ModuloSeguridad.Usuario
{
    public partial class frmFiltroUsuario : Form
    {
        public frmFiltroUsuario()
        {
            InitializeComponent();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void frmFiltroUsuario_Load(object sender, EventArgs e)
        {
            CargarComboRol();
            cmbTipo.Text = "";
        }

        private void CargarComboRol()
        {
            try
            {
                var jsonResponse = new JsonResponse { Success = false };
                jsonResponse = InvokeHelper.MakeRequest(ConstantesWindows.WS_Rol_GetAllActives, null, ConstantesWindows.METHODPOST);

                if (jsonResponse.Success && !jsonResponse.Warning)
                {
                    var rolListDTO = (List<SEG_ROLDTO>)JsonConvert.DeserializeObject(jsonResponse.Data.ToString(), (new List<SEG_ROLDTO>()).GetType());
                    //Limpia datos
                    cmbTipo.DataSource = null;
                    //Llna combo
                    cmbTipo.ValueMember = "Id_rol";
                    cmbTipo.DisplayMember = "rol";
                    cmbTipo.DataSource = rolListDTO;

                    cmbTipo.SelectedIndex = 0;

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

        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //Color de Borde De formulario
            Rectangle rect = new Rectangle(e.ClipRectangle.X,
            e.ClipRectangle.Y, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1);
            e.Graphics.DrawRectangle(Pens.Gray, rect);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtApellidos.Text.Length > 0)
            {
                ComunFilter.f_usuario_Apellidos = txtApellidos.Text;
            }
            else
            {
                ComunFilter.f_usuario_Apellidos = "0";
            }

            if (cmbEstado.Text.Length > 0)
            {
                ComunFilter.f_usuario_Estado = cmbEstado.Text;
            }
            else
            {
                ComunFilter.f_usuario_Estado = "0";
            }
            if (cmbTipo.Text.Length > 0)
            {
                ComunFilter.f_usuario_IdTipoUsers = Convert.ToInt32(cmbTipo.SelectedValue);
            }
            else
            {
                ComunFilter.f_usuario_IdTipoUsers = 0;
            }

            if (txtLoginName.Text.Length > 0)
            {
                ComunFilter.f_usuario_LoginName = txtLoginName.Text;
            }
            else
            {
                ComunFilter.f_usuario_LoginName = "0";
            }
            if (txtDni.Text.Length > 0)
            {
                ComunFilter.f_usuario_DNI = txtDni.Text;
            }
            else
            {
                ComunFilter.f_usuario_DNI = "0";
            }

            DialogResult = DialogResult.OK;

            this.Close();

        }
    }
}
