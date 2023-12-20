using Microsoft.AspNetCore.Http;

namespace Amazone.Api.Errors
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string? Massege { get; set; }
        public ApiResponse(int statusCode, string? massege = null)
        {
            StatusCode = statusCode;
            Massege = massege ?? GetDefulteMassegeForStatusCode(statusCode);
        }

        private string? GetDefulteMassegeForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "You Made A Bad Request",
                401 => "You Are Not Authorized",
                404 => "Resources Not Found",
                500 => "Internal Server Error",
                _ => null
            };
        }
    }
}
