using System.ComponentModel.DataAnnotations;

namespace LMS.WebAPI.DTOs
{
    public class ChapterDto
    {
        [Required]
        public int ChapterTitalId { get; set; }
        [Required]
        public string ChapterTital { get; set; }

        public string ChapterRating { get; set; }
    }
}