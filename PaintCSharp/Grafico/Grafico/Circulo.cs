using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Grafico
{
    class Circulo : Ponto
    {
        //herda o ponto central (x,y) da classe Ponto
        int raio;

        public int Raio
        {
            get { return raio; }

            set { raio = value; }
        }

        public Circulo(int xCentro, int yCentro, int novoRaio, Color novaCor) : 
                        base(xCentro, yCentro, novaCor) // construtor de Ponto(x,y)
        {
            raio = novoRaio;
        }

        public void setRaio(int novoRaio)
        {
            raio = novoRaio;
        }

        public override void Desenhar(Color corDesenho, Graphics g)
        {
            Pen pen = new Pen(corDesenho);
            g.DrawEllipse(pen, base.X - raio, base.Y - raio,    // centro - raio
                                    2 * raio, 2 * raio);        // centro + raio

        }

        public override bool PertenceFigura(int x, int y)
        {
            int raioAux;
            raioAux = Convert.ToInt32(Math.Sqrt(Math.Pow(Math.Abs(x-base.X),2) + Math.Pow(Math.Abs(y-base.Y),2)));
            //if (Math.Abs(x - base.X) > Math.Abs(y - base.Y))
            //    raioAux = (int)Math.Abs(x - base.X);
            //else
            //    raioAux = (int)Math.Abs(y - base.Y);

            if (raioAux <= raio)
                return true;
            else
                return false;
        }

        public int CompareTo()
        {
            //precisa implementar
           return 0;
        }

        public override String ToString()
        {
            return transformaString("c", 5) +
                  transformaString(base.X, 5) +
                  transformaString(base.Y, 5) +
                  transformaString(raio, 5) +
                    transformaString(Cor.R, 5) +
                    transformaString(Cor.G, 5) +
                    transformaString(Cor.B, 5);
       }

    }
}
