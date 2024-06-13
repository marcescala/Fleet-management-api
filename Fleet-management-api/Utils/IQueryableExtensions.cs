using System;
using Fleet_management_api.DTO;

namespace Fleet_management_api.Utils
{
	 public static class IQueryableExtensions
     {
            public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable, PaginationDTO paginationDTO)
            // aplicar paginacion
            {
                return queryable
                    .Skip((paginationDTO.Page - 1) * paginationDTO.Size)
                    .Take(paginationDTO.Size);
            }
     }
    
}

