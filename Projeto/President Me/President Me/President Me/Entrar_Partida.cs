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
    public partial class Entrar_Partida : Form
    {
        //---VARIAVEIS---
        public int idpartida { get; set; }
        public string idp { get; set; }
        public string nome_jogador { get; set; }
        public string senha_partida { get; set; }
        public string listar { get; set; }
        public string idesenha_jogador { get; set; }
        public string versao { get; set; }
        public static  string idJogador { get; set; }
        public string DadosJogador { get; set; }
        public static bool iniciou_partida { get; set; }
        public int numJogadores { get; set; }
        public string ListarJogadores { get; set; }
        public static string []colunas { get; set; }
        public string []listP { get; set; }
        public string listpartidas { get; set; }
        public static string []id { get; set; }

        public Entrar_Partida()
        {
            InitializeComponent();
        }

        private void btn_voltar_Click(object sender, EventArgs e)
        {
            Lobby f = new Lobby(versao);
            iniciou_partida = false;
            this.Close();
        }

        private void btn_listar_Click(object sender, EventArgs e)
        {
            listar = Jogo.ListarPartidas();
            //txtListarPartidas.Text = listar;
            listP = this.listar.Split('\n');
            for (int i = 0; i < listP.Length; i++)
            {
                listPartidas.Items.Add(listP[i].ToString());
            }
        }

        private void btn_entrar_Click(object sender, EventArgs e)
        {
            //txtId_Entrar.Text = id[1];
            //this.idp = txtId_Entrar.Text;
            idpartida = int.Parse(id[1]);
            this.nome_jogador = txtJogador.Text;
            this.senha_partida = txtSenha_Entrar.Text;
            this.idesenha_jogador = Jogo.Entrar(idpartida, nome_jogador, senha_partida);
            lblEntrou.Text = "ENTROU NA PARTIDA";
            //lblEntrou.Text = "";

            colunas = this.idesenha_jogador.Split(',');
            lblDadosJogadorId.Text = colunas[0];
            lblDadosJogadorSenha.Text = colunas[1];
            this.numJogadores++;

            ListarJogadores = Jogo.ListarJogadores(idpartida);
            txtListarJogadores.Text = ListarJogadores;
        }

        private void btn_iniciar_Click(object sender, EventArgs e)
        {
            if (numJogadores > 1 && numJogadores < 7)
            {
                //lblEntrou.Text = "ENTROU NA PARTIDA";
                idJogador = Jogo.Iniciar(idpartida, senha_partida);
                iniciou_partida = true;
                this.Close();
            }
            else
            {
                lblnumJog.Text = "JOGADORES INSUFICIENTES";
                iniciou_partida = false;
            }
        }

        private void listPartidas_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.listpartidas = listPartidas.Text.ToString();
            id = this.listpartidas.Split(',');
            String status = id[0];
            String idl = id[1];
            String data = id[2];
            String nome = id[3];
        }
    }
}
