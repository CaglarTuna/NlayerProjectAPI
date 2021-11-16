using NLayerProject.Core.Models;
using NLayerProject.Core.Repositories;
using NLayerProject.Core.Services;
using NLayerProject.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Service.Services
{
    public class PersonService : Service<Person>, IPersonService
    {
        public PersonService(IUnitOfWork unitOfWork, IRepository<Person> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<Person> GetByMailAsync(string mail)
        {
            return await _unitOfWork.Persons.GetByMailAsync(mail);
        }

        public async Task<Person> Login(string password, string mail)
        {
            return await _unitOfWork.Persons.Login(password, mail);
        }
    }
}
