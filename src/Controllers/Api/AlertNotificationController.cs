using Microsoft.AspNetCore.Mvc;
using PayloadPost.Models;
using PayloadPost.ViewRenders.Interfaces;
using PayloadPost.Services.Interfaces;
using System.Text;
using System.Threading.Tasks;

namespace PayloadPost.Controllers.Api
{
    /// <summary>
    /// Capture action related to a trasaction
    /// </summary>
    [Route("api/alert-notification")]
    [ApiController]
    public class AlertNotificationController : NotificationController
    {
        private readonly IEmailService _emailService;
        private readonly IHtmlContentRenderer _viewRenderer;

        public AlertNotificationController(IEmailService emailService, IHtmlContentRenderer viewRenderer)
        {
            this._emailService = emailService;
            this._viewRenderer = viewRenderer;
        }

        // POST api/capture
        [HttpPost]
        public async Task<IActionResult> PostAsync(AlertNotification request)
        {
            var model = new AlertNotificationViewModel()
            {
                AffectedSystem = request.AffectedSystem,
                ErrorDetail = request.ErrorDetail,
                OccurrenceDateTime = request.OccurrenceDateTime,
                TicketLink = request.TicketLink
            };
            var plainTextContent = this.GetPlainText(model);


            foreach (var keeper in request.Keepers)
            {
                model.KeeperName = keeper.Name;
                var htmlContent =  await this._viewRenderer.RenderViewToString("Views/EmailRender/Admin/Alert.cshtml", model);

                var emailDetail = new EmailDetail()
                {
                    ToEmail = keeper.Email,
                    ToName = keeper.Name,
                    Subject = $"[Alert From System {request.AffectedSystem}]",
                    PlainTextContent = plainTextContent,
                    HtmlContent = htmlContent,
                    FromEmail = request.CompanyEmail,
                    FromName = request.CompanyName,
                };

                await this._emailService.SendEmail(emailDetail);
            }
            return Ok();
        }
        
        private string GetPlainText(AlertNotificationViewModel model)
        {
            StringBuilder messageBuilder = new StringBuilder();

            messageBuilder.AppendLine($@"Ola! Você tem uma nova alerta!");
            messageBuilder.AppendLine($@"Sistema: {model.AffectedSystem}. ");
            messageBuilder.AppendLine($@"Data: {model.OccurrenceDateTime.Date}. ");
            messageBuilder.AppendLine($@"Hora: {model.OccurrenceDateTime.Hour}:{model.OccurrenceDateTime.Minute}:{model.OccurrenceDateTime.Second}.");
            messageBuilder.AppendLine($@"Detalhes: {model.ErrorDetail}. ");
            messageBuilder.AppendLine($@"Ticket: {model.TicketLink}.");

            return messageBuilder.ToString();
        }
    }
}
