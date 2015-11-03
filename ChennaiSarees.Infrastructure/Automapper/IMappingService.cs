namespace ChennaiSarees.Infrastructure.Automapper
{
    public interface IMappingService
    {
        TDest Map<TSrc, TDest>(TSrc source) where TDest : class;

        void Map<TSrc, TDest>(TSrc Source, TDest Destination);
    }
}