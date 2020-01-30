using Google.Protobuf;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System;
using System.Threading.Tasks;

namespace AspCoreProtobufFormatters
{
    public class ProtobufOutputFormatter : OutputFormatter
    {

        public ProtobufOutputFormatter() : base()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse(ProtobufFormatterUtils.BinContentType));
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse(ProtobufFormatterUtils.JsonContentType));
        }

        protected override bool CanWriteType(Type type)
        {
            return ProtobufFormatterUtils.IsProtobuf(type);
        }

        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context)
        {
            HttpResponse response = context.HttpContext.Response;

            IMessage msg = context.Object as IMessage;

            if (msg == null) return Task.CompletedTask;

            byte[] data = msg.ToByteArray();

            return response.Body.WriteAsync(data, 0, data.Length);
        }
    }
}