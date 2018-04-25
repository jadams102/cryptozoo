using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CryptoSanctuary.Models;

namespace CryptoSanctuary.Controllers
{
    public class AnimalController : Controller
    {
        private IAnimalRepository animalRepo;  // New!

        public AnimalController(IAnimalRepository repo = null)
        {
            if (repo == null)
            {
                this.animalRepo = new EFAnimalRepository();
            }
            else
            {
                this.animalRepo = repo;
            }
        }

        public ViewResult Index()
        {
            // Updated:
            return View(animalRepo.Animals.ToList());
        }

        public IActionResult Details(int id)
        {
            // Updated:
           Animal thisAnimal = animalRepo.Animals.FirstOrDefault(x => x.AnimalId == id);
            return View(thisAnimal);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Animal animal)
        {
            animalRepo.Save(animal);   // Updated
            // Removed db.SaveChanges() call
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            // Updated:
            Animal thisAnimal = animalRepo.Animals.FirstOrDefault(x => x.AnimalId == id);
            return View(thisAnimal);
        }

        [HttpPost]
        public IActionResult Edit(Animal animal)
        {
            animalRepo.Edit(animal);   // Updated!
            // Removed db.SaveChanges() call
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            // Updated:
           Animal thisAnimal = animalRepo.Animals.FirstOrDefault(x => x.AnimalId == id);
            return View(thisAnimal);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            // Updated:
            Animal thisAnimal = animalRepo.Animals.FirstOrDefault(x => x.AnimalId == id);
            animalRepo.Remove(thisAnimal);   // Updated!
            // Removed db.SaveChanges() call
            return RedirectToAction("Index");
        }
    }
}
