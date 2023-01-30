using System;
using System.IO;
using System.Text;
using System.Net;
using System.Threading.Tasks;

namespace AoT.Pages
{
    // https://learn.microsoft.com/en-us/aspnet/core/tutorials/choose-web-ui?view=aspnetcore-7.0
    // Using something like Razor for rendering server sided pages would be better
    class Store
    {
        public static string FrontPage =
            "<!DOCTYPE>" +
            "<html>" +
            "  <head>" +
            "    <title>Store</title>" +
            "  </head>" +
            "  <body>" +
            "    Items for purchase" +
            "  </body>" +
            "</html>";

        public static string ListItemPage =
            "<!DOCTYPE>" +
            "<html>" +
            "  <head>" +
            "    <title>List New Item</title>" +
            "  </head>" +
            "  <body>" +
            "    Add item" +
            "    <form method=\"post\" action=\"list_item\">" +
            "      <input type=\"text\" value=\"name\">" +
            "      <input type=\"text\" value=\"description\">" +
            "      <input type=\"submit\" value=\"list\">" +
            "    </form>" +
            "  </body>" +
            "</html>";

        public static string PurchasePage =
            "<!DOCTYPE>" +
            "<html>" +
            "  <head>" +
            "    <title>Purchase</title>" +
            "  </head>" +
            "  <body>" +
            "    Purchase" +
            "    <form method=\"post\" action=\"buy_item\">" +
            "      <input type=\"text\" value=\"username\">" +
            "      <input type=\"submit\" value=\"Buy\">" +
            "    </form>" +
            "  </body>" +
            "</html>";
    }
}