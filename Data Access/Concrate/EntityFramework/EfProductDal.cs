using Core.DataAccess.EntityFramework;
using Data_Access.Abstract;
using Entities.Concrate;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.Concrate.EntityFramework
{                                   //IProductDal daki herşey burada var efentityrep ta
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetail()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from p in context.Products
                             join c in context.Categories on p.CategoryId equals c.CategoryId //ürünler ile kategorileri join et
                             select new ProductDetailDto { ProductId = p.ProductId, ProductName = p.ProductName, CategoryName = c.CategoryName, UnitsInStock = p.UnitsInStock };
                             // burada kolonları productdetails tekilere göre seçtik
                return result.ToList();             
            }
        }
    }

}
