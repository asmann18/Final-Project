using Atlet.Business.DTOs.Common;
using Atlet.Business.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace Atlet.API.Extensions;

public static class ExceptionHandlerExtension
{
    public static IApplicationBuilder AddExceptionHandlerService(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(error =>
        {
            error.Run(async context =>
            {
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                int statusCode = (int)HttpStatusCode.InternalServerError;
                string message = "Internal Server Error";
                if(contextFeature is not null)
                {
                    if(contextFeature.Error is IBaseException)
                    {
                        var error= (IBaseException)contextFeature.Error;
                        message= error.Message;
                        statusCode= error.StatusCode;
                    }
                }
                context.Response.StatusCode = statusCode;
                await context.Response.WriteAsJsonAsync(new ResultDto(statusCode,false,message));
            });
        });
        return app;
    }
}
