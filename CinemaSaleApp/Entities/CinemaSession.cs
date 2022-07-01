using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSaleApp.Entities
{
    public class CinemaSession
    {
        public CinemaSession()
        {
            Default();
        }

        private void Default()
        {
            CinemaChairs = new List<CinemaChair>();
            string[] cinemaRows = { "A", "B", "C", "D", "E", "F" };
            string[] cinemaNumbers = { "1", "2", "3", "4", "5", "6", "7", "8" };

            foreach (var item in cinemaRows)
            {
                foreach (var number in cinemaNumbers)
                {
                    CinemaChair cinemaChair = new CinemaChair(item, number);
                    CinemaChairs.Add(cinemaChair);
                }
            }
        }

        public string movieDate { get; set; }
        public string movieTime { get; set; }
        public List<CinemaChair> CinemaChairs { get; set; }
    }
}
