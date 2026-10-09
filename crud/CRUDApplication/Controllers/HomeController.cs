using CRUDApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CRUDApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Insertdata(Cruddata obj)
        {
            if (ModelState.IsValid)
            {
                obj.Insertdata();
                return RedirectToAction("Showdata");
            }
            else
            {
                return View("Index");
            }   
        
        }

        public IActionResult Showdata()
        {
            Cruddata obj = new Cruddata();
            var dataTable = obj.Showdata();
            return View(dataTable);
        }
        public IActionResult getdata_form(int id)
        {
            Cruddata obj = new Cruddata();
            obj.getdata(id);
            return View(obj);
        }
        public IActionResult updatedata(Cruddata obj)
        {
            if (ModelState.IsValid)
            {
                obj.updatedata();
                return RedirectToAction("showdata");
            }
            else
            {
                return View("getdata_form", obj);
            }
        }
        public IActionResult Details(int id)
        {
            Cruddata obj = new Cruddata();
            obj.getdata(id);
            return View(obj);
        }

        public IActionResult Check_delete(int id)
        {
            Cruddata obj = new Cruddata();
            obj.getdata(id);
            return View(obj);
        }
        public IActionResult delete(int id)
        {
            Cruddata obj = new Cruddata();
            obj.delete(id);
            return RedirectToAction("showdata");
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
