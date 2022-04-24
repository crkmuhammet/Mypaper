using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Maypaper.Entities.Concrete;
using Maypaper.Entities.Dto;
using Maypaper.Shared.Utilities.Results.Abstract;

namespace Maypaper.Services.Abstract
{
    public interface IQuestionService
    {
        Task<IDataResult<Question>> Get(int questionId);
        Task<IDataResult<IList<Question>>> GetAll();
        Task<IDataResult<IList<Question>>> GetAllByNonDeleted();

        Task<IResult> Add(QuestionAddDto questionAddDto, string createdByName);
        Task<IResult> Update(QuestionUpdateDto questionUpdateDto, string modifiedByName);
        Task<IResult> Delete(int questionId, string modifiedByName);
        Task<IResult> HardDelete(int questionId);
    }
}
