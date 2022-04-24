using System;
using Maypaper.Shared.Utilities.Results.Abstract;
using Maypaper.Shared.Utilities.Results.ComplexTypes;

namespace Maypaper.Shared.Utilities.Results.Concrete
{
    public class DataResult<T> : IDataResult<T>
    {
        // İhtiyacımıza göre verilerin durumunu bu sınıf ile taşıyabiliriz.
        // x Kategorisi Eklendi!
        // x Kategorisi Eklenirken Hata Oluştu!
        public T Data { get; }

        public ResultStatus ResultStatus { get; }

        public string Message { get; }

        public Exception Exception { get; }

        // Her zaman için bir ResultStatus dönmemize gerek var.
        public DataResult(ResultStatus _resultStatus, T _data)
        {
            ResultStatus = _resultStatus;
            Data = _data;
        }
        public DataResult(ResultStatus _resultStatus,string _message, T _data)
        {
            ResultStatus = _resultStatus;
            Data = _data;
            Message = _message;
        }
        public DataResult(ResultStatus _resultStatus, string _message, T _data, Exception _exception)
        {
            ResultStatus = _resultStatus;
            Data = _data;
            Message = _message;
            Exception = _exception;
        }
    }
}
