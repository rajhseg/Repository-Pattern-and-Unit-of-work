namespace Application
{
    public interface IAuthorService
    {
        Task<AuthorModel> UpateAuthor(AuthorModel model);
    }
}
