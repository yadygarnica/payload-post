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
        public AlertNotificationController(IEmailService emailService
            , IPlainTextContentRenderer plainTextContentRenderer
            , IHtmlContentRenderer viewRenderer) : base(emailService, plainTextContentRenderer
            , viewRenderer)
        { }

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
            var plainTextContent = base._plainTextContentRenderer.RenderModelToString(new
            {
                Sistema = model.AffectedSystem,
                Data= model.OccurrenceDateTime.Date,
                Hora = $"{model.OccurrenceDateTime.Hour}:{model.OccurrenceDateTime.Minute}:{model.OccurrenceDateTime.Second}.",
                Detalhes = model.ErrorDetail,
                Ticket= model.TicketLink,
            });

            foreach (var keeper in request.Keepers)
            {
                model.KeeperName = keeper.Name;
                var htmlContent =  await base._viewRenderer.RenderViewToString("Views/Admin/Alert.cshtml", model);

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

                await base._emailService.SendEmail(emailDetail);
            }
            return Ok();
        }     
    }
}
