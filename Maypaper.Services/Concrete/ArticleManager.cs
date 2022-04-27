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
    public class ArticleManager : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ArticleManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        // ADD ARTICLE
        public async Task<IResult> Add(ArticleAddDto articleAddDto, string createdByName)
        {
            await _unitOfWork.Articles.AddAsync(new Article
            {
                Title = articleAddDto.Title,
                Content = articleAddDto.Content,
                Note = articleAddDto.Note,
                IsActive = articleAddDto.IsActive,
                CreatedByName = createdByName,
                CreatedDate = DateTime.Now,
                ModifiedByName = createdByName,
                ModifiedDate = DateTime.Now,
                IsDeleted = false

            });
            await _unitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, $"{articleAddDto.Title} Başarıyla Eklenmiştir");
        }

        // SET ACTIVATE FALSE ARTICLE
        public async Task<IResult> Delete(int articleId, string modifiedByName)
        {
            var articleToDelete = await _unitOfWork.Articles.GetAsync(a => a.Id == articleId);
            if (articleToDelete!=null)
            {
                articleToDelete.IsDeleted = true;
                articleToDelete.ModifiedByName = modifiedByName;
                articleToDelete.ModifiedDate = DateTime.Now;
                await _unitOfWork.Articles.UpdateAsync(articleToDelete);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{articleToDelete.Title} Başarıyla Silindi!");
            }
            return new Result(ResultStatus.Error, "Bir Hata Oluştu!");
        }

        // GET ARTICLE
        public async Task<IDataResult<Article>> Get(int articleId)
        {
            var article = await _unitOfWork.Articles.GetAsync(a => a.Id == articleId, a=>a.Questions);
            if (article != null)
            {
                return new DataResult<Article>(ResultStatus.Success, article);
            }
            return new DataResult<Article>(ResultStatus.Error, "Böyle Bir Belge Bulunamadı!", null);
        }

        // GET ALL ARTICLES
        public async Task<IDataResult<IList<Article>>> GetAll()
        {
            var articleList = await _unitOfWork.Articles.GetAllAsync(null, a=>a.Questions);
            if (articleList.Count>-1)
            {
                return new DataResult<IList<Article>>(ResultStatus.Success, articleList);
            }
            return new DataResult<IList<Article>>(ResultStatus.Error, "Bir Hata Oluştu!", null);
        }

        // GET ALL ARTICLES WHICH DELETED
        public async Task<IDataResult<IList<Article>>> GetAllByNonDeleted()
        {
            var articleList = await _unitOfWork.Articles.GetAllAsync(null, a=>a.Questions ,a => a.IsDeleted == false);
            if (articleList.Count>-1)
            {
                return new DataResult<IList<Article>>(ResultStatus.Success, articleList);
            }
            return new DataResult<IList<Article>>(ResultStatus.Error, "Bir Hata Oluştu!", articleList);
        }

        // DELETE ARTICLE FROM DATABASE
        public async Task<IResult> HardDelete(int articleId)
        {
            
            var articleToHardDelete = await _unitOfWork.Articles.GetAsync(a => a.Id == articleId);
            if (articleToHardDelete !=null)
            {
                await _unitOfWork.Articles.DeleteAsync(articleToHardDelete);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{articleToHardDelete.Title} Başarıyla Veritabanından Silindi!");
            }
            return new Result(ResultStatus.Error, "Bir Hata Oluştu!");
        }

        //UPDATE ARTICLE
        public async Task<IResult> Update(ArticleUpdateDto articleUpdateDto, string modifiedByName)
        {
            var articleUpdate = await _unitOfWork.Articles.GetAsync(a => a.Id == articleUpdateDto.ArticleId);
            if (articleUpdate !=null)
            {
                articleUpdate.Title = articleUpdateDto.Title;
                articleUpdate.Content = articleUpdateDto.Content;
                articleUpdate.IsActive = articleUpdateDto.IsActive;
                articleUpdate.IsDeleted = articleUpdateDto.IsDeleted;
                articleUpdate.Note = articleUpdateDto.Note;
                articleUpdate.ModifiedByName = modifiedByName;
                articleUpdate.ModifiedDate = DateTime.Now;
                await _unitOfWork.Articles.UpdateAsync(articleUpdate);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{articleUpdateDto.Title} Başarıyla Güncellendi!");
            }
            return new Result(ResultStatus.Error, "Bir Hata Oluştu!");
        }
    }
}
