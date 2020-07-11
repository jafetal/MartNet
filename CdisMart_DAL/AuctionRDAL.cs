using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CdisMart_DAL
{
    public class AuctionRDAL
    {
        CdisMartEntities1 modelo;
        public AuctionRDAL()
        {
            modelo = new CdisMartEntities1();
        }

        public void addRecord(AuctionRecord auctionR)
        {
            modelo.AuctionRecord.Add(auctionR);
            modelo.SaveChanges();
        }
    }
}
