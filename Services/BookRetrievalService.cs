using Assignment_12._3._2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_12._3._2.Services
{
    public class BookRetrievalService
    {
        private HttpClient httpClient;
        public BookRetrievalService()
        {
            httpClient = new()
            {
                BaseAddress = new Uri("https://openlibrary.org/search.json")
            };
        }
        public async Task<List<Book>?> FindBookAsync(string? title, string? author = null)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(title) &&
                    string.IsNullOrWhiteSpace(author))
                    return null;

                title = title?.Trim().Replace(" ", "+");
                author = author?.Trim().Replace(" ", "+");

                var titleParam = title!=string.Empty && title!=null ? $"&title={title}" : "";
                var authorParam = author!=string.Empty && author!=null? $"&author={author}" : "";

                var query = $"?{titleParam}{authorParam}";
                var result = await httpClient.GetAsync(httpClient.BaseAddress + query);
                var root = await result.Content.ReadFromJsonAsync<Root>();
                return root?.docs;
            }
            catch
            {
                throw;
            }
        }
    }
}