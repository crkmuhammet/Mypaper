using System;
using Maypaper.Shared.Entities.Abstract;

namespace Maypaper.Entities.Concrete
{
    public class Question : EntityBase, IEntity
    {
        // Sorunun Başlığı
        public string Title { get; set; }
        // Sorunun Metni
        public string Content { get; set; }
        // Maplemek için kullancağımız soruya ait döküman
        public int ArticleId { get; set; }
        public Article Article { get; set; }
    }
}
