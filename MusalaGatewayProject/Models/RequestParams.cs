using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusalaGatewayProject.Models
{
    public class RequestParams
    {
        const int maxPageSize = 100;
        public int PageNumber { get; set; } = 1;
        private int _pageSize { get; set; } = 10;

        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
}
