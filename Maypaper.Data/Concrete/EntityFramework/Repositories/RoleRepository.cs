using System;
using Maypaper.Data.Abstract;
using Maypaper.Entities.Concrete;
using Maypaper.Shared.Data.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Maypaper.Data.Concrete.EntityFramework.Repositories
{
    public class RoleRepository:EfEntityRepositoryBase<Role>,IRoleRepository
    {
        public RoleRepository(DbContext context):base(context)
        {
        }
    }
}
