using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CdisMart_DAL;
using CdisMart_BLL;

namespace CdisMart.ListaSubastas
{
    public partial class ListaSubastas_s : System.Web.UI.Page
    {
        #region eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                grd_Auctions.DataSource = (cargarSubastas());
                grd_Auctions.DataBind();
            }
        }

        protected void grd_Auctions_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "History")
            {
                Response.Redirect("~/Subastas/ListaSubastas_s.aspx?pId=" + e.CommandArgument);
            }
        }

            #endregion

            #region metodos

            public List<object> cargarSubastas()
        {
            AuctionBLL AuctionBLL = new AuctionBLL();
            List<object> listAuctions = new List<object>();

            listAuctions = AuctionBLL.cargarSubastas();

            return listAuctions;
        }
        #endregion

        protected void grd_Auctions_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = "selectRow(" + e.Row.Cells[0].Text + ");";
                e.Row.ToolTip = "Clic para ir a subasta.";
            }
        }
    }
}