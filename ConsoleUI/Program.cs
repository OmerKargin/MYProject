using Business.Concrate;
using Data_Access.Concrate.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProdutTest();
            CategoryTest();
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine("******* {0} ,{1}", category.CategoryName,category.CategoryId);
            }
        }

        private static void ProdutTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            var result = productManager.GetProductDetails();
            if (result.Success==true)
           
            {
                foreach (var product in result.Data)
            {
                Console.WriteLine(product.ProductName);
            }

            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}
