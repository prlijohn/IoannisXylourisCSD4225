using formsWeb.Data;
using formsWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace formsWeb.Controllers
{
    public class PatientController : Controller
    {
        private readonly ApplicationDbContext _db;

        public PatientController(ApplicationDbContext db)
        {
            _db = db;
        }
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var userIdClaim = User.FindFirst("PatientId");
            var userNameClaim = HttpContext.User.Claims.ToList();
            var id = int.Parse(userNameClaim[1].Value);
            if (id != null)
            {
                //string userName = userNameClaim;
                // Do something with the userName
            }
            var Questionnaires = await _db.Questionnaire.OrderBy(c => c.Id).ToListAsync();
            var Forms =await  _db.Forms
                .Where(c => c.PatientId == id)
                .DefaultIfEmpty()
                .ToListAsync();
            var model = new
            {
                Questionnaires,
                Forms
            };
            return View(model);
        }

        //GET
        public async Task<IActionResult> Register()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Patient pt) 
        {
            Console.WriteLine(pt);
            _db.Patients.Add(pt);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Patient pt, string returnUrl)
        {
            Console.WriteLine(pt);
            Console.WriteLine(returnUrl);
            var first = _db.Patients
                .Where(c => c.username == pt.username && c.password == pt.password)
                .FirstOrDefault();
            if (first != null) {
                Console.WriteLine(returnUrl);

                //return Redirect("./Questionnaire/Question");
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, pt.username),
                    new Claim("PatientId", first.Id.ToString())

                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties { };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);
            }

            return View();
        }
    }
}
