using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace WebStore.Infrastructure.Middleware
{
    public class TestMiddleware
    {
        private readonly RequestDelegate _Next;

        public TestMiddleware(RequestDelegate Next) => _Next = Next;

        public async Task InvokeAsync(HttpContext context)
        {           
            var next = _Next(context);
            await next;
        }
    }
}
