using PayloadPost.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace PayloadPost.Controllers
{
    /// <summary>
    /// Assistant to render and show examples of email templates.
    /// Each route display an exmaple of one email template view.
    /// </summary>
    [Route("help/email-render")]
    // [ApiExplorerSettings(IgnoreApi = true)]
    public class EmailRenderController : Controller
    {
        /// <summary>
        /// Render and show example of Alert template.
        /// </summary>
        [HttpGet]
        [Route("alert")]
        public IActionResult Alert()
        {
            var model = new AlertNotificationViewModel()
            {
                AffectedSystem = "AffectedSystem",
                ErrorDetail = "ErrorDetail: Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed eiusmod tempor incidunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquid ex ea commodi consequat. Quis aute iure reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint obcaecat cupiditat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                KeeperName = "KeeperName",
                TicketLink = "TestTicketLink.com",
                OccurrenceDateTime = DateTime.Now
            };
            return View("Admin/Alert",model);
        }

        /// <summary>
        /// Render and show example of Alert template.
        /// </summary>
        [HttpGet]
        [Route("contact")]
        public IActionResult Contact()
        {
            ContactFromUserViewModel model = new ContactFromUserViewModel()
            {
                CompanyName = "CompanyName",
                CostumerEmail = "CostumerEmail@email.com",
                CostumerName = "CostumerName",
                Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed eiusmod tempor incidunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquid ex ea commodi consequat. Quis aute iure reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint obcaecat cupiditat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                Subject = "Subject"
            };
          
            return View("Admin/ContactFromUser", model);
        }

        /// <summary>
        /// Render and show example of Reset Password template.
        /// </summary>
        [HttpGet]
        [Route("reset-password")]
        public IActionResult ResetPassword()
        {
            ResetPasswordViewModel model = new ResetPasswordViewModel()
            {
                CustomerName = "CustomerName",
                ResetLink = "ResetLink.com"
            };
            return View("Identity/ResetPassword", model);
        }

        /// <summary>
        /// Render and show example of Confirmation Account Email  template.
        /// </summary>
        [HttpGet]
        [Route("confirm-email")]
        public IActionResult ConfirmEmail()
        {
            ConfirmEmailViewModel model = new ConfirmEmailViewModel()
            {
                CustomerName = "CustomerName",
                ConfirmLink = "ConfirmLink.com",
                CompanyContactLink = "CompanyContactLink.",
                CompanyName= "CompanyName"

            };
            return View("Identity/ConfirmEmail", model);
        }

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
            return View("Payment/PaymentBoleto", model);
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
            return View("Payment/PaymentBoletoReminder", model);
        }
    }
}