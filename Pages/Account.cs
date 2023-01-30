using System;
using System.IO;
using System.Text;
using System.Net;
using System.Threading.Tasks;

namespace AoT.Pages
{
    // https://learn.microsoft.com/en-us/aspnet/core/tutorials/choose-web-ui?view=aspnetcore-7.0
    // Using something like Razor for rendering server sided pages would be better
    class User
    {
        // add a reCapture or rate limit the IP address to stop password stuffing
        public static string LoginPage =
        "<!DOCTYPE>" +
        "<html>" +
        "  <head>" +
        "    <title>Login</title>" +
        "  </head>" +
        "  <body>" +
        "    Login" +
        "    <form method=\"post\" action=\"login\">" +
        "      <input type=\"text\" value=\"username\">" +
        "      <input type=\"text\" value=\"password\">" +
        "      <input type=\"submit\" value=\"Login\">" +
        "    </form>" +
        "  </body>" +
        "</html>";

        public static string RegisterPage =
            "<!DOCTYPE>" +
            "<html>" +
            "  <head>" +
            "    <title>Login</title>" +
            "  </head>" +
            "  <body>" +
            "    Login" +
            "    <form method=\"post\" action=\"register\">" +
            "      <input type=\"text\" value=\"username\">" +
            "      <input type=\"text\" value=\"password\">" +
            "      <input type=\"submit\" value=\"Register\">" +
            "    </form>" +
            "  </body>" +
            "</html>";
    }
}