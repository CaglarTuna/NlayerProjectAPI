using NLayerProject.Core.Models;
using NLayerProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayerProject.Data.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }
        public OrderRepository(AppDbContext context) : base(context)
        {
        }
    }
}
