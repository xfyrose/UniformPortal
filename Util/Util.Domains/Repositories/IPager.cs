namespace Util.Domains.Repositories
{
    public interface IPager
    {
        int PageNumber { get; set; } 
        int PageSize { get; set; }
        int TotalCount { get; set; }
        int PageCount { get; }
        int SkipCount { get; }
        string Order { get; set; }
        int FirstLineNumber { get; }
        int LastLineNumber { get; }
    }
}