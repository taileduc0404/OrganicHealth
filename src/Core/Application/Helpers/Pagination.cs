

namespace Application.Helpers
{
    public class Pagination<T> where T : class
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
        public List<T> Data { get; set; }
        public Pagination(int pageNumber, int pageSize, int count, List<T> data)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            Count = count;
            Data = data;
        }
    }
}
