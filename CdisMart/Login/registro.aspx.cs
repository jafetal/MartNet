using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CdisMart_BLL;
using CdisMart_DAL;

namespace CdisMart
{
    public partial class registro : System.Web.UI.Page
    {
        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void registrar_Click(object sender, EventArgs e)
        {
            if (agregarUsuario())
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "alert('Usuario registrado exitosamente')", true);
                Response.Redirect("~/Login/login.aspx");
            }
            
        }

        #endregion

        #region métodos

        public bool agregarUsuario()
        {
            UsuarioBLL userBll = new UsuarioBLL();
            User usuario = new User();

            usuario.Name = txtNombre.Text;
            usuario.Email = txtCorreo.Text;
            usuario.UserName = txtUsuario.Text;
            usuario.Password = txtContrasena.Text;
            try
            {
                userBll.agregarUsuario(usuario);
                return true;
            }catch(Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "alert('" + ex.Message + "')", true);
            }
            return false;
        }

        #endregion
    }
}