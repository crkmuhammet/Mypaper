using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Maypaper.Data.Abstract;
using Maypaper.Entities.Concrete;
using Maypaper.Shared.Data.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Maypaper.Data.Concrete.EntityFramework.Repositories
{
    public class ArticleRepository : EfEntityRepositoryBase<Article>, IArticleRepository
    {

        public ArticleRepository(DbContext context):base(context)
        {

        }
    }
}
