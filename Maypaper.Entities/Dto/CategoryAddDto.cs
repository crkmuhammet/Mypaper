using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Maypaper.Entities.Dto
{
    public class CategoryAddDto
    {
        [DisplayName("Kategori Adı")]
        [Required(ErrorMessage ="{0} Boş Geçilemez")]
        [MaxLength(250,ErrorMessage ="{0} {1} Karakterden Büyük Olamaz!")]
        [MinLength(3,ErrorMessage ="{0} {1} Karakterden Küçük Olamaz!")]
        public string Name { get; set; }

        [DisplayName("Kategori Açıklaması")]
        [Required(ErrorMessage = "{0} Boş Geçilemez")]
        [MaxLength(250, ErrorMessage = "{0} {1} Karakterden Büyük Olamaz!")]
        [MinLength(3, ErrorMessage = "{0} {1} Karakterden Küçük Olamaz!")]
        public string Description { get; set; }

        [DisplayName("Kategori Notu")]
        public string Note { get; set; }

        [DisplayName("Aktif Mi?")]
        [Required(ErrorMessage ="{0} Boş Geçilemez!")]
        public bool IsActive { get; set; }
    }
}
