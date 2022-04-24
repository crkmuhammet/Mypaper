using System;
using Maypaper.Shared.Utilities.Results.ComplexTypes;

namespace Maypaper.Shared.Utilities.Results.Abstract
{
    public interface IResult
    {
        // Servis katmanında yaptığımız işlemlerde başarılı mı başarısız mı olduğuna dair
        // Front-end katmanını bilgilendirmek için kullanacağız.
        // Örnek kayıt eklenirken hata oluştu ya da xx başarıyla eklendi ya da silindi.
        // Shared içinde kullanıyoruz ki ihtiyacımız olan her yerde kullanabilelim.

        // Kullanıcılara sonuç döneceğiz
        public ResultStatus ResultStatus { get;} // ResultStatus.Success
        public string Message { get;}
        public Exception Exception { get;}
    }
}
