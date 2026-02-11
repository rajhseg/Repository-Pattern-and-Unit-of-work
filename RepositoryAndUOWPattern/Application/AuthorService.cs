using Domain;
using Domain.Interfaces;

namespace Application
{
    internal class AuthorService : IAuthorService
    {
        private readonly IRepository<Authors> repository;

        public AuthorService(IRepository<Authors> repository)
        {
            this.repository = repository;
        }

        public  async Task<AuthorModel> UpateAuthor(AuthorModel model)
        {
            if (model == null) 
                throw new ArgumentNullException("model");

            var author = await this.repository.GetById(model.Id);

            if (author == null)
                throw new InvalidOperationException();

            author.Name = model.Name;
            author.PhotoName = model.PhotoName;
            author.PhotoContent = model.PhotoContent;

            var updatedAuthor = await this.repository.Update(author);

            return new AuthorModel
            {
                PhotoName = updatedAuthor.PhotoName,
                PhotoContent = updatedAuthor.PhotoContent,
                Name = updatedAuthor.Name,
                Id = updatedAuthor.Id
            };
        }
    }
}
