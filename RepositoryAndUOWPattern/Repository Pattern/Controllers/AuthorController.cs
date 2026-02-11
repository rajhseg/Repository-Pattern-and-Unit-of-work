using Application;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace RepositoryAndUOWPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IUnitOfWork uow;
        private readonly IAuthorService authorService;

        public AuthorController(IAuthorService service, IUnitOfWork unitOfWork)
        {
            this.uow = unitOfWork;
            this.authorService = service;   
        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult> UpdateAuthor(AuthorModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            using (var trans = await this.uow.BeginTransactionAsync())
            {
                try
                {
                    var author = await this.authorService.UpateAuthor(model);
                    await this.uow.CommitTransactionAsync(trans);
                    return Ok(author);
                }
                catch (Exception ex)
                {
                    await this.uow.RollbackTransactionAsync(trans);
                    return StatusCode(500);
                }
            }
        }
    }
}
