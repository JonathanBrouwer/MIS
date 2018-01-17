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
    public partial class FormHome : Form
    {
        public static FormHome Home;
        public static ControlZoekenHeader CZH = new ControlZoekenHeader();
        public static ControlZoekenBody CZB = new ControlZoekenBody();
        public FormHome()
        {
            InitializeComponent();
            Home = this;

            SetFullscreenMode(true);
            panelH.Controls.Add(new ControlLogin());
        }

        public void SetFullscreenMode(bool fullsceen)
        {
            if (fullsceen)
            {
                panelH.Size = new Size(985, 109 + 554);
                panelB.Visible = false;
            }else
            {
                panelH.Size = new Size(985, 109);
                panelB.Visible = true;
            }
        }

        public void NaarZoeken()
        {
            FormHome.Home.panelH.Controls.Clear();
            FormHome.Home.panelH.Controls.Add(FormHome.CZH);
            FormHome.Home.panelB.Controls.Clear();
            FormHome.Home.panelB.Controls.Add(FormHome.CZB);
            FormHome.Home.SetFullscreenMode(false);
            CZH.pictureBox1.Visible = SessionManager.IsLoggedIn();
            CZH.label2.Visible = SessionManager.IsLoggedIn();
            if (SessionManager.IsLoggedIn())
            {
                CZH.label2.Text = ((Gebruiker)SessionManager.GetCurrentUser()).voornaam;
            }
        }

        public void NaarInloggen()
        {
            SessionManager.SetCurrentUser(null);
            FormHome.Home.panelH.Controls.Clear();
            FormHome.Home.panelH.Controls.Add(new ControlLogin());
            FormHome.Home.panelB.Controls.Clear();
            FormHome.Home.SetFullscreenMode(true);
        }
    }
}
