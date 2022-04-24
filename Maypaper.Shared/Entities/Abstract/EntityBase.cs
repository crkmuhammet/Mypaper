using System;
namespace Maypaper.Shared.Entities.Abstract
{
    public abstract class EntityBase
    {
        // Abstract: Temel değerlerin diğer sınıflarda değişikliğe uğramasını isteyebiliriz.
        //  Bu nedenle bu sınıf abstract olarak tanımlanmıştır.
        //  Değişikliğe uğratmak istediğimizde ise override ile çağırıyoruz.
        public virtual int Id { get; set; }
        public virtual DateTime CreatedDate { get; set; } = DateTime.Now;
        public virtual DateTime ModifiedDate { get; set; } = DateTime.Now;
        public virtual bool IsDeleted { get; set; } = false;
        public virtual bool IsActive { get; set; } = true;
        public virtual string CreatedByName { get; set; } = "Admin";
        public virtual string ModifiedByName { get; set; } = "Admin";
        public virtual string Note { get; set; }
    }
}
