using AspCoreProtobufFormatters.ContentFormatters;
using AspCoreProtobufFormatters.Extensions;
using Google.Protobuf;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace AspCoreProtobufFormatters
{
    public class ProtobufInputFormatter : InputFormatter
    {
        private readonly Dictionary<string, IContentReader> _readers = new Dictionary<string, IContentReader>();

        public ProtobufInputFormatter() : this(new ProtobufBinFormatter(), new ProtobufJsonFormatter()) { }

        public ProtobufInputFormatter(params IContentReader[] readers) : base()
        {
            if (readers == null) throw new ArgumentNullException(nameof(readers));

            foreach (IContentReader reader in readers)
            {
                _readers.Add(reader.SupportedContentType, reader);

                SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse(reader.SupportedContentType));
            }
        }

        protected override bool CanReadType(Type type)
        {
            return ProtobufFormatterUtils.IsProtobuf(type) && base.CanReadType(type);
        }

        public override async Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context)
        {
            HttpRequest request = context.HttpContext.Request;
            IContentReader reader = _readers[request.ContentType];

            (bool success, IMessage msg) = await reader.Read(context.ModelType, request.Body);

            return success ? await InputFormatterResult.SuccessAsync(msg) : await InputFormatterResult.FailureAsync();
        }
    }
}