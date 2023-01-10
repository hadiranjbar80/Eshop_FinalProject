
using Eshop_FinalProject.Context;
using Eshop_FinalProject.Models;
using Eshop_FinalProject.Services;

namespace Eshop_FinalProject
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDbContext context = new AppDbContext();
            //Category category = new Category()
            //{
            //    CategoryName = "Test"
            //};

            //categoryService.InsertCategory(category);

            //var categories=categoryService.GetAllCategories();

            //categories.ForEach(x => Console.WriteLine(x.CategoryName));


            //var getCategory = CategoryService.GetCategory(1,context);

            //Product product = new Product()
            //{
            //    CategoryId = getCategory.Id,
            //    ProductName = "Test3",
            //    Count = 1,
            //    Price = 150
            //};

            //ProductService.InsertProduct(product, context);

            
            

            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();

            if (AuthService.Authenticate(username, password, context) == -1)
            {
                Console.WriteLine("404");
            }
            else
            {
               if (AuthService.isAuth)
                {
                    if (AuthService.IsAdmin(username, context))
                    {
                        Console.WriteLine($"{username} is Admin");
                    }
                    else
                    {
                        Console.WriteLine($"{username} is not Admin");
                    }
                }
            }
            
            
            Order order = new Order()
            {
                DateCreated = DateTime.Now,
                IsFinalized = true,
                ProductId = 1,
                UserId = 1
            };

            OrderDetail detail = new OrderDetail
            {
                DateCreated = DateTime.Now,
                ProductCount = 1,
                TotalPrice = 1254
            };

            order.OrderDetail = detail;

            OrderService.InsertOrder(order,context);
            
            

        }

    }
}
