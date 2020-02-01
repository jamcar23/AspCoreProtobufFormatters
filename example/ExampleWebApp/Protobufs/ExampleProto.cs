using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleWebApp.Protobufs
{
    public partial class ExampleProto
    {
        public static ExampleProto Input => new ExampleProto()
        {
            Id = 1,
            Message = "Input from client",
            MyUint = 12
        };

        public static ExampleProto Output => new ExampleProto()
        {
            Id = 2,
            Message = "Output from server",
            MyUint = 23
        };

        public bool HasAllData => Id != 0 && !string.IsNullOrEmpty(Message) && MyUint != 0;
    }
}
