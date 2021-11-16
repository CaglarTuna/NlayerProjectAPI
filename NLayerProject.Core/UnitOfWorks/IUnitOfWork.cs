using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NLayerProject.Core.Repositories;

namespace NLayerProject.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
        ICategoryRepository Categories { get; }
        IBasketRepository Baskets { get; }
        IPersonRepository Persons { get; }
        Task CommitAsync();
        void Commit();
    }
}
