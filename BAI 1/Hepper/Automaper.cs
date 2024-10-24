using AutoMapper;
using BAI_1.Data;
using BAI_1.Models;

namespace BAI_1.Hepper
{
    public class Automaper : Profile
    {
        public Automaper()
        {
            CreateMap<Book, BookModel>().ReverseMap();
        }
    }
}
