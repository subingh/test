using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stripe.BillingPortal;
using Stripe.Checkout;
using StripeWebApp.Data;
using StripeWebApp.Model




namespace StripeWebApp.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create()
        {
            var domain = "http://localhost:7204";
            var options = new Stripe.SessionCreateOptions
            {
                LineItems = new List<SessionLineItemOptions>
                {
                  new() {
                    // Provide the exact Price ID (for example, pr_1234) of the product you want to sell
                    Price = "price_1P9L0lDESKPRzOOfxK5F8Rdl",
                    Quantity = 1,
                  },
                },
                Mode = "payment",
                SuccessUrl = domain + "/success.html",
                CancelUrl = domain + "/cancel.html",
            };
            var service = new SessionService();
            Session session = service.Create(options);

            Response.Headers.Add("Location", session.Url);
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
