using Google.Protobuf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace AspCoreProtobufFormatters.ContentFormatters
{
    public interface IContentReader : IContentFormatter
    {
        ValueTask<(bool, IMessage)> Read(Type model, Stream body);
    }
}
