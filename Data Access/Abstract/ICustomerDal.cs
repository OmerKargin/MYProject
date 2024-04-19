using Core.DataAccess;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.Abstract
{
    public interface ICustomerDal:IEntityRepository<Customer>
    {
    }
}
