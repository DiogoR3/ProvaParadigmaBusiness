using AlgoritmoArvore.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoritmoArvore.Algoritmo
{
    public class Arvore
    {
        public Galho GalhoEsquerda { get; private set; }
        public Galho GalhoDireita { get; private set; }
        public int Raiz { get; private set; }
        private int TamanhoMaiorGalho { get; set; }
        private int[] Numeros { get; set; }

        public Arvore(int[] numeros)
        {
            // Atribuir um item com valor de 0 caso o array seja nulo
            Numeros = numeros ?? (new int[0]);

            if (Numeros.Length != Numeros.Distinct().Count())
                throw new AlgoritmoArvoreException("O array possui pelo menos um item repetido.");

            AtribuirValores();
        }

        private void AtribuirValores()
        {
            Raiz = Numeros.Max();
            int posicaoRaiz = Array.IndexOf(Numeros, Raiz);

            List<int> numerosEsquerda = new List<int>();
            List<int> numerosDireita = new List<int>();

            for (int i = default; i < Numeros.Length; i++)
            {
                if (i < posicaoRaiz) numerosEsquerda.Add(Numeros[i]);
                else if (i > posicaoRaiz) numerosDireita.Add(Numeros[i]);
            }

            GalhoEsquerda = Galho.Criar(numerosEsquerda.ToArray(), GalhoLado.Esquerdo);
            GalhoDireita = Galho.Criar(numerosDireita.ToArray(), GalhoLado.Direito);

            TamanhoMaiorGalho = GalhoEsquerda.Numeros.Length > GalhoDireita.Numeros.Length ? GalhoEsquerda.Numeros.Length : GalhoDireita.Numeros.Length;
        }

        public IEnumerable<string> Resultados()
        {
            yield return $"Array de entrada: [{string.Join(',', Numeros)}]";
            yield return "Raiz: " + Raiz;
            yield return "Galhos da Esquerda: " + GalhoEsquerda;
            yield return "Galhos da Direita: " + GalhoDireita;
        }

        public override string ToString()
        {
            int qtdEspacosLado = 3 * TamanhoMaiorGalho - 1;
            int qtdEspacosMeio = 1;

            string arvore = string.Format("{0}{1}\n", espacos(qtdEspacosLado), Raiz.ToString());

            for (int i = 0; i < TamanhoMaiorGalho; i++)
            {
                qtdEspacosLado--;
                arvore += $"{espacos(qtdEspacosLado)}/{espacos(qtdEspacosMeio)}\\\n";
                qtdEspacosLado--;
                qtdEspacosMeio += 2 + (GalhoDireita.ObterNumero(i) ?? " ").Length - (GalhoEsquerda.ObterNumero(i) ?? " ").Length;
                arvore += $"{espacos(qtdEspacosLado)}{GalhoEsquerda.ObterNumero(i) ?? "/"}{espacos(qtdEspacosMeio)}{GalhoDireita.ObterNumero(i) ?? "\\"}\n";
                qtdEspacosMeio += 2;
            }

            return arvore;

            static string espacos(int qtd) => new string(' ', qtd > 0 ? qtd : 0);
        }
    }
}
