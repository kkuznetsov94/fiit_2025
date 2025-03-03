using Kontur.BigLibrary.Tests.Core;
using Kontur.BigLibrary.Tests.Core.Helpers;
using NUnit.Framework;

namespace Tests.ApiSystem
{
    [SetUpFixture]
    public class SetUpFixture
    {
        [OneTimeSetUp]
        public async Task Setup()
        {
            await DbHelper.CreateDbAsync();
        }

        [OneTimeTearDown]
        public async Task Teardown()
        {
            await DbHelper.DropDbAsync();
        }
    }
}