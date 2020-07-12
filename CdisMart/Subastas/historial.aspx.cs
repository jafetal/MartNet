using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CdisMart_DAL;
using CdisMart_BLL;

namespace CdisMart.Subastas
{
    public partial class historial : System.Web.UI.Page
    {
        #region eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int idSubasta = int.Parse(Request.QueryString["pId"]);
                cargarSubasta(idSubasta);
                grd_Records.DataSource = cargarOfertas(idSubasta);
                grd_Records.DataBind();
                cargarUsuariosEnSubasta(idSubasta);
            }
        }

        #endregion

        #region metodos

        public void cargarUsuariosEnSubasta(int idSubasta)
        {
            UsuarioBLL users = new UsuarioBLL();
            AuctionRBLL auctionRBLL = new AuctionRBLL();
            List<AuctionRecord> Lista = new List<AuctionRecord>();
            Lista = auctionRBLL.cargarSubastasId(idSubasta);
            List<string> usuarios = new List<string>();

            foreach(AuctionRecord oferta in Lista)
            {
                if (!usuarios.Contains(users.obtenerNombre(oferta.UserId).UserName))
                {
                    usuarios.Add(users.obtenerNombre(oferta.UserId).UserName);
                }
            }

            DDLUsers.DataSource = usuarios;
            DDLUsers.DataBind();

            DDLUsers.Items.Insert(0, new ListItem("---- Todos los usuarios ----", "0"));
        }

        public void cargarSubasta(int idSubasta)
        {
            AuctionBLL auctionBLL = new AuctionBLL();
            Auction auction = new Auction();
            

            auction = auctionBLL.cargarSubasta(idSubasta);

            lblName.Text = auction.ProductName;
            lblDescription.Text = auction.Description;
        }

        public List<object> cargarOfertas(int idSubasta)
        {
            AuctionRBLL auctionRBLL = new AuctionRBLL();
            UsuarioBLL user = new UsuarioBLL();

            List<object> listAuctions = new List<object>();
            listAuctions = auctionRBLL.cargarSubastasIdS(idSubasta);
            return listAuctions;
        }

        public String obtenerNombre(int id)
        {
            UsuarioBLL user = new UsuarioBLL();
            return user.obtenerNombre(id).UserName;
        }



        #endregion
    }
}