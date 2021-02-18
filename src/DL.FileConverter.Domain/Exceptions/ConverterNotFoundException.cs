using System;

namespace DL.FileConverter.Domain.Exceptions
{
    [Serializable]
    public class ConverterNotFoundException : Exception
    {
        public ConverterNotFoundException(string message) : base(message)
        {
        }
    }
}
