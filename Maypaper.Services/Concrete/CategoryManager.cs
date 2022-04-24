using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Maypaper.Data.UnitOfWork.Abstract;
using Maypaper.Entities.Concrete;
using Maypaper.Entities.Dto;
using Maypaper.Services.Abstract;
using Maypaper.Shared.Utilities.Results.Abstract;
using Maypaper.Shared.Utilities.Results.ComplexTypes;
using Maypaper.Shared.Utilities.Results.Concrete;

namespace Maypaper.Services.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        // Database ile işlemlerimizi UnitOfWork sınıfında yapmıştık.
        // UnitofWork içinde database ile etkileşimde bulunan context'imiz mevcut.
        // Aynı zamanda oluşturduğumuz Entity'leri işaretlediğimiz Interfacelerimiz var.
        // Bu nedenle UnitOfWork'u burada kullanıyoruz.
        public CategoryManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<IResult> Add(CategoryAddDto categoryAddDto, string createdByName)
        {
            // Kategori oluştururken burada gönderdiğimiz anda yeni bir kategori oluşturmamız gerekiyor.
            // DTO içindeki alanlar ile Category Entity içindeki alanları birbirine eşliyoruz.
            // DTO içinde olmayan alanları ise kendimiz veriyoruz.
            await _unitOfWork.Categories.AddAsync(new Category
            {
                Name = categoryAddDto.Name,
                Description = categoryAddDto.Description,
                Note = categoryAddDto.Note,
                IsActive = categoryAddDto.IsActive,
                CreatedByName=createdByName,
                CreatedDate=DateTime.Now,
                ModifiedByName=createdByName,
                ModifiedDate=DateTime.Now,
                IsDeleted=false
            });
            await _unitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, $"{categoryAddDto.Name} Başarıyla Eklenmiştir!");
        }

        public async Task<IResult> Delete(int categoryId,string modifiedByName)
        {
            // Delete için öncelikle kategoriyi getirmemiz gerekiyor.
            var category = await _unitOfWork.Categories.GetAsync(c => c.Id == categoryId);

            if (category!=null)
            {
                category.IsDeleted = true;
                category.ModifiedByName = modifiedByName;
                category.ModifiedDate = DateTime.Now;
                // Alanları güncelledikten sonra kategoriyi güncellemek için Update işlemi yapıyoruz.
                await _unitOfWork.Categories.UpdateAsync(category);
                await _unitOfWork.SaveAsync();

                return new Result(ResultStatus.Success, $"{category.Name} Başarıyla Silindi!");
            }
            else
            {
                return new Result(ResultStatus.Error, "Bir Hata Oluştu!");
            }
        }


        // GET CATEGORY
        public async Task<IDataResult<Category>> Get(int categoryId)
        {
            // Dışardangelen categoryId'ye eşit olan kategoriyi ve içinde bulunan Article verilerini getir ve bir değişkenin içine at.
           var category = await _unitOfWork.Categories.GetAsync(c=>c.Id==categoryId,c=>c.Articles);
            if (category!=null)
            {
                return new DataResult<Category>(ResultStatus.Success, category);
            }
            return new DataResult<Category>(ResultStatus.Error, "Böyle Bir Kategori Bulunamadı", null);
        }


        // GET ALL CATEGORIES
        public async Task<IDataResult<IList<Category>>> GetAll()
        {
            var categoryList = await _unitOfWork.Categories.GetAllAsync(null,c=>c.Articles);
            if (categoryList.Count>-1)
            {
                return new DataResult<IList<Category>>(ResultStatus.Success, categoryList);
            }
            return new DataResult<IList<Category>>(ResultStatus.Error, "Bir Hata Oluştu", null);
        }


        // GET ALL CATEGORIES WHICH IS NOT DELETED
        public async Task<IDataResult<IList<Category>>> GetAllByNonDeleted()
        {
            var categoriesNonDeleted = await _unitOfWork.Categories.GetAllAsync(null, c => c.Articles, c=>c.IsDeleted==false);
            if (categoriesNonDeleted.Count>-1)
            {
                return new DataResult<IList<Category>>(ResultStatus.Success, "Kategoriler Listelendi", categoriesNonDeleted);
            }
            return new DataResult<IList<Category>>(ResultStatus.Error, "Bir Hata Oluştu", null);
        }


        // DELETE CATEGORY FROM DATABASE
        public async Task<IResult> HardDelete(int categoryId)
        {
            // Delete için öncelikle kategoriyi getirmemiz gerekiyor.
            var category = await _unitOfWork.Categories.GetAsync(c => c.Id == categoryId);

            if (category != null)
            {
                await _unitOfWork.Categories.DeleteAsync(category);
                await _unitOfWork.SaveAsync();

                return new Result(ResultStatus.Success, $"{category.Name} Başarıyla Veritabanından Silindi!");
            }
            else
            {
                return new Result(ResultStatus.Error, "Bir Hata Oluştu!");
            }
        }


        // UPDATE CATEGORY
        public async Task<IResult> Update(CategoryUpdateDto categoryUpdateDto, string modifiedByName)
        {
            // Kategoriyi Update etmeden önce Update edeceğimiz kategoriyi getirmemiz gerekiyor.
            var categoryUpdate = await _unitOfWork.Categories.GetAsync(c => c.Id == categoryUpdateDto.CategoryId);

            if (categoryUpdate!=null)
            {
                categoryUpdate.Name = categoryUpdateDto.Name;
                categoryUpdate.Description = categoryUpdateDto.Description;
                categoryUpdate.Note = categoryUpdateDto.Note;
                categoryUpdate.IsActive = categoryUpdateDto.IsActive;
                categoryUpdate.IsDeleted = categoryUpdateDto.IsDeleted;
                categoryUpdate.ModifiedByName = modifiedByName;
                categoryUpdate.ModifiedDate = DateTime.Now;
                await _unitOfWork.Categories.UpdateAsync(categoryUpdate);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{categoryUpdateDto.Name} Başarıyla Güncellenmiştir!");
            }
            else
            {
                return new Result(ResultStatus.Error, "Kategori Bulunamadı!");
            }
            
        }
    }
}
