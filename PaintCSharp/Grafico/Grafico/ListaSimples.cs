﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Grafico
{
    public class ListaSimples<Dado> where Dado : IComparable<Dado>
    {
        NoLista<Dado> primeiro, ultimo, atual, anterior;
        int quantosNos;
        bool primeiroAcessoDoPercurso;

        public ListaSimples()
        {
            primeiro = null;
            ultimo = null;
            quantosNos = 0;
            primeiroAcessoDoPercurso = false;
        }

        public int QuantosNos
        {
            get { return quantosNos; }

            set
            {
                if (value >= 0)
                    quantosNos = value;
                else
                    throw
                    new Exception("Quantidade de nós deve ser positiva!");
            }
        }

        public void IniciarPercursoSequencial()
        {
            primeiroAcessoDoPercurso = true; 
            anterior = null;
            atual = primeiro;
        }

        public bool ChegouNoFim()
        {
            return atual == null;
        }

        public bool podePercorrer()
    {
      if (!primeiroAcessoDoPercurso)
      {
        anterior = atual;
        atual = atual.Prox;
      }
      else
        primeiroAcessoDoPercurso = false;

      return atual != null;
    }

        public Dado InfoAtual()
        {
            if (atual != null)
                return atual.Info;

            throw new Exception("Tentativa de acesso a informação inacessível!");
        }

        public void Avancar()
        {
            if (atual != null)
                atual = atual.Prox;
        }

        public void InserirAposFim(Dado informacao)
        {
            NoLista<Dado> novoNo = new NoLista<Dado>(informacao, null);
            if (EstaVazia)
                primeiro = novoNo;
            else
                ultimo.Prox = novoNo;
            ultimo = novoNo;
            quantosNos++;
        }

        public void InserirAntesDoInicio(Dado informacao)
        {
            var novoNo = new NoLista<Dado>(informacao, null);
            if (EstaVazia)
                ultimo = novoNo;
            else
                novoNo.Prox = primeiro;
            primeiro = novoNo;
            quantosNos++;
        }

        public void InserirAposFim(NoLista<Dado> novoNo)
        {            
            if (EstaVazia)
                primeiro = novoNo;
            else
                ultimo.Prox = novoNo;
            ultimo = novoNo;
            quantosNos++;
        }

        public void InserirAntesDoInicio(NoLista<Dado> novoNo)
        {
            if (EstaVazia)
                ultimo = novoNo;
            else
                novoNo.Prox = primeiro;
            primeiro = novoNo;
            quantosNos++;
        }

        public bool ExisteDado(Dado outroProcurado)
        {
            anterior = null;
            atual = primeiro;

            // Em seguida, é verificado se a lista está vazia. Caso esteja, é
            // retornado false ao local de chamada, indicando que a chave não foi
            // encontrada, e atual e anterior ficam valendo null

            if (EstaVazia)
                return false;

            // a lista não está vazia, possui nós
            // dado procurado é menor que o primeiro dado da lista:
            // portanto, dado procurado não existe

            if (outroProcurado.CompareTo(primeiro.Info) < 0)
                return false;

            // dado procurado é maior que o último dado da lista:
            // portanto, dado procurado não existe

            if (outroProcurado.CompareTo(ultimo.Info) > 0)
            {
                anterior = ultimo;
                atual = null;
                return false;
            }

            // caso não tenha sido definido que a chave está fora dos limites de
            // chaves da lista, vamos procurar no seu interior
            // o apontador atual indica o primeiro nó da lista e consideraremos que
            // ainda não achou a chave procurada nem chegamos ao final da lista
            
            bool achou = false;
            bool fim = false;
            
            // repete os comandos abaixo enquanto não achou o RA nem chegou ao
            // final da lista
            while (!achou && !fim)
            
                // se o apontador atual vale null, indica final da lista
                if (atual == null)
                    fim = true;
            
                        // se não chegou ao final da lista, verifica o valor da chave atual
                else
                
                // verifica igualdade entre chave procurada e chave do nó atual
                if (outroProcurado.CompareTo(atual.Info) == 0)
                    achou = true;
                else
                
                // se chave atual é maior que a procurada, significa que
                // a chave procurada não existe na lista ordenada e, assim,
                // termina a pesquisa indicando que não achou. Anterior
                // aponta o anterior ao atual, que foi acessado por
                // último
                
                if (atual.Info.CompareTo(outroProcurado) > 0)
                    fim = true;
                else
                {
                
                    // se não achou a chave procurada nem uma chave > que ela,
                    // então a pesquisa continua, de maneira que o apontador
                    // anterior deve apontar o nó atual e o apontador atual
                    // deve seguir para o nó seguinte

                    anterior = atual;
                    atual = atual.Prox;
                }

            // por fim, caso a pesquisa tenha terminado, o apontador atual
            // aponta o nó onde está a chave procurada, caso ela tenha sido
            // encontrada, ou o nó onde ela deveria estar para manter a
            // ordenação da lista. O apontador anterior aponta o nó anterior
            // ao atual

            return achou; // devolve o valor da variável achou, que indica
        }                 // se a chave procurada foi ou não encontrado

        private void InserirNoMeio(Dado dados)
        {
            NoLista<Dado> novoNo = new NoLista<Dado>(dados, null);

            // ExisteDado() encontrou intervalo de inclusão do novo nó

            anterior.Prox = novoNo; // liga anterior ao novo
            novoNo.Prox = atual;    // e novo no atual
            
            if (anterior == ultimo) // se incluiu ao final da lista,
                ultimo = novoNo;    // atualiza o apontador ultimo
            
            quantosNos++; // incrementa número de nós da lista
        }
        public void InserirEmOrdem(Dado dados)
        {
            if (!ExisteDado(dados)) // ExisteDado configura anterior e atual
            {                       // aqui temos certeza de que a chave não existe
                                    // novo nó
                if (EstaVazia)                   // se a lista está vazia, então o
                    InserirAntesDoInicio(dados); // novo nó é o primeiro da lista
                else
                if (anterior == null && atual != null)
                    InserirAntesDoInicio(dados);    // liga novo antes do primeiro
                else
                    InserirNoMeio(dados); // insere entre os nós anterior e atual
            }
        }
        public bool EstaVazia
        {
            get { return primeiro == null; }
        }

        public NoLista<Dado> Atual
        {
            get
            {
                return atual;
            }
        }

        public void percorrer()
        {
            atual = primeiro;
            while (atual != null)
            {
                MessageBox.Show(atual.Info.ToString());
                atual = atual.Prox;
            }
        }

        public void Remover(NoLista<Dado> ant, NoLista<Dado> atu)
        {
            if (EstaVazia)
                return;

            // se o fluxo de execução segue para cá, a lista não
            // está vazia e, portanto, temos ao menos um nó

            if (atu == primeiro)  // queremos excluir o 1o nó
            {
                primeiro = primeiro.Prox;  // aponta o 2o nó
                if (primeiro == null)
                    ultimo = null;
            }
            else
              if (atu == ultimo)    // vamos excluir o último nó
            {
                ant.Prox = null;
                ultimo = ant;       // aponta quem era penúltimo
            }
            else
                ant.Prox = atu.Prox;

            quantosNos--;  // removemos um nó, acertamos a contagem
        }
        public bool Remover(Dado info)
        {
            if (ExisteDado(info))  // ExisteDado posiciona anterior e atual
            {
                Remover(anterior, atual);
                return true;   // conseguimos remover o nó
            }
            else
                return false;
        }
        public void SalvarNoArquivo(string nomeArquivo)
        {
            var arq = new StreamWriter(nomeArquivo);
            atual = primeiro;
            while (atual != null)
            {
                arq.WriteLine(atual.Info.ToString());
                atual = atual.Prox;
            }
            arq.Close();
        }

        public void listar(ListBox umListBox, string cabecalho)
        {
            umListBox.Items.Clear();
            umListBox.Items.Add(cabecalho);

            atual = primeiro;
            while (atual != null)
            {
                umListBox.Items.Add(atual.Info.ToString());
                atual = atual.Prox;
            }
        }

        public int Contar()
        {
            int contagemAtual = 0;
            atual = primeiro;
            while (atual != null)
            {
                contagemAtual++;
                atual = atual.Prox;
            }
            return contagemAtual;
        }

        public ListaSimples<Dado> Juntar(ListaSimples<Dado> outra)
        {
            var result = new ListaSimples<Dado>();

            this.atual = this.primeiro;         // posicionamos ponteiro atual no início da lista this
            outra.atual = outra.primeiro;       // posicionamos ponteiro atual no início da lista outra

            while (this.atual != null && outra.atual != null)  // enquanto uma das listas ainda não acabou
            {
                if (this.atual.Info.CompareTo(outra.atual.Info) < 0)
                {
                    result.InserirAposFim(this.atual.Info);  // guardamos o menor elemento
                    this.atual = this.atual.Prox;            // avançamos na lista do menor elemento
                }
                else
                    if (outra.atual.Info.CompareTo(this.atual.Info) < 0)
                {
                    result.InserirAposFim(outra.atual.Info);    // guardamos o menor elemento
                    outra.atual = outra.atual.Prox;             // avançamos na lista do menor elemento
                }
                else    // elementos de chaves iguais
                {
                    result.InserirAposFim(this.atual.Info);  // guardamos um dos elementos iguais
                    this.atual = this.atual.Prox;            // como empatou, avançamos nas duas
                    outra.atual = outra.atual.Prox;          // listas
                }
            }

            // quando uma das listas terminar de ser percorrida, temos que
            // "esgotar" o percurso da lista que sobrou, percorrendo-a até
            // seu final:

            while (this.atual != null)   // a lista this ainda não acabou
            {
                result.InserirAposFim(this.atual.Info);  // guardamos o elemento que sobrou
                this.atual = this.atual.Prox;            // avançamos na lista this
            }

            while (outra.atual != null)   // a lista this ainda não acabou
            {
                result.InserirAposFim(outra.atual.Info);  // guardamos o elemento que sobrou
                outra.atual = outra.atual.Prox;           // avançamos na outra lista 
            }

            return result;
        }

        public void Inverter()
        {
            NoLista<Dado> um, dois, tres;
            um = dois = tres = null;

            if (!EstaVazia)
            {
                um = primeiro;
                dois = primeiro.Prox;
                while (dois != null)
                {
                    tres = dois.Prox;
                    dois.Prox = um;
                    um = dois;
                    dois = tres;
                }
                ultimo = primeiro;
                primeiro = um;
                ultimo.Prox = null;
            }
        }
    }
}
