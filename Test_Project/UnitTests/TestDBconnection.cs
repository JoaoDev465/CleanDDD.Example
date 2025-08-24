using DDD_clean_architecture.Infrastructure;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Xunit;
using Assert = Xunit.Assert;

namespace Test_Project.UnitTests;

public class TestDBconnection
{
   
    
    [Fact]
    public void TestConnection()
    {
        var configurestring = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("C:\\Users\\User\\RiderProjects\\good_pratices\\Test_Project\\test.File.json", optional: false, reloadOnChange: true).Build();

        var connectionstring = configurestring.GetConnectionString("Connection");

        var options = new DbContextOptionsBuilder<Context>().UseSqlServer(new SqlConnection(connectionstring)).Options;

        var context = new Context(options).Database.CanConnect();
        
        Assert.True(context);
    }
}