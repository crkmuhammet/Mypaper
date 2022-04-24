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



        public Task<IResult> Add(ArticleAddDto articleAddDto, string createdByName)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Delete(int articleId, string modifiedByName)
        {
            throw new NotImplementedException();
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

        // GET ALL ARTICLES NON DELETED
        public async Task<IDataResult<IList<Article>>> GetAllByNonDeleted()
        {
            var articleList = await _unitOfWork.Articles.GetAllAsync(null, a=>a.Questions ,a => a.IsDeleted == false);
            if (articleList.Count>-1)
            {
                return new DataResult<IList<Article>>(ResultStatus.Success, articleList);
            }
            return new DataResult<IList<Article>>(ResultStatus.Error, "Bir Hata Oluştu!", articleList);
        }

        public Task<IResult> HardDelete(int articleId)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Update(ArticleUpdateDto articleUpdateDto, string modifiedByName)
        {
            throw new NotImplementedException();
        }
    }
}
