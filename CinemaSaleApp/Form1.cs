using CinemaSaleApp.Entities;
using CinemaSaleApp.Methods;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<CinemaMovie> cinemaMovies;

        DateTime currentDate = DateTime.Now;
        DateTime useDate;
        KoltukSecimi koltukSecimi;
        private void Form1_Load(object sender, EventArgs e)
        {
            useDate = currentDate;
            lbldate.Text = useDate.ToShortDateString();
            cinemaMovies = CinemaMethods.AddMovie();
            controlList();

            koltukSecimi = new KoltukSecimi(cinemaMovies,this);



        }

        private void controlList()
        {
            Size pictureSize = new Size(300, 420);
            Size buttonSize = new Size(80, 40);
            int x = 60;
            int y = 80;
            int xIncrease = 400;
            int yIncrease = 300;
            for (int i = 0; i < cinemaMovies.Count; i++)
            {
                PictureBox pictureBox = new PictureBox();
                pictureBox.Location = new Point(x,y);
                pictureBox.Size = pictureSize;
                pictureBox.Image = Image.FromFile(cinemaMovies[i].MoviePicture);
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                this.Controls.Add(pictureBox);
                int xButton = x;
                int yButton = pictureBox.Bottom + 10;

                for (int j = 0; j < 3; j++)
                {
                    Button btn = new Button();
                    btn.Text = cinemaMovies[i].CinemaSessions[j].movieTime;
                    btn.Location = new Point(xButton, yButton);
                    btn.Size = buttonSize;
                    btn.Tag = i;
                    btn.Click += new EventHandler(button_Click);
                    this.Controls.Add(btn);

                    xButton += 110;
                }

                if (1280 >  x + xIncrease + pictureBox.Width)
                {
                    x += xIncrease;
                }
                else
                {
                    x = 50;
                    y += yIncrease;
                }
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int indexMovie = Convert.ToInt32(btn.Tag);
            string timeSession = btn.Text;
            string dateSession = lbldate.Text;

            if (DateTime.Parse($"{dateSession} {timeSession}") < DateTime.Now)
            {
                MessageBox.Show("Seçilen Film Seansı'nı Geçtiniz !");
                return;
            }

            this.Hide();
            koltukSecimi.Show();

            koltukSecimi.Detail(indexMovie,timeSession,dateSession);

        }

        private void btnnext_Click(object sender, EventArgs e)
        {
            useDate = useDate.AddDays(1);
            lbldate.Text = useDate.ToShortDateString();
            btnpre.Enabled = true;

            if (currentDate.AddDays(2) == useDate)
            {
                btnnext.Enabled = false;
            }


        }

        private void btnpre_Click(object sender, EventArgs e)
        {
            useDate = useDate.AddDays(-1);
            lbldate.Text = useDate.ToShortDateString();
            btnpre.Enabled = true;

            if (currentDate == useDate)
            {
                btnpre.Enabled = false;
                btnnext.Enabled = true;
            }
        }
    }
}
