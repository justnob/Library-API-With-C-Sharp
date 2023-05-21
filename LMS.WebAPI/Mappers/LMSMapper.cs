using AutoMapper;
using LMS.WebAPI.DTOs;
using LMS.WebAPI.Modles;

namespace LMS.WebAPI.Mappers
{
    public class LMSMapper : Profile
    {
        public LMSMapper()
        {
            CreateMap<BookDto, Book>().ReverseMap();

            CreateMap<ChapterDto, Chapters>().ReverseMap();
        }
    }
}