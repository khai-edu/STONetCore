using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public IActionResult ListPersons()
        {

            var personsList = context.Persons
                .OrderBy(person => person.FullName).ToList();
            return View(personsList);
        }

        public IActionResult AddPerson()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddPerson(Person person)
        {
            if (!ModelState.IsValid)
                return View();
             context.Persons.Add(person);
             context.SaveChanges();
            return RedirectToAction("ListPersons");
        }

        public IActionResult EditPerson(int id)
        {
            var person = context.Persons.Find(id);
            return View(person);
        }

        [HttpPost]
        public IActionResult EditPerson(Person person)
        {
            if (!ModelState.IsValid)
                return View();
            /*context.Persons.AddAsync(person);*/

            context.Persons.Update(person);
            context.SaveChanges();
            return RedirectToAction("ListPersons");
        }

        public IActionResult DeletePerson(int id)
        {
            var person = context.Persons.Find(id);
            context.Persons.Remove(person);
            context.SaveChangesAsync();
            return RedirectToAction("ListPersons");

        }

        public IActionResult ListUsers()
        {

            var personsList = context.Users.Include(User=>User.Person)
                .OrderBy(user => user.Person.FullName).ToList();
            return View(personsList);
        }

        public IActionResult AddUser()
        {

            IEnumerable<SelectListItem> PersonList =  context.Persons
      .Select(person => new SelectListItem
      {
          Text = person.FullName,
          Value = person.Id.ToString()
      }).ToList();

            var user = new User();
            var editUsernDto = new EditUserDto(user, 0, PersonList);
            return View(editUsernDto);
        }

        

    }
}
