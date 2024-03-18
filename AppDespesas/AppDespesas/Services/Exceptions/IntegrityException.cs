using System;

namespace AppDespesas.Services.Exceptions 
{ //Exceção personsalizada de serviço para erros de integridade referencial
    public class IntegrityException : ApplicationException
    {
        public IntegrityException(string message) : base(message)
        {
        }
    }
}
