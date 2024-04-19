using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity>//Burada base oluşturuyoruz ki her zaman her yerde kullanılabilsin diye.Ayriyetten diyoruzki bana bir bağlantı ve onın tablosunu ver
    where TEntity : class ,IEntity, new() where TContext:DbContext, new() //Kodu generic hale getiriyoruz.
    {
        public void Add(TEntity entity)
        {
            using (TContext context = new TContext()) //Burada using bloğu ile işi bitince silinecek
            {
                var addedEntity = context.Entry(entity);    //Dedikki bunu ilişkilendir durumunuda ekleme yap ve savechanges
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);    //Dedikki bunu ilişkilendir durumunuda Silme yap ve savechanges
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }
        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null) //burası linq kodları yazmamızı sağlıor
        {
            using (TContext context = new TContext()) //filtre null ise set ile product hepsini getir. Set<T> burası da dbsetten alıyor
            {
                return filter == null ?
                    context.Set<TEntity>().ToList() :
                    context.Set<TEntity>().Where(filter).ToList(); //Buradaki filter diyorki ana kodda yazılacak zaten link
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var UpdatedEntity = context.Entry(entity);    //Dedikki bunu ilişkilendir durumunuda güncelle yap ve savechanges
                UpdatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
