﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MIS
{
    public partial class FormBekijkenprofiel : Form
    {
        private int UserId;

        public FormBekijkenprofiel(int userid)
        {
            InitializeComponent();
            UserId = userid;
        }

        private void FormBekijkenprofiel_Load(object sender, EventArgs e)
        {
            var gebruiker = DatabaseManager.GebruikerOpvragen(UserId);
            Naam.Text = gebruiker.voornaam + " " + gebruiker.achternaam;
            Adres.Text = gebruiker.woonplaats;
            Kanpassenop.Text = gebruiker.diertypes;
            Overmijinfo.Text = gebruiker.overmij;
            Prijs.Text = "Prijs per dag: €" + gebruiker.vraagprijs;
            //Rating
            var list = new List<PictureBox>() { nul, een, twee, drie, vier, vijf };
            list[gebruiker.rating].Visible = true;
            Verified.Visible = gebruiker.verified;
        }
    } 

}
