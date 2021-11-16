using Microsoft.EntityFrameworkCore;
using NLayerProject.Core.Models;
using NLayerProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Data.Repositories
{
    public class BasketRepository:Repository<Basket>, IBasketRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }
        public BasketRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Basket>> GetBypIdAsync(int pid)
        {
            return await _appDbContext.Baskets.Include(x => x.Product).Include(x=>x.Person).Where(x=>x.PersonId==pid)
                .ToListAsync();
        }
    }
}
