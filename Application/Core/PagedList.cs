using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Application.Core
{
    public class PagedList<T>:List<T>
    {
        public PagedList(IEnumerable<T> data,int pageNumber, int count, int pageSize)
        {
            CurrentPage = pageNumber;   
            PageSize = pageSize;
            TotalCount = count;
            TotalPages = (int) Math.Ceiling(count/(double)pageSize);
            AddRange(data);
        }

        public int CurrentPage{get;set;}
        public int TotalPages{get;set;}
        public int PageSize{get;set;}
        public int TotalCount{get;set;}

        public static async Task<PagedList<T>> CreateAsync(IQueryable<T> source,int pageNumber, int pageSize){
            var count  = await source.CountAsync();
            var data = await source.Skip((pageNumber-1)* pageSize).Take(pageSize).ToListAsync();
            return new PagedList<T>(data, pageNumber,count,pageSize);
        }
    }
}