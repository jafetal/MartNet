using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CdisMart_BLL;
using CdisMart_DAL;

namespace CdisMart.Subastas
{
    public partial class Subasta_info : System.Web.UI.Page
    {
        #region eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int idSubasta = int.Parse(Request.QueryString["pId"]);
                cargarSubasta(idSubasta);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ofertar();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "alert('Se ha realizado la oferta')", true);
        }
        #endregion

        #region metodos

        public void ofertar()
        {
            AuctionRBLL auctionRBLL = new AuctionRBLL();
            AuctionRecord aR = new AuctionRecord();

            aR.AuctionId = int.Parse(lblId.Text);
            aR.Amount = decimal.Parse(txtOferta.Text);
            aR.UserId = getUserID();
            aR.BidDate = DateTime.Now;

            try
            {
                auctionRBLL.addRecord(aR, int.Parse(lblUser.Text));
            }catch(Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "alert('" + ex.Message + "')", true);
            }
        }
        public void cargarSubasta(int idSubasta)
        {
            AuctionBLL auctionBLL = new AuctionBLL();
            Auction auction = new Auction();
            UsuarioBLL user = new UsuarioBLL();

            auction = auctionBLL.cargarSubasta(idSubasta);
            lblId.Text = auction.AuctionId.ToString();
            lblNombre.Text = auction.ProductName;
            lblDescription.Text = auction.Description;
            lblFechaI.Text = auction.StartDate.ToString();
            lblFechaF.Text = auction.EndDate.ToString();
            lblUser.Text = auction.UserId.ToString();
            if (auction.HighestBid != null)
            {
                lblAlta.Text = "$" + auction.HighestBid.ToString();
            }
            else
            {
                lblAlta.Text = "No se han hecho ofertas aún";
            }
            if (auction.Winner != null)
            {
                lblUrsOferta.Text = user.obtenerNombre(auction.Winner ?? default(int)).Name;
            }
            else
            {
                lblUrsOferta.Text = "No se han hecho ofertas aún";
            }
        }

        public int getUserID()
        {
            User usuario = new User();
            usuario = (User) Session["Usuario"];
            return usuario.UserId;
        }
        #endregion

        
    }
}