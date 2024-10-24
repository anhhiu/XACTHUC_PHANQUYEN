using BAI_1.Data;
using BAI_1.Models;

namespace BAI_1.Repository
{
    public interface IbookRes
    {
        public Task<List<BookModel>> GetAllBook();
        public Task<BookModel> GetBookById(int id);
        public Task<int> AddBook(BookModel model);
        public Task<Book> UpdateBook(int id, BookModel model);
        public Task<Book> DeleteBook(int id);
    }
}
