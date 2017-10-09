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
        
       public override bool PertenceFigura(int x, int y)
        {
           int clickbox = 10;
           int boxX = x - clickbox / 2;
           int boxY = y - clickbox / 2;
           int largura = clickbox;
           int altura = clickbox;

           if (pontoFinal.X >= base.X)
           {
               if (pontoFinal.Y >= base.Y)
               {
                   if((base.X > x && x < pontoFinal.X)||
                       (base.Y > y && y < pontoFinal.Y))
                       return false;
               }
               else
               {
                   if((base.X > x && x < pontoFinal.X)||
                       (base.Y < y && y > pontoFinal.Y))
                       return false;
               }
           }
           else
           {
               if (pontoFinal.Y >= base.Y)
               {
                   if((base.X < x && x > pontoFinal.X)||
                       (base.Y > y && y < pontoFinal.Y))
                       return false;
               }
               else
               {
                   if((base.X < x && x > pontoFinal.X)||
                       (base.Y < y && y > pontoFinal.Y))
                       return false;
               }
           }
           int testY = ((base.Y - pontoFinal.Y)*x + (base.X*pontoFinal.Y - base.Y*pontoFinal.X))/(base.X - pontoFinal.X);
           int testX = ((pontoFinal.X - base.X)*y + (base.X*pontoFinal.Y - base.Y*pontoFinal.X))/(pontoFinal.Y - base.Y);
           if ((boxX <= testX && testX <= boxX + largura) &&
               (boxY <= testY && testY <= boxY + altura))
               return true;
           else
               return false;
        }
        
        //public int CompareTo(Reta other)
        //{
        //    //precisa implementar
        //    return 0;
        //}
        
        //public override String ToString()
        //{
        //    return transformaString("l", 5) +
        //          transformaString(base.X, 5) +
        //          transformaString(base.Y, 5) +
        //          transformaString(pontoFinal.X, 5) +
        //          transformaString(pontoFinal.Y, 5) +
        //            transformaString(Cor.R, 5) +
        //            transformaString(Cor.G, 5) +
        //            transformaString(Cor.B, 5);
        //}

      //  public int CompareTo(Reta other)
      //  {
       //     //precisa implementar
       //     return 0;
      //  }
        
     //   public override String ToString()
     //   {
     //       return transformaString("l", 5) +
    //              transformaString(base.X, 5) +
     //             transformaString(base.Y, 5) +
     //             transformaString(pontoFinal.X, 5) +
     //             transformaString(pontoFinal.Y, 5) +
     //               transformaString(Cor.R, 5) +
     //               transformaString(Cor.G, 5) +
    //                transformaString(Cor.B, 5);
     //   }


    }
}
