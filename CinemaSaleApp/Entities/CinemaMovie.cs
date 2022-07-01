using CinemaSaleApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSaleApp.Entities
{
    public class CinemaMovie:EntityBase
    {
        private void MovieDefault()
        {
            CinemaSessions = new List<CinemaSession>();
            DateTime dateNow = DateTime.Now;
            TimeSpan ts = new TimeSpan(9, 0, 0);

            for (int i = 0; i < 3; i++)
            {
                dateNow = dateNow.Date + ts;
                for (int j = 0; j < 3; j++)
                {
                    CinemaSession cinemaSession = new CinemaSession();
                    cinemaSession.movieDate = dateNow.ToShortDateString();
                    cinemaSession.movieTime = dateNow.ToShortTimeString();
                    CinemaSessions.Add(cinemaSession);
                    dateNow = dateNow.AddHours(3);
                }

                dateNow = dateNow.AddDays(1);
            }

        }

        public decimal MoviePrice { get; set; }
        public string MovieMinute { get; set; }
        public string MoviePicture { get; set; }
        public Category Category { get; set; }
        public List<CinemaSession> CinemaSessions { get; set; }

        public CinemaMovie()
        {
            MovieDefault();
        }


       

    }
}
