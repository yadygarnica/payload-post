using PayloadPost.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace PayloadPost.Controllers
{
    /// <summary>
    /// Assistant to render and show examples of email templates.
    /// Each route display an exmaple of one email template view.
    /// </summary>
    [Route("email-samples/admin")]
    // [ApiExplorerSettings(IgnoreApi = true)]
    public class AdminEmailSamplesController : Controller
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
                ErrorDetail = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed eiusmod tempor incidunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquid ex ea commodi consequat. Quis aute iure reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint obcaecat cupiditat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                KeeperName = "KeeperName",
                TicketLink = "TestTicketLink.com",
                OccurrenceDateTime = DateTime.Now
            };
            return View(model);
        }

        /// <summary>
        /// Render and show example of Alert template.
        /// </summary>
        [HttpGet]
        [Route("contact")]
        public IActionResult ContactFromUser()
        {
            ContactFromUserViewModel model = new ContactFromUserViewModel()
            {
                CompanyName = "CompanyName",
                CostumerEmail = "CostumerEmail@email.com",
                CostumerName = "CostumerName",
                Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed eiusmod tempor incidunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquid ex ea commodi consequat. Quis aute iure reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint obcaecat cupiditat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                Subject = "Subject"
            };

            return View(model);
        }
    }     
}