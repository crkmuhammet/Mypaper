using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Maypaper.Entities.Dto
{
    public class ArticleAddDto
    {

        [DisplayName("Belge Başlığı")]
        [Required(ErrorMessage = "{0} Boş Geçilemez")]
        [MaxLength(250, ErrorMessage = "{0} {1} Karakterden Büyük Olamaz!")]
        [MinLength(3, ErrorMessage = "{0} {1} Karakterden Küçük Olamaz!")]
        public string Title { get; set; }
        [DisplayName("Belge İçeriği")]
        [Required(ErrorMessage = "{0} Boş Geçilemez")]
        [MaxLength(250, ErrorMessage = "{0} {1} Karakterden Büyük Olamaz!")]
        [MinLength(3, ErrorMessage = "{0} {1} Karakterden Küçük Olamaz!")]
        public string Content { get; set; }

        [DisplayName("Belge Notu")]
        public string Note { get; set; }

        [DisplayName("Aktif Mi?")]
        [Required(ErrorMessage = "{0} Boş Geçilemez!")]
        public bool IsActive { get; set; }
    }
}
