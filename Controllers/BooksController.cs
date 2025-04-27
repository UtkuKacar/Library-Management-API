using LibraryManagementAPI.Data;      // <<< DbContext’i içe aktarır
using LibraryManagementAPI.Models;    // <<< Author/Book sınıflarını içe aktarır
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly LibraryContext _context;
    public BooksController(LibraryContext context) => _context = context;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var books = await _context.Books
            .Include(b => b.Author)
            .ToListAsync();
        return Ok(books);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var book = await _context.Books
            .Include(b => b.Author)
            .FirstOrDefaultAsync(b => b.Id == id);
        if (book == null) return NotFound();
        return Ok(book);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Book book)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        _context.Books.Add(book);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Book updated)
    {
        if (id != updated.Id) return BadRequest();
        if (!ModelState.IsValid) return BadRequest(ModelState);

        _context.Entry(updated).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book == null) return NotFound();

        _context.Books.Remove(book);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
