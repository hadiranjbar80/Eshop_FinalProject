using Eshop_FinalProject.Context;
using Eshop_FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop_FinalProject.Services
{
    public class OrderService
    {
        AppDbContext context = new AppDbContext();

        public void InsertOrder(Order order)
        {
            context.Add(order);
            context.SaveChanges();
        }

        public void UpdateOrder(Order order)
        {
            context.Update(order);
            context.SaveChanges();
        }

        public void DeleteOrder(Order order)
        {
            context.Remove(order);
            context.SaveChanges();
        }
    }
}
