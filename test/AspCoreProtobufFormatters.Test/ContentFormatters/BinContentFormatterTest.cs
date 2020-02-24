using AspCoreProtobufFormatters.ContentFormatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspCoreProtobufFormatters.Test.ContentFormatters
{
    public class BinContentFormatterTest : BaseContentFormatterTests
    {
        public override void SetUp()
        {
            ProtobufBinFormatter formatter = new ProtobufBinFormatter();

            _reader = formatter;
            _writer = formatter;
        }
    }
}
