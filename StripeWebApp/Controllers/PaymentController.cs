﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stripe.Checkout;
using StripeWebApp.Data;
using StripeWebApp.Models;

namespace StripeWebApp.Controllers
{
    public class PaymentController : Controller
    {
        private readonly MvcContext _context;
        public PaymentController(MvcContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Items.ToListAsync());
        }
        [HttpPost]
        public ActionResult CreateCheckout([Bind("Id, Name, ImageUrl, PriceId")] Item item)
        {
            var domain = "https://localhost:7059";
            var options = new SessionCreateOptions
            {
                LineItems =
                [
                  new SessionLineItemOptions
                  {
                    // Provide the exact Price ID (for example, pr_1234) of the product you want to sell
                    Price = $"{item.PriceId}",
                    Quantity = 1,
                  },
                ],
                Mode = "payment",
                SuccessUrl = domain + "/Payment/Success",
                CancelUrl = domain + "/Cancel/Success",
            };
            var service = new SessionService();
            Session session = service.Create(options);

            Response.Headers.Append("Location", session.Url);
            return new StatusCodeResult(303);
        }
        public IActionResult Success()
        {
            return View();
        }
        public IActionResult Cancel()
        {
            return View();
        }
    }
}
