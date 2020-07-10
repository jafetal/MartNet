using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CdisMart_DAL;
using CdisMart_BLL;

namespace CdisMart.Subastas
{
    public partial class subasta_i : System.Web.UI.Page
    {
        #region eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            txtFechaI.Text = DateTime.Now.Date.ToString().Substring(0,10).Replace('/','-');
        }
        
        protected void agregar_Click(object sender, EventArgs e)
        {
            if (agregarSubasta())
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                    "alert",
                    "alert('La subasta ha sido creada');window.location ='ListaSubastas_s.aspx';",
                    true);
                //Response.Redirect("~/Subastas/ListaSubastas_s.aspx");
            }
            
        }
        #endregion

        #region métodos

        public bool agregarSubasta()
        {
            User usuario = new User();
            usuario = (User)Session["Usuario"];
            Auction subasta = new Auction();

            subasta.ProductName = txtNombre.Text;
            subasta.Description = txtDescripcion.Text;

            DateTime dtDate = DateTime.ParseExact(txtFechaI.Text, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
            var dtTime = DateTime.ParseExact(txtFIH.Text+":00", "HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            subasta.StartDate = new DateTime(dtDate.Year, dtDate.Month, dtDate.Day, dtTime.Hour, dtTime.Minute, dtTime.Second);

            DateTime dtDateF = DateTime.ParseExact(txtFechaF.Text, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
            var dtTimeF = DateTime.ParseExact(txtFFH.Text + ":00", "HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            subasta.EndDate = new DateTime(dtDateF.Year, dtDateF.Month, dtDateF.Day, dtTimeF.Hour, dtTimeF.Minute, dtTimeF.Second);

            subasta.UserId = usuario.UserId;

            AuctionBLL cSubasta = new AuctionBLL();
            try
            {
                cSubasta.addAuction(subasta);
                return true;
            } catch(Exception e)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "alert('" + e.Message + "')", true);
                return false;
            }

        }
        #endregion


        #region validadores
        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
                IFormatProvider culture = new CultureInfo("en-AU", true);
                try
                {
                    String[] formats = { "dd MM yyyy", "dd/MM/yyyy", "dd-MM-yyyy" };
                    DateTime dt1;
                    dt1 = DateTime.ParseExact(args.Value, formats, culture, DateTimeStyles.AdjustToUniversal);
                    args.IsValid = true;
                }
                catch
                {
                    args.IsValid = false;
                }
        }

        protected void c_horaI_ServerValidate(object source, ServerValidateEventArgs args)
        {
            /**try
            {
                int i = int.Parse(args.Value);
                args.IsValid = ((i % 2) == 0);

            }

            catch (Exception ex)
            {
                args.IsValid = false;
            }**/
        }
        #endregion


    }
}