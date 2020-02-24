using AspCoreProtobufFormatters.Extensions;
using Google.Protobuf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace AspCoreProtobufFormatters.ContentFormatters
{
    /// <summary>
    /// <para>
    /// A content formatter for the protobuf standard binary message. By default this supports the content type
    /// 'application/x-protobuf'.
    /// </para>
    /// <para>This is usually the formatter you want to use.</para>
    /// </summary>
    public class ProtobufBinFormatter : BaseProtobufFormatter
    {
        public ProtobufBinFormatter() : base(ProtobufFormatterUtils.BinContentType) { }

        public ProtobufBinFormatter(string supportedContentType) : base(supportedContentType) { }

        protected override (bool, IMessage) ParseBytes(MessageParser parser, byte[] bytes) => (true, parser.ParseFrom(bytes));

        protected override (bool, byte[]) WriteBytes(IMessage message) => (true, message.ToByteArray());
    }
}
