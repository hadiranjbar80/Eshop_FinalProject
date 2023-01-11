using Eshop_FinalProject.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eshop_FinalProject.Models;

namespace Eshop_FinalProject.Services
{
    public class AuthService
    {
        public static bool isAuth = false;
        public static User User;

        public static int Authenticate(string username, string password, AppDbContext context)
        {
            username = Clean(username);

            var user = context.Users.Include(user => user.Role).FirstOrDefault(user => user.Username.ToLower() == username && user.Password == password);
            User = user;
            if (User != null)
            {
                isAuth = true;
                return User.Role.Id;
            }
            else
            {
                return -1;
            }
        }

        public static bool IsAdmin(string username, AppDbContext context)
        {
            username = Clean(username);

            var user = context.Users.Include(user => user.Role).FirstOrDefault(user => user.Username.ToLower() == username);

            if (user != null)
            {
                return (user.Role.Id == Role.Admin);
            }
            return false;
        }

        public static bool IsAdmin(int roleId)
        {
            if (roleId == 1) { return true; }
            return false;
        }

        public static string PasswordHandle()
        {
            string password = "";
            ConsoleKey key;

            do
            {
                var KeyInfo = Console.ReadKey(intercept: true);
                key = KeyInfo.Key;

                if (key != ConsoleKey.Backspace)
                {
                    Console.Write("*");
                    if (key != ConsoleKey.Enter)
                        password = password + KeyInfo.KeyChar;
                } else if (password.Length > 0 && key == ConsoleKey.Backspace)
                {
                    Console.Write("\b \b");
                    password = password.Substring(0, password.Length - 1);
                }


            } while (key != ConsoleKey.Enter);
            return password;
        }

        private static string Clean(string text)
        {
            text = text.Replace(" ", "");
            text = text.ToLower();
            return text;
        }

    }
}
