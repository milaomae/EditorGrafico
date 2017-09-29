using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing;


namespace Grafico
{
    public partial class frmGrafico : Form
    {
        private ListaSimples<Ponto> figuras = new ListaSimples<Ponto>();
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
            if(dlgAbrir.ShowDialog() == DialogResult.OK)
            {
                //abertura do arquivo, sua leitura e armazenamento
                // de figuras na lista ligada
                StreamReader arquivo = new StreamReader(dlgAbrir.FileName);
                string linha = "";

                while (!arquivo.EndOfStream)
                {
                    linha = arquivo.ReadLine();
                    if(linha != null)
                    {
                        var figuraLida = new Ponto(0,0,Color.White);

                        string tipoFigura = linha.Substring(0, 5);

                        switch (tipoFigura)
                        {
                            case "p":                                
                                string coordBaseX = linha.Substring(6, 5);
                                string coordBaseY = linha.Substring(11, 5);
                                string corR = linha.Substring(16, 5);
                                string corG = linha.Substring(21, 5);
                                string corB = linha.Substring(26, 5);                                                                
                                figuraLida = new Ponto(Convert.ToInt32(coordBaseX), Convert.ToInt32(coordBaseY), 
                                                            Color.FromArgb(Convert.ToInt32(corR), Convert.ToInt32(corG), Convert.ToInt32(corB)));
                                break;

                            case "l":
                                coordBaseX = linha.Substring(6, 5);
                                coordBaseY = linha.Substring(11, 5);
                                corR = linha.Substring(16, 5);
                                corG = linha.Substring(21, 5);
                                corB = linha.Substring(26, 5);
                                string fimX = linha.Substring(31, 5);
                                string fimY = linha.Substring(36, 5);
                                figuraLida = new Reta(Convert.ToInt32(coordBaseX), Convert.ToInt32(coordBaseY), Convert.ToInt32(fimX), Convert.ToInt32(fimY),
                                                            Color.FromArgb(Convert.ToInt32(corR), Convert.ToInt32(corG), Convert.ToInt32(corB)));
                                break;

                            case "c":
                                coordBaseX = linha.Substring(6, 5);
                                coordBaseY = linha.Substring(11, 5);
                                corR = linha.Substring(16, 5);
                                corG = linha.Substring(21, 5);
                                corB = linha.Substring(26, 5);
                                string raio = linha.Substring(31, 5);
                                figuraLida = new Circulo(Convert.ToInt32(coordBaseX), Convert.ToInt32(coordBaseY), Convert.ToInt32(raio),
                                                            Color.FromArgb(Convert.ToInt32(corR), Convert.ToInt32(corG), Convert.ToInt32(corB)));

                                break;

                            case "e":
                                coordBaseX = linha.Substring(6, 5);
                                coordBaseY = linha.Substring(11, 5);
                                corR = linha.Substring(16, 5);
                                corG = linha.Substring(21, 5);
                                corB = linha.Substring(26, 5);
                                string raioA = linha.Substring(31, 5);
                                string raioB = linha.Substring(36, 5);
                                figuraLida = new Elipse(Convert.ToInt32(coordBaseX), Convert.ToInt32(coordBaseY), Convert.ToInt32(raioA), Convert.ToInt32(raioB),
                                                            Color.FromArgb(Convert.ToInt32(corR), Convert.ToInt32(corG), Convert.ToInt32(corB)));

                                break;
                        }

                        figuras.InserirAposFim(figuraLida);
                        
                         
                    }
                }
            }
        }
    }
}
