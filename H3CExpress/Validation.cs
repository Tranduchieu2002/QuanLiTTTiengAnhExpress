using H3CExpress.Data.NewEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace H3CExpress
{
    internal class Validation
    {
        public bool IsValid(string emailaddress)
        {
            return Regex.IsMatch(emailaddress, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        public bool CheckLogin(string username, string password)
        {
            using (NewAppContext context = new NewAppContext())
            {
                // Check if the username and password match an existing user
                var user = context.users.FirstOrDefault(u => u.username == username && u.password == password);
                if (user != null)
                {
                    Auth.User = user;
                    Auth.IsLoggedIn = true;
                    // Login successful
                    return true;
                }
                else
                {
                    // Login failed
                    return false;
                }
            }
        }


    }
}
