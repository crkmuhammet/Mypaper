using System;
using System.Threading.Tasks;
using Maypaper.Data.Abstract;

namespace Maypaper.Data.UnitOfWork.Abstract
{
    public interface IUnitOfWork:IAsyncDisposable
    {
        // Projemiz içinde bulunan tüm repository'leri tek bir yerden yönetebiliyoruz.
        // Tek bir UnitOfWork sınıfını new'leyerek aynı anda tüm repository'lere erişebileceğiz.
        // Öncesinde tüm repository'lerin Interface'lerini burada tanımlamamız gerekiyor.

        IArticleRepository Articles { get; } //_unitofWork.Articles.AddAsync() gibi kullanımı olacak.
        ICategoryRepository Categories { get; }
        IQuestionRepository Questions { get; }
        IRoleRepository Roles { get; }
        IUserRepository Users { get; }

        //Repositorylerimiz içinde hiç Save methodumuz yok. EfEntityRepositoryBase sınıfımızda da yok.
        //Bu işlemi burada implemente edeceğiz.

        // _unitOfWork.Categories.AddAsync(category);
        // _unitOfWork.Users.AddAsync(user);
        // _unitOfWork.SaveAsync(); Aynı anda hem category hem de user'ı kayıt ettirebiliyoruz.
        // eğer kayıt ederken user ya da category'de hata alırsa devam etmiyor ve exception fırlatıyor.
        Task<int> SaveAsync(); // Etkilenen kayıt sayısı için int olarak tanımladık. 1 rows affected gibi düşünebiliriz.
    }
}
