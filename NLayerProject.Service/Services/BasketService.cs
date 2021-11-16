using NLayerProject.Core.Models;
using NLayerProject.Core.Repositories;
using NLayerProject.Core.Services;
using NLayerProject.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Service.Services
{
    public class BasketService: Service<Basket>, IBasketService
    {
        public BasketService(IUnitOfWork unitOfWork, IRepository<Basket> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<IEnumerable<Basket>> GetBypIdAsync(int pid)
        {
            return await _unitOfWork.Baskets.GetBypIdAsync(pid);
        }
    }
}
