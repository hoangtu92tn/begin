using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopTu.Web.Infrustructere.Core
{
    public class Pagination<T>
    {
        public int Page { get; set; }

        public int Count
        {
            get
            {
                return (items != null) ? items.Count() : 0; 
                
            }
        }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
        public IEnumerable<T> items { get; set; }
    }
}