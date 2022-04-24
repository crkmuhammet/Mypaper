using System;
using Maypaper.Data.Abstract;
using Maypaper.Entities.Concrete;
using Maypaper.Shared.Data.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Maypaper.Data.Concrete.EntityFramework.Repositories
{
    public class CategoryRepository:EfEntityRepositoryBase<Category>,ICategoryRepository
    {
        public CategoryRepository(DbContext context):base(context)
        {
        }
    }
}
