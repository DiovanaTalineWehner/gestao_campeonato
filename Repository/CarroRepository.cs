using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using gestao_campeonato.Models;
using gestao_campeonato.Database;

namespace gestao_campeonato.Repository
{
    public class CarroRepository : BaseRepository, ICarroRepository
    {
        public CarroRepository(MyDbContext context) : base(context) { }

        public async Task<IEnumerable<Carro>> ListAsync()
        {
            return await _context.Carro.ToListAsync();
        }

        public async Task<Carro> GetCarro(int id)
        {
            return await _context.Carro.FirstOrDefaultAsync(e => e.id_carro == id);
        }

        public async Task<Carro> GetCarroByName(string nome_carro)
        {
            return await _context.Carro.FirstOrDefaultAsync(e => e.nome_carro == nome_carro);
        }

        public async Task CadastrarCarro(Carro carro)
        {
             _context.Carro.AddAsync(carro);
            await _context.SaveChangesAsync();

        }

         public async Task DeleteCarro(Carro carro)
        {
            _context.Carro.Remove(carro);
            _context.SaveChangesAsync();
        }
    }
}