using MemoarWeb.Data;
using MemoarWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace MemoarWeb.Controllers
{
    public class MemoarController : Controller
    {
        //cal dependency injection db
        private readonly ApplicationDbContext _db;

        public MemoarController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Memoar> objMemoarList = _db.Memoars;
            return View(objMemoarList);
        }

        public IActionResult Create()
        {
            return View();
        }

        //post method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Memoar obj)
        {
            if (ModelState.IsValid)
            {

                _db.Memoars.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Data has created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //get
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0) {
                return NotFound("The data is not found");
            }

           var datamemoar =  _db.Memoars.Find(id);
            if (datamemoar == null)
            {
                return NotFound("The data is not found");
            }
            return View(datamemoar);
        }

        //post method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Memoar obj)
        {
            if (ModelState.IsValid)
            {

                _db.Memoars.Update(obj);
                _db.SaveChanges();

                TempData["success"] = "Data has updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        //get
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound("The data is not found");
            }

            var datamemoar = _db.Memoars.Find(id);
            if (datamemoar == null)
            {
                return NotFound("The data is not found");
            }
            return View(datamemoar);
        }

        //post method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {

            var obj = _db.Memoars.Find(id);
           
                if(obj == null)
            {
                return NotFound();
            }
            _db.Memoars.Remove(obj);
            _db.SaveChanges();

            TempData["success"] = "Data has deleted successfully";
            return RedirectToAction("Index");

        }



    }
}
