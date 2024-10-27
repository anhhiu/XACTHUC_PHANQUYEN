using AutoMapper;
using BAI_1.Data;
using BAI_1.Models;
using BAI_1.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BAI_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IbookRes res;

        public BookController(IbookRes res)
        {
            this.res = res;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBook()
        {
            try
            {
                return Ok(await res.GetAllBook());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddNewBook(BookModel model)
        {
            try
            {
                var newbook = await res.AddBook(model);
                var book = await res.GetBookById(newbook);
                return book != null ? Ok(book) : NotFound();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateBook(int id, BookModel model)
        {

            try
            {
                if (id != model.Id)
                {
                    return BadRequest("Mismatched ID"); // Trả về lỗi nếu ID không khớp
                }

                var book = await res.UpdateBook(id, model); // Gọi phương thức trong service

                if (book == null)
                {
                    return NotFound("Book not found or not updated");
                }

                return Ok(book); // Trả về kết quả thành công
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteBook(int id)
        {
             try
                {
                    var book = await res.DeleteBook(id); // Đảm bảo phương thức DeleteBook là bất đồng bộ

                    if (book == null)
                    {
                        return NotFound("Book not found"); // Kiểm tra nếu không tìm thấy book
                    }

                    if (id != book.Id)
                    {
                        return BadRequest("Mismatched ID"); // Trả về lỗi nếu ID không khớp
                    }

                    return Ok("Delete successful"); // Xóa thành công
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
             }
         
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            try
            {
                var book = await res.GetBookById(id);
                if(book != null)
                {
                    return Ok(book);
                }
                return NotFound();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
