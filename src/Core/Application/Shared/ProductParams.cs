using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Shared
{
    public class ProductParams
    {
        public int MaxPageSize { get; set; } = 10;
        private int _pageSize = 5;

        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value > MaxPageSize ? MaxPageSize : value; }
        }


        public string? Sort { get; set; }
        public int? CategoryId { get; set; }
        public int PageNumber { get; set; } = 1;
        private string _search = "";
        public string Search
        {
            get { return _search; }
            set { _search = value.ToLower(); }
        }

    }
}
