using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace Grafico
{
    public partial class frmGrafico : Form
    {
        bool esperaPonto = false;
        bool esperaInicioReta = false;
        bool esperaFimReta = false;
        private ListaSimples<Ponto> figuras = new ListaSimples<Ponto>();
        private static Ponto p1 = new Ponto(0, 0, Color.Black);

        Color corAtual = Color.Black;
	
        private void limparEsperas()
        {
            esperaPonto = false;
            esperaInicioReta = false;
            esperaFimReta = false;
        }

        public frmGrafico()
        {
            InitializeComponent();
        }

        private void pbAreaDesenho_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics; // acessa contexto gráfico

            figuras.IniciarPercursoSequencial();
            while (!figuras.ChegouNoFim())
            {
                Ponto figuraAtual = figuras.Atual.Info;
                figuraAtual.Desenhar(figuraAtual.Cor, g);
            }
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            //Está dando erro!!!
            if (dlgAbrir.ShowDialog() == DialogResult.OK)
                try
                {
                    StreamReader arqFiguras = new StreamReader(dlgAbrir.FileName);
                    String linha = arqFiguras.ReadLine();
                    Double xInfEsq = Convert.ToDouble(linha.Substring(0, 5).Trim());
                    Double yInfEsq = Convert.ToDouble(linha.Substring(5, 5).Trim());
                    Double xSupDir = Convert.ToDouble(linha.Substring(10, 5).Trim());
                    Double ySupDir = Convert.ToDouble(linha.Substring(15, 5).Trim());

                    while (!arqFiguras.EndOfStream)
                    {
                        String tipo = linha.Substring(0, 5).Trim();
                        int xBase = Convert.ToInt32(linha.Substring(5, 5).Trim());
                        int yBase = Convert.ToInt32(linha.Substring(10, 5).Trim());
                        int corR = Convert.ToInt32(linha.Substring(15, 5).Trim());
                        int corG = Convert.ToInt32(linha.Substring(20, 5).Trim());
                        int corB = Convert.ToInt32(linha.Substring(25, 5).Trim());
                        Color cor = new Color();
                        cor = Color.FromArgb(255, corR, corG, corB);

                        switch (tipo[0])
                        {
                            case 'p': // figura é um ponto
                                figuras.InserirAposFim(
                                    new NoLista<Ponto>(new Ponto(xBase, yBase, cor), null));
                                break;
                            case 'l': // figura é uma reta
                                int xFinal = Convert.ToInt32(linha.Substring(30, 5).Trim());
                                int yFinal = Convert.ToInt32(linha.Substring(35, 5).Trim());
                                figuras.InserirAposFim(new NoLista<Ponto>(
                                        new Reta(xBase, yBase, xFinal, yFinal, cor), null));
                                break;
                            case 'c': // figura é um círculo
                                int raio = Convert.ToInt32(linha.Substring(30, 5).Trim());
                                figuras.InserirAposFim(new NoLista<Ponto>(
                                           new Circulo(xBase, yBase, raio, cor), null));
                                break;
                        }
                    }
                    arqFiguras.Close();
                    this.Text = dlgAbrir.FileName;
                    pbAreaDesenho.Invalidate();
                }
                catch (IOException)
                {
                    Console.WriteLine("Erro de leitura no arquivo");
                }
        }
        

        private void pbAreaDesenho_MouseMove(object sender, MouseEventArgs e)
        {
            stMensagem.Items[3].Text = e.X + "," + e.Y;
        }

        private void btnPonto_Click(object sender, EventArgs e)
        {
            stMensagem.Items[1].Text = "clique no local do ponto desejado:";
            limparEsperas();
            esperaPonto = true;

        }

        private void pbAreaDesenho_MouseClick(object sender, MouseEventArgs e)
        {
            if (esperaPonto)
            {
                Ponto novoPonto = new Ponto(e.X, e.Y, corAtual);
                figuras.InserirAposFim(new NoLista<Ponto>(novoPonto, null));
                novoPonto.Desenhar(novoPonto.Cor, pbAreaDesenho.CreateGraphics());
                esperaPonto = false;
                stMensagem.Items[1].Text = "";
            }
            else
                if (esperaInicioReta)
                 {
                     p1.Cor = corAtual;
                     p1.X = e.X;
                     p1.Y = e.Y;
                     esperaInicioReta = false;
                     esperaFimReta = true;
                     stMensagem.Items[1].Text = "Mensagem: clique o ponto final da reta";
            }
            else
                  if (esperaFimReta)
                  {
                     esperaInicioReta = false;
                     esperaFimReta = false;
                     Reta novaLinha = new Reta(p1.X, p1.Y, e.X, e.Y, corAtual);
                     figuras.InserirAposFim(new NoLista<Ponto>(novaLinha, null));
                     novaLinha.Desenhar(novaLinha.Cor, pbAreaDesenho.CreateGraphics());
                    }



        }

        private void btnReta_Click(object sender, EventArgs e)
        {
            stMensagem.Items[1].Text = "Clique no local do ponto inicial da reta:";
            limparEsperas();
            esperaInicioReta = true;

        }
    }

    

}


