using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopTu.Model.Models;
using ShopTu.Data.Infrastructure;
using ShopTu.Data.Repositories;

namespace ShopTu.Service
{
    public interface ITagService
    {
        IEnumerable<Tag> GetAll();
        Tag Add(Tag tag);
        void Commit();
    }

   
    public class TagService:ITagService
    {
        ITagRepository _tagRepository;
        IUnitOfWork _unitOfWork;

        public TagService(ITagRepository tagRepository,IUnitOfWork unitOfWork)
        {
            this._tagRepository = tagRepository;
            this._unitOfWork = unitOfWork;

        }

        public Tag Add(Tag tag)
        {
            return _tagRepository.Add(tag);
        }

        public void Commit()
        {
            _unitOfWork.Commit();
        }

        public IEnumerable<Tag> GetAll()
        {
            return _tagRepository.GetAll();
        }
    }
}
