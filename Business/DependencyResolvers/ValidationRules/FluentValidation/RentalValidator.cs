using Entitiy.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.ValidationRules.FluentValidation
{
  public  class RentalValidator:AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(r => r.CarId).GreaterThan(0);
            RuleFor(r => r.CustomerId).GreaterThan(0);
            RuleFor(r => r.RentDate).NotEmpty();
            RuleFor(r => r.RentDate).LessThanOrEqualTo(p => p.ReturnDate);

         //   RuleFor(r => r.ReturnDate).Custom(());
        }

       

      
    }
}
