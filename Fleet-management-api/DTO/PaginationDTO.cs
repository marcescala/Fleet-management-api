using System;
namespace Fleet_management_api.DTO
{
	public class PaginationDTO
	{
        public int Page { get; set; } = 1;
        private int size = 10;

        private readonly int maxSize = 50;

        public int Size
        {
            get { return size; }
            set
            {
                size = (value > maxSize) ? maxSize : value;//previene que el usuario mande cantidades incoherentes de registros por pág.
            }
        }
        
	}
}

