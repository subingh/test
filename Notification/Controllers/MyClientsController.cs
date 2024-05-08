using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Notification.Data;
using Notification.Models;

namespace Notification.Controllers
{
    public class MyClientsController : Controller
    {
        private readonly NotificationContext _context;

        public MyClientsController(NotificationContext context)
        {
            _context = context;
        }

        // GET: MyClients
        public async Task<IActionResult> Index()
        {
            return View(await _context.MyClient.ToListAsync());
        }

        // GET: MyClients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myClient = await _context.MyClient
                .FirstOrDefaultAsync(m => m.ID == id);
            if (myClient == null)
            {
                return NotFound();
            }

            return View(myClient);
        }

        // GET: MyClients/Create
        public IActionResult Create()
        {

            return View();
        }

        // POST: MyClients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Email")] MyClient myClient)
        {
            if (ModelState.IsValid)
            {
                _context.Add(myClient);
                await _context.SaveChangesAsync();
                TempData["message"] = "The detail is successfully added.";
                return RedirectToAction(nameof(Index));
            }
            return View(myClient);
        }

        // GET: MyClients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myClient = await _context.MyClient.FindAsync(id);
            if (myClient == null)
            {
                return NotFound();
            }
            return View(myClient);
        }

        // POST: MyClients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Email")] MyClient myClient)
        {
            if (id != myClient.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(myClient);
                    await _context.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MyClientExists(myClient.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(myClient);
        }

        // GET: MyClients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myClient = await _context.MyClient
                .FirstOrDefaultAsync(m => m.ID == id);
            if (myClient == null)
            {
                return NotFound();
            }

            return View(myClient);
        }

        // POST: MyClients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var myClient = await _context.MyClient.FindAsync(id);
            if (myClient != null)
            {
                _context.MyClient.Remove(myClient);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MyClientExists(int id)
        {
            return _context.MyClient.Any(e => e.ID == id);
        }
    }
}
