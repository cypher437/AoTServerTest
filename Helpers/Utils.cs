using System;
using System.IO;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
public static class Utils
{
    // should be converted this to JSON
    public static string GetRequestPostData(HttpListenerRequest request)
    {
        if (!request.HasEntityBody)
        {
            return null;
        }
        using (System.IO.Stream body = request.InputStream)
        {
            using (var reader = new System.IO.StreamReader(body, request.ContentEncoding))
            {
                return JsonSerializer.Serialize(reader.ReadToEnd());
            }
        }
    }
}