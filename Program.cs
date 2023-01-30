// Filename:  HttpServer.cs
// Author:    Benjamin N. Summerton <define-private-public>
// License:   Unlicense (http://unlicense.org/)

using System;
using System.IO;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using AoT.Pages;
using AoT.Models;
using AoT.Controllers;

namespace AoT
{
    class HttpServer
    {
        public static HttpListener listener;
        public static string url = "http://localhost:8000/";
        public static int pageViews = 0;
        public static int requestCount = 0;

        public static AccountController AccountController;
        public static async Task HandleIncomingConnections()
        {
            bool runServer = true;
            string pageData = Landing.FrontPage;
            byte[] data = null;
            // While a user hasn't visited the `shutdown` url, keep on handling requests
            while (runServer)
            {
                // Will wait here until we hear from a connection
                HttpListenerContext ctx = await listener.GetContextAsync();

                // Peel out the requests and response objects
                HttpListenerRequest req = ctx.Request;
                HttpListenerResponse resp = ctx.Response;

                // Print out some info about the request
                Console.WriteLine(req.Url.ToString());

                // Using an MVC framework would be better to use instead of using this base code setup.
                if (req.HttpMethod == "GET")
                {
                    switch (req.Url.AbsolutePath)
                    {
                        case "/login":
                            pageData = User.LoginPage;
                        break;
                        case "/register": //we'd want to validate the registration from email or phone number
                            pageData = User.RegisterPage;
                        break;
                        case "/admin":
                        case "/shutdown":
                            pageData = Admin.ControlsPage;
                        break;
                        case "/purchase":
                            pageData = Store.PurchasePage;
                        break;
                        case "/shop":
                            pageData = Store.FrontPage;
                        break;
                        case "/store":
                            // check if there is an itemId
                        break;
                        case "/user":
                            //Get the current user's information.
                        break;
                        case "/friends":
                            // get list of users
                        break;
                    }
                    // Write the response info
                    data = Encoding.UTF8.GetBytes(String.Format(pageData, ""));

                } else if (req.HttpMethod == "POST")
                {
                    switch (req.Url.AbsolutePath)
                    {
                        case "/shutdown":
                            Console.WriteLine("Shutdown requested");
                            //should check user is an admin with a valid session before shutting down
                            data = Encoding.UTF8.GetBytes(String.Format(Admin.ControlsPage, "disabled"));
                            runServer = false;
                        break;
                        case "/login":
                            // add a reCapture or rate limit the IP address
                            Console.WriteLine("Login Requested");
                            string response = AccountController.Register(ctx);
                            data = Encoding.UTF8.GetBytes(String.Format(response));
                        break;
                        case "/register":
                            Console.WriteLine("Register Request");
                            response = AccountController.Register(ctx);
                            data = Encoding.UTF8.GetBytes(String.Format(response));
                            data = Ok(new { token = response.tokenString });
                        break;
                        case "/store/purchase":
                            // The body of the request should be JSON object {itemId, userId, processorId}
                            //Purchase an item.
                            data = StoreController.Purchase(ctx);
                        break;
                        case "/authenticate":
                            if (AccountController.isValidToken(ctx))
                                data =  Ok();
                            data =  Unauthorized();
                        break;
                        case "/friends/add":
                            // The body of the request should be JSON object {friendId = 10, userId=10}
                            friendId = GetRequestPostData(req).friendId;
                            // would be better to looked up userId from bearer token
                            userId = GetRequestPostData(req).userId;
                            AccountController.AddFriend(userId, friendId);
                        break;
                    }
                }

                resp.ContentType = "text/html";
                resp.ContentEncoding = Encoding.UTF8;
                resp.ContentLength64 = data.LongLength;
                // Write out to the response stream (asynchronously), then close it
                await resp.OutputStream.WriteAsync(data, 0, data.Length);
                resp.Close();
            }
        }

        public static void initApp(){
            StoreController = new StoreController(new Store());
            AccountController = new AccountController(new AccountRepository());
        }
        public static void Main(string[] args)
        {
            // Create a Http server and start listening for incoming connections
            listener = new HttpListener();
            listener.Prefixes.Add(url);

            initApp();

            listener.Start();
            Console.WriteLine("Listening for connections on {0}", url);
            // Handle requests
            Task listenTask = HandleIncomingConnections();
            listenTask.GetAwaiter().GetResult();
            // Close the listener
            listener.Close();
        }
    }
}