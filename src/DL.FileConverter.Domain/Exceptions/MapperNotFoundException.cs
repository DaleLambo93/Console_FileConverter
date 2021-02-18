﻿using System;
using System.Runtime.Serialization;

namespace DL.FileConverter.Domain.Exceptions
{
    [Serializable]
    internal class MapperNotFoundException : Exception
    {
        public MapperNotFoundException()
        {
        }

        public MapperNotFoundException(string message) : base(message)
        {
        }

        public MapperNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MapperNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
