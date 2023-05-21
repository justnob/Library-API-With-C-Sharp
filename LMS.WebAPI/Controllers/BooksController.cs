using AutoMapper;
using LMS.WebAPI.DataRepository;
using LMS.WebAPI.DTOs;
using LMS.WebAPI.Modles;
using Microsoft.AspNetCore.Mvc;

namespace LMS.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly ILMSRepository lMSRepository;
        private readonly IMapper mapper;

        //dependency injection
        public BooksController(ILMSRepository lMSRepository, IMapper mapper)
        {
            this.lMSRepository = lMSRepository;
            this.mapper = mapper;
        }
        // Direct connect to database 
        // [HttpGet]
        // //IEnumerable for list out array
        // public IEnumerable<Book> GetBooks()
        // {
        //     //return "Hello world";
        //     return lMSRepository.GetAllCourses();
        // }

        //[HttpGet]
        //IEnumerable for list out array
        // public IEnumerable<BookDto> GetBooks()
        // {
        //     //return "Hello world";
        //     try
        //     {
        //         IEnumerable<Book> books = lMSRepository.GetAllCourses();
        //         var result = MapBookToBookDto(books);
        //         return result;

        //     }
        //     catch (System.Exception)
        //     {
                
        //         throw;
        //     }
        // }
        
        // [HttpGet]
        // //IEnumerable for list out array
        // //IActionResult Example
        // public IActionResult GetBooks()
        // {
        //     //return "Hello world";
        //     try
        //     {
        //         IEnumerable<Book> books = lMSRepository.GetAllCourses();
        //         var result = MapBookToBookDto(books);
        //         return Ok(result);

        //     }
        //     catch (System.Exception ex)
        //     {
                
        //         return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        //     }
        // }

        //  [HttpGet]
        // //IEnumerable for list out array
        // //ActionResult<T> Example
        // public ActionResult<IEnumerable<BookDto>> GetBooks()
        // {
        //     //return "Hello world";
        //     try
        //     {
        //         IEnumerable<Book> books = lMSRepository.GetAllCourses();
        //         var result = MapBookToBookDto(books);
        //         return result.ToList();

        //     }
        //     catch (System.Exception ex)
        //     {
                
        //         return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        //     }
        // }

        // [HttpGet]
        // //IEnumerable for list out array
        // //Async Example
        // public async Task<ActionResult<IEnumerable<BookDto>>> GetBooksAsync()
        // {
        //     //return "Hello world";
        //     try
        //     {
        //         IEnumerable<Book> books = await lMSRepository.GetAllCoursesAsync();
        //         var result = MapBookToBookDto(books);
        //         return result.ToList();

        //     }
        //     catch (System.Exception ex)
        //     {
                
        //         return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        //     }
        // }

        [HttpGet]
        //IEnumerable for list out array
        //Async Example
        //With AutoMapper
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooksAsync()
        {
            //return "Hello world";
            try
            {
                IEnumerable<Book> books = await lMSRepository.GetAllCoursesAsync();
                //var result = MapBookToBookDto(books);
                var result = mapper.Map<BookDto[]>(books);
                return result.ToList();

            }
            catch (System.Exception ex)
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public  ActionResult<BookDto> AddBook([FromBody]BookDto books)
        {
            try
            {
                //done by API controller Atribute
                // if(!ModelState.IsValid)
                // {
                //     return BadRequest(ModelState);
                // }


                var newBook = mapper.Map<Book>(books);
                newBook = lMSRepository.AddBook(newBook);
                return  mapper.Map<BookDto>(newBook);
            }
            catch (System.Exception ex)
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{bookId}")]
        public ActionResult<BookDto> GetBook(int bookId)
        {
            try
            {
                if (!lMSRepository.IsBookExists(bookId))
                {
                    return NotFound("The book you are trying to find does not exixt!");
                }

                Book book = lMSRepository.GetBook(bookId);
                var result = mapper.Map<BookDto>(book);
                return result;
            }
            catch (System.Exception ex)
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{bookId}")]
        public ActionResult<BookDto> UpdateBook(int bookId, BookDto book)
        {
            try
            {

                if (!lMSRepository.IsBookExists(bookId))
                {
                    return NotFound("The book you are trying to find and update does not exixt!");
                }

                Book updatedBook = mapper.Map<Book>(book);
                updatedBook = lMSRepository.UpdateBook(bookId, updatedBook);
                var result = mapper.Map<BookDto>(updatedBook);
                return result; 

            }
            catch (System.Exception ex)
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{bookId}")]
        public ActionResult<BookDto> DeleteBook(int bookId)
        {
            try
            {

                if (!lMSRepository.IsBookExists(bookId))
                {
                    return NotFound("The book you are trying to find and delete does not exixt!");
                }

                Book book = lMSRepository.DeleteBook(bookId);
                if(book == null)
                {
                    return BadRequest("You have made a bad request");
                }

                var result = mapper.Map<BookDto>(book);


                
                return result;

                
            }
            catch (System.Exception ex)
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // Get Through ../book/1/chapters
        [HttpGet("{bookId}/chapters")]
        public ActionResult<IEnumerable<ChapterDto>> GetChapters(int bookId)
        {
            try
            {
                if (!lMSRepository.IsBookExists(bookId))
                {
                    return NotFound("The chapter you are trying to find does not exixt!");
                }

                IEnumerable<Chapters> chapters = lMSRepository.GetChapters(bookId);
                var result = mapper.Map<ChapterDto[]>(chapters);
                return result;
            }
            catch (System.Exception ex)
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

         [HttpPost("{bookId}/chapters")]
        public  ActionResult<ChapterDto> AddChapters(int bookId, ChapterDto chapters)
        {
            try
            {
                //done by API controller Atribute
                // if(!ModelState.IsValid)
                // {
                //     return BadRequest(ModelState);
                // }
                if (!lMSRepository.IsBookExists(bookId))
                {
                    return NotFound("The chapter you are trying to find does not exixt!");
                }


                Chapters newChapters = mapper.Map<Chapters>(chapters);
                // Assign book
                Book book = lMSRepository.GetBook(bookId);
                newChapters.Book = book;

                newChapters = lMSRepository.AddChapters(newChapters);
                var result = mapper.Map<ChapterDto>(newChapters);
                return StatusCode(StatusCodes.Status201Created, result);
            }
            catch (System.Exception ex)
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        //custom mapper functions
        // private BookDto MapBookToBookDto(Book book)
        // {
        //     return new BookDto()
        //     {
        //         BookId = book.BookId,
        //         BookName = book.BookName,
        //         BookAuthor = book.BookAuthor,
        //         BookType = book.BookType,
        //         BookShelfNumber = book.BookShelfNumber,
        //         BookNumber = book.BookNumber

        //     };
        // }

        // //making a dto based return result(Business layer)
        // private IEnumerable<BookDto> MapBookToBookDto(IEnumerable<Book> books)
        // {
        //     IEnumerable<BookDto> result;
        //     result = books.Select(b => new BookDto()
        //     {
        //         BookId = b.BookId,
        //         BookName = b.BookName,
        //         BookAuthor = b.BookAuthor,
        //         BookType = b.BookType,
        //         BookShelfNumber = b.BookShelfNumber,
        //         BookNumber = b.BookNumber
        //     });
        //     return result;
        // }
    }
}