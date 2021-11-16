using NLayerProject.Core.Models;
using NLayerProject.Core.Repositories;
using NLayerProject.Core.Services;
using NLayerProject.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayerProject.Service.Services
{
    public class OrderService:Service<Order>, IOrderService
    {
        public OrderService(IUnitOfWork unitOfWork, IRepository<Order> repository) : base(unitOfWork, repository)
    {
    }
}
}
