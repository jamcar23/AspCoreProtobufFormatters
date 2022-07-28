using Google.Protobuf;
using System;

namespace AspCoreProtobufFormatters
{
    public static class ProtobufFormatterUtils
    {
        public const string BinContentType = "application/x-protobuf";
        public const string JsonContentType = "application/x-protobuf-json";
        public const string ApplicationJsonContentType = "application/json";

        public static bool IsProtobuf(Type type)
        {
            return type.GetInterface(typeof(IMessage).FullName) != null;
        }
    }
}