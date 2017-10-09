using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Grafico
{
    class Polilinha : Ponto
    {
        ListaSimples<Ponto> polilinha = new ListaSimples<Ponto>();
        Point[] polil;
        int i = 0;
        
        public Polilinha(int x, int y, ListaSimples<Ponto> polilinha, Color novaCor)
            : base(x, y, novaCor)
        {
            this.polilinha = polilinha; 
            polil[i] = new Point(polilinha.Atual.Info.X, polilinha.Atual.Info.Y);
            i++;
        }

        public override void Desenhar(Color corDesenho, Graphics g)
        {
            Pen pen = new Pen(corDesenho);
            g.DrawLines(pen, polil);
            
        }
    }
}
