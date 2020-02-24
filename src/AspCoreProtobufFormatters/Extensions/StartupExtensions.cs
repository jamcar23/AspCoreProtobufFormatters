using AspCoreProtobufFormatters.ContentFormatters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspCoreProtobufFormatters.Extensions
{
    public static class StartupExtensions
    {
        /// <summary>
        /// Adds the standard input and output formatters using the default <see cref="IContentFormatter"/>
        /// with the default http content types.
        /// </summary>
        public static void AddProtobufFormatters(this MvcOptions mvc)
        {
            mvc.InputFormatters.Insert(0, new ProtobufInputFormatter());
            mvc.OutputFormatters.Insert(0, new ProtobufOutputFormatter());
        }

        /// <summary>
        /// Adds the standard input and output formatters using custom content formatters.
        /// </summary>
        public static void AddProtobufFormatters(this MvcOptions mvc, IContentReader[] readers, IContentWriter[] writers)
        {
            mvc.InputFormatters.Insert(0, new ProtobufInputFormatter(readers));
            mvc.OutputFormatters.Insert(0, new ProtobufOutputFormatter(writers));
        }
    }
}
