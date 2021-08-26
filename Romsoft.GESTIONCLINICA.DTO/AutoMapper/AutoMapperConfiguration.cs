using System;
using AutoMapper;

namespace Romsoft.GESTIONCLINICA.DTO.AutoMapper
{
    public abstract class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DomainToDtoMappingProfile>();
                x.AddProfile<DtoToDomainMappingProfile>();
            });
        }

    }
}
