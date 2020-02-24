using Google.Protobuf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace AspCoreProtobufFormatters.ContentFormatters
{
    /// <summary>
    /// <para>Interface used to read http body content for a custom protobuf formatter.</para>
    /// <para><inheritdoc/></para>
    /// </summary>
    public interface IContentReader : IContentFormatter
    {
        /// <summary>
        /// Method that is called by <see cref="ProtobufInputFormatter"/> to read the contents of the body.
        /// </summary>
        /// <param name="model">The model used as input in the REST end point.</param>
        /// <param name="body">The HTTP request's body.</param>
        /// <returns>
        /// Returns a tuple holding a bool and the protobuf. The bool indicates whether or not
        /// this reader could successfully read the model from the body.
        /// </returns>
        ValueTask<(bool, IMessage)> Read(Type model, Stream body);
    }
}
