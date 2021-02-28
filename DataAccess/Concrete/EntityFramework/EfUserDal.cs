using Core.DataAccess.EntityFremework;
using Core.Entitiy.Concrete;
using DataAccess.Abstract;
using Entitiy.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, ReCapContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using(var context = new ReCapContext())
            {
                var result = from OperationClaim in context.OperationClaims
                             join UserOparationClaim in context.UserOparationClaims
                                on OperationClaim.Id equals UserOparationClaim.OparationClaimId
                                where UserOparationClaim.UserId == user.Id
                                select new OperationClaim { Id = OperationClaim.Id,Name=OperationClaim.Name};
                return result.ToList();
            }
        }
    }
}
