using System;
using System.Collections.Generic;
using System.Data.Objects.SqlClient;
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

        public List<object> cargarSubastasIdS(int idSubasta)
        {

            var ofertas = from mrecord in modelo.AuctionRecord
                          where mrecord.AuctionId == idSubasta
                          select new
                          {
                              UserName = modelo.User
                                .Where(x => x.UserId == mrecord.UserId)
                                .Select(x => x.UserName).FirstOrDefault(),
                              Amount = mrecord.Amount,
                              BidDate = SqlFunctions.DateName("day", mrecord.BidDate) + "-" + SqlFunctions.DateName("month", mrecord.BidDate) + "-" + 
                              SqlFunctions.DateName("year", mrecord.BidDate) + "  " + SqlFunctions.DateName("hour", mrecord.BidDate) + ":" + SqlFunctions.DateName("minute", mrecord.BidDate)
                           };
            return ofertas.AsEnumerable<object>().ToList();
        }

        public List<AuctionRecord> cargarSubastasId(int idSubasta)
        {

            var ofertas = from mrecord in modelo.AuctionRecord
                          where mrecord.AuctionId == idSubasta
                          select mrecord;
            return ofertas.AsEnumerable<AuctionRecord>().ToList();
        }
    }
}
