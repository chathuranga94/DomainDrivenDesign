using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;

namespace BiBi.WebAPI.Controllers
{
    [RoutePrefix("response")]
    public class ResponseController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        

        [Route("success")]
        [HttpGet]
        public IHttpActionResult ResponseSuccess()
        {
            logger.Warn("NLog Response Message");

            //  return Ok(1);
            //  return NotFound();
            //  return Ok(obj);
            //  return BadRequest("Custom Message Here");
            //  return Content(HttpStatusCode.BadRequest, "Any object");

            //  custom IHttpActionResult https://stackoverflow.com/questions/21440307/how-to-set-custom-headers-when-using-ihttpactionresult
            //  return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Message describing the error here"));
            return Content((HttpStatusCode)422, "ERROR MSG HERE");

        //  http://stackoverflow.com/questions/28588652/return-content-with-ihttpactionresult-for-non-ok-response
        //  https://weblogs.asp.net/dwahlin/new-features-in-asp-net-web-api-2-part-i
        }

        [Route("failure")]
        [HttpGet]
        public HttpResponseMessage ResponseFailure()
        {
            return new HttpResponseMessage(HttpStatusCode.NotFound);
            // throw new HttpResponseException(HttpStatusCode.NotFound);

            //HttpResponseMessage responseMessage = new HttpResponseMessage(HttpStatusCode.Moved);
            //return ResponseMessage(responseMessage); -> custom response message

            //  HttpError myCustomError = new HttpError("The file has no content or rows to process.") { { "CustomErrorCode", 42 } };
            //  return Request.CreateErrorResponse(HttpStatusCode.BadRequest, myCustomError);


        }

    }
}
