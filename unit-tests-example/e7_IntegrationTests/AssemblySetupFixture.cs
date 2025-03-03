using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace IntegrationTests;

[SetUpFixture]
public class AssemblySetupFixture
{
    public static readonly IServiceProvider ContainerCache
        = new Container().BuildServiceProvider();

    [OneTimeTearDown]
    public async Task DisposeContainer()
        => await (ContainerCache as ServiceProvider)!.DisposeAsync();
}