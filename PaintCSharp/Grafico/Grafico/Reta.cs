using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Grafico
{
    class Reta : Ponto
    {
        //herda (x,y) da classe Ponto = coordenadas do
        //ponto inicial da reta
        //também herda a cor
        //define o PONTO FINAL

        private Ponto pontoFinal;

        public Reta(int x1, int y1, int x2, int y2, Color novaCor) : base(x1, y1, novaCor)
        {
            pontoFinal = new Ponto(x2, y2, novaCor);
        }

        public override void Desenhar(Color corDesenho, Graphics g)
        {
            Pen pen = new Pen(corDesenho);
            g.DrawLine(pen, base.X, base.Y,         // ponto inicial
                            pontoFinal.X, pontoFinal.Y);
        }
    }
}
