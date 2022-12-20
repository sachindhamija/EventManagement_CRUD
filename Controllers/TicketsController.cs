using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EventManagement_CRUD.Data;
using EventManagement_CRUD.Models;

namespace EventManagement_CRUD.Controllers
{
    public class TicketsController : Controller
    {
        private readonly DataContext _context;

        public TicketsController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Tickets.Include(t => t.Event);
            return View(await dataContext.ToListAsync());
        }



        public IActionResult AddOrEdit(int id)
        {
            if (id == 0 || id == null)
            {
                ViewData["EventId"] = new SelectList(_context.Events, "Id", "Name");
                return View();
            }
            else
            {
                var data = _context.Tickets.Where(x => x.Id == id).FirstOrDefault();
                ViewData["EventId"] = new SelectList(_context.Events, "Id", "Name");
                return View(data);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("Id,Number,Price,EventId")] Ticket ticket)
        {
            if (id != null && id != 0)
            {
                var updateticket = await _context.Tickets.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (updateticket != null)
                {
                    updateticket.Number = ticket.Number;
                    updateticket.Price = ticket.Price;
                    _context.Tickets.Update(updateticket);
                    await _context.SaveChangesAsync();
                }

            }
            else
            {
                if (ModelState.IsValid)
                {
                    _context.Add(ticket);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));


                }
            }
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets
                .Include(t => t.Event)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TicketExists(int id)
        {
            return _context.Tickets.Any(e => e.Id == id);
        }
    }
}
