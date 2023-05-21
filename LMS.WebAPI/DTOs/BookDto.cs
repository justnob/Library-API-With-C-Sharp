using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using LMS.WebAPI.Modles;

namespace LMS.WebAPI.DTOs
{
    public class BookDto
    {
        public int BookId { get; set; }

        [Required]//so that it is required and can be null or empty
        [MaxLength(50)]// for max lengh can't be more
        public string? BookName { get; set; }

        [Required]
        public string? BookAuthor { get; set; }

        public string? BookShelfNumber { get; set; }
        [Range(0, 1000)]//Seating the range a usr can input
        public int BookNumber { get; set; }

        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public BOOK_TYPE BookType { get; set; }

        
    }
}