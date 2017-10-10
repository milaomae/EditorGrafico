using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Grafico
{
    class Elipse : Ponto
    {
        private int raioUm, raioDois;

        public Elipse(int xCentro, int yCentro, int raioUm, int raioDois, Color novaCor) : base(xCentro, yCentro, novaCor)
        {
            this.RaioUm = raioUm;
            this.RaioDois = raioDois;
        }

        public int RaioDois
        {
            get {  return raioDois; }

            set { raioDois = value; }
        }

        public int RaioUm
        {
            get {  return raioUm;  }

            set { raioUm = value; }
        }

        public override void Desenhar(Color corDesenho, Graphics g)
        {
            Pen pen = new Pen(corDesenho);
            g.DrawEllipse(pen, base.X - raioUm, base.Y - raioDois,    
                                    2 * raioUm, 2 * raioDois);
            
        }

        public override bool PertenceFigura(int x, int y)
        {
            int raioAux;
            raioAux = Convert.ToInt32(Math.Pow(Math.Abs(x - base.X)/this.raioUm, 2) + Math.Pow(Math.Abs(y - base.Y)/this.raioDois, 2));
            if (raioAux <= 1)
                return true;
            else
                return false;
        }
        
         public int CompareTo(Elipse other)
        {
           //precisa implementar
            return 0;
        }
        
        public override String ToString()
        {
            return transformaString("e", 5) +
                   transformaString(base.X, 5) +
                   transformaString(base.Y, 5) +
                   transformaString(raioUm, 5) +
                   transformaString(raioDois, 5) +
                   transformaString(Cor.R, 5) +
                   transformaString(Cor.G, 5) +
                   transformaString(Cor.B, 5);
        }
    }
}
