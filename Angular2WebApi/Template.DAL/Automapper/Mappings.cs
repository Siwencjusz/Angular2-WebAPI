using System.Threading.Tasks;
using AutoMapper;
using Commons.DTOs;
using Commons.Entities;

namespace Template.DAL.Automapper
{
    public class Mappings : Profile
    {
        public Mappings()
        {

            CreateMap<Task, int>().ConvertUsing(x => x.Id);

            CreateMap<Author, AuthorDto>().ReverseMap();
            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<BookType, BookTypeDto>().ReverseMap();
            CreateMap<PublishingHouse, PublishingHouseDto>().ReverseMap();
        }
    }
}
