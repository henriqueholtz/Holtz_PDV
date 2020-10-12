using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/*
 
 //só pega next e previous
 
 
 
 index:
@model PaginatedList<Holtz_PDV.Models.Cliente>
 @{ 
    var prevDisabled = !Model.PreviousPage ? "disabled" : "";
    var nextDisabled = !Model.NestPage ? "disabled" : "";
}

<a asp-action="Index"
   asp-route-page="@(Model.PageIndex -1)"
   class="btn btn-default @prevDisabled">
   Previous
</a>

<a asp-action="Index"
   asp-route-page="@(Model.PageIndex +1)"
   class="btn btn-default @nextDisabled">
    Next
</a>
 * */

namespace Holtz_PDV.Models
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; set; }
        public PaginatedList(List<T> items, int count, int pageIndex,int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            this.AddRange(items);
        }
        public bool PreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }
        public bool NestPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }
        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageIndex,int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
    }
}
