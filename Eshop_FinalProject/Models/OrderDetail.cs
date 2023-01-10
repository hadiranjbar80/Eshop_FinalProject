using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop_FinalProject.Models
{
    public class OrderDetail
    {
        public OrderDetail()
        {
            Order = new Order();
        }

        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int ProductCount { get; set; }
        public float TotalPrice { get; set; }
        public DateTime DateCreated { get; set; }

        // Navigation Proreties

        [ForeignKey("OrderId")]
        public Order Order { get; set; }

    }
}
