using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Maypaper.Entities.Dto
{
    public class QuestionUpdateDto
    {
        [Required]
        public int QuestionId { get; set; }

        [DisplayName("Soru Başlığı")]
        [Required(ErrorMessage = "{0} Boş Geçilemez")]
        [MaxLength(250, ErrorMessage = "{0} {1} Karakterden Büyük Olamaz!")]
        [MinLength(3, ErrorMessage = "{0} {1} Karakterden Küçük Olamaz!")]
        public string Title { get; set; }
        [DisplayName("Soru İçeriği")]
        [Required(ErrorMessage = "{0} Boş Geçilemez")]
        [MaxLength(250, ErrorMessage = "{0} {1} Karakterden Büyük Olamaz!")]
        [MinLength(3, ErrorMessage = "{0} {1} Karakterden Küçük Olamaz!")]
        public string Content { get; set; }

        [DisplayName("Soru Notu")]
        public string Note { get; set; }

        [DisplayName("Aktif Mi?")]
        [Required(ErrorMessage = "{0} Boş Geçilemez!")]
        public bool IsActive { get; set; }
        [DisplayName("Silindi Mi?")]
        [Required(ErrorMessage = "{0} Boş Geçilemez!")]
        public bool IsDeleted { get; set; }
    }
}
