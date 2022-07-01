using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSaleApp.Entities
{
    public class CinemaChair
    {
        public string ChairNumber { get; set; }
        public string ChairRow { get; set; }
        public bool ChairStatus { get; set; }

        public CinemaChair(string row, string number)
        {
            ChairRow = row;
            ChairNumber = number;
        }



    }
}
