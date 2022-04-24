using System;
using Maypaper.Data.UnitOfWork.Abstract;
using Maypaper.Services.Abstract;

namespace Maypaper.Services.Concrete
{
    public class QuestionManager:IQuestionService
    {
        private readonly IUnitOfWork _unitOfWork;
        public QuestionManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
