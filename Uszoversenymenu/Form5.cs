﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Uszoversenymenu.Form1;

namespace Uszoversenymenu
{
    public partial class Form5 : Form
    {
        private int bal = 20, fent = 20, tavX = 120, tavY = 80, zaszloX = 75, zaszloY = 50, labelY = 15;
        private int oszlopSzam = 3;
        private List<Versenyzo> versenyzok;
        private List<string> zaszlok = new List<string>();
        private List<string> feliratok = new List<string>();

        public Form5()
        {
            InitializeComponent();

            // Panel inicializálása
            panel1 = new Panel();
            panel1.Size = new Size(400, 300);
            panel1.Location = new Point(10, 10);
            this.Controls.Add(panel1);

            this.Load += new EventHandler(ZaszloForm_Load);
        }

        private void ZaszloForm_Load(object sender, EventArgs e)
        {
            ZaszloKigyujt();
            ZaszloFelrak();
        }

        public void Fogad(List<Versenyzo> versenyzok)
        {
            this.versenyzok = new List<Versenyzo>(versenyzok);
        }

        private void ZaszloKigyujt()
        {
            foreach (var versenyzo in versenyzok)
            {
                if (!zaszlok.Contains(versenyzo.ZaszloNev))
                {
                    zaszlok.Add(versenyzo.ZaszloNev);
                    feliratok.Add(versenyzo.Orszag);
                }
            }
        }

        private void ZaszloFelrak()
        {
            PictureBox pctBox;
            Label felirat;
            int sor = 0, oszlop = 0;

            for (int i = 0; i < zaszlok.Count; i++)
            {
                pctBox = new PictureBox();
                pctBox.Location = new Point(bal + oszlop * tavX, fent + sor * tavY);
                pctBox.Size = new Size(zaszloX, zaszloY);
                pctBox.SizeMode = PictureBoxSizeMode.StretchImage;

                try
                {
                    pctBox.Image = Image.FromFile(zaszlok[i] + ".png");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hiba a kép betöltésekor: {zaszlok[i]}.png: {ex.Message}");
                    continue;
                }

                felirat = new Label();
                felirat.Location = new Point(pctBox.Location.X, pctBox.Location.Y + zaszloY);
                felirat.Size = new Size(zaszloX, labelY);
                felirat.TextAlign = ContentAlignment.MiddleCenter;
                felirat.Text = feliratok[i];

                panel1.Controls.Add(pctBox);
                panel1.Controls.Add(felirat);

                oszlop++;
                if (oszlop == oszlopSzam)
                {
                    oszlop = 0;
                    sor++;
                }
            }
        }

        private Panel panel1;
    }
}
