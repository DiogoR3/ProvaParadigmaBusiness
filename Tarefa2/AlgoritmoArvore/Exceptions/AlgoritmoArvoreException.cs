using System;

namespace AlgoritmoArvore.Exceptions
{
    public class AlgoritmoArvoreException : Exception
    {
        public AlgoritmoArvoreException() { }

        public AlgoritmoArvoreException(string message) : base(message) { }
    }
}
