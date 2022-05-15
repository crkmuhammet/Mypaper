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
    public class QuestionManager:IQuestionService
    {
        private readonly IUnitOfWork _unitOfWork;
        public QuestionManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IResult> Add(QuestionAddDto questionAddDto, string createdByName)
        {
            // Kategori oluştururken burada gönderdiğimiz anda yeni bir kategori oluşturmamız gerekiyor.
            // DTO içindeki alanlar ile Category Entity içindeki alanları birbirine eşliyoruz.
            // DTO içinde olmayan alanları ise kendimiz veriyoruz.
            await _unitOfWork.Questions.AddAsync(new Question
            {
                Title = questionAddDto.Title,
                Content = questionAddDto.Content,
                IsActive = questionAddDto.IsActive,
                CreatedByName = createdByName,
                CreatedDate = DateTime.Now,
                ModifiedByName = createdByName,
                ModifiedDate = DateTime.Now,
                IsDeleted=false
            });
            await _unitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, $"{questionAddDto.Title} Başarıyla Oluşturuldu!");
        }

        public async Task<IResult> Delete(int questionId, string modifiedByName)
        {
            //Delete işlemi için öncelikle silmek istediğimiz veriyi getiriyoruz.
            //Bu Fonksiyon için Question
            var question = await _unitOfWork.Questions.GetAsync(q => q.Id == questionId);
            //Gelen değerin boş olup olmadığını kontrol ediyoruz.
            if (question !=null)
            {
                question.IsDeleted = true;
                question.ModifiedByName = modifiedByName;
                question.ModifiedDate = DateTime.Now;

                // Alanları güncelledikten sonra Update işlemi yapmamız gerekiyor.
                await _unitOfWork.Questions.UpdateAsync(question);
                // Update işleminden sonra update edilen datayı kayıt etmemiz gerekiyor.
                await _unitOfWork.SaveAsync();
                // İşlemler başarılıysa bilgi Başarılı mesajı döndüreceğiz.
                return new Result(ResultStatus.Success, $"{question.Content} Başarıyla Silindi!");
            }
            // İşlemler başarısız ise Başarısız mesajı döndüreceğiz.
            else
            {
                return new Result(ResultStatus.Error, "Bir Hata Oluştu!");
            }
        }

        // GET QUESTION
        public async Task<IDataResult<Question>> Get(int questionId)
        {
            var question = await _unitOfWork.Questions.GetAsync(q => q.Id == questionId);
            if (question!=null)
            {
                return new DataResult<Question>(ResultStatus.Success, question);
            }
            return new DataResult<Question>(ResultStatus.Error, "Bir Hata Oluştu!", null);
        }

        // GET ALL QUESTIONS
        public async Task<IDataResult<IList<Question>>> GetAll()
        {
            var questionList = await _unitOfWork.Questions.GetAllAsync();
            if (questionList.Count>-1)
            {
                return new DataResult<IList<Question>>(ResultStatus.Success, questionList);
            }
            return new DataResult<IList<Question>>(ResultStatus.Error, "Bir Hata Oluştu!", null);
        }


        //GET ALL QUESTIONS NON DELETED
        public async Task<IDataResult<IList<Question>>> GetAllByNonDeleted()
        {
            var questionList = await _unitOfWork.Questions.GetAllAsync(null, q => q.IsDeleted == false);
            if (questionList.Count>-1)
            {
                return new DataResult<IList<Question>>(ResultStatus.Success, questionList);
            }
            return new DataResult<IList<Question>>(ResultStatus.Error, "Bir Hata Oluştu!", null);
        }

        public async Task<IResult> HardDelete(int questionId)
        {
            var questionToDelete = await _unitOfWork.Questions.GetAsync(q => q.Id == questionId);
            if (questionToDelete !=null)
            {
                await _unitOfWork.Questions.DeleteAsync(questionToDelete);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{questionToDelete.Title} Başarıyla Veritabanından Silindi!");
            }
            return new Result(ResultStatus.Error, "Bir Hata Oluştu!");
        }

        public async Task<IResult> Update(QuestionUpdateDto questionUpdateDto, string modifiedByName)
        {
            var questionToUpdate = await _unitOfWork.Questions.GetAsync(q => q.Id == questionUpdateDto.QuestionId);
            if (questionToUpdate != null)
            {
                questionToUpdate.Title = questionUpdateDto.Title;
                questionToUpdate.Content = questionUpdateDto.Content;
                questionToUpdate.IsActive = questionUpdateDto.IsActive;
                questionToUpdate.IsDeleted = questionUpdateDto.IsDeleted;
                questionToUpdate.Note = questionUpdateDto.Note;
                questionToUpdate.ModifiedByName = modifiedByName;
                questionToUpdate.ModifiedDate = DateTime.Now;
                await _unitOfWork.Questions.UpdateAsync(questionToUpdate);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{questionUpdateDto.Title} Başarıyla Güncellenmiştir");
            }
            return new Result(ResultStatus.Error, "Bir Hata Oluştu!");
        }
    }
}
