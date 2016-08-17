using ShopTu.Data.Infrastructure;
using ShopTu.Data.Repositories;
using ShopTu.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTu.Service
{

    public interface IProductService
    {
        Product Add(Product product);
        void Delete(Product product);
        void Update(Product product);
        IEnumerable<Product> GetAll();
        //IEnumerable<Product> GetAllPaging(int page, int pageSize, out int total);
        Product GetById(int id);
        void Commit();


    }
    public class ProductService : IProductService
    {
        IProductRepository _productRepository;
        IUnitOfWork _unitOfWork;
        public ProductService(IProductRepository productService, IUnitOfWork unitOfWork)
        {
            this._productRepository = productService;
            this._unitOfWork = unitOfWork;
        }
        public Product Add(Product product)
        {
            return _productRepository.Add(product);
        }

        public void Delete(Product product)
        {
            _productRepository.Delete(product);
        }

        public void Update(Product product)
        {
            _productRepository.Update(product);
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        //public IEnumerable<Product> GetAllPaging(int page, int pageSize, out int total)
        //{
        //    return _productRepository.GetAll(page, pageSize, out total);
        //}

        public Product GetById(int id)
        {
            return _productRepository.GetSingleById(id);
        }

        public void Commit()
        {
            _unitOfWork.Commit();
        }
    }
}
