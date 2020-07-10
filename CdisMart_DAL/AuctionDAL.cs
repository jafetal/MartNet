using System;
using System.Collections.Generic;
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
    }
}
