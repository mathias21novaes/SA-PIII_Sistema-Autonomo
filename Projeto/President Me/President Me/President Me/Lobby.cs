﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MePresidentaServidor;

namespace President_Me
{
    public partial class Lobby : Form
    {
        int X = 0;
        int Y = 0;

        public Lobby(string Versao)
        {
            InitializeComponent();
            lblversao.Text = Versao;
            Location = new Point(700, 700);

            this.MouseDown += new MouseEventHandler(Lobby_MouseDown);
            this.MouseMove += new MouseEventHandler(Lobby_MouseMove);
        }

        private void Lobby_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            X = this.Left - MousePosition.X;
            Y = this.Top - MousePosition.Y;
        }

        private void Lobby_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            this.Left = X + MousePosition.X;
            this.Top = Y + MousePosition.Y;
        }

        private void Lobby_Load(object sender, EventArgs e)
        {

        }

        private void btn_fechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_entrar_Click(object sender, EventArgs e)
        {
            Entrar_Partida p = new Entrar_Partida();
            p.ShowDialog();

            if (Entrar_Partida.entrou_partida == true)
            {
                this.Close();
            }
        }

        private void btn_criar_Click(object sender, EventArgs e)
        {
            Criar_Partida c = new Criar_Partida();
            c.ShowDialog();
        }
    }
}
