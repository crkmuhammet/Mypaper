using System;
using System.Collections.Generic;
using Maypaper.Shared.Entities.Abstract;

namespace Maypaper.Entities.Concrete
{
    public class Article : EntityBase, IEntity
    {
        //  Belgelerin Adı
        public string Title { get; set; }
        //  Belgenin İçeriği
        public string Content { get; set; }
        public DateTime Date { get; set; }
        // Kaç kere görüntülendi
        public int ViewsCount { get; set; }
        // Kaç kere indirildi?
        public int DownloadsCount { get; set; }


        //  SEO Etiketleri
        public string SeoAuthor { get; set; }
        public string SeoDescription { get; set; }
        public string SeoTags { get; set; }

        // Mapping 
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        // Bu makaleye ait sorular
        public ICollection<Question> Questions { get; set; }
    }
}
