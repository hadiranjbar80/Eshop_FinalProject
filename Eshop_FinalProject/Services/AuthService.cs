using FinalProject_ECommerceApplication.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject_ECommerceApplication.Models;

namespace FinalProject_ECommerceApplication.Services
{
    public class AuthService
    {
        public static bool isAuth = false;

        public static int Authenticate(string username, string password, AppDbContext context)
        {
            username = Clean(username);

            var user = context.Users.Include(user => user.Role).FirstOrDefault(user => user.Username == username && user.Password == password);

            if (user != null)
            {
                isAuth = true;
                return user.Role.Id;
            }
            else
            {
                return -1;
            }
        }

        public static bool IsAdmin(string username, AppDbContext context)
        {
            username = Clean(username);

            var user = context.Users.Include(user => user.Role).FirstOrDefault(user => user.Username == username);

            if (user != null)
            {
                if (user.Role.Id == 1) 
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        private static string Clean(string text)
        {
            text = text.Replace(" ", "");
            text = text.ToLower();
            return text;
        }


    }
}
