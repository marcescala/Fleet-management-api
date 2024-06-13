using System;
using Microsoft.EntityFrameworkCore;

namespace Fleet_management_api.Utils
{
	public static class HttpContextExtensions
	{
		public async static Task InsertPaginationHeader<T>(this HttpContext HttpContext, IQueryable<T> queryable)
            // agrega un encabezado de paginacion.
        {
            if (HttpContext == null)
            {
                throw new ArgumentNullException(nameof(HttpContext));
            }

            double cantidad = await queryable.CountAsync();
            // conteo numero de elementos
            HttpContext.Response.Headers.Add("X-Total_Count", cantidad.ToString());
            // encabezado
        }
    }
	
}

