using AutoMapper;

namespace ChennaiSarees.Infrastructure.Automapper
{
    public class MappingService : IMappingService
    {
        public TDest Map<TSrc, TDest>(TSrc source) where TDest : class
        {
            return Mapper.Map<TSrc, TDest>(source);
        }

        public void Map<TSrc, TDest>(TSrc Source, TDest Destination)
        {
            Mapper.Map(Source, Destination);
        }
    }
}