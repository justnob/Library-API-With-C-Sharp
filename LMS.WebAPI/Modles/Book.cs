namespace LMS.WebAPI.Modles
{
    public class Book
    {
        public int BookId { get; set; }

        public string? BookName { get; set; }

        public string? BookAuthor { get; set; }

        public string? BookShelfNumber { get; set; }

        public int BookNumber { get; set; }

        public BOOK_TYPE BookType { get; set; }
    }
}