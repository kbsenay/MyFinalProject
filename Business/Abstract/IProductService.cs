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
        List<Product> GetAll();
        List<Product> GetAllByCategoryId(int id);

        List<Product> GetByUnitPrice(decimal min, decimal max);

        List<ProductDetailDto> GetProductDetails();
        Product GetById(int productId);  //Tel başına ürün döndürür. Alışveriş sitesinde tek bir ürün ararken ayrıntılarına bakmak için.

        IResult Add(Product product);
    }
}
