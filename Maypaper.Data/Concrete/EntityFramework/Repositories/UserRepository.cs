using System;
using Maypaper.Data.Abstract;
using Maypaper.Entities.Concrete;
using Maypaper.Shared.Data.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Maypaper.Data.Concrete.EntityFramework.Repositories
{
    public class UserRepository:EfEntityRepositoryBase<User>,IUserRepository
    {
        public UserRepository(DbContext context):base(context)
        {
        }
    }
}
