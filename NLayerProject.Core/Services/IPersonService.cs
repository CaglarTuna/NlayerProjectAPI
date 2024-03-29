﻿using NLayerProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Core.Services
{
    public interface IPersonService:IService<Person>
    {
        Task<Person> Login(string password, string mail);
        Task<Person> GetByMailAsync(string mail);
    }
}
