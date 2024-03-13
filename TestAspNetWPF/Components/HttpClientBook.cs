using System;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace TestAspNetWPF.Components
{
    public class HttpClientBook
    {
        private T ConvertFromJson<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        private void GetRequestAsync(string url)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(url);

            client.GetAsync(url);
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
