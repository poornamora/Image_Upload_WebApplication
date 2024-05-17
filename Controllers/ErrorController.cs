using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;


namespace Practice_WebApp_MVC_Venkat_TT.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger logger;
        public ErrorController(ILogger<ErrorController> logger)
        {
            this.logger = logger;
        }

        [Route("Error/{statusCode}")]
        public IActionResult StatusCodePage(int statuscode)
        {
            var statuscodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            switch(statuscode)
            {
                case 404:
                    ViewBag.Display = "Sorry your requested response could not be found";
                    logger.LogWarning($"404 Error Occured Path={statuscodeResult.OriginalPath}"+
                        $"and QueryString ={statuscodeResult.OriginalQueryString}");
                    break;

                default:
                    ViewBag.Display = "Error occured";
                    break;
            }
            return View("NotFound");
        }

        [Route("Error")]
        [AllowAnonymous]
        public IActionResult Error()
        {
            var exceptiondetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            logger.LogError($"The path {exceptiondetails.Path} threw an exception" + $"{exceptiondetails.Error}");
            ViewBag.ExeceptionPath = exceptiondetails.Path;
            ViewBag.ExceptionMessage = exceptiondetails.Error.Message;
            ViewBag.ExceptionStacktrace = exceptiondetails.Error.StackTrace;
            return View("Exception");
        }
    }
}
