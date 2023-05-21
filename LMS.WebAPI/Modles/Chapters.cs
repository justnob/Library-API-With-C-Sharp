namespace LMS.WebAPI.Modles
{
    public class Chapters
    {
        public int ChapterTitalId { get; set; }

        public string ChapterTital { get; set; }

        public string ChapterRating { get; set; }
        // Link To connect the book and chapters.
        public Book Book { get; set; }
        
    }
}