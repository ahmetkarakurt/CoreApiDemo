﻿using Core.DataAcess;
using Entitiy.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
   public interface ICustomerDal:IEntityRepository<Customer>
    {
    }
}
