using CinemaSaleApp.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinemaSaleApp
{
    public partial class KoltukSecimi : Form
    {
        public KoltukSecimi(List<CinemaMovie> _movie, Form1 _form1)
        {
            InitializeComponent();
            movies = _movie;
            form1 = _form1;

        }

        List<CinemaMovie> movies;
        Form1 form1;
        CinemaMovie selectedmovie;
        CinemaSession selectedsession;

        public void Detail(int indexMovie, string _time, string _date)
        {
            selectedmovie = movies[indexMovie];
            selectedsession = selectedmovie.CinemaSessions.Find(x => x.movieDate == _date && x.movieTime == _time);
           
            lbldatetime.Text = $"{_date} - {_time}";
            lbldak.Text = selectedmovie.MovieMinute;
            lblfiyat.Text = selectedmovie.MoviePrice.ToString() + " TL";
            selectedpic.Image = Image.FromFile(selectedmovie.MoviePicture);
            lblkat.Text = selectedmovie.Category.ToString();

            CheckStatus();

        }


        private void CheckStatus()
        {
            foreach (Control item in grbchair.Controls)
            {
                if (item is Button)
                {
                    string chairrow = item.Tag.ToString();
                    string number = item.Text;
                    item.Enabled = true;

                    foreach (CinemaChair chair in selectedsession.CinemaChairs)
                    {
                        if (chair.ChairRow == chairrow && chair.ChairNumber == number)
                        {
                            if (chair.ChairStatus)
                            {
                                item.BackColor = Color.DarkRed;
                                item.Enabled = false;
                            }
                            else
                            {
                                item.BackColor = Color.LightGreen;
                            }
                            break;
                        }


                    }

                }
            }

        }

        List<CinemaChair> cinemaChairs = new List<CinemaChair>();

        private void button36_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string row = btn.Tag.ToString();
            string number = btn.Text;

            CinemaChair chair = selectedsession.CinemaChairs.Find(x => x.ChairRow == row && x.ChairNumber == number);

            if (btn.BackColor.Name!= "Blue")
            {
                cinemaChairs.Add(chair);
                btn.BackColor = Color.Blue;
            }
            else
            {
                cinemaChairs.Remove(chair);
                btn.BackColor = Color.LightGreen;

            }


        }

        private decimal FiyatHesapla()
        {
            decimal fiyat = selectedmovie.MoviePrice * cinemaChairs.Count;
            return fiyat;
        }


        private void button37_Click(object sender, EventArgs e)
        {
            if (cinemaChairs.Count == 0)
            {
                MessageBox.Show("Lütfen bir koltuk seçiniz !");
                return;
            }

            TicketSales sales = new TicketSales();

            sales.MovieName = selectedmovie.MovieName;
            sales.TicketCount = cinemaChairs.Count;
            sales.SessionTime = $"{selectedsession.movieDate} - {selectedsession.movieTime}";
            sales.TotalPrice = FiyatHesapla();

            foreach (CinemaChair item in cinemaChairs)
            {
                item.ChairStatus = true;
            }


            MessageBox.Show(sales.ToString());
            SayfaDegis();
        }


        private void SayfaDegis()
        {
            this.Hide();
            form1.Show();
        }

        private void button38_Click(object sender, EventArgs e)
        {
            SayfaDegis();
        }
    }
}
