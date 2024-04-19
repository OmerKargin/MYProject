using Data_Access.Abstract;
using Entities.Concrate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.Concrate.InMemory
{          
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product> { 
            new Product{ProductId=1,CategoryId=1,ProductName="Bardak",UnitPrice=15,UnitsInStock=151 },
            new Product{ProductId=2,CategoryId=1,ProductName="Kamera",UnitPrice=155,UnitsInStock=152 },
            new Product{ProductId=3,CategoryId=2,ProductName="Telefon",UnitPrice=156,UnitsInStock=153 },
            new Product{ProductId=4,CategoryId=2,ProductName="fare",UnitPrice=157,UnitsInStock=154 },

            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
           Product producttoDelete = null;
            
            //silmek istediğimiz ürünü seçtik
            producttoDelete=_products.SingleOrDefault(x => x.ProductId == product.ProductId);
            _products.Remove(producttoDelete);  
        }

        public List<Product> GetAll()
        {
            return _products; //Products ı hepsini getiriyoruz zaten bu liste
        }
    
        public void Update(Product product)
        {
            //Gönderdiim ürünü bul ve güncelle
            Product producttoUpdate;
            producttoUpdate = _products.SingleOrDefault(x => x.ProductId == product.ProductId);

            producttoUpdate.ProductName = product.ProductName;
            producttoUpdate.CategoryId = product.CategoryId;
            producttoUpdate.UnitPrice = product.UnitPrice;
            producttoUpdate.UnitsInStock = product.UnitsInStock;

        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList(); //Where ile bulduk liste yapıp gönderdik.
        }

        public Product Get(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<ProductDetailDto> GetProductDetail()
        {
            throw new NotImplementedException();
        }
    }
}
