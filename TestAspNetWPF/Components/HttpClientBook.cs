using System;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Collections.Generic;

namespace TestAspNetWPF.Components
{
    public class HttpClientBook
    {
        private string url = @"http://localhost:5008";
        public List<Book> GetAllBooks()
        {
            return ConvertFromJson<List<Book>>(GetRequestAsync(url + "bookitems"));
        }

        public Book GetBookId(int id)
        {
            return ConvertFromJson<Book>(GetRequestAsync(url + $"/bookitem/{id}"));
        }

        public void AddBook(Book book)
        {
            PostRequestAsync(url + $"/bootitem", book);
        }

        private T ConvertFromJson<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        private string GetRequestAsync(string url)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(url);

            var response = client.GetAsync(url).Result;

            return response.Content.ReadAsStringAsync().Result;
        }

        private async void PostRequestAsync(string url, Book book)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(url);

            var content =
                new StringContent(JsonConvert.SerializeObject(book), Encoding.UTF8, "application/json");

            await client.PostAsync(url, content);
        }

        private async void PutRequestAsync(string url, Book book)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(url);

            var content =
                new StringContent(JsonConvert.SerializeObject(book), Encoding.UTF8, "application/json");

            await client.PutAsync(url, content);
        }

        private async void DeleteRequestAsync(string url)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(url);

            await client.DeleteAsync(url);
        }
    }
}
