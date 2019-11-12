using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Belt.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;


namespace Belt.Controllers
{
    public class HomeController : Controller
    {
        private ElContext context;

        public HomeController(ElContext ec)
        {
            context = ec;
        }


        public IActionResult Show()
        {
            return View("Show");
        }


        [HttpGet("/")]
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpPost("login")]
        public IActionResult Login(OldUser user)
        {
            User userInDb = context.Users.FirstOrDefault(u => u.email == user.EmailO);
            if (!ModelState.IsValid)
            {

                return View("Index");

            }
            if (userInDb == null)
            {
                ModelState.AddModelError("EmailO", "Email not found!");
            }
            else
            {
                var hasher = new PasswordHasher<OldUser>();
                var result = hasher.VerifyHashedPassword(user, userInDb.password, user.PasswordO);
                if (result == 0)
                {
                    ModelState.AddModelError("PassdwordO", "Incorrect Password!");
                }
            }
            HttpContext.Session.SetInt32("UserId", userInDb.UserId);
            return Redirect("main");
        }



        [HttpPost("register")]
        public IActionResult Register(User user)
        {
            // if (context.Users.Any(u => u.email == user.email))
            // {
            //     ModelState.AddModelError("email", "Email already in use!");
            // }
            if (ModelState.IsValid)
            {
                Console.WriteLine("valid");
                var hasher = new PasswordHasher<User>();
                user.password = hasher.HashPassword(user, user.password);
                context.Users.Add(user);
                context.SaveChanges();
                HttpContext.Session.SetInt32("UserId", user.UserId);
                return Redirect("main");
            }
            Console.WriteLine("not valid");

            return View("Index");
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("/");
        }

        [HttpPost("create")]
        public IActionResult Wedding(TheFiesta fiesta)
        {
            int? userid = HttpContext.Session.GetInt32("UserId");
            User userInDb = context.Users.FirstOrDefault(u => u.UserId == userid);
            if (fiesta.Date < DateTime.Now)
            {
                ModelState.AddModelError("Date", "Date cant be in the past");

            }
            if (ModelState.IsValid)
            {


                fiesta.PlannerName = userInDb.name;
                fiesta.PlannerId = (int)userid;
                context.Fiesta.Add(fiesta);
                context.SaveChanges();
                return RedirectToAction("Main");

            }
            return View("CreateFiesta");

        }

        [HttpGet("create")]
        public IActionResult Wedding()
        {
            int? userid = HttpContext.Session.GetInt32("UserId");
            if (userid == null)
            {
                return Redirect("/");
            }

            return View("CreateFiesta");
        }

        [HttpGet("main")]
        public IActionResult Main()
        {
            int? userid = HttpContext.Session.GetInt32("UserId");
            User userInDb = context.Users.FirstOrDefault(u => u.UserId == userid);
            if (userid == null)
            {
                return Redirect("/");
            }
            // ViewBag.UserId = (int)userid;


            ViewBag.Fiestas = context.Fiesta.Include(fiesta => fiesta.JoinedUsers).OrderBy(x => x.Date).ToList();
            ViewBag.User = userInDb;
            return View("Main");

        }

        [Route("delete/{FiestaId}")]
        [HttpGet]

        public IActionResult Delete(int FiestaId)
        {
            int? userid = HttpContext.Session.GetInt32("UserId");
            User userInDb = context.Users.FirstOrDefault(u => u.UserId == userid);
            if (userid == null)
            {
                return Redirect("/");
            }
            var fiesta = context.Fiesta.FirstOrDefault(w => w.FiestaId == FiestaId);
            context.Fiesta.Remove(fiesta);
            context.SaveChanges();
            return Redirect("/main");
        }

        [Route("join/{FiestaId}")]
        [HttpGet]
        public IActionResult RSVP(int FiestaId)
        {
            int? userid = HttpContext.Session.GetInt32("UserId");
            User userInDb = context.Users.FirstOrDefault(u => u.UserId == userid);
            if (userid == null)
            {
                return Redirect("/");
            }

            FiestaAndPlanner w = new FiestaAndPlanner();
            w.FiestaId = FiestaId;
            w.UserId = (int)userid;
            context.FiestaAndPlanner.Add(w);
            context.SaveChanges();
            return Redirect("/main");
        }

        [Route("leave/{FiestaId}")]
        [HttpGet]
        public IActionResult UnRSVP(int FiestaId)
        {
            int? userid = HttpContext.Session.GetInt32("UserId");
            User userInDb = context.Users.FirstOrDefault(u => u.UserId == userid);
            if (userid == null)
            {
                return Redirect("/");
            }

            FiestaAndPlanner Invitee = context.FiestaAndPlanner.Where(w => w.FiestaId == FiestaId).Where(g => g.UserId == userid).FirstOrDefault();
            context.FiestaAndPlanner.Remove(Invitee);
            context.SaveChanges();
            return Redirect("/main");
        }
        [Route("view/{FiestaId}")]
        [HttpGet]
        public IActionResult View(int FiestaId)
        {
            int? userid = HttpContext.Session.GetInt32("UserId");
            User userInDb = context.Users.FirstOrDefault(u => u.UserId == userid);
            if (userid == null)
            {
                return Redirect("/");
            }
            ViewBag.participants = context.Fiesta.Include(f => f.JoinedUsers).ThenInclude(p => p.Planner).FirstOrDefault(f => f.FiestaId == FiestaId);


            // FiestaAndPlanner participants = context.FiestaAndPlanner.Where(w => w.FiestaId == FiestaId).Include(fiesta => fiesta.JoinedUsers).ToList();

            ViewBag.fiesta = context.Fiesta.FirstOrDefault(ff => ff.FiestaId == FiestaId);

            return View("ViewFiesta");

        }
    }
}
