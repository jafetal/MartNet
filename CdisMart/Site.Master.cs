using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CdisMart_DAL;
namespace CdisMart
{
    public partial class SiteMaster : MasterPage
    {
        #region eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (sessionIniciada())
            {
                User usuario = new User();
                usuario = (User)Session["Usuario"];
                lblUsuario.Text = "Sesión iniciada como " + usuario.UserName;
            }
            else
            {
                Response.Redirect("~/Login/login.aspx");
            }
        }
        #endregion

        #region metodos
        public bool sessionIniciada()
        {
            if (Session["Usuario"] != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}