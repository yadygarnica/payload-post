using PayloadPost.Models;
using PayloadPost.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using PayloadPost.ViewRenders.Interfaces;
using System.Threading.Tasks;
using PayloadPost.Controllers.Api;

namespace PayloadPost.Controllers.Api
{
    /// <summary>
    /// Capture action related to a trasaction
    /// </summary>
    [Route("api/payment-notification")]
    [ApiController]
    public class PaymentNotificationController : NotificationController
    {
        public PaymentNotificationController(IEmailService emailService
            , IPlainTextContentRenderer plainTextContentRenderer
            , IHtmlContentRenderer viewRenderer) : base(emailService, plainTextContentRenderer
            , viewRenderer)
        { }

        // POST api/capture
        [HttpPost]
        public async Task<IActionResult> PostAsync(PaymentNotification request)
        {
            switch (request.PaymentNotificationType)
            {
                case PaymentNotificationTypeEnum.ReceivedOrder:
                    await this.SendReceivedOrder(request.CustomerName, request.CustomerEmail, request.AmountInCents, request.CompanyName, request.CompanyEmail);
                    break;
                case PaymentNotificationTypeEnum.Boleto:
                    await this.SendBoleto(request.CustomerName, request.CustomerEmail, request.BoletoLink, request.CompanyName, request.CompanyEmail);
                    break;
                case PaymentNotificationTypeEnum.ComfirmedPayment:
                    await this.SendConfirmedPayment(request.CustomerName, request.CustomerEmail, request.CompanyName, request.CompanyEmail);
                    break;
                case PaymentNotificationTypeEnum.RefusedPayment:
                    await this.SendRefusedPayment(request.CustomerName, request.CustomerEmail, request.RefusedPaymentReason, request.CompanyName, request.CompanyEmail);
                    break;
            }
            return Ok();
        }


        private async Task SendConfirmedPayment(string customerName, string customerEmail,
            string companyName, string companyEmail)
        {
            PaymentConfirmedViewModel model = new PaymentConfirmedViewModel();
            model.CustomerName = customerName;

            var htmlContent = await base._viewRenderer.RenderViewToString("Views/Payment/PaymentConfirmed.cshtml", model);
            var plainTextContent = base._plainTextContentRenderer.RenderModelToString(new
            {
                Memsagem = $"Olá {customerName}! Seu pagamento foi confirmado",
            });

            var emailDetail = new EmailDetail()
            {
                ToEmail = customerEmail,
                ToName = customerName,
                Subject = "Pagamento aprovado",
                PlainTextContent = plainTextContent,
                HtmlContent = htmlContent,
                FromEmail = companyEmail,
                FromName = companyName
            };

            await base._emailService.SendEmail(emailDetail);
        }

        private async Task SendBoleto(string customerName, string customerEmail,
            string boletoUrl, string companyName, string companyEmail)
        {
            PaymentBoletoViewModel model = new PaymentBoletoViewModel();
            model.BoletoLink = boletoUrl;
            model.CustomerName = customerName;

            var htmlContent = await base._viewRenderer.RenderViewToString("Views/Payment/PaymentBoleto.cshtml", model);
            var plainTextContent = base._plainTextContentRenderer.RenderModelToString(new
            {
                Memsagem = $"Olá {customerName}! Seu boleto foi gerado, entre no link para obte-lo",
                BoletoLink = boletoUrl
            });

            var emailDetail = new EmailDetail()
            {
                ToEmail = customerEmail,
                ToName = customerName,
                Subject = "Boleto para pagamento",
                PlainTextContent = plainTextContent,
                HtmlContent = htmlContent,
                FromEmail = companyEmail,
                FromName = companyName
            };

            await base._emailService.SendEmail(emailDetail);
        }

        private async Task SendReceivedOrder(string customerName, string customerEmail,
            long amountInCents, string companyName, string companyEmail)
        {
            ReceivedOrderViewModel model = new ReceivedOrderViewModel();
            model.CustomerName = customerName;
            model.AmountInCents = amountInCents;

            var htmlContent = await base._viewRenderer.RenderViewToString("Views/Payment/ReceivedOrder.cshtml", model);
            var plainTextContent = base._plainTextContentRenderer.RenderModelToString(new
            {
                Memsagem = $"Olá {customerName}! Recebemos seu pedido",
            });

            var emailDetail = new EmailDetail()
            {
                ToEmail = customerEmail,
                ToName = customerName,
                Subject = "Pedido recebido",
                PlainTextContent = plainTextContent,
                HtmlContent = htmlContent,
                FromEmail = companyEmail,
                FromName = companyName
            };
            await base._emailService.SendEmail(emailDetail);
        }

        private async Task SendRefusedPayment(string customerName, string customerEmail,
            string refusedReason, string companyName, string companyEmail)
        {
            PaymentRefusedViewModel model = new PaymentRefusedViewModel();
            model.CustomerName = customerName;

            var htmlContent = await base._viewRenderer.RenderViewToString("Views/Payment/PaymentRefusedByIssuer.cshtml", model);
            var plainTextContent = base._plainTextContentRenderer.RenderModelToString(new
            {
                Memsagem = $"Olá {customerName}! Seu pagamento foi rejeitado",
                Motivos = refusedReason
            });

            var emailDetail = new EmailDetail()
            {
                ToEmail = customerEmail,
                ToName = customerName,
                Subject = "Pagamento não aprovado",
                PlainTextContent = plainTextContent,
                HtmlContent = htmlContent,
                FromEmail = companyEmail,
                FromName = companyName
            };

            await base._emailService.SendEmail(emailDetail);
        }
    }
}
