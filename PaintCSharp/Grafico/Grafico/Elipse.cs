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
            if ((Math.Pow((base.X - x) / raioUm, 2) + Math.Pow((base.Y - y) / raioDois, 2)) <= 1)
            {
                return true;
            }
            return false;
        }
    }
}
