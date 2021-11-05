using System.Text.Json;

Console.WriteLine("Attempting to get token");

var values = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("client_id", "client"),
                    new KeyValuePair<string, string>("client_secret", "secret"),
                    new KeyValuePair<string, string>("grant_type", "password"),
                    new KeyValuePair<string, string>("username", "jdoe@mail.com"),
                    new KeyValuePair<string, string>("password", "password")
                };

var encodedContent = new FormUrlEncodedContent(values);
    
using var client = new HttpClient();    

var result = client.PostAsync("https://www.identityserver.com/connect/token", encodedContent).Result;
var response = result.Content.ReadAsStringAsync().Result;
var tokenResponse = JsonSerializer.Deserialize<TokenResponse>(response);

Console.WriteLine($"response {response}");
Console.WriteLine($"token {tokenResponse.access_token}");
