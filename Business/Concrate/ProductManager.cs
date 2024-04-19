using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Utilities.Results;
using Data_Access.Abstract;
using Entities.Concrate;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrate
{
    public class ProductManager : IProductService
    {
        //İŞ kodları burada olacak  //Bir iş sınıfı başka sınıfları newlemez constractır injection yap

        IProductDal _productDal;         //!!!soyut nesne ile bağlantı kur.  kuralları geçince data acceses gitti


        public ProductManager(IProductDal productDal)
        {
                _productDal = productDal;
        }

        public IResult Add(Product product)   //result IResulttan implement olduğu iiçin problem yok 
        {
            var context = new ValidationContext<Product>(product);
            ProductValidator productValidator= new ProductValidator();
            var result = productValidator.Validate(context);
            {
                if (!result.IsValid)
                {
                    throw new ValidationException(result.Errors);
                }
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded); //Geri dönüş verdik
        }

        public IDataResult<List<Product>> GetAll() //Burada normalde Liste döndürüyor zaten ama biz buraya IdataResult ekleyerek bunu hem liste 
        {                                             // hem de Data sonucu başarılı mı başarısız mı diye bilgilendirme yaptık
            if (DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductListed ); //Burası I productdaldan geldi
        }

        public IDataResult <List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=>p.CategoryId==id));
        }

        public IDataResult<List<Product>> GetAllByUnitPrice(decimal min, decimal max)
        {
            return  new SuccessDataResult<List<Product>>(_productDal.GetAll(p=>p.UnitPrice >=min && p.UnitPrice<= max));
        }

        public IDataResult <Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>( _productDal.GetProductDetail());     
        }
    }
}
