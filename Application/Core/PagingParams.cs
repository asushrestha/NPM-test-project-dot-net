using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Core
{
    public class PagingParams
    {

        public int PageNumber {get;set;} =1;
        private int _pageSize = 10;

        private const int MaxPageSize = 50;
        
        
        public int PageSize{
            
            get => _pageSize;
            set=>_pageSize=(value>MaxPageSize)?MaxPageSize:value;
            }

        
    }
}