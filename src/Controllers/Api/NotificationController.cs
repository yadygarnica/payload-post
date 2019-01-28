using Microsoft.AspNetCore.Mvc;
using PayloadPost.Services.Interfaces;
using PayloadPost.ViewRenders.Interfaces;

namespace PayloadPost.Controllers.Api
{
    public abstract class NotificationController : ControllerBase
    {
        protected readonly IEmailService _emailService;
        protected readonly IPlainTextContentRenderer _plainTextContentRenderer;
        protected readonly IHtmlContentRenderer _viewRenderer;

        protected NotificationController(IEmailService emailService, 
            IPlainTextContentRenderer plainTextContentRenderer, IHtmlContentRenderer viewRenderer)
        {
            this._emailService = emailService;
            this._plainTextContentRenderer = plainTextContentRenderer;
            this._viewRenderer = viewRenderer;
        }
    }
}
