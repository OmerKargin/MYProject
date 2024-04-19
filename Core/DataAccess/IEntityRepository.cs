using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{                                          //Bu kısım class demek sınırladık ve referans tip olabilir dedik
                                           // Ve dedikki sadece Bizim klaslar kullanılsın o da Ientity den geliyor ve new koyduk oda somut nesne için 
    public interface IEntityRepository<T> where T:class,IEntity,new()    
        //Burada aynı özellikler olanları toparladık ve sadece T farklı olduğu
                                                    //için hepsini burada toparladık
    {
        T Get(Expression<Func<T,bool>> filter); //Burası diğer yerlerde link kullanmamızı sağlayacak
        List<T> GetAll(Expression<Func<T, bool>> filter =null); //birşeyin detayına kadar gitmek için bunları yazdık
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
       
    }
}
