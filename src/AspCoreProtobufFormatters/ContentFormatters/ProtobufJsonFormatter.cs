using Google.Protobuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspCoreProtobufFormatters.ContentFormatters
{
    public class ProtobufJsonFormatter : BaseProtobufFormatter
    {
        public ProtobufJsonFormatter() : base(ProtobufFormatterUtils.JsonContentType) { }

        public ProtobufJsonFormatter(string supportedContentType) : base(supportedContentType) { }

        protected override (bool, IMessage) ParseBytes(MessageParser parser, byte[] bytes)
        {
            return (true, parser.ParseJson(Encoding.UTF8.GetString(bytes)));
        }

        protected override (bool, byte[]) WriteBytes(IMessage message)
        {
            return (true, Encoding.UTF8.GetBytes(JsonFormatter.Default.Format(message)));
        }
    }
}
