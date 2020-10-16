using Microsoft.AspNetCore.Routing;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Holtz_PDV.Models
{
    public class PaginatedListH<T> : List<T>, IPaginatedListH, IEnumerable<T>, IEnumerable where T : class
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }



        public string Action { get; set; }
        public string PageParameterName { get; set; }
        public string SortExpressionParameterName { get; set; }
        public string SortExpression { get; }
        public string DefaultSortExpression { get; }
        public PaginatedListH(List<T> items, int count, int pageIndex,int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            this.AddRange(items);
        }
        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }
        public bool HasNextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }
        public static PaginatedListH<T> Create(IList<T> source, int pageIndex, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return new PaginatedListH<T>(items, count, pageIndex, pageSize);
        }

        public RouteValueDictionary RouteValue { get; set; }

        public RouteValueDictionary GetRouteValueForPage(int pageIndex)
        {

            var dict = this.RouteValue == null ? new RouteValueDictionary() :
                                                 new RouteValueDictionary(this.RouteValue);

            dict[this.PageParameterName] = pageIndex;

            if (this.SortExpression != this.DefaultSortExpression)
            {
                dict[this.SortExpressionParameterName] = this.SortExpression;
            }

            return dict;
        }

        public RouteValueDictionary GetRouteValueForSort(string sortExpression)
        {

            var dict = this.RouteValue == null ? new RouteValueDictionary() :
                                                 new RouteValueDictionary(this.RouteValue);

            if (sortExpression == this.SortExpression)
            {
                sortExpression = this.SortExpression.StartsWith("-") ? sortExpression.Substring(1) : "-" + sortExpression;
            }

            dict[this.SortExpressionParameterName] = sortExpression;

            return dict;
        }
    }
}
