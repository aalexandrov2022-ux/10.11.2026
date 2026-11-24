using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using WebDogApp.Core.Contacts;
using WebDogApp.Infrastructure.Data.Domain;
using WebDogApp.Models.Breed;

namespace WebDogApp.Controllers
{
    public class BreedController : Controller
    {
        private readonly IBreedService _breedService;

        public BreedController(IBreedService breedService)
        {
            _breedService = breedService;
        }

        // GET: BreedController
        public IActionResult Index()
        {
            List<BreedIndexVM> breeds = _breedService.GetBreeds()
                .Select(item => new BreedIndexVM
                {
                    Id = item.Id,
                    Name = item.Name
                })
                .ToList();

            return View(breeds);
        }

        // GET: BreedController/Details/5
        public IActionResult Details(int id)
        {
            Breed item = _breedService.GetBreedById(id);
            if (item == null)
            {
                return NotFound();
            }

            BreedDetailsVM breed = new BreedDetailsVM
            {
                Id = item.Id,
                Name = item.Name,
                DogsCount = _breedService.GetDogsByBreed(id).Count
            };

            return View(breed);
        }

        // GET: BreedController/Create
        public IActionResult Create()
        {
            return View(new BreedCreateVM());
        }

        // POST: BreedController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] BreedCreateVM model)
        {
            if (ModelState.IsValid)
            {
                var created = _breedService.Create(model.Name);
                if (created)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(model);
        }

        // GET: BreedController/Edit/5
        public IActionResult Edit(int id)
        {
            Breed item = _breedService.GetBreedById(id);
            if (item == null)
            {
                return NotFound();
            }

            BreedEditVM breed = new BreedEditVM
            {
                Id = item.Id,
                Name = item.Name
            };

            return View(breed);
        }

        // POST: BreedController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, BreedEditVM model)
        {
            if (ModelState.IsValid)
            {
                var updated = _breedService.UpdateBreed(id, model.Name);
                if (updated)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(model);
        }

        // GET: BreedController/Delete/5
        public IActionResult Delete(int id)
        {
            Breed item = _breedService.GetBreedById(id);
            if (item == null)
            {
                return NotFound();
            }

            BreedDeleteVM breed = new BreedDeleteVM
            {
                Id = item.Id,
                Name = item.Name
            };

            return View(breed);
        }

        // POST: BreedController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            var deleted = _breedService.RemoveById(id);
            if (deleted)
            {
                return RedirectToAction(nameof(Index));
            }

            return View();
        }
    }
}
