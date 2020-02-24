using System;
using System.Collections.Generic;
using System.Text;

namespace AspCoreProtobufFormatters.ContentFormatters
{
    public interface IContentFormatter
    {
        public string SupportedContentType { get; }
    }
}
