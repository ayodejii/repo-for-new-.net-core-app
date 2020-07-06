using BopHub.Models.Account;
using BopHub.Models.Bops;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BopHub.Models
{
    public class NavBarViewModel
    {
        public AccountViewModel AccountModel { get; set; }
        public BopsDetailModel BopModel { get; set; }
    }
}
