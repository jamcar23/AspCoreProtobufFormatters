using AspCoreProtobufFormatters.ContentFormatters;
using Google.Protobuf;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspCoreProtobufFormatters
{
    public class ProtobufOutputFormatter : OutputFormatter
    {
        private readonly Dictionary<string, IContentWriter> _writers = new Dictionary<string, IContentWriter>();

        public ProtobufOutputFormatter() : this(new ProtobufBinFormatter()) { }

        public ProtobufOutputFormatter(params IContentWriter[] writers) : base()
        {
            if (writers == null) throw new ArgumentNullException(nameof(writers));

            foreach (IContentWriter writer in writers)
            {
                _writers.Add(writer.SupportedContentType, writer);

                SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse(writer.SupportedContentType));
            }
        }

        protected override bool CanWriteType(Type type)
        {
            return ProtobufFormatterUtils.IsProtobuf(type);
        }

        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context)
        {
            HttpResponse response = context.HttpContext.Response;

            IContentWriter writer = _writers[response.ContentType];

            (bool success, byte[] data) = await writer.Write(context.Object);

            if (success && data != null)
            {
                await response.Body.WriteAsync(data, 0, data.Length);
            }
        }
    }
}