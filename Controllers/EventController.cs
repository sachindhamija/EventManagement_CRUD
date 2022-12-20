using EventManagement_CRUD.Data;
using EventManagement_CRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EventManagement_CRUD.Controllers
{
    public class EventController : Controller
    {
        DataContext _context;
        public EventController(DataContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            
            return View();
        }
        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
     
        public IActionResult Create(string Id, string Name,string Description,string StartDate,string EndDate,string Organizer)
        {
            
            var events = new Event()
            {
                Name = Name,    
                Description = Description,
                StartDate = Convert.ToDateTime(StartDate),
                EndDate = Convert.ToDateTime(EndDate),
                Organizer = Organizer
            };
            try
            {
            
                if (events != null)
                {
                    _context.Events.Add(events);
                    _context.SaveChanges();
                    return Json("success");
                }
                else
                    return Json("failed");

            }
            catch (Exception ex)
            { return Json(ex.Message); }

        }
        
     
    }
}
