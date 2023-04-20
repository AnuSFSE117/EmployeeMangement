﻿using EmployeeMangement.Exception_Handling;
using EmployeeMangement.Exceptions;
using System.Net;
using System.Text.Json;

namespace EmployeeMangement.Configurations
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode status;
            var stackTrace = string.Empty;
            string message;

            var exceptionType = exception.GetType();

           
            
            if (exceptionType == typeof(IdNotFoundException))
            {
                status = HttpStatusCode.NotFound;
                message = exception.Message;
                stackTrace = exception.StackTrace;
            }else if(exceptionType == typeof(EmailAlreadyExistsException))
            {
                status = HttpStatusCode.InternalServerError;
                message = exception.Message;
                stackTrace = exception.StackTrace;
            }
            else if (exceptionType == typeof(RecordsNotFoundException))
            {
                status = HttpStatusCode.NotFound;
                message = exception.Message;
                stackTrace = exception.StackTrace;
            }
            else
            {
                status = HttpStatusCode.InternalServerError;
                message = exception.Message;
                stackTrace = exception.StackTrace;
            }

            var exceptionResult = JsonSerializer.Serialize(new { error = message});
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;

            return context.Response.WriteAsync(exceptionResult);
        }
    }
}

