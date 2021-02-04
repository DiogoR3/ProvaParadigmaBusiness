using AlgoritmoArvore.Exceptions;
using System.Linq;

namespace AlgoritmoArvore.Algoritmo
{
    public class Arvore
    {
        public Galho GalhoEsquerda { get; private set; }
        public Galho GalhoDireita { get; private set; }
        public int Raiz { get; private set; }

        public Arvore(int[] numeros)
        {
            // Atribuir um item com valor de 0 caso o array seja nulo
            numeros ??= (new int[0]);

            if (numeros.Length != numeros.Distinct().Count())
                throw new AlgoritmoArvoreException("O array possui pelo menos um item repetido.");

            AtribuirValores(numeros);
        }

        private void AtribuirValores(int[] numeros)
        {
            Raiz = numeros.Max();
            GalhoEsquerda = Galho.Criar(numeros.Where(n => n < Raiz).ToArray(), GalhoLado.Esquerdo);
            GalhoDireita = Galho.Criar(numeros.Where(n => n > Raiz).ToArray(), GalhoLado.Esquerdo);
        }
    }
}
