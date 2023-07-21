using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Json;
using blazor_author.Models;

namespace blazor_author.Services
{


    public class AuthorService : IAuthorService
    {
        private readonly HttpClient _httpClient;


        public AuthorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://authorapi123.azurewebsites.net/api/");
        }

        public async Task<List<Author>> GetAllAuthor()
        {
            List<Author> authorList = new();

            HttpResponseMessage response = await _httpClient.GetAsync("Authors/GetAll");

            if (response.IsSuccessStatusCode)
            {
                authorList = await response.Content.ReadFromJsonAsync<List<Author>>();
            }


            return authorList;
        }

        public async Task<Author> GetAuthorById(int id)
        {
            Author author = new();

            HttpResponseMessage response = await _httpClient.GetAsync("Authors/" + id);

            if (response.IsSuccessStatusCode)
            {
                author = await response.Content.ReadFromJsonAsync<Author>();
            }


            return author;

        }
    }
}