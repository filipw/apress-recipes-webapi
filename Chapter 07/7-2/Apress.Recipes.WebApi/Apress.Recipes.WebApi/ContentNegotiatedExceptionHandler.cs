using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;

namespace Apress.Recipes.WebApi
{
    public class ContentNegotiatedExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            var metadata = new ErrorData
            {
                Message = "An unexpected error occurred! Please use the ticket ID to contact support",
                DateTime = DateTime.Now,
                RequestUri = context.Request.RequestUri,
                ErrorId = Guid.NewGuid()
            };
            //log the metadata.ErrorId and the correlated Exception info to your DB/logs
            //or, if you have IExceptionLogger (chapter 8-3), it will already have been logged
            Debug.WriteLine("Error correlation id: {0}", metadata.ErrorId);

            var response = context.Request.CreateResponse(HttpStatusCode.InternalServerError, metadata);
            context.Result = new ResponseMessageResult(response);
        }
    }

}