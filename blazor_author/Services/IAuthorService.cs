using blazor_author.Models;

namespace blazor_author.Services
{
    public interface IAuthorService
    {
        Task<List<Author>> GetAllAuthor();
        Task<Author> GetAuthorById(int id);
    }
}