using Autofac;
using Business.Abstract;
using Business.Concrate;
using Data_Access.Abstract;
using Data_Access.Concrate.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module //Sen bir modülsün (autofac)
    {
        protected override void Load(ContainerBuilder builder)  //uygulama ayağa kalkınca direkt çalışacak
        {
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance(); //Eğer biri productservice isterse product manager ver
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();//Eğer birisi productdal istersen burası efproductdal verecek
        }
    }
}
