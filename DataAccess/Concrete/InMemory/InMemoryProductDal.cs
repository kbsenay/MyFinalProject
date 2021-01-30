using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product> { 
                new Product{ProductId=1, CategoryId=1, ProductName= "Bardak", UnitPrice=15, UnitsInStock=15},
                new Product{ProductId=2, CategoryId=1, ProductName= "Kamera", UnitPrice=500, UnitsInStock=3},
                new Product{ProductId=3, CategoryId=2, ProductName= "Telefon", UnitPrice=1500, UnitsInStock=2},
                new Product{ProductId=4, CategoryId=2, ProductName= "Klavye", UnitPrice=150, UnitsInStock=65},
                new Product{ProductId=5, CategoryId=2, ProductName= "Fare", UnitPrice=85, UnitsInStock=1}
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //LINQ - Language Integrated Query (Dile Gömülü Sorgulama)
            Product productToDelete = null;

            //foreach (var p  in _products)
            //{
            //    if (product.ProductId == p.ProductId)
            //    {
            //        productToDelete = p;
            //    }
            //}

            productToDelete = _products.SingleOrDefault(p=>p.ProductId == product.ProductId);
            
            //Tek bir eleman bulmaya yarar.  // => lambda işareti 
            //Bu koda tek tek dolaşmaya yarar. Foreach gibi... First, FirstOrDefault da kullanılabilir. 
            //Her p için id si benim parametreyle gönderdiğim ürünün idsine eşitse bul.
            //Bu bir metottur.

            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public void Update(Product product)
        {
            //Gönderdiğim ürün id'aine sahip olan listedeki ürünü bul
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }

        public List<Product> GetAllByCategory(int categoryID) 
        {
            return _products.Where(p => p.CategoryId == categoryID).ToList();
            //ürün listesinde parametre olarak verilen kategori idye eşit olan kayıtları döner
        }
    }
}
