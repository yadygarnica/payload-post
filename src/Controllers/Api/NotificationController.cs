using Microsoft.AspNetCore.Mvc;

namespace PayloadPost.Controllers.Api
{
    public abstract class NotificationController : ControllerBase
    {
        private bool IsValidRequest()
        {
            var sig = Request.Headers["X-Token"];
            //TODO:
            return true;            
        }
    }
}
