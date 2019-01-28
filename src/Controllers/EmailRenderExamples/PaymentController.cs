using PayloadPost.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace PayloadPost.Controllers
{
    /// <summary>
    /// Assistant to render and show examples of email templates.
    /// Each route display an exmaple of one email template view.
    /// </summary>
    [Route("email-samples/payment")]
    // [ApiExplorerSettings(IgnoreApi = true)]
    public class PaymentController : Controller
    {
        /// <summary>
        /// Render and show example of Payment Boleto template.
        /// </summary>
        [HttpGet]
        [Route("payment-boleto")]
        public IActionResult PaymentBoleto()
        {
            PaymentBoletoViewModel model = new PaymentBoletoViewModel()
            {
                CustomerName = "CustomerName",
                BoletoLink = "boleto.link.com",
                BoletoValidDaysCount = 3,
                CompanyName = "CompanyName",
                CompanyWebsite= "CompanyWebsite.com"
            };
            return View(model);
        }

        /// <summary>
        /// Render and show example of Payment Boleto template.
        /// </summary>
        [HttpGet]
        [Route("payment-boleto-reminder")]
        public IActionResult PaymentBoletoReminder()
        {
            PaymentBoletoViewModel model = new PaymentBoletoViewModel()
            {
                CustomerName = "CustomerName",
                BoletoLink = "boleto.link.com",
                BoletoValidDaysCount = 1,
                CompanyName = "CompanyName",
                CompanyWebsite = "CompanyWebsite.com"
            };
            return View(model);
        }
    }
}