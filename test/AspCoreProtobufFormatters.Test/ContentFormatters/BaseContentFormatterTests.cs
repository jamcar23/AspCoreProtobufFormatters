using AspCoreProtobufFormatters.ContentFormatters;
using ExampleWebApp.Protobufs;
using Google.Protobuf;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace AspCoreProtobufFormatters.Test.ContentFormatters
{
    public abstract class BaseContentFormatterTests
    {
        protected IContentReader _reader;
        protected IContentWriter _writer;

        [SetUp]
        public abstract void SetUp();

        //[Test]
        //public async Task TestWriter()
        //{
        //    (bool success, byte[] data) = await _writer.Write(ExampleProto.Input);

        //    Assert.IsTrue(success);
        //    Assert.IsTrue(data != null && data.Length != 0);
        //}

        [Test]
        public async Task TestRoundTrip()
        {
            (bool didWrite, byte[] writeData) = await _writer.Write(ExampleProto.Input);

            Assert.IsTrue(didWrite);
            Assert.IsTrue(writeData != null && writeData.Length != 0);

            using MemoryStream ms = new MemoryStream(writeData);

            (bool didRead, IMessage readMessage) = await _reader.Read(typeof(ExampleProto), ms);

            Assert.IsTrue(didRead);
            Assert.IsNotNull(readMessage);
            Assert.AreEqual(ExampleProto.Input, readMessage);
        }
    }
}
