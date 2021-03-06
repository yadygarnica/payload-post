﻿using PayloadPost.Models;
using PayloadPost.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using PayloadPost.ViewRenders.Interfaces;
using System.Threading.Tasks;

namespace PayloadPost.Controllers.Api
{
    /// <summary>
    /// Capture action related to a trasaction
    /// </summary>
    [Route("api/identity-notification")]
    [ApiController]
    public class IdentityNotificationController : NotificationController
    {
        public IdentityNotificationController(IEmailService emailService
            , IPlainTextContentRenderer plainTextContentRenderer
            , IHtmlContentRenderer viewRenderer) : base(emailService, plainTextContentRenderer
            , viewRenderer)
        { }

        // POST api/capture
        [HttpPost]
        public async Task<IActionResult> PostAsync(IdentityNotification request)
        {
            switch (request.IdentityNotificationType)
            {
                case IdentityNotificationTypeEnum.ConfirmEmail:
                    await this.SendConfirmEmailAsync(request.CustomerName, request.CustomerEmail,
                        request.Link, request.CompanyContactLink, request.CompanyName, request.CompanyEmail);
                    break;
                case IdentityNotificationTypeEnum.ResetPassword:
                    await this.SendResetPaswordAsync(request.CustomerName, request.CustomerEmail
                        , request.Link, request.CompanyName, request.CompanyEmail);
                    break;
            }
            return Ok();
        }

        private async Task SendConfirmEmailAsync(string customerName, string customerEmail
           , string confirmLink, string companyContactLink, string companyName, string companyEmail)
        {
            ConfirmEmailViewModel model = new ConfirmEmailViewModel();
            model.CustomerName = customerName;
            model.ConfirmLink = confirmLink;
            model.CompanyContactLink = companyContactLink;
            model.CompanyName = companyName;


            var htmlContent = await base._viewRenderer.RenderViewToString("Views/Identity/ConfirmEmail.cshtml", model);
            var plainTextContent = base._plainTextContentRenderer.RenderModelToString(new
            {
                Memsagem = $"Olá {customerName}! Criamos uma conta para você. Confirme o seu email e escolha uma nova senha",
                Link = confirmLink
            });

            var emailDetail = new EmailDetail()
            {
                ToEmail = customerEmail,
                ToName = customerName,
                Subject = "Confirme seu email",
                PlainTextContent = plainTextContent,
                HtmlContent = htmlContent,
                FromEmail = companyEmail,
                FromName = companyName,
            };

            await this._emailService.SendEmail(emailDetail);
        }

        private async Task SendResetPaswordAsync(string customerName, string customerEmail, string resetLink,
            string companyName, string companyEmail)
        {
            ResetPasswordViewModel model = new ResetPasswordViewModel();
            model.CustomerName = customerName;
            model.ResetLink = resetLink;

            var htmlContent = await base._viewRenderer.RenderViewToString("Views/Identity/ResetPassword.cshtml", model);
            var plainTextContent = base._plainTextContentRenderer.RenderModelToString(new
            {
                Memsagem = $"Olá {customerName}! Entre no link e escolha uma nova senha",
                Link = resetLink
            });

            var emailDetail = new EmailDetail()
            {
                ToEmail = customerEmail,
                ToName = customerName,
                Subject = "Mude sua senha",
                PlainTextContent = plainTextContent,
                HtmlContent = htmlContent,
                FromEmail = companyEmail,
                FromName = companyName,
            };

            await base._emailService.SendEmail(emailDetail);
        }
    }
}
