using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CdisMart_DAL;
using CdisMart_BLL;

namespace CdisMart
{
    public class TemasMart : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
            {
                //
            }
        }
    }
}