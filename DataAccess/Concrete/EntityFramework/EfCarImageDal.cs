﻿using Core.DataAccess.EntityFremework;
using DataAccess.Abstract;
using Entitiy.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
   public class EfCarImageDal : EfEntityRepositoryBase<CarImage,ReCapContext>,ICarImageDal
    {
    }
}
