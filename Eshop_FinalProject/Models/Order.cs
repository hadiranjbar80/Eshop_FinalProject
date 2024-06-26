﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Eshop_FinalProject.Models
{
    public class Order
    {
        public Order()
        {
            OrderDetail = new OrderDetail();
        }

        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public bool IsFinalized { get; set; }
        public DateTime DateCreated { get; set; }

        // Navigation Properties

        public OrderDetail OrderDetail { get; set; }
        public User User { get; set; }
        public Product Product { get; set; }

    }
}
