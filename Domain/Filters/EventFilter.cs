using System.Data.SqlTypes;

public class EventFilter
{
    public string? Search {get;set;}
    public int? CategoryId{get;set;}
    public decimal? MaxPrice{get;set;}
    public decimal? MinPrice{get;set;}
    public  string SortBy{get;set;}=string.Empty;
    public bool Desc{get;set;}
    public int Page{get;set;}
    public int PageSize{get;set;}
    
}