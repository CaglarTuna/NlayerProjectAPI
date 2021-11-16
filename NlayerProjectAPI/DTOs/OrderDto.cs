using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerProject.API.DTOs
{
    public class OrderDto
    {
        public int Number { get; set; }
        public decimal TotalPrice{ get; set; }
        public string ProductName { get; set; }
        public string PersonName{ get; set; }
        public string CategoryName{ get; set; }
    }
}
