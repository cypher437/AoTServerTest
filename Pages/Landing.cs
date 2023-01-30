using System;
using System.IO;
using System.Text;
using System.Net;
using System.Threading.Tasks;

namespace AoT.Pages
{
    // https://learn.microsoft.com/en-us/aspnet/core/tutorials/choose-web-ui?view=aspnetcore-7.0
    // Using something like Razor for rendering server sided pages would be better
    class Landing
    {
        public static string FrontPage =
            "<!DOCTYPE>" +
            "<html>" +
            "  <head>" +
            "    <title>AoT Example</title>" +
            "  </head>" +
            "  <body>" +
            "    <form method=\"get\" action=\"admin\">" +
            "      <input type=\"submit\" value=\"admin\">" +
            "    </form>" +
            "    <form method=\"get\" action=\"login\">" +
            "      <input type=\"submit\" value=\"login\">" +
            "    </form>" +
            "    <form method=\"get\" action=\"register\">" +
            "      <input type=\"submit\" value=\"register\">" +
            "    </form>" +
            "  </body>" +
            "</html>";
    }
}