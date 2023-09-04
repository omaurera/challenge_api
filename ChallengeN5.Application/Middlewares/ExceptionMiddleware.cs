using System;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using ChallengeN5.Application.Responses;

namespace ChallengeN5.Application.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ArgumentException ex)
            {
                var response = context.Response;
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                await HandleException(response, ex.Message);
            }
            catch (Exception ex)
            {
                var response = context.Response;
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await HandleException(response, ex.Message);
            }
        }

        private async Task HandleException(HttpResponse response, string message)
        {
            response.ContentType = "application/json";
            await response.WriteAsync(JsonConvert.SerializeObject(new CustomResponse<bool>
            {
                IsSuccess = false,
                ResponseCode = response.StatusCode,
                Message = message,
                Data = false
            }));
        }
    }
}

