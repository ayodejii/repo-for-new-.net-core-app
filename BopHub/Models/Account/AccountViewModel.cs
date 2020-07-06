using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BopHub.Models.Account
{
    public class AccountViewModel
    {
        //public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool isUserLoggedIn { get; set; }
        //public AccountViewModel()
        //{
        //    isUserLoggedIn = false;
        //}
    }
}
