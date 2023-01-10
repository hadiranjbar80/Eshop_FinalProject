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

        public static void InsertOrder(Order order,AppDbContext context)
        {
            context.Add(order);
            context.SaveChanges();
        }

        public static void UpdateOrder(Order order,AppDbContext context)
        {
            context.Update(order);
            context.SaveChanges();
        }

        public static void DeleteOrder(Order order,AppDbContext context)
        {
            context.Remove(order);
            context.SaveChanges();
        }
    }
}
