using System;
using System.Collections.Generic;
using Maypaper.Shared.Entities.Abstract;

namespace Maypaper.Entities.Concrete
{
    public class Category:EntityBase,IEntity
    {
        //  Kategorinin Adı
        public string Name { get; set; }

        //  Kategorinin Açıklaması
        public string Description { get; set; }

        //  Kategori içinde bulunan belgeler
        public ICollection<Article> Articles { get; set; } 
    }
}
