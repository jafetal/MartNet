using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CdisMart_DAL;

namespace CdisMart_BLL
{
    public class AuctionRBLL
    {
        public void addRecord(AuctionRecord auctionR,int userId)
        {
            AuctionRDAL auctionRDAL = new AuctionRDAL();
            AuctionBLL auction = new AuctionBLL();
            if (userId == auctionR.UserId)
            {
                throw new Exception("No se le permite ofertar en esta subasta, ya que usted es el organizador.");
            }else if (auctionR.Amount<=auction.cargarSubasta(auctionR.AuctionId).HighestBid && auction.cargarSubasta(auctionR.AuctionId).HighestBid!=null)
            {
                throw new Exception("La oferta debe ser mayor que la oferta actual.");
            }else if (auctionR.BidDate>= auction.cargarSubasta(auctionR.AuctionId).EndDate)
            {
                throw new Exception("La subasta ha finalizado.");
            }
            else
            {
                Auction modifica = new Auction();
                modifica = auction.cargarSubasta(auctionR.AuctionId);
                modifica.HighestBid = auctionR.Amount;
                modifica.Winner = auctionR.UserId;
                auction.actualizarSubasta(modifica);
                auctionRDAL.addRecord(auctionR);
            }
            
        }

        public List<object> cargarSubastasIdS(int idSubasta)
        {
            AuctionRDAL auctionRDAL = new AuctionRDAL();
            return auctionRDAL.cargarSubastasIdS(idSubasta);
        }
        public List<AuctionRecord> cargarSubastasId(int idSubasta)
        {
            AuctionRDAL auctionRDAL = new AuctionRDAL();
            return auctionRDAL.cargarSubastasId(idSubasta);
        }

    }
}
