using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BopHub.Models;
using BopHubData.Repository;
using BopHubData.Model;
using BopHub.Models.Bops;

namespace BopHub.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Bop> bop;

        public HomeController(IRepository<Bop> bop)
        {
            this.bop = bop;
        }
        public IActionResult Index()
        {
            var bopList = bop.GetAllIncluding(x => x.Artiste);
            var listingResult = bopList
                .Select(a => new BopsDetailModel
                {
                    BopId = a.BopId,
                    BopName = a.BopName,
                    Artiste = a.Artiste.Username,
                    ReleaseDate = a.ReleaseDate.ToShortDateString(),
                    ReleaseVenue = a.ReleaseVenue,
                    Genre = a.Genre.Id
                });

            var model = new BopsListingModel
            {
                BopsDetailsList = listingResult
            };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
