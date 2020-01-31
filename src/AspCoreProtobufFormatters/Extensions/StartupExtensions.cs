using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspCoreProtobufFormatters.Extensions
{
    public static class StartupExtensions
    {
        public static void AddProtobufFormatters(this MvcOptions mvc)
        {
            mvc.InputFormatters.Insert(0, new ProtobufInputFormatter());
            mvc.OutputFormatters.Insert(0, new ProtobufOutputFormatter());
        }
    }
}
