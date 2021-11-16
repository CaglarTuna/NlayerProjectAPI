using System;
using System.Collections.Generic;
using System.Text;

namespace NLayerProject.Core.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int BasketId { get; set; }
        public int TotalPrice{ get; set; }
        public virtual Basket Basket { get; set; }
    }
}
