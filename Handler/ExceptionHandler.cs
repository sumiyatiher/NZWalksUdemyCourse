using System.Net;

namespace NZWalkz.API.Handler
{
    public class ExceptionHandler
    {
        private readonly ILogger<ExceptionHandler> log;
        private readonly RequestDelegate next;

        public ExceptionHandler(ILogger<ExceptionHandler> log, RequestDelegate next)
        {
            this.log = log;
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {
                //Log the exception
                var errorId = Guid.NewGuid();
                log.LogError(ex, $"{errorId} : {ex.Message}");

                

                //Return custom error response
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                httpContext.Response.ContentType = "application/json";

                var error = new
                {
                    id = errorId,
                    ErrorMsg = "Something went wrong"
                };

                await httpContext.Response.WriteAsJsonAsync(error);
                
            }
        }
    }
}
