using Microsoft.AspNetCore.Hosting;
using MyHouseAPI;
using Xunit.FixtureInjection;

[assembly: RequiresXunitFixtureInjection]
public class TestStartup : Startup
{
    public TestStartup(IHostingEnvironment environment) : base(environment)
    {
    }
}