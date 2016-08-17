using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopTu.Data.Infrastructure;
using ShopTu.Model.Models;

namespace ShopTu.Data.Repositories
{
    public interface ITagRepository:IRepository<Tag>
    {
        
    }
    public class TagRepository: RepositoryBase<Tag>,ITagRepository
    {
        public TagRepository(IDbFactory dbFactory) : base(dbFactory)
        {
            
        }
    }
}
