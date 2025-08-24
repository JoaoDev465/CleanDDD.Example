using System.Net;
using System.Text;
using System.Text.Json;
using Core.Request;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit;
using Xunit.Abstractions;
using Assert = Xunit.Assert;

namespace Test_Project.IntegrationTests.IntegrationHttpTest;

public class HttpPostAndUpdateTest: IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;
    private readonly ITestOutputHelper _helper;

    public HttpPostAndUpdateTest(WebApplicationFactory<Program> factory, ITestOutputHelper helper)
    {
        _client = factory.CreateClient();
        _helper = helper;
    }

    [Fact]
    public async Task Post()
    {
        var car = new CarDto
        {
            Carcolor = "azul",
            CarModel = "fusca",
            CarPrice = 5000,
            sold = false
        };
        var content = new StringContent(JsonSerializer.Serialize(car), Encoding.UTF8,"application/json");
       var response = await _client.PostAsync("/car",content);

       Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }

    [Fact]
    public async Task Update()
    {
        var car = new CarDto
        {
            Carcolor = "preto",
            CarModel = "fusca",
            CarPrice = 4000,
            sold = false
        };
        var content = new StringContent(JsonSerializer.Serialize(car), Encoding.UTF8,"application/json");
        var response = await  _client.PutAsync("/car", content);
        
        Assert.Equal(HttpStatusCode.OK,response.StatusCode);
        _helper.WriteLine(response.ReasonPhrase);
        
        var json = await response.Content.ReadAsStringAsync();
        
        Assert.False(string.IsNullOrEmpty(json));
    }
}