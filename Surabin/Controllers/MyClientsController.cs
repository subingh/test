using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Surabin.Data;
using Surabin.Models;
using Surabin.Models.Entities;
using System.Net.Sockets;

namespace Surabin.Controllers
{   

    public class MyClientsController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public MyClientsController(ApplicationDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Add(AddClientsViewModel addClient)
        {
            if (addClient != null)
            {
                var myClient = new MyClient
                {
                    ClientName = addClient.ClientName,
                    Email = addClient.Email,
                    ContactNo = addClient.ContactNo,
                    TaskCategories = addClient.TaskCategories
                };
                await _dbContext.MyClients.AddAsync(myClient);
                await _dbContext.SaveChangesAsync();
                TempData["Message"] = "client detail is added Successfully";
                return RedirectToAction("List");
            }

            return View();
        }
      

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var myClients = await _dbContext.MyClients.ToListAsync();
            return View(myClients);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int ID)
        {
            var myClient = await _dbContext.MyClients.FindAsync(ID);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(MyClient viewModel)
        {
            var myClient = await _dbContext.MyClients.FindAsync(viewModel.ID);
            if (myClient is not null)
            {
                myClient.ClientName = viewModel.ClientName;
                myClient.Email = viewModel.Email;
                myClient.ContactNo = viewModel.ContactNo;
                myClient.TaskCategories = viewModel.TaskCategories;

                await _dbContext.SaveChangesAsync();

            }
            return RedirectToAction("List","MyClients");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(MyClient viewModel)
        {
            var myClient = await _dbContext.MyClients.FirstOrDefaultAsync(x => x.ID == viewModel.ID);
            if (myClient is not null)
            {
                _dbContext.MyClients.Remove(myClient);
                await _dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "MyClients");
        }
    }
}
