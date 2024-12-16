using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using STO.DataTransferObjects;
using STO.Models;

namespace STO.Controllers
{
    public class AdminController(StoContext context) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ListPersons()
        {

            var personsList = await context.Persons
                .OrderBy(person => person.FullName).ToArrayAsync();
            return View();
        }
    }
}
