using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Grafico
{
    public class NoLista<Dado> where Dado : IComparable<Dado>
    {
        Dado info;
        NoLista<Dado> prox;

        public NoLista(Dado info, NoLista<Dado> prox)
        {
            this.Info = info;
            this.Prox = prox;
        }

        public Dado Info
        {
            get
            {
                return info;
            }

            set
            {
                info = value;
            }
        }

        public NoLista<Dado> Prox
        {
            get
            {
                return prox;
            }

            set
            {
                prox = value;
            }
        }
    }
}
