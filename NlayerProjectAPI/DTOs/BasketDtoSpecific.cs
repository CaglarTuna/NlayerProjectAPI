using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerProject.API.DTOs
{
    public class BasketDtoSpecific
    {
        public int Id{ get; set; }
        public string ProductName { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
