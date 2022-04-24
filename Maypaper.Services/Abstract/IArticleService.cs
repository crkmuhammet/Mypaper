using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Maypaper.Entities.Concrete;
using Maypaper.Entities.Dto;
using Maypaper.Shared.Utilities.Results.Abstract;

namespace Maypaper.Services.Abstract
{
    public interface IArticleService
    {
        Task<IDataResult<Article>> Get(int articleId);
        Task<IDataResult<IList<Article>>> GetAll();
        Task<IDataResult<IList<Article>>> GetAllByNonDeleted();

        Task<IResult> Add(ArticleAddDto articleAddDto, string createdByName);
        Task<IResult> Update(ArticleUpdateDto articleUpdateDto, string modifiedByName);
        Task<IResult> Delete(int articleId, string modifiedByName);
        Task<IResult> HardDelete(int articleId);
    }
}
