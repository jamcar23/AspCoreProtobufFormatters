using System;
using System.Collections.Generic;
using System.Text;

namespace AspCoreProtobufFormatters.ContentFormatters
{
    /// <summary>
    /// <para>Common interface for custom content formatters. </para>
    /// <para>See <see cref="IContentReader"/> or <see cref="IContentWriter"/>.</para>
    /// </summary>
    public interface IContentFormatter
    {
        /// <summary>
        /// <para>The supported http content type. This should NEVER be null or empty.</para>
        /// <para>
        /// Note: this is matched up to the content type in the http request / response to select the actual 
        /// content formatter.
        /// </para>
        /// </summary>
        public string SupportedContentType { get; }
    }
}
