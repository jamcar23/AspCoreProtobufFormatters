using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspCoreProtobufFormatters.ContentFormatters
{
    public interface IContentWriter : IContentFormatter
    {
        ValueTask<(bool, byte[])> Write(object obj);
    }
}
