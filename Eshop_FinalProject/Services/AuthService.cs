using Eshop_FinalProject.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eshop_FinalProject.Models;

namespace FinalProject_ECommerceApplication.Services
{
    public class AuthService
    {
        public static bool isAuth = false;
        public static User User { get; set; }
        public static int Authenticate(string username, string password, AppDbContext context)
        {
            username = Clean(username);

            var user = context.Users.FirstOrDefault(user => user.UserName.ToLower() == username.ToLower() && user.Password == password);
            User = user;
            if (user != null)
            {
                isAuth = true;
                return (int)user.Role;
            }
            else
            {
                return -1;
            }
        }

        public static bool IsAdmin(string username, AppDbContext context)
        {
            username = Clean(username);

            var user = context.Users.FirstOrDefault(user => user.UserName.ToLower() == username.ToLower());

            if (user != null)
            {
                if ((int)user.Role == 1) 
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
