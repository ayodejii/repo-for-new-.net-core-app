using BopHub.Models;
using BopHub.Models.Bops;
using BopHubData.Model;
using BopHubData.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BopHub.Controllers
{
    public class BopsController : Controller
    {
        private readonly IRepository<Genre> genre;
        private readonly IRepository<Bop> bop;
        private readonly IRepository<Account> account;

        public BopsController(IRepository<Genre> genre, IRepository<Bop> bop, IRepository<Account> account)
        {
            this.genre = genre;
            this.bop = bop;
            this.account = account;
        }

        public async Task<IActionResult> Create()
        {
            var genreList = await genre.GetAllAsync();
            var model = new BopsDetailModel
            {
                Genres = genreList
            };
            //dynamic modelNav = new NavBarViewModel
            //{
            //    BopModel = model
            //};
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] BopsDetailModel bopsDetail)
        {
            if (!ModelState.IsValid)
            {
                bopsDetail.Genres = await genre.GetAllAsync();
                return View("Create", bopsDetail);
            }
                
            var artiste = await account.Find(x => x.Id == 1);
            var model = new Bop()
            {
                Artiste = artiste,
                ReleaseDate = DateTime.Parse(bopsDetail.ReleaseDate),
                Genre = await genre.Find(x => x.Id == bopsDetail.Genre),
                ReleaseVenue = "Lagos",
                BopName = bopsDetail.BopName,
            };
            bop.Add(model);
            bop.Save();
            return RedirectToAction("Index", "Home");
        }
    }
}
