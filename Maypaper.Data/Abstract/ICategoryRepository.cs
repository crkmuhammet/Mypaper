using System;
using Maypaper.Entities.Concrete;
using Maypaper.Shared.Data.Abstract;

namespace Maypaper.Data.Abstract
{
    // IEntityRepository'den implemente ettiğimiz zaman CRUD işlemlerinin tamamı eklenmiş oluyor.
    // Generic Repository ile çalışmıştık. Bu nedenle IEntityRepository tanımlarken Entity modelini de vermemiz gerekiyor.
    public interface ICategoryRepository:IEntityRepository<Category>
    {
    }
}
