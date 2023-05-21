using LMS.WebAPI.DTOs;
using LMS.WebAPI.Modles;

namespace LMS.WebAPI.DataRepository
{
    public interface ILMSRepository
    {
         IEnumerable<Book> GetAllCourses();

         Task<IEnumerable<Book>> GetAllCoursesAsync();
         
         Book AddBook(Book newBook);

         bool IsBookExists(int bookId);

         Book GetBook(int bookId);

         Book UpdateBook(int bookId, Book newBook);

         Book DeleteBook(int bookId);


         // Association

         IEnumerable<Chapters> GetChapters(int bookId);

         // Creating the Chapters and connecting to the course class.
        Chapters AddChapters( Chapters chapters);
    }
}