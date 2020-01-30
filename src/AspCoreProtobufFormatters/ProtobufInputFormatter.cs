using AspCoreProtobufFormatters.Extensions;
using Google.Protobuf;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace AspCoreProtobufFormatters
{
    public class ProtobufInputFormatter : InputFormatter
    {
        public ProtobufInputFormatter() : base()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse(ProtobufFormatterUtils.BinContentType));
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse(ProtobufFormatterUtils.JsonContentType));
        }

        protected override bool CanReadType(Type type)
        {
            return ProtobufFormatterUtils.IsProtobuf(type) && base.CanReadType(type);
        }

        public override async Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context)
        {
            Type type = context.ModelType;
            HttpRequest request = context.HttpContext.Request;
            MessageParser parser = type.GetPropertyValue<MessageParser>("Parser");

            if (parser == null)
            {
                return await InputFormatterResult.FailureAsync();
            }

            byte[] bytes;

            using (MemoryStream ms = new MemoryStream())
            {
                await request.Body.CopyToAsync(ms);

                bytes = ms.ToArray();
            }

            IMessage msg = request.ContentType.Equals(ProtobufFormatterUtils.BinContentType) ? parser.ParseFrom(bytes)
                : parser.ParseJson(Encoding.UTF8.GetString(bytes));

            return await InputFormatterResult.SuccessAsync(msg);
        }
    }
}