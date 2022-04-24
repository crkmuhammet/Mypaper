using System;
using Maypaper.Shared.Utilities.Results.Abstract;
using Maypaper.Shared.Utilities.Results.ComplexTypes;

namespace Maypaper.Shared.Utilities.Results.Concrete
{
    public class Result : IResult
    {
        // Bu sınıfta sadece sonuçları dönebiliyoruz. Ancak tipleri taşıyamıyoruz. Veriyi getirmek istediğimiz zaman taşıyamıyoruz.
        // Örneğin : Kategoriler getirilirken hata oluştu vs.


        public ResultStatus ResultStatus { get; }

        public string Message { get; }

        public Exception Exception { get; }

        // Sadece Status Döner
        public Result(ResultStatus _resultStatus)
        {
            ResultStatus = _resultStatus;
        }
        // Sadece Status ve Message Döner
        public Result(ResultStatus _resultStatus, string _message)
        {
            ResultStatus = _resultStatus;
            Message = _message;
        }
        // Status, Message ve Exception'ı döner.
        public Result(ResultStatus _resultStatus, string _message, Exception _exception)
        {
            ResultStatus = _resultStatus;
            Message = _message;
            Exception = _exception;
        }
    }
}
