using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models.Respones
{
    public class PagedResponse<T> : ServiceResponse
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }


        public PagedResponse(List<T> data,int totalRecords, int pageNumber, int pageSize)
        {
            this.TotalRecords = totalRecords;
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.TotalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);
            this.Data = data;
            this.Succedded = true;
            this.Errors = new();
        }
       
        public static async Task<PagedResponse<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PagedResponse<T>(items, count, pageNumber, pageSize);
        }
    }
}
