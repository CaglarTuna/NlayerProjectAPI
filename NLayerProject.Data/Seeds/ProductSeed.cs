using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerProject.Core.Models;

namespace NLayerProject.Data.Seeds
{
    public class ProductSeed:IEntityTypeConfiguration<Product>
    {
        private readonly int[] _ids;
        public ProductSeed(int [] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(new Product
            {
                Id = 1,
                Name = "Pen",
                Price = 12.50m,
                Stock = 100,
                CategoryId = _ids[0]
            }, new Product
            {
                Id = 2,
                Name = "Pencil",
                Price = 40.50m,
                Stock = 200,
                CategoryId = _ids[0]
            }, new Product
            {
                Id = 3,
                Name = "Small Notebook",
                Price = 30.50m,
                Stock = 300,
                CategoryId = _ids[0]
            }, new Product
            {
                Id = 4,
                Name = "Mid Notebook",
                Price = 12.50m,
                Stock = 100,
                CategoryId = _ids[1]
            }, new Product
            {
                Id = 5,
                Name = "Big Notebook",
                Price = 12.50m,
                Stock = 100,
                CategoryId = _ids[1]
            }, new Product
            {
                Id = 6,
                Name = "Normal Notebook",
                Price = 12.50m,
                Stock = 100,
                CategoryId = _ids[1]
            });
        }
    }
}
