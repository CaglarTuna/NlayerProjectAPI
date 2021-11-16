using NLayerProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Core.Services
{
    public interface IBasketService:IService<Basket>
    {
        Task<IEnumerable<Basket>> GetBypIdAsync(int pid);
    }
}
