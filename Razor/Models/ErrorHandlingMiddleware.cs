using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Razor.Models
{
    public class ErrorHandlingMiddleware
    {
        private const string JsonContentType = "application/json";
        private readonly RequestDelegate request;

        /// <summary>
        /// Initializes a new instance of the ExceptionHandlerMiddleware class.
        /// </summary>
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.request = next;
        }

        /// <summary>
        /// Invokes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public Task Invoke(HttpContext context) => this.InvokeAsync(context);

        async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await this.request(context);
            }
            catch (Exception exception)
            {
                var httpStatusCode = ConfigureExceptionTypes(exception);

                // set http status code and content type
                context.Response.StatusCode = httpStatusCode;
                context.Response.ContentType = JsonContentType;

                // writes or returns error model to the response
                await context.Response.WriteAsync(
                    JsonConvert.SerializeObject(new ErrorModel
                    {
                        Message = exception.Message,
                        StackTrace = exception.StackTrace                    
                    }));

                context.Response.Headers.Clear();
            }
        }

        /// <summary>
        /// This Configures / maps exception to the proper HTTP error type
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <returns></returns>
        private static int ConfigureExceptionTypes(Exception exception)
        {
            int httpStatusCode;

            // Exception type To Http Status configuration 
            switch (exception)
            {
                case var validEx when exception is ValidationException:
                    httpStatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                default:
                    httpStatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            return httpStatusCode;
        }
    }
}
