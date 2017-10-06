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
        bool esperaInicioCirculo = false;
        bool esperaFimCirculo = false;
        bool esperaInicioElipse = false;
        bool esperaFimElipse = false;
        bool esperaSeleciona = false;

        private ListaSimples<Ponto> figuras = new ListaSimples<Ponto>();
        private ListaSimples<Ponto> Selecionadas = new ListaSimples<Ponto>();
        private static Ponto p1 = new Ponto(0, 0, Color.Black);


        Color corAtual = Color.Black;
        Color novaCor;

        private void limparEsperas()
        {
            esperaPonto = false;
            esperaInicioReta = false;
            esperaFimReta = false;
            esperaInicioCirculo = false;
            esperaFimCirculo = false;
            esperaInicioElipse = false;
            esperaFimElipse = false;
            esperaSeleciona = false;
        }

        public frmGrafico()
        {
            InitializeComponent();
        }

        private void pbAreaDesenho_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;    // acessa contexto gráfico
            
            //g.Clear(SystemColors.Control); //limpa a tela
            figuras.IniciarPercursoSequencial();
            while (figuras.podePercorrer())
            {
                Ponto figuraAtual = figuras.Atual.Info;
                figuraAtual.Desenhar(figuraAtual.Cor, g);
            }
        }
        
        //deve redesenhar as figuras quando um novo arquivo for aberto e quando maximiza, minimiza a janela!
        

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            if (dlgAbrir.ShowDialog() == DialogResult.OK)
                try
                {
                    StreamReader arqFiguras = new StreamReader(dlgAbrir.FileName);
                    String linha = arqFiguras.ReadLine();
                    Double xInfEsq = Convert.ToDouble(linha.Substring(0, 5).Trim());
                    Double yInfEsq = Convert.ToDouble(linha.Substring(5, 5).Trim());
                    Double xSupDir = Convert.ToDouble(linha.Substring(10, 5).Trim());
                    Double ySupDir = Convert.ToDouble(linha.Substring(15, 5).Trim());

                    while ((linha = arqFiguras.ReadLine()) != null)
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
            //criar forma de iniciar o percurso de traz para frente!!
                figuras.IniciarPercursoSequencialTP();          //percorre de traz pra frente
                while (figuras.podePercorrerTP())  
                {
                     if (figuras.Atual.Info.PertenceFigura(e.X, e.Y)) //ve se o ponto selecionado na tela pertence a alguma figura que
                     {                                                //esta na lista ligada de figuras
                         Selecionadas.InserirAposFim(figuras.Atual);  // adiciona a figura que pertence ao ponto em uma nova lista
                         stMensagem.Items[1].Text = "Figura selecionada";    //sempre selecionara a ultima figura desenhada, ou seja, a do ultimo plano caso 
                                                                             //seja clicado em mais de uma figura
                         if(!Selecionadas.EstaVazia)
                         {
                             Selecionadas.IniciarPercursoSequencial();
                             while(Selecionadas.podePercorrer())
                             {
                                 if(figuras.Atual.Info.PertenceFigura(e.X, e.Y)){     //se o clicou mais uma vez em cima da mesma figura
                                  if(Selecionadas.Atual.Info == figuras.Atual.Info)
                                     Selecionadas.Remover(Seleciondas.Atual.Info);     //figura deixa de ser selecionada                             
                             }
                         }
                     }
                     else    // caso clique em um ponto onde não tem figuras, a lista de figuras selecionadas é limpada;
                     {
                         Selecionadas.LimparLista();
                         stMensagem.Items[1].Text = "";
                     }
                }
                
            

            if (esperaPonto)
            {
                esperaPonto = false;
                Ponto novoPonto = new Ponto(e.X, e.Y, corAtual);
                figuras.InserirAposFim(new NoLista<Ponto>(novoPonto, null));
                novoPonto.Desenhar(novoPonto.Cor, pbAreaDesenho.CreateGraphics());
                stMensagem.Items[1].Text = "clique no local do ponto desejado:";
            }
            else
                if (esperaInicioReta)
            {
                esperaInicioReta = false;
                p1.Cor = corAtual;
                p1.X = e.X;
                p1.Y = e.Y;
                esperaFimReta = true;
                stMensagem.Items[1].Text = "clique o ponto final da reta";
            }
            else
                  if (esperaFimReta)
            {
                esperaFimReta = false;
                Reta novaLinha = new Reta(p1.X, p1.Y, e.X, e.Y, corAtual);
                figuras.InserirAposFim(new NoLista<Ponto>(novaLinha, null));
                novaLinha.Desenhar(novaLinha.Cor, pbAreaDesenho.CreateGraphics());
                stMensagem.Items[1].Text = "Clique no local do ponto inicial da reta:";
            }
            else
                  if (esperaInicioCirculo)
            {
                esperaInicioCirculo = false;
                esperaFimCirculo = true;
                p1.X = e.X;
                p1.Y = e.Y;
                stMensagem.Items[1].Text = "clique o ponto da extremidade do circulo";
            }
            else
                  if (esperaFimCirculo)
            {
                esperaFimCirculo = false;
                Circulo novaLinha = new Circulo(p1.X, p1.Y, (int)Math.Sqrt(Math.Pow(p1.X - e.X, 2) + Math.Pow(p1.Y - e.Y, 2)), corAtual);
                figuras.InserirAposFim(new NoLista<Ponto>(novaLinha, null));
                novaLinha.Desenhar(novaLinha.Cor, pbAreaDesenho.CreateGraphics());
                stMensagem.Items[1].Text = "Clique no local do ponto central do círculo:";
            }
            else
                  if (esperaInicioElipse)
            {
                esperaInicioElipse = false;
                esperaFimElipse = true;
                p1.X = e.X;
                p1.Y = e.Y;
                stMensagem.Items[1].Text = "clique o ponto da extremidade da Elipse";
            }
            else
                  if (esperaFimElipse)
            {
                esperaFimElipse = false;
                Elipse novaLinha = new Elipse(p1.X, p1.Y, Math.Abs(p1.X - e.X), Math.Abs(p1.Y - e.Y), corAtual);
                figuras.InserirAposFim(new NoLista<Ponto>(novaLinha, null));
                novaLinha.Desenhar(novaLinha.Cor, pbAreaDesenho.CreateGraphics());
                stMensagem.Items[1].Text = "Clique no local do ponto central da Elipse:";
            }




        }

        private void btnReta_Click(object sender, EventArgs e)
        {
            stMensagem.Items[1].Text = "Clique no local do ponto inicial da reta:";
            limparEsperas();
            esperaInicioReta = true;

        }

        private void btnCirculo_Click(object sender, EventArgs e)
        {
            stMensagem.Items[1].Text = "Clique no local do ponto central do círculo:";
            limparEsperas();
            esperaInicioCirculo = true;
        }

        private void btnElipse_Click(object sender, EventArgs e)
        {
            stMensagem.Items[1].Text = "Clique no local do ponto central da Elipse:";
            limparEsperas();
            esperaInicioElipse = true;
        }

        private void pbAreaDesenho_Click(object sender, EventArgs e)
        {

        }
        
        //precisa ser criado!
        private bool limparAreaDesenho()
        {
            return false;
        }
        
        //metodo que remove da lista figuras os que estão na lista de selecionados
        public void RemoverSelecionados()
        {
            Selecionados.IniciarPercursoSequencial();
            while(Selecionados.podePercorrer())
            {
                if(Selecionados.Atual = figuras.Atual)
                {
                    figuras.Remover(figuras.Atual);
                }
            }
            Selecionados.limparLista();
        }
        
        public void TrocarCor()
        {
            Selecionados.IniciarPercursoSequencial();
            while(Selecionados.podePercorrer())
            {
                if(Selecionados.Atual = figuras.Atual)
                {
                    figuras.Atual.Info.Cor = novaCor;   //novaCor será a cor selecionada no botão de selecao de cores!
                }
            }
            Selecionados.limparLista();
        }
        
        


    }
}


