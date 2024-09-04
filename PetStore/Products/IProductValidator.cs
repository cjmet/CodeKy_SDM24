using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using PetStore.Interfaces;

namespace PetStore.Products
{
    internal class IProductValidator : AbstractValidator<IProduct>
    {
        public IProductValidator()
        {
            RuleFor(product => product.Name).NotEmpty();
            RuleFor(product => product.Price).GreaterThan(0);
            RuleFor(product => product.Description).Length(10,80);
            RuleFor(product => product.Quantity).GreaterThan(0);
        }
    }
}
