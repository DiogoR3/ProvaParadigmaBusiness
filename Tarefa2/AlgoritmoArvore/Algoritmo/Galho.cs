using System.Linq;

namespace AlgoritmoArvore.Algoritmo
{
    public class Galho
    {
        public int[] Numeros { get; private set; }

        // Para forcar os Galhos a serem criados pelo metodo estatico abaixo
        private Galho() { }

        public static Galho Criar(int[] numeros, GalhoLado lado)
        {
            Galho galho = new Galho();

            if(lado == GalhoLado.Esquerdo)
                galho.Numeros = numeros.OrderBy(n => n).ToArray();
            else
                galho.Numeros = numeros.OrderByDescending(n => n).ToArray();

            return galho;
        }
    }
}
