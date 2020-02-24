using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspCoreProtobufFormatters.ContentFormatters
{
    /// <summary>
    /// Interface used to write an object to a byte array which will be written to the http response body.
    /// <inheritdoc/>
    /// </summary>
    public interface IContentWriter : IContentFormatter
    {
        /// <summary>
        /// Called by <see cref="ProtobufOutputFormatter"/> to serialize the object so the output formatter
        /// can write it to the http response's body.
        /// </summary>
        /// <param name="obj">Object provided by the http context. It is the object that is returned from a REST end point.</param>
        /// <returns>Returns a tuple containing a bool and the serialized object. The bool represents whether or not
        /// the object could be properly serialized.</returns>
        ValueTask<(bool, byte[])> Write(object obj);
    }
}
