using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WilmfebAPI.Various
{
    public class UserParams
    {
        private const int MaxPageSize = 50;

        public int PageNumber { get; set; } = 1;
        private int pageSize = 2;
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = (value > MaxPageSize) ? MaxPageSize : value; }
        }
    }
}
