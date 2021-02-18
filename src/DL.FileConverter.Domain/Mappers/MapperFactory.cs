using System;
using DL.FileConverter.Domain.Exceptions;
using Microsoft.Extensions.DependencyInjection;

namespace DL.FileConverter.Domain.Mappers
{
    public class MapperFactory : IMapperFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public MapperFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IMapper<TOut, TIn> Get<TOut, TIn>()
        {
            var service = _serviceProvider.GetService<IMapper<TOut, TIn>>();

            return service ?? throw new MapperNotFoundException(
                       $"Mapper<{typeof(TOut).Name},{typeof(TIn).Name}> not found.");
        }
    }
}
