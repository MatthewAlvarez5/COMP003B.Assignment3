using COMP003B.Assignment3.Models;
using Microsoft.AspNetCore.Mvc;

namespace COMP003B.Assignment3.Controllers
{
    public class PeopleController : Controller
    {
        private static List<Person> _people = new List<Person>();

        //Get: People
        [HttpGet]
        public IActionResult Index()
        {
            return View(_people);
        }
        //Get: People/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Person person)
        {
            if (ModelState.IsValid)
            {
                if(!_people.Any(p => p.Id == person.Id))
                {
                    _people.Add(person);
                }
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        //Get: People/Edit/1
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var person = _people.FirstOrDefault(p => p.Id == id);

            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Person person)
        {
            if (id != person.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var existingPerson = _people.FirstOrDefault(p => p.Id == person.Id);

                if (existingPerson != null) 
                {
                    existingPerson.Name = person.Name;
                    existingPerson.Age = person.Age;
                }
                return RedirectToAction(nameof(Index));


            }
            return View(person);
        }
        //get: People/Delete/1
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var person = _people.FirstOrDefault(p => p.Id == id);

            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

        //Post: People/Delete/1
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var person = _people.FirstOrDefault(p => p.Id == id);
            if (person != null)
            {
                _people.Remove(person);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
