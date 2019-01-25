
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

        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;
        private readonly IPlainTextContentRenderer _plainTextContentRenderer;
        private readonly IHtmlContentRenderer _viewRenderer;

        public ContactNotificationController(IEmailService emailService
            , IConfiguration configuration, IPlainTextContentRenderer plainTextContentRenderer
            , IHtmlContentRenderer viewRenderer)
        {
            this._emailService = emailService;
            this._configuration = configuration;
            this._plainTextContentRenderer = plainTextContentRenderer;
            this._viewRenderer = viewRenderer;
        }

        // POST api/capture
        [HttpPost]
        public async Task<IActionResult> PostAsync(ContactNotification request)
        {
            await this.SendUserContact(request);
            return Ok();
        }

        private async Task SendUserContact(ContactNotification model)
        {

            var htmlContent = await this._viewRenderer.RenderViewToString("Views/EmailRender/Admin/ContactFromUser.cshtml", new ContactFromUserViewModel()
            {
                CompanyName = model.CompanyName,
                CostumerEmail = model.CostumerEmail,
                CostumerName = model.CostumerName,
                Message = model.Message,
                Subject = model.Subject
            });

            var plainTextContent = this._plainTextContentRenderer.RenderModelToString(new
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

            await this._emailService.SendEmail(emailDetail);
        }
    }
}
