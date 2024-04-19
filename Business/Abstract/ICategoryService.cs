using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService //Category ile ilgili dış dünyaya neyi servis etmek istiyorsan burada yazıyorsun
    {
        List<Category> GetAll();
        Category GetById(int categoryid);
    }
}
