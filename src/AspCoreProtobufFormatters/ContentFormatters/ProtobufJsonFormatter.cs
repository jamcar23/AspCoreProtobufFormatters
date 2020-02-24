using Google.Protobuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspCoreProtobufFormatters.ContentFormatters
{
    /// <summary>
    /// <para>
    /// A content formatter for converting protobufs to / from JSON. By default this supports the http content type
    /// 'application/x-protobuf-json'.
    /// </para>
    /// <para>
    /// This is may be useful for debugging or for supporting platforms which don't support protobufs. In general, 
    /// this is NOT the formatter you want to use as, according to Google, it is slower than binary messages and generally
    /// not heavily optimized.
    /// </para>
    /// </summary>
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
