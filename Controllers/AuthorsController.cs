using LibraryManagementAPI.Data;
using LibraryManagementAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


[ApiController]
[Route("api/[controller]")]
public class AuthorsController : ControllerBase
{
    private readonly LibraryContext _context;
    public AuthorsController(LibraryContext context) => _context = context;

    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok(await _context.Authors.ToListAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var author = await _context.Authors.FindAsync(id);
        if (author == null) return NotFound();
        return Ok(author);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Author author)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        _context.Authors.Add(author);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = author.Id }, author);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Author updated)
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
        var author = await _context.Authors
            .Include(a => a.Books)
            .FirstOrDefaultAsync(a => a.Id == id);

        if (author == null) return NotFound();
        if (author.Books.Any())
            return BadRequest("Bu yazarın silinemez; ilişkili kitapları var.");

        _context.Authors.Remove(author);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
