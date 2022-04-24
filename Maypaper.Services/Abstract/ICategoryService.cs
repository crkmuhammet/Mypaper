using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Maypaper.Entities.Concrete;
using Maypaper.Entities.Dto;
using Maypaper.Shared.Utilities.Results.Abstract;

namespace Maypaper.Services.Abstract
{
    public interface ICategoryService
    {
        // Asenkron bir yapı kurduğunuz için Task olarak işaretlememiz gerekecek.
        // IDataResult Status ile birlikte Data'yı da taşır. xx Kategorisi Getirildi vb.
        Task<IDataResult<Category>> Get(int categoryId); // Şu kategori ID'li kategoriyi getir ve sonuçları gösterecek.
        Task<IDataResult<IList<Category>>> GetAll(); // Burada predicate vermemize gerek yok. Çünkü tüm kategorileri getireceğiz.
        Task<IDataResult<IList<Category>>> GetAllByNonDeleted();

        // IResult sadece Status'u taşır. Başarılı Bir şekilde Listelendi ya da Listelenirken Hata oluştu.
        Task<IResult> Add(CategoryAddDto categoryAddDto, string createdByName); // DTO nedir? Data Transfer Object Sadece ihtiyacımız olacak alanları taşıyacağız.
        Task<IResult> Update(CategoryUpdateDto categoryUpdateDto, string modifiedByName);
        Task<IResult> Delete(int categoryId,string modifiedByName); // Gerçekten bir datayı silmeyecek sadece IsActive'i False yapacak.
        Task<IResult> HardDelete(int categoryId); // Datayı veri tabanından da silecek.

    }
}
