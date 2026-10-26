using Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Order: IEntity
    {
        public int OrderId { get; set; }
        public string CustomerId { get; set; }
        public int EmpoloyeeId { get; set; }
        public DateTime OderDate { get; set; }
        public string ShipCity { get; set; }
    }
}
