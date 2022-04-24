using System;
namespace Maypaper.Entities.Dto
{
    public class QuestionAddDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsActive { get; set; }
    }
}
