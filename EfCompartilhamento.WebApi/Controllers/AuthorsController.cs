using EfCompartilhamento.Domain.Repositories;
using EfCompartilhamento.WebApi.Dtos;
using EfCompartilhamento.WebApi.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace EfCompartilhamento.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorsController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        // GET: api/<AuthorsController>
        [HttpGet]
        public ActionResult<IEnumerable<AuthorDto>> Get()
        {
            var authors = _authorRepository.GetAll();
            var authorDtos = authors.Select(author => AuthorMapper.MapToDto(author));
            return Ok(authorDtos);
        }

        // GET api/<AuthorsController>/5
        [HttpGet("{id}")]
        public ActionResult<AuthorDto> Get(int id)
        {
            if (!AuthorExists(id))
            {
                return NotFound("Author does not exists");
            }
            var author = _authorRepository.GetById(id);
            return Ok(AuthorMapper.MapToDto(author!));
        }

        // POST api/<AuthorsController>
        [HttpPost]
        public ActionResult Post([FromBody] AuthorDto authordto)
        {
            var author = AuthorMapper.MapToEntity(authordto);
            _authorRepository.Insert(author);
            _authorRepository.Save();
            return Ok();
        }

        // PUT api/<AuthorsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] AuthorDto authorDto)
        {
            if (!AuthorExists(id))
            {
                return NotFound("Author does not exists");
            }
            var author = AuthorMapper.MapToEntity(authorDto, id);
            _authorRepository.Update(author);
            _authorRepository.Save();
            return Ok();
        }

        // DELETE api/<AuthorsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (!AuthorExists(id))
            {
                return NotFound("Author does not exists");
            }
            _authorRepository.Delete(id);
            _authorRepository.Save();
            return Ok();
        }

        //GET api/<AuthorsController>/5/books
        [HttpGet("{id}/books")]
        public ActionResult<IEnumerable<BookDto>> GetBooks(int id)
        {
            if (!AuthorExists(id))
            {
                return NotFound("Author does not exists");
            }
            var author = _authorRepository.GetWithBooks(id);
            var bookDtos = author!.Books.Select(book => BookMapper.MapToDto(book));
            return Ok(bookDtos);
        }

        private bool AuthorExists(int id)
        {
            return _authorRepository.GetById(id, shouldTrackEntity: false) is not null;
        }
    }
}