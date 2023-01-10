
using Eshop_FinalProject.Context;
using Eshop_FinalProject.Models;
using Eshop_FinalProject.Services;
using FinalProject_ECommerceApplication.Services;

namespace Eshop_FinalProject
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDbContext context = new AppDbContext();

            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();

            // Authorizing User
            if (AuthService.Authenticate(username, password, context) == -1)
            {
                Console.WriteLine("User not found!");
            }
            else
            {
                if (AuthService.isAuth)
                {
                    // Checking User Role
                    if (AuthService.IsAdmin(username, context))
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.WriteLine("What do you want to do?");
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("To add a product press 1\nTo update a product press 2\n" +
                            "To delete a product press 3\nTo show all products press 4\nTo show Invoices press 5");
                        ConsoleKeyInfo consoleKey = Console.ReadKey();

                        Console.BackgroundColor = ConsoleColor.Magenta;

                        if (consoleKey.Key == ConsoleKey.NumPad1)
                        {
                            Console.WriteLine("Enter Product Name:");
                            var productName = Console.ReadLine();
                            Console.WriteLine("Enter Product Price:");
                            var productPrice = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Product Description:");
                            var productDescription = Console.ReadLine();
                            Console.WriteLine("Enter a category ID:");
                            var productCategory = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Product Count");
                            var productCount = int.Parse(Console.ReadLine());
                            Product product = new Product()
                            {
                                ProductName = productName,
                                Price = productPrice,
                                Count = productCount,
                                Description = productDescription,
                                CategoryId = productCategory

                            };
                            ProductService.InsertProduct(product, context);
                        }
                        else if (consoleKey.Key == ConsoleKey.NumPad2)
                        {
                            Console.WriteLine("Enter a product ID:");
                            var productId = int.Parse(Console.ReadLine());
                            Console.WriteLine("--------------------------------------");
                            Console.WriteLine("Enter Product Name:");
                            var productName = Console.ReadLine();
                            Console.WriteLine("Enter Product Price:");
                            var productPrice = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Product Description:");
                            var productDescription = Console.ReadLine();
                            Console.WriteLine("Enter a category ID:");
                            var productCategory = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Product Count");
                            var productCount = int.Parse(Console.ReadLine());

                            var product = ProductService.GetProduct(productId, context);

                            product.ProductName = productName;
                            product.Price = productPrice;
                            product.Count = productCount;
                            product.Description = productDescription;
                            product.CategoryId = productCategory;

                            ProductService.UpdateProduct(product, context);


                        }
                        else if (consoleKey.Key == ConsoleKey.NumPad3)
                        {
                            Console.WriteLine("Enter Product Count");
                            var productId = int.Parse(Console.ReadLine());
                            ProductService.DeleteProduct(productId, context);
                        }
                        else if (consoleKey.Key == ConsoleKey.NumPad4)
                        {
                            var products = ProductService.GetAllProducts(context);
                            Console.WriteLine("\nId - Name - Price - Count - Description");
                            products.ForEach(x => Console.WriteLine($"{x.Id} - {x.ProductName} - {x.Price} - {x.Count} - {x.Description}\n"));
                        }
                        else if (consoleKey.Key == ConsoleKey.NumPad5)
                        {
                            // To Do: Showing Invoices to Admin
                        }
                    }
                    else // User Actions
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.WriteLine("What do you want to do?");
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("To show Products list press 1\nTo buy a Product press 2\n");
                        ConsoleKeyInfo consoleKey = Console.ReadKey();

                        if (consoleKey.Key == ConsoleKey.NumPad1)
                        {
                            var products = ProductService.GetAllProducts(context);
                            Console.WriteLine("\nId - Name - Price - Count - Description");
                            products.ForEach(x => Console.WriteLine($"{x.Id} - {x.ProductName} - {x.Price} - {x.Count} - {x.Description}\n"));
                        }
                        else if (consoleKey.Key == ConsoleKey.NumPad2)
                        {
                            Console.WriteLine("Enter Product ID that you want to buy");
                            var productId = int.Parse(Console.ReadLine());

                            var product = ProductService.GetProduct(productId, context);

                            if (product == null)
                            {
                                Console.WriteLine("Product does not exist!");
                                return;
                            }
                            Console.WriteLine("How many Count of this Product you want to buy?");
                            var productCount = int.Parse(Console.ReadLine());
                            Order order = new Order()
                            {
                                IsFinalized = true,
                                ProductId = productId,
                                UserId = AuthService.User.Id,
                                DateCreated = DateTime.Now,
                            };

                            OrderDetail detail = new OrderDetail()
                            {
                                DateCreated = DateTime.Now,
                                OrderId = order.OrderId,
                                ProductCount = productCount,
                                TotalPrice = product.Price * productCount
                            };

                            order.OrderDetail = detail;
                            OrderService.InsertOrder(order, context);

                            // To Do: Showing Invoice 

                            OrderService.InsertOrder(order, context);

                        }
                    }
                }

            }

        }
    }
}
