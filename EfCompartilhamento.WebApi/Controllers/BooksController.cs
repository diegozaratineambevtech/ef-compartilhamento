using EfCompartilhamento.Domain.Repositories;
using EfCompartilhamento.WebApi.Dtos;
using EfCompartilhamento.WebApi.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace EfCompartilhamento.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;

        public BooksController(IBookRepository bookRepository, IAuthorRepository authorRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
        }

        // GET: api/<BooksController>
        [HttpGet]
        public ActionResult<IEnumerable<BookDto>> Get()
        {
            var books = _bookRepository.GetAll();
            var bookDtos = books.Select(book => BookMapper.MapToDto(book));
            return Ok(bookDtos);
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public ActionResult<BookDto> Get(int id)
        {
            if (!BookExist(id))
            {
                return NotFound("Book does not exists");
            }
            var book = _bookRepository.GetById(id);
            return Ok(BookMapper.MapToDto(book!));
        }

        // POST api/<BooksController>
        [HttpPost]
        public ActionResult Post([FromBody] BookDto bookDto)
        {
            var book = BookMapper.MapToEntity(bookDto);
            _bookRepository.Insert(book);
            _bookRepository.Save();
            return Ok();
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] BookDto bookDto)
        {
            if (!BookExist(id))
            {
                return NotFound("Book does not exists");
            }
            var book = BookMapper.MapToEntity(bookDto, id);
            _bookRepository.Update(book);
            _bookRepository.Save();
            return Ok();
        }

        // PATCH api/<BooksController>/5
        [HttpPatch("{id}")]
        public ActionResult AddAuthor(int id, int authorId)
        {
            var author = _authorRepository.GetById(authorId);
            if (author is null)
            {
                return NotFound("Author does not exists");
            }
            var book = _bookRepository.GetById(id);
            if (book is null)
            {
                return NotFound("Book does not exists");
            }
            //adicionar autor a um livro, o que acontece se adicionar um autor que já está no livro?
            //como evitar o erro?
            book.Authors.Add(author);
            _bookRepository.Update(book);
            _bookRepository.Save();
            return Ok();
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (!BookExist(id))
            {
                return NotFound("Book does not exists");
            }
            _bookRepository.Delete(id);
            _bookRepository.Save();
            return Ok();
        }

        private bool BookExist(int id)
        {
            return _bookRepository.GetById(id, shouldTrackEntity: false) is not null;
        }
    }
}