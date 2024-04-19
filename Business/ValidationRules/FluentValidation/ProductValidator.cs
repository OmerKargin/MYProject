using Entities.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator:AbstractValidator<Product>             //product için validator
    {
        public ProductValidator()
        {//Kurallar buraya yazılacak
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.ProductName).MinimumLength(2);
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p=>p.CategoryId==1); //kural koyduk bunları tek satırda yazabilirsin
            RuleFor(p => p.ProductName).Must(StarthWithA);
        }

        private bool StarthWithA(string arg)
        {
            return arg.StartsWith("A"); //A ile başla demek 
        }
    }
}
