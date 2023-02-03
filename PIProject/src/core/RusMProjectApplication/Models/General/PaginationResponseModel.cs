using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RusMProjectApplication.Models.General
{
    public class PaginationResponseModel<TModel,TEntity>
    {
        public PaginationResponseModel(List<TModel> data,List<TEntity> fullData, int pageIndex,int dataSize)
        {
            Data = new List<TModel>();
            Data = data;
            PageIndex = pageIndex;
            if (pageIndex == 1)
                HasPreviousPage = false;
            else
                HasPreviousPage = true;
            if ((int)Math.Ceiling(fullData.Count / (double)dataSize) <= pageIndex)
                HasNextPage = false;
            else
                HasNextPage = true;
            TotalPages = (int)Math.Ceiling(fullData.Count / (double)dataSize);
            TotalCount = fullData.Count;
        }
        public List<TModel> Data { get; set; }
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
        public bool HasPreviousPage { get; set; }
        public bool HasNextPage { get; set; }
    }
}
