using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSaleApp.Entities
{
    public class TicketSales:EntityBase
    {
        public decimal TotalPrice { get; set; }
        public string CreatedDate { get; set; }
        public string SessionTime { get; set; }
        public int TicketCount { get; set; }

        public TicketSales()
        {
            CreatedDate = DateTime.Now.ToString();
        }

        public override string ToString()
        {
            return $"{MovieName} adlı filmin {SessionTime} zamanlı seansına {TicketCount} adet bilet alınmıştır. Toplam Fiyat : {TotalPrice} TL'dir. ";
        }

    }
}
