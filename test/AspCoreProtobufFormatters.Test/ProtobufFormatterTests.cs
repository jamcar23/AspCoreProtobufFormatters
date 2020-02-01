using ExampleWebApp;
using ExampleWebApp.Protobufs;
using Google.Protobuf;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using NUnit.Framework;
using System.Net.Http;
using System.Net.Http.Headers;
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

            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(ProtobufFormatterUtils.BinContentType));
        }

        [Test]
        public async Task TestConnection()
        {
            HttpResponseMessage m = await _client.GetAsync("/Example/Empty");

            Assert.DoesNotThrow(() => m.EnsureSuccessStatusCode());
        }

        [Test]
        public async Task TestInput()
        {
            ByteArrayContent content = new ByteArrayContent(ExampleProto.Input.ToByteArray());
            content.Headers.ContentType = MediaTypeHeaderValue.Parse(ProtobufFormatterUtils.BinContentType);

            HttpResponseMessage m = await _client.PostAsync("/Example/Input", content);

            Assert.DoesNotThrow(() => m.EnsureSuccessStatusCode());
        }

        [Test]
        public async Task TestOutput()
        {
            HttpResponseMessage m = await _client.GetAsync("/Example/Output");

            Assert.DoesNotThrow(() => m.EnsureSuccessStatusCode());
            Assert.AreEqual(ProtobufFormatterUtils.BinContentType, m.Content.Headers.ContentType.ToString());

            ExampleProto proto = ExampleProto.Parser.ParseFrom(await m.Content.ReadAsByteArrayAsync());

            Assert.AreEqual(ExampleProto.Output, proto);
        }
    }
}