using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Maypaper.Shared.Entities.Abstract;

namespace Maypaper.Shared.Data.Abstract
{
    // T alıyoruz ancak kullanıcı bize Abstract sınıf gönderebilir. Modellerimizde olmayan başka bir nesne de gönderebilir.
    // Bu nedenle filtreleme yapmamız gerekiyor.
    // IEntity'den türeyen modeller geldiği zaman çalışması için bir filtre ekledik.
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        // Bu interface'imiz Asenkron çalışacak bir Generic Interface'tir.
        // Verilen Type'a göre repository işlem yapacak. Bu nedenle Task olarak tanımlama yapıyoruz.

        // Get Methodumuz. Tek bir Makale ya da İşlem getirir.
        // 15. ID'ye eşit olan kullanıcıyı getir. Bu nedenle Expression ekliyoruz.
        // predicate filtredir. var kullanici = repository.Get(k=>k.Id==15)
        // params ekledik çünkü tüm parametreleri tek tek includeProperties dizisine eklemiş olacak.
        Task<T> GetAsync(Expression<Func<T,bool>> predicate, params Expression<Func<T,object>>[] includeProperties);

        // Tüm T'yi getirir. Yani User verirsek tüm userları verir.
        Task<IList<T>> GetAllAsync(Expression<Func<T,bool>>predicate=null, params Expression<Func<T,object>>[] includeProperties);

        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);

        // Kullanıcı eklerken, kullanıcının maili daha önce sitemizde kullanılmış mı?
        Task<bool> AnyAsync(Expression<Func<T,bool>> predicate);
        // Admin panelinde elimizdeki verileri sayısal olarak listelemek isteyebiliriz.
        // Kaç kullanıcı var, kaç makale var vs.
        Task<int> CountAsync(Expression<Func<T, bool>> predicate);
    }
}
