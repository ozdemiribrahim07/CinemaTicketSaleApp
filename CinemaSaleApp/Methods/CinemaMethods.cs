using CinemaSaleApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSaleApp.Methods
{
    public class CinemaMethods
    {
        public static List<CinemaMovie> AddMovie()
        {
            string Path = "C:/Users/İbrahim/Source/Repos/CinemaSaleApp/CinemaSaleApp/MoviePictures/";

            return new List<CinemaMovie>()
            {
                new CinemaMovie()
                {
                    MovieName = "Freedom",
                    Category = Enums.Category.Gerilim,
                    MovieMinute = "3 Saat 50 Dakika",
                    MoviePrice = 60,
                    MoviePicture = Path + "1.jpg"

                },
                 new CinemaMovie()
                {
                    MovieName = "Assasin",
                    Category = Enums.Category.Aksiyon,
                    MovieMinute = "3 Saat ",
                    MoviePrice = 65,
                    MoviePicture = Path + "2.jpg"

                },
                  new CinemaMovie()
                {
                    MovieName = "Life Of Game",
                    Category = Enums.Category.Bilimkurgu,
                    MovieMinute = "2 Saat 35 Dakika",
                    MoviePrice = 50,
                    MoviePicture = Path + "3.jpeg"

                }

            };
        }

    }
}
