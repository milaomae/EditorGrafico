using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Grafico
{
    class Ponto : IComparable<Ponto>
    {
        private int x, y;
        private Color cor;

        public int X
        {
            get { return x; }

            set { x = value; }
        }

        public int Y
        {
            get { return y; }

            set { y = value; }
        }

        public Color Cor
        {
            get { return cor; }

            set { cor = value; }
        }
        public Ponto(int cX, int cY, Color qualCor)
        {
            X = cX;
            Y = cY;
            Cor = qualCor;
        }

        public virtual void Desenhar(Color cor, Graphics g)
        {
            Pen pen = new Pen(cor);
            g.DrawLine(pen, x, y, x, y);
        }

        public int CompareTo(Ponto other)
        {
            int diferencaX = X - other.X;
            if (diferencaX == 0)
                return Y - other.Y;
            return diferencaX;
        }
    }
}
