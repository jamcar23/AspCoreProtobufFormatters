using AspCoreProtobufFormatters.Extensions;
using Google.Protobuf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace AspCoreProtobufFormatters.ContentFormatters
{
    public abstract class BaseProtobufFormatter : IContentReader, IContentWriter
    {
        public string SupportedContentType { get; }

        public BaseProtobufFormatter(string supportedContentType)
        {
            SupportedContentType = supportedContentType ?? throw new ArgumentNullException(nameof(supportedContentType));
        }

        public async ValueTask<(bool, IMessage)> Read(Type model, Stream body)
        {
            MessageParser parser = model.GetPropertyValue<MessageParser>("Parser");

            if (parser == null)
            {
                return (false, null);
            }

            byte[] bytes;

            using (MemoryStream ms = new MemoryStream())
            {
                await body.CopyToAsync(ms);
                bytes = ms.ToArray();
            }

            if (bytes == null || bytes.Length == 0)
            {
                return (false, null);
            }

            return ParseBytes(parser, bytes);
        }

        public ValueTask<(bool, byte[])> Write(object obj)
        {
            IMessage message = obj as IMessage;

            if (message == null)
            {
                return new ValueTask<(bool, byte[])>((false, null));
            }

            return new ValueTask<(bool, byte[])>(WriteBytes(message));
        }

        protected abstract (bool, IMessage) ParseBytes(MessageParser parser, byte[] bytes);

        protected abstract (bool, byte[]) WriteBytes(IMessage message);
    }
}
