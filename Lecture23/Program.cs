using System.Net.Http.Json;
using System.Text.Json;
using Lecture23.Models;

HttpClient client = new HttpClient();

string url = "https://jsonplaceholder.typicode.com/posts/1";

string data = await client.GetStringAsync(url);

Console.WriteLine(data);

var post = JsonSerializer.Deserialize<Post>(data, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

Console.WriteLine(post.Title);



Post posts = await client.GetFromJsonAsync<Post>(url);

Console.WriteLine(posts.Title);


string url2 = "https://api.breakingbadquotes.xyz/v1/quotes/25";

string data2 = await client.GetStringAsync(url2);

Console.WriteLine(data2);

var allQuotes = JsonSerializer.Deserialize<List<Quotes>>(data2, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

foreach (Quotes quote in allQuotes)
{
    Console.WriteLine(quote.Author);
}