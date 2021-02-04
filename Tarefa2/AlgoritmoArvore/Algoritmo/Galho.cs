using System.Linq;

namespace AlgoritmoArvore.Algoritmo
{
    public class Galho
    {
        public int[] Numeros { get; private set; }
        private GalhoLado Lado { get; set; }

        // Para forcar os Galhos a serem criados pelo metodo estatico abaixo
        private Galho() { }

        public string ObterNumero(int posicao)
        {
            if (posicao + 1 > Numeros.Length)
                return null;

            return Numeros[posicao].ToString();
        }

        public static Galho Criar(int[] numeros, GalhoLado lado)
        {
            Galho galho = new Galho
            {
                Lado = lado
            };

            if (lado == GalhoLado.Esquerdo)
                galho.Numeros = numeros.OrderByDescending(n => n).ToArray();
            else
                galho.Numeros = numeros.OrderByDescending(n => n).ToArray();

            return galho;
        }

        public override string ToString()
        {
            return string.Join(",", Numeros);
        }
    }
}
