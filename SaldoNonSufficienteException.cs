using System.Runtime.Serialization;

namespace csharp_banca_oop
{
    [Serializable]
    internal class SaldoNonSufficienteException : Exception
    {
        public SaldoNonSufficienteException()
        {
        }

        public SaldoNonSufficienteException(string? message, int soldi) : base(message)
        { 
        }

        public SaldoNonSufficienteException(string? message, Exception? innerException) : base(message, innerException)
        {

        }

        protected SaldoNonSufficienteException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }


    }
}