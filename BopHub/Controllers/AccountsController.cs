using BopHub.Models.Account;
using BopHubData.Model;
using BopHubData.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BopHub.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IRepository<Account> repository;

        public AccountsController(IRepository<Account> repository) => this.repository = repository;

        public IActionResult Index()
        {
            //retrives the session object and if it is null 
            //it sets isUserLoggedIn to false
            //if not, it sets up the account model
            //sends the model to the view
            //var model = new AccountViewModel()
            //{
            //    Username = null,
            //    Password = null,
            //    isUserLoggedIn = false
            //};
            return View();
        }

        [HttpPost]
        public IActionResult Login([FromForm] AccountViewModel account)
        {
            var accounts = repository.Find(x => x.Username == account.Username && x.Password == account.Password);
            if (accounts is null)
                return RedirectToAction("Index");
            var model = new AccountViewModel()
            {
                Username = account.Username,
                Password = account.Password,
                isUserLoggedIn = true
            };
            //saves the account in session 
            return RedirectToAction("Index", "Home");
        }

    }
}


