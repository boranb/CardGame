using System;
using System.Collections;
using System.Threading;
using System.Windows.Forms;

namespace CardGame
{
    public partial class Form1 : Form
    {
        private enum Tiklamalar
        {
            ilkTiklama, ikinciTiklama
        }

        private Tiklamalar tiklama = Tiklamalar.ilkTiklama;
        private PictureBox oncekiResim;

        public Form1()
        {
            InitializeComponent();
        }

        private void ResimleriGizle()
        {
            foreach (PictureBox x in panel1.Controls)
            {
                x.Image = imgList.Images[0];
            }
        }

        private void ResimleriGoster()
        {
            foreach (PictureBox x in panel1.Controls)
            {
                x.Image = imgList.Images[(int)x.Tag];
            }
        }

        private void ResimleriDoldur()
        {
            ArrayList Tagler = new ArrayList();
            for (int i = 0; i < (imgList.Images.Count - 1) * 2; i++)
            {
                Tagler.Add((i % 32) + 1);
            }

            foreach (PictureBox x in panel1.Controls)
            {
                int sansli = new Random().Next(Tagler.Count);
                x.Tag = Tagler[sansli];
                Tagler.RemoveAt(sansli);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ResimleriDoldur();
            ResimleriGizle();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            PictureBox simdikiResim = sender as PictureBox;
            simdikiResim.Image = imgList.Images[(int)simdikiResim.Tag];

            if (oncekiResim == simdikiResim)
            {
                return;
            }

            panel1.Refresh();
            switch (tiklama)
            {
                case Tiklamalar.ilkTiklama:
                    oncekiResim = simdikiResim;
                    tiklama = Tiklamalar.ikinciTiklama;
                    break;

                case Tiklamalar.ikinciTiklama:
                    Thread.Sleep(500);
                    if (oncekiResim.Tag.ToString() == simdikiResim.Tag.ToString())
                    {
                        oncekiResim.Hide();
                        simdikiResim.Hide();
                    }

                    ResimleriGizle();
                    {
                        tiklama = Tiklamalar.ilkTiklama;
                        break;
                    }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ResimleriGoster();
            panel1.Refresh();
            Thread.Sleep(1000);
            ResimleriGizle();
        }
    }
}