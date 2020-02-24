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
    /// <para>Abstract base protobuf formatter. This is mainly used to reduce common boilerplate code.</para>
    /// <para>See <see cref="ProtobufBinFormatter"/> or <see cref="ProtobufJsonFormatter"/>.</para>
    /// <para><inheritdoc/></para>
    /// </summary>
    public abstract class BaseProtobufFormatter : IContentReader, IContentWriter
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public string SupportedContentType { get; }

        public BaseProtobufFormatter(string supportedContentType)
        {
            SupportedContentType = supportedContentType ?? throw new ArgumentNullException(nameof(supportedContentType));
        }


        /// <summary>
        /// <para><inheritdoc/></para>
        /// <para>
        /// Note: this implementation provides boilerplate code to get a <see cref="MessageParser"/>
        /// and read the bytes from the stream. A child class should implement <see cref="ParseBytes(MessageParser, byte[])"/>
        /// to handle the actual parsing.
        /// </para>
        /// </summary>
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

        /// <summary>
        /// <para><inheritdoc/></para>
        /// <para>
        /// Note: this implementation just checks if the object is an <see cref="IMessage"/>. A child class should
        /// implement <see cref="WriteBytes(IMessage)"/> to handle serializing the message.
        /// </para>
        /// </summary>
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
