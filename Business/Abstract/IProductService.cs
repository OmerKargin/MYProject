using Core.Utilities.Results;
using Entities.Concrate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService //Business hem data accesi hemide Entity i kullanıyor
    {
        IDataResult <List<Product>> GetAll(); //hem işlem sonucunu hem data döndürür
        IDataResult <List<Product>> GetAllByCategoryId(int id);//hem işlem sonucunu hem data döndüröe
        IDataResult <List<Product>> GetAllByUnitPrice(decimal min, decimal max);//hem işlem sonucunu hem data (yani listemizi) döndüröe
        IDataResult <List<ProductDetailDto>> GetProductDetails();//hem işlem sonucunu hem data döndüröe
        IDataResult <Product> GetById(int productId);//hem işlem sonucunu hem data döndüröe
        IResult Add(Product product); //IResult döndüreceğim diyor
    }
} //RESTFUL => HTTP(internet  protokolü),TCP(iki pc arası örnek olarak kablo ile) =>
