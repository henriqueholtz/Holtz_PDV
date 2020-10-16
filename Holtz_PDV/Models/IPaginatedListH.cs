using Microsoft.AspNetCore.Routing;

namespace Holtz_PDV.Models
{
    public interface IPaginatedListH
    {
        string Action { get; set; }
        int TotalPages { get; }
        int PageIndex { get; }
        //int TotalRecordCount { get; }
        RouteValueDictionary RouteValue { get; set; }
        //string SortExpression { get; }
        //int NumberOfPagesToShow { get; set; }
        //int StartPageIndex { get; }
        //int StopPageIndex { get; }

        RouteValueDictionary GetRouteValueForPage(int pageIndex);
    }
}
