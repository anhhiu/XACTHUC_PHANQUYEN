using AutoMapper;
using BAI_1.Data;
using BAI_1.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BAI_1.Repository
{
    public class BookRes : IbookRes
    {
        private readonly MybookDbcontext context;
        private readonly IMapper mapper;

        public BookRes(MybookDbcontext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<int> AddBook(BookModel model)
        {
            var newbook  = mapper.Map<Book>(model);

            await context.Books.AddAsync(newbook);

            await context.SaveChangesAsync();

            return newbook.Id;
            
        }

        public async Task<Book> DeleteBook(int id)
        {
            var book = await context.Books.FirstOrDefaultAsync(x => x.Id == id);
            if (book != null)
            {
                context.Books.Remove(book);
                await context.SaveChangesAsync();
                return book;
            }
            return null!;
           
        }

        public async Task<List<BookModel>> GetAllBook()
        {
                var books = await context.Books.ToListAsync();
                return  mapper.Map<List<BookModel>>(books);
        }

        public async Task<BookModel> GetBookById(int id)
        {
             var book = await context.Books.FindAsync(id);
           
                return mapper.Map<BookModel>(book);
          
        }

        public async Task<Book> UpdateBook(int id, BookModel model)
        {
            if (id == model.Id)
            {
                var updatebook =mapper.Map<Book>(model);
                context.Books.Update(updatebook);
                await context.SaveChangesAsync();
                return updatebook;
            }
            return null!;

          
        }
    }
}
