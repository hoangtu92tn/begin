using ShopTu.Data.Infrastructure;
using ShopTu.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;

namespace ShopTu.Data.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetProductByCategory(int pageIndex, int pageSize, out int total);
    }
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public IEnumerable<Product> GetProductByCategory(int pageIndex, int pageSize, out int total)
        {
            var query = from p in DbContext.Products
                        join ct in DbContext.ProductCategories
                            on p.CategoryID equals ct.ID
                        where p.Status
                        select p;
            total = query.Count();
            query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return query;


        }
    }
}
