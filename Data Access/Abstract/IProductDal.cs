using Core.DataAccess;
using Entities.Concrate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.Abstract
{
    public interface IProductDal : IEntityRepository<Product> //Burada ürüne özel operasyonları yapacağız. :)
    {
        List<ProductDetailDto> GetProductDetail();

    }
}
