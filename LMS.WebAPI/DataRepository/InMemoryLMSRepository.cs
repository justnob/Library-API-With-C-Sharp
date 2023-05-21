using LMS.WebAPI.Modles;

namespace LMS.WebAPI.DataRepository
{
    public class InMemoryLMSRepository : ILMSRepository
    {
        // Generating the new object for book class
        List<Book>? book = null;

        // Generating the new object for chapters class
         List<Chapters>? chapters = null;
        public InMemoryLMSRepository()
        {
            book = new List<Book>();
            book.Add(
                new Book()
                {
                    BookId = 1,
                    BookName = "Harry Poter And The Sorcerer's Stone",
                    BookAuthor = "J.K.Rowling",
                    BookShelfNumber = "H-33",
                    BookNumber = 33,
                    BookType = BOOK_TYPE.FANTASY
                }
            );

            book.Add(
                new Book()
                {
                    BookId = 2,
                    BookName = "YOU: Hidden Bodies",
                    BookAuthor = "Caroline Kepnes",
                    BookShelfNumber = "Y-20",
                    BookNumber = 108,
                    BookType = BOOK_TYPE.THRILLER
                }
            );

            chapters = new List<Chapters>();
            chapters.Add(
                new Chapters()
                {
                    ChapterTitalId = 1,
                    ChapterTital = "The boy who lived",
                    ChapterRating = "4/5",
                    // Linking with a perticular Book.
                    Book = book.Where(x => x.BookId == 1).SingleOrDefault()
                }
            );

            chapters.Add(
                new Chapters()
                {
                    ChapterTitalId = 1,
                    ChapterTital = "Have a nice day,Beck",
                    ChapterRating = "4/5",
                    // Linking with a perticular Book.
                    Book = book.Where(x => x.BookId == 2).SingleOrDefault()
                }
            );

        }



        public IEnumerable<Book> GetAllCourses()
        {
            return book;
        }

        public Book AddBook(Book newBook)
        {
            var maxBookId = book.Max(c => c.BookId);
            newBook.BookId = maxBookId + 1;
            book.Add(newBook);

            return newBook;
        }

        public bool IsBookExists(int bookId)
        {
            return book.Any(x => x.BookId == bookId);
        }

        public Book GetBook(int bookId)
        {
            var result = book.Where(x => x.BookId == bookId).SingleOrDefault();
            return result;
        }

        public Book UpdateBook(int bookId, Book updatedBook)
        {
            var bookup = book.Where(x => x.BookId == bookId).SingleOrDefault();
            if(book != null)
            {
                bookup.BookName = updatedBook.BookName;
                bookup.BookAuthor = updatedBook.BookAuthor;
                bookup.BookNumber = updatedBook.BookNumber;
                bookup.BookShelfNumber = updatedBook.BookShelfNumber;
                bookup.BookType = updatedBook.BookType;
            }

            return bookup;
        }

        public Book DeleteBook(int bookId)
        {
            var result = book.Where(x => x.BookId == bookId).SingleOrDefault();

            if(result != null)
            {
                book.Remove(result);
            }

            return result;
        }

        public async Task<IEnumerable<Book>> GetAllCoursesAsync()
        {
            return await Task.Run(() => book.ToList());
        }

        public IEnumerable<Chapters> GetChapters(int bookId)
        {
            return chapters.Where(s => s.Book.BookId == bookId);
        }

        public Chapters AddChapters(Chapters newChapters)
        {
            var maxChapterTitalId = chapters.Max(c => c.ChapterTitalId);
            newChapters.ChapterTitalId = maxChapterTitalId + 1;
            chapters.Add(newChapters);

            return newChapters;
        }

    }
}