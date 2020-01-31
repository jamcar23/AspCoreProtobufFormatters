using ExampleWebApp;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using NUnit.Framework;
using System.Net.Http;
using System.Threading.Tasks;

namespace AspCoreProtobufFormatters.Test
{
    public class ProtobufFormatterTests
    {
        private TestServer _server;
        private HttpClient _client;

        [SetUp]
        public void Setup()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Test]
        public async Task TestConnection()
        {
            HttpResponseMessage m = await _client.GetAsync("/Example/Empty");

            Assert.DoesNotThrow(() => m.EnsureSuccessStatusCode());
        }
    }
}