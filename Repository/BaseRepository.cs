using gestao_campeonato.Database;

namespace gestao_campeonato.Repository
{
    public abstract class BaseRepository
    {
        protected readonly MyDbContext _context;

        public BaseRepository(MyDbContext context)
        {
            _context = context;
        }
    }
}