using Google.Protobuf;
using System;

namespace AspCoreProtobufFormatters
{
    public static class ProtobufFormatterUtils
    {
        public static readonly string BinContentType = "application/x-protobuf";
        public static readonly string JsonContentType = "application/x-protobuf-json";

        public static bool IsProtobuf(Type type)
        {
            return type.GetInterface(typeof(IMessage).FullName) != null;
        }
    }
}