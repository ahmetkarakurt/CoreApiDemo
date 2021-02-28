using Core.DataAcess;
using Core.Entitiy.Concrete;
using Entitiy.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
 public   interface IUserDal :IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}
