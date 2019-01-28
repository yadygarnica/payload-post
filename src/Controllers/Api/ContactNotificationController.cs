
using PayloadPost.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PayloadPost.ViewRenders.Interfaces;
using System.Threading.Tasks;
using PayloadPost.Models;

namespace PayloadPost.Controllers.Api
{
    /// <summary>
    /// Capture action related to a trasaction
    /// </summary>
    [Route("api/contact-notification")]
    [ApiController]
    public class ContactNotificationController : NotificationController
    {
        public ContactNotificationController(IEmailService emailService
            , IConfiguration configuration, IPlainTextContentRenderer plainTextContentRenderer
            , IHtmlContentRenderer viewRenderer):base(emailService, plainTextContentRenderer
            ,  viewRenderer){}

        // POST api/capture
        [HttpPost]
        public async Task<IActionResult> PostAsync(ContactNotification request)
        {
            await this.SendUserContact(request);
            return Ok();
        }

        private async Task SendUserContact(ContactNotification model)
        {

            var htmlContent = await base._viewRenderer.RenderViewToString("Views/Admin/ContactFromUser.cshtml", new ContactFromUserViewModel()
            {
                CompanyName = model.CompanyName,
                CostumerEmail = model.CostumerEmail,
                CostumerName = model.CostumerName,
                Message = model.Message,
                Subject = model.Subject
            });

            var plainTextContent = base._plainTextContentRenderer.RenderModelToString(new
            {
                Nome = model.CostumerName,
                Email = model.CostumerEmail,
                Assunto = model.Subject,
                Memsagem = model.Message,
            });

            var emailDetail = new EmailDetail()
            {
                ToEmail = model.CompanyEmail,
                ToName = model.CompanyName,
                Subject = $"[Contact From {model.CompanyName} Site: {model.Subject}]",
                PlainTextContent = plainTextContent,
                HtmlContent = htmlContent,
                FromEmail = model.CostumerEmail,
                FromName = model.CostumerName,
            };

            await base._emailService.SendEmail(emailDetail);
        }
    }
}
