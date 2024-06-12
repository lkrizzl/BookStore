using BookStore.Application.Services;
using BookStore.Domain.Models;
using BookStore.WebApi.Cintracts;
using BookStore.WebApi.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebApi.Controllers;

    [ApiController]
    [Route("[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBooksService _booksService;

    public BooksController(IBooksService booksService)
    {
        _booksService = booksService;
    }

    [HttpGet]

    public async Task<ActionResult<List<BooksResponse>>> GetBooks()
    {
        var books = await _booksService.GetAllBooksAsync();

        var response = books.Select(b => new BooksResponse(b.Id, b.Title, b.Description, b.Price));

        return Ok(response);
    }

    [HttpPost]

    public async Task<ActionResult<Guid>> CreateBook([FromBody] BooksRequest request)
    {
        var result = await _booksService.CreateBookAsync(request.Title, request.Description, request.Price);

        if (result.IsFailure)
        {
            return BadRequest($"{result.Error}");
        }

        return Ok();
    }

    [HttpPut("{id:guid}")]

    public async Task<ActionResult<Guid>> UpdateBooks(Guid id, [FromBody] BooksRequest request)
    {
        var result = await _booksService.ChangeBookInfoAsync(id, request.Title, request.Description, request.Price);

        if(result.IsFailure)
        {
            return BadRequest($"{result.Error}");
        }

        return Ok();
    }

    [HttpDelete("{id:guid}")]

    public async Task<ActionResult<Guid>> DeleteBook(Guid id)
    {
        var result = await _booksService.DeleteBookAsync(id);

        if (result.IsFailure)
        {
            return BadRequest($"{result.Error}");
        }

        return NoContent();
    }
}
