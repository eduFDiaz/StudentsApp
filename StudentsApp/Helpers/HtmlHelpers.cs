using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Humanizer;

namespace StudentsApp.Helpers
{
    public static class HtmlHelpers
    {
        // We extend the HtmlHelper class and define a Trucate method
        public static string Truncate(this HtmlHelper helper, string input, int length)
        {
            if (input.Length <= length)
                return input;
            else
                return input.Substring(0,length) + "...";
        }
        public static string HumanDate(this HtmlHelper helper, DateTime input)
        {
            return input.Humanize();
        }
    }
}