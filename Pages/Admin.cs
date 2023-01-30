using System;
using System.IO;
using System.Text;
using System.Net;
using System.Threading.Tasks;

namespace AoT.Pages
{
    // https://learn.microsoft.com/en-us/aspnet/core/tutorials/choose-web-ui?view=aspnetcore-7.0
    // Using something like Razor for rendering server sided pages would be better
    class Admin
    {
        public static string ControlsPage =
            "<!DOCTYPE>" +
            "<html>" +
            "  <head>" +
            "    <title>AoT Example</title>" +
            "  </head>" +
            "  <body>" +
            "    <form method=\"post\" action=\"shutdown\">" +
            "      <input type=\"submit\" value=\"Shutdown\" {0}>" +
            "    </form>" +
            "  </body>" +
            "</html>";
    }
}