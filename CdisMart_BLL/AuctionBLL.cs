using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CdisMart_DAL;

namespace CdisMart_BLL
{
    public class AuctionBLL
    {
        public void addAuction(Auction auction)
        {
            AuctionDAL auctionDAL = new AuctionDAL();
            Console.WriteLine(auctionDAL.subastasActivas(auction.UserId));
            if (auctionDAL.subastasActivas(auction.UserId) < 3)
            {
                auctionDAL.addAuction(auction);
            }
            else
            {
                throw new Exception("No se puede tener mas de 3 subastas activas.");
            }
        }

        public List<object> cargarSubastas()
        {
            AuctionDAL auctionDAL = new AuctionDAL();
            return auctionDAL.cargarSubastas();
        }
    }
}
