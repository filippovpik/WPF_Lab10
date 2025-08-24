using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task10_1.Models
{
    internal static class AuthModel
    {
        const string ValidUsername = "admin";
        const string ValidPassword = "12345";   
    
    public static bool Authenticate(string username, string password)
        {
            if (username == ValidUsername && password == ValidPassword)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}


    
