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



        public IEnumerable<SelectListItem> GetPersonList(int selectedval) {
            IEnumerable<SelectListItem> PersonList = context.Persons.OrderBy(person => person.FullName)
            .Select(person => new SelectListItem
            {
                Text = person.FullName,
                Value = person.Id.ToString(),
                Selected = person.Id==selectedval 
            }).ToList();

            return PersonList;  

        }


        public IEnumerable<SelectListItem> GetBrandsList(int selectedval)
        {
            IEnumerable<SelectListItem> BrandList = context.Brands.OrderBy(brand => brand.Name)
            .Select(brand => new SelectListItem
            {
                Text = brand.Name,
                Value = brand.Id.ToString(),
                Selected = brand.Id == selectedval
            }).ToList();

            return BrandList;

        }


        public IActionResult AddUser()
        {

        var PersonList = GetPersonList(0);
        var rolesList = new List<SelectListItem>
        {
        new SelectListItem { Text = "Admin", Value = "Admin" },
        new SelectListItem { Text = "User", Value = "User" }
        };

            var user = new User();
            var editUsernDto = new EditUserDto(user, 0, PersonList, rolesList);
            return View(editUsernDto);
        }

        [HttpPost]
        public IActionResult AddUser(EditUserDto edituserdto)
        {
            
            var user = edituserdto.user;
            context.Users.Add(user);
            context.SaveChanges(); 

            return RedirectToAction("ListUsers");
        }

        public IActionResult EditUser(int id)
        {
            var user = context.Users.Include(User => User.Person).
                Where(User => User.Id == id).
                FirstOrDefault();

            var selectedval = user.Id;
            var PersonList = GetPersonList(selectedval);
            var rolesList = new List<SelectListItem>
            {
                new SelectListItem { Text = "Admin", Value = "Admin" },
                new SelectListItem { Text = "User", Value = "User" }
            };

            var editUsernDto = new EditUserDto(user, user.Id, PersonList, rolesList);
            return View(editUsernDto);
        }

        [HttpPost]
        public IActionResult EditUser(EditUserDto edituserdto)
        {
            var user = edituserdto.user;
            context.Users.Update(user);
            context.SaveChanges();
            return RedirectToAction("ListUsers");
        }

        public IActionResult DeleteUser(int id)
        {

            var user = context.Users.Find(id);
            context.Users.Remove(user);
            context.SaveChanges();
            return RedirectToAction("ListUsers");
        }

        public IActionResult ListBrands()
        {

            var brandList = context.Brands
                .OrderBy(brand => brand.Name).ToList();
            return View(brandList);
        }

        public IActionResult AddBrand()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddBrand(Brand brand)
        {
            if (!ModelState.IsValid)
                return View();
            context.Brands.Add(brand);
            context.SaveChanges();
            return RedirectToAction("ListBrands");
        }

        public IActionResult EditBrand(int id)
        {
            var brand = context.Brands.Find(id);
            return View(brand);
        }

        [HttpPost]
        public IActionResult EditBrand(Brand brand)
        {
            if (!ModelState.IsValid)
                return View();
            /*context.Persons.AddAsync(person);*/

            context.Brands.Update(brand);
            context.SaveChanges();
            return RedirectToAction("ListBrands");
        }

        public IActionResult DeleteBrand(int id)
        {
            var brand = context.Brands.Find(id);
            context.Brands.Remove(brand);
            context.SaveChangesAsync();
            return RedirectToAction("ListBrands");

        }


        public IActionResult ListModels()
        {

            var modelList = context.Models.Include(model => model.Brand)
                .OrderBy(model => model.Brand.Name).ThenBy(model => model.Name).ToList();
            return View(modelList);
        }

        public IActionResult AddModel()
        {

            var BrandsList = GetBrandsList(0);

            var model = new Model();
            var editModelDto = new EditModelDto(model, 0, BrandsList);
            return View(editModelDto);
        }

        [HttpPost]
        public IActionResult AddModel(EditModelDto editmodeldto)
        {

            var carmodel = editmodeldto.model;
            context.Models.Add(carmodel);
            context.SaveChanges();

            return RedirectToAction("ListModels");
        }

        public IActionResult EditModel(int id)
        {
            var carmodel = context.Models.Include(Model => Model.Brand).
                Where(Model => Model.Id == id).
                FirstOrDefault();

            var selectedval = carmodel.Id;
            var BrandsList = GetBrandsList(selectedval);

            var editModelDto = new EditModelDto(carmodel, carmodel.Id, BrandsList);
            return View(editModelDto);
        }

        [HttpPost]
        public IActionResult EditModel(EditModelDto editmodeldto)
        {
            var carmodel = editmodeldto.model;
            context.Models.Update(carmodel);
            context.SaveChanges();
            return RedirectToAction("ListModels");
        }

        public IActionResult DeleteModel(int id)
        {

            var carmodel = context.Models.Find(id);
            context.Models.Remove(carmodel);
            context.SaveChanges();
            return RedirectToAction("ListModels");
        }

    }
}
