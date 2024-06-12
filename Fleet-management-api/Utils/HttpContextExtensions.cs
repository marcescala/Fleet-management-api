using System;
using Microsoft.EntityFrameworkCore;

namespace Fleet_management_api.Utils
{
	public static class HttpContextExtensions
	{
		public async static Task InsertPaginationHeader<T>(this HttpContext HttpContext, IQueryable<T> queryable)
        {
            if (HttpContext == null)
            {
                throw new ArgumentNullException(nameof(HttpContext));
            }

            double cantidad = await queryable.CountAsync();
            HttpContext.Response.Headers.Add("X-Total_Count", cantidad.ToString());
        }
    }
	
}

