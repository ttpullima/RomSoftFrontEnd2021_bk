using AutoMapper;

namespace Romsoft.GESTIONCLINICA.DTO.AutoMapper
{
    public static class MapperHelper
    {
        public static TDest Map<TSource, TDest>(TSource source)
        {
            return Mapper.Map<TSource, TDest>(source);
        }

        public static TDest Map<TSource, TDest>(TSource source, TDest dest)
        {
            return Mapper.Map(source, dest);
        }
    }
}
