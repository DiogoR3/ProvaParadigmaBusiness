using AlgoritmoArvore.Algoritmo;
using AlgoritmoArvore.Exceptions;
using System;
using static AlgoritmoArvore.FuncoesConsole;

namespace AlgoritmoArvore
{
    public class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                PerguntaInicial();

                try
                {
                    int[] numeros = ObterNumeros();
                    Arvore arvore = new Arvore(numeros);

                    foreach (string item in arvore.Resultados())
                        Imprimir(item);

                    Imprimir("\n" + arvore);
                }
                catch (AlgoritmoArvoreException ex)
                {
                    Imprimir(ex.Message);
                }
                catch (Exception)
                {
                    Imprimir("A entrada não é valida!");
                }
                finally
                {
                    Imprimir("\n");
                }
            }
        }
    }
}
