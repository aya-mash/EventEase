using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EventEaseAdmin.Models;
using System.Diagnostics;

namespace EventEaseAdmin.Controllers
{
    public class ErrorController : Controller
    {
        [Route("/Error/Error")]
        public IActionResult Error()
        {
            var feature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            var requestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            var model = new ErrorViewModel
            {
                RequestId = requestId,
                Message = feature?.Error?.Message ?? "An unexpected error occurred.",
                SuggestedAction = "Please try again or contact support."
            };
            return View("~/Views/Shared/Error.cshtml", model);
        }

        [Route("/Error/StatusCode")]
        public IActionResult StatusCode(int code)
        {
            var requestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            var model = new ErrorViewModel { RequestId = requestId };
            switch (code)
            {
                case 400:
                    model.Message = "Bad request.";
                    model.SuggestedAction = "Check your input and try again.";
                    break;
                case 401:
                    model.Message = "Unauthorized.";
                    model.SuggestedAction = "Please log in.";
                    break;
                case 403:
                    model.Message = "Forbidden.";
                    model.SuggestedAction = "You do not have permission to access this resource.";
                    break;
                case 404:
                    model.Message = "Page not found.";
                    model.SuggestedAction = "Check the URL or return to the home page.";
                    break;
                case 409:
                    model.Message = "Conflict.";
                    model.SuggestedAction = "Please refresh and try again.";
                    break;
                case 422:
                    model.Message = "Unprocessable entity.";
                    model.SuggestedAction = "Check your input and try again.";
                    break;
                case 500:
                default:
                    model.Message = "An unexpected error occurred.";
                    model.SuggestedAction = "Please try again or contact support.";
                    break;
            }
            return View("~/Views/Shared/StatusCode.cshtml", model);
        }
    }
}
