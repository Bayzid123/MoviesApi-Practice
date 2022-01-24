using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApi.Helpers
{
    public static class HttpContextExtensions
    {
        public async static Task InsertPaginationParameteresInResponse<T>(this HttpContext httpContext, 
            IQueryable<T>queryable, int recordsperpage)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException(nameof(httpContext));
            }
            double count = await queryable.CountAsync();
            double totalAmountPages = Math.Ceiling(count / recordsperpage);
            httpContext.Response.Headers.Add("totalAmountPages", totalAmountPages.ToString());
        }
    }
}
