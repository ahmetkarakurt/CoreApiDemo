﻿using Entitiy.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.ValidationRules.FluentValidation
{
  public  class BrandValidator: AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(b=>b.BrandName).NotEmpty();
            RuleFor(b => b.BrandName).MinimumLength(3);
        }
    }
}
