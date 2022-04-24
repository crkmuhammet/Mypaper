using System;
namespace Maypaper.Shared.Utilities.Results.Abstract
{
    public interface IDataResult<out T>:IResult
    {
        // Örnek olarak kategoriyi tek başına da taşımak isteyebilirim.
        // Kategoriyi bir liste olarak taşımak da isteyebilirim.
        // Bu nedenle out T olarak işaretledik.

        T Data { get; }
        // İstersek bir kategori, istersek bir kategori listesi atayabiliyor olacağız.
        // new DataResult<Category>(ResultStatus.Success, category);
        // new DataResult<IList<Category>>(ResultStatus.Success, categoryList);

    }
}
