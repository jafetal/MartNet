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
    public partial class Login : System.Web.UI.Page
    {
        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnIngresar_Click1(object sender, EventArgs e)
        {
            if (usuarioValido())
            {
                Response.Redirect("~/ListaSubastas/ListaSubastas_s.aspx");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Sesión", "alert('El usuario y o contraseña son inválidos')", true);
            }
        }

        #endregion

        #region métodos
        public bool usuarioValido()
        {
            bool acceso = false;

            UsuarioBLL userBLL = new UsuarioBLL();
            User usuario = new User();

            usuario = userBLL.consultarUsuario(txtUsuario.Text, txtContrasena.Text);

            if (usuario != null)
            {
                Session["Usuario"] = usuario;
                acceso = true;
            }

            return acceso;
        }
        #endregion

        
    }
}