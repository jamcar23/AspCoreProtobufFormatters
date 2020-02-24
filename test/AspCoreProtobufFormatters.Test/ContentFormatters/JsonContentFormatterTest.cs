using AspCoreProtobufFormatters.ContentFormatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspCoreProtobufFormatters.Test.ContentFormatters
{
    public class JsonContentFormatterTest : BaseContentFormatterTests
    {
        public override void SetUp()
        {
            ProtobufJsonFormatter formatter = new ProtobufJsonFormatter();

            _reader = formatter;
            _writer = formatter;
        }
    }
}
