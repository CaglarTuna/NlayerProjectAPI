﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NLayerProject.Core.Repositories;
using NLayerProject.Core.UnitOfWorks;
using NLayerProject.Data.Repositories;

namespace NLayerProject.Data.UnitOfWork
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly AppDbContext _context;
        private ProductRepository _productRepository;
        private CategoryRepository _categoryRepository;

        public IProductRepository Products => _productRepository ??= new ProductRepository(_context);
        public ICategoryRepository Categories => _categoryRepository ??= new CategoryRepository(_context);

        public UnitOfWork(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
