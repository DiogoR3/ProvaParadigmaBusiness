using System.Linq;

namespace AlgoritmoArvore.Algoritmo
{
    public class Galho
    {
        public int[] Numeros { get; private set; }

        // Para forcar os Galhos a serem criados pelo metodo estatico "Criar"
        private Galho() { }

        public string ObterNumero(int posicao)
        {
            // Retorna null caso a posicao nao exista no array
            if (posicao + 1 > Numeros.Length)
                return null;

            return Numeros[posicao].ToString();
        }

        /// <summary>
        /// Cria o galho com seus numeros em ordem decrescente
        /// </summary>
        /// <param name="numeros"></param>
        /// <returns></returns>
        public static Galho Criar(int[] numeros)
        {
            Galho galho = new Galho()
            {
                Numeros = numeros.OrderByDescending(n => n).ToArray()
            };

            return galho;
        }

        /// <summary>
        /// Retorna os numeros separados por vírgula (,)
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Join(",", Numeros);
        }
    }
}
