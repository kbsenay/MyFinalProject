using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            //Loosely coupled
            //naming convention
            //IoC Container -- Inversion of Control
            _productService = productService;
        }

        [HttpGet]
        public List<Product> Get() 
        {
            //Dependency chain-- Bağımlılık Zinciri
            
            var result = _productService.GetAll();
            return result.Data;
        }
    }
}
