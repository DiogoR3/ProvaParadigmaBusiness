using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoritmoArvore
{
    public static class FuncoesConsole
    {
        public static bool ErroEntrada { get; set; } = false;
        public static void Imprimir(string mensagem) => Console.WriteLine(mensagem);

        public static void PerguntaInicial()
        {
            Imprimir("Digite um array de números inteiros separados por vírgula (,)");
            Imprimir($"Exemplo: \"{GerarExemplo()}\"");
        }

        private static string GerarExemplo(int qtdNumeros = 10)
        {
            Random random = new Random();
            List<int> exemplo = new List<int>();

            while (qtdNumeros > 0)
            {
                exemplo.Add(random.Next(1, 100));
                qtdNumeros--;
            }

            return string.Join(",", exemplo.Select(n => n.ToString()).ToArray());
        }

        public static int[] ObterNumeros()
        {
            string entrada = Console.ReadLine();
            return Array.ConvertAll(entrada.Split(','), n => int.Parse(n));
        }
    }
}
