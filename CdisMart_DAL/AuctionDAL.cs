using System;
using System.Collections.Generic;
using System.Data.Objects.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CdisMart_DAL
{
    public class AuctionDAL
    {
        CdisMartEntities1 modelo;
        public AuctionDAL()
        {
            modelo = new CdisMartEntities1();
        }

        public void addAuction(Auction auction)
        {
            modelo.Auction.Add(auction);
            modelo.SaveChanges();
        }

        public int subastasActivas(int idUser)  //obtiene la cantidad de subastas activas por usuario
        {
            var subastas = from mSubasta in modelo.Auction
                           where mSubasta.UserId == idUser
                           select mSubasta;

            int contador = 0;
            foreach(Auction a in subastas.ToList())
            {
                if(a.EndDate.Date > DateTime.Now)
                {
                    contador += 1;
                }
            }

            return contador;
        }

        public List<object> cargarSubastas()
        {
            var subastas = from msubasta in modelo.Auction
                           select new
                           {
                               Auctionid = msubasta.AuctionId,
                               ProductName = msubasta.ProductName,
                               Description = msubasta.Description,
                               StartDate = SqlFunctions.DateName("day", msubasta.StartDate) + "-" + SqlFunctions.DateName("month", msubasta.StartDate) + "-" + SqlFunctions.DateName("year", msubasta.StartDate),
                               StartHour = SqlFunctions.DateName("hour", msubasta.StartDate) + ":" + SqlFunctions.DateName("minute", msubasta.StartDate),
                               EndDate = SqlFunctions.DateName("day", msubasta.EndDate) + "-" + SqlFunctions.DateName("month", msubasta.EndDate) + "-" + SqlFunctions.DateName("year", msubasta.EndDate),
                               EndHour = SqlFunctions.DateName("hour", msubasta.EndDate) + ":" + SqlFunctions.DateName("minute", msubasta.EndDate)

                           };
            return subastas.AsEnumerable<object>().ToList();
        }

        public Auction cargarSubasta(int idSubasta)
        {
            var subasta = (from msubasta in modelo.Auction
                            where msubasta.AuctionId == idSubasta
                            select msubasta).FirstOrDefault();

            return subasta;
        }

        public void actualizarSubasta(Auction pAuction)
        {
            var subasta = (from msubasta in modelo.Auction
                           where msubasta.AuctionId == pAuction.AuctionId
                           select msubasta).FirstOrDefault();

            subasta.HighestBid = pAuction.HighestBid;
            subasta.Winner = pAuction.Winner;

            modelo.SaveChanges();
        }
    }
}
