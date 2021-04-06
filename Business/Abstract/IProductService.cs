using Core.Entities;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();
        IDataResult<List<Product>> GetAllByCategoryId(int id);

        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);

        IDataResult<List<ProductDetailDto>> GetProductDetails();
        IDataResult<Product> GetById(int productId);  //Tel başına ürün döndürür. Alışveriş sitesinde tek bir ürün ararken ayrıntılarına bakmak için.

        IResult Add(Product product);
        IResult Update(Product product);

        IResult AddTransactionalTest(Product product);
        
    }
}
