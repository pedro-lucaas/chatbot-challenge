using BlipApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();

HttpClient httpClient = new();
httpClient.DefaultRequestHeaders.Add("User-Agent", "BlipApi/1.0");
httpClient.BaseAddress = new Uri("https://api.github.com");

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("/", async () =>
    await httpClient.GetAsync("/users/takenet/repos?sort=created&direction=asc") 
    is HttpResponseMessage response && response.IsSuccessStatusCode ?
        await response.Content.ReadFromJsonAsync<Repo[]>() is Repo[] repos
            ? Results.Ok(Array.FindAll(repos, r => r.Language == "C#").Take(5).ToArray())
            : Results.NoContent()
        : Results.StatusCode(500))
    .WithName("GetOlderRepositories");

app.Run();