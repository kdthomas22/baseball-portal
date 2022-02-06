using System.Collections.Generic;

public class PaginatedView<TEntity> where TEntity : class
{
    public PaginatedView(int pageIndex, int pageSize, long count, IEnumerable<TEntity> data)
    {
        PageIndex = pageIndex;
        PageSize = pageSize;
        Count = count;
        Data = data;
    }

    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public long Count { get; set; }
    public IEnumerable<TEntity> Data { get; set; }
}
