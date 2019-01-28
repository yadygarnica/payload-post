using PayloadPost.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace PayloadPost.Controllers
{
    /// <summary>
    /// Assistant to render and show examples of email templates.
    /// Each route display an exmaple of one email template view.
    /// </summary>
    [Route("email-samples/identity")]
    // [ApiExplorerSettings(IgnoreApi = true)]
    public class IdentityController : Controller
    {
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
            return View(model);
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
            return View(model);
        }       
    }
}