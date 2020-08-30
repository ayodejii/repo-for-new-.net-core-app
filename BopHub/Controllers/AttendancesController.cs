using BopHubData.Model;
using BopHubData.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BopHub.Controllers
{
    [Route("/api/Attendances")]
    public class AttendanceController: Controller
    {
        private readonly IRepository<Attendance> attendances;

        public AttendanceController(IRepository<Attendance> attendances)
        {
            this.attendances = attendances;
        }

        [HttpPost]
        public IActionResult Attend([FromBody] int bopId)
        {
            var userId = HttpContext.Session.GetInt32("user");

            if (userId is null)
                return BadRequest("please sign in");

            if (userId is null)
                return RedirectToAction("Index");
            var attendance = new Attendance()
            {
                BopId = bopId,
                AttendeeId = (int)userId
            };
            attendances.Add(attendance);
            attendances.Save();
            return Ok();
        }
    }
}
