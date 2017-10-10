using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Grafico
{
    class Retangulo : Ponto
    {
        Ponto pontoFinal;       
        int altura, largura;

        public int Altura
        {
            get { return altura; }
            set { altura = value; }
        }

        public int Largura
        {
            get { return largura; }
            set { largura = value; }
        }

        public Retangulo(int x, int y, int x2, int y2, int largura, int altura, Color novaCor)
            : base(x, y, novaCor)
        {
            this.Largura = largura;
            this.Altura = altura;
            pontoFinal = new Ponto(x2, y2, novaCor);
            
        }

        public override void Desenhar(Color corDesenho, Graphics g)
        {
            Pen pen = new Pen(corDesenho);            
            g.DrawRectangle(pen, new Rectangle(Math.Min(base.X, pontoFinal.X), 
                                                 Math.Min(base.Y, pontoFinal.Y),
                                                 Math.Abs(pontoFinal.X - base.X),
                                                 Math.Abs(pontoFinal.Y - base.Y)));
        }

        public override bool PertenceFigura(int x, int y)
        {
            if(pontoFinal.X >= base.X)
            {
                if (pontoFinal.Y >= base.Y)
                {
                    if ((x <= base.X + largura && x >= base.X) && 
                        (y <= base.Y + altura && y >= base.Y))
                        return true;
                    else
                        return false;
                }
                else
                {
                    if ((x <= base.X + largura && x >= base.X) && 
                        (y >= base.Y + altura && y <= base.Y))
                        return true;
                    else
                        return false;
                }
            }
            else
            {
                if (pontoFinal.Y >= base.Y)
                {
                    if ((x >= base.X + largura && x <= base.X) &&
                        (y <= base.Y + altura && y >= base.Y))
                        return true;
                    else
                        return false;
                }
                else
                {
                    if ((x >= base.X + largura && x <= base.X) &&
                        (y >= base.Y + altura && y <= base.Y))
                        return true;
                    else
                        return false;
                }
            }
                
        }
        
        public int CompareTo(Retangulo other)
        {
           //precisa implementar
            return 0;
        }
        
        public override String ToString()
        {
            return transformaString("r", 5) +
                   transformaString(base.X, 5) +
                   transformaString(base.Y, 5) +
                   transformaString(pontoFinal.X, 5) +
                   transformaString(pontoFinal.Y, 5) +
                   transformaString(largura, 5) +
                   transformaString(altura, 5) +
                   transformaString(Cor.R, 5) +
                   transformaString(Cor.G, 5) +
                   transformaString(Cor.B, 5);
        }

    }
}
