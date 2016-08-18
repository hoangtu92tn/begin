using ShopTu.Data.Infrastructure;
using ShopTu.Data.Repositories;
using ShopTu.Model.Models;
using System.Collections.Generic;

namespace ShopTu.Service
{
    public interface ITagService
    {
        IEnumerable<Tag> GetAll();

        Tag Add(Tag tag);

        void Commit();
    }

    public class TagService : ITagService
    {
        private ITagRepository _tagRepository;
        private IUnitOfWork _unitOfWork;

        public TagService(ITagRepository tagRepository, IUnitOfWork unitOfWork)
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