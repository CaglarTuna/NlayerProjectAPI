using Microsoft.EntityFrameworkCore;
using NLayerProject.Core.Models;
using NLayerProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Data.Repositories
{
    public class PersonRepository: Repository<Person>, IPersonRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }
        public PersonRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Person> Login(string password, string mail)
        {
            return  await _appDbContext.Persons.SingleOrDefaultAsync(x =>x.Email==mail&x.Password==password);
        }

        public async Task<Person> GetByMailAsync(string mail)
        {
            return await _appDbContext.Persons.SingleOrDefaultAsync(x=>x.Email==mail);
        }
    }
}
