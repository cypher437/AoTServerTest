# AoTServerTest
A Simple Sever Programming Test Project for demonstration purposes, serves no real world use.

# Considerations

Firstly I'll use the provided base class code for "simplicity".

## Alternative approach
If I were starting a real project i'd recommend using something like Entity Framework core rather than basing it off this demo code because of advantages in terms of time, performance and code readability.
https://learn.microsoft.com/en-us/aspnet/core/tutorials/min-web-api?view=aspnetcore-7.0&tabs=visual-studio

## Performance
I suspect the provided `HttpListenerContext ctx = await listener.GetContextAsync();` so without writing a custom thread pool within the main it wont be scalable. I'd recommend using a async main function with C# 7.1

## Password
I'll keep password plain text due to time constraints.
OWASP current best practices recommend using PBKDF2 with (600k) rounds.
https://pages.nist.gov/800-63-3/sp800-63b.html

I'd also recommend, in order to discourage brute force attacks from threats like hashcash implement rate to slow down attempts and also reCAPTCHA to deter bots. I'd also recommend users pick a unique passwords with special characters and 2FA.

## Database

For this project I'll use JSON files to retrieve some seed data rather than plugin in an SQLite due to requirements and time constraints.
In reality the choices are Relational or Graph Databases. I'd recommend an class based SQL but it depends on how flexible & scalable the business  needs it to be base on their roadmap. Many choices between, Cloud based or Enterprise, clusters, location, pricing and running backups, DevOPS.

# Design

![Architecture Design](https://github.com/cypher437/AoTServerTest/blob/main/Mock%20Diagram.png)

## API
Ideas for the API design.

    - GET /user: Get the current user's information.
    - GET /store: Get a list of all items available in the store.
    - GET /store/{id}: Get the details of a specific item.
    - GET /friends: Get the current user's friend list.
    - POST /authenticate: Authenticate a user with their credentials. JWT
    - POST /register: Register a new user.
    - POST /store/purchase: Purchase an item.
    - POST /payment: Process a payment transaction.
    - POST /friends/add: Add a new friend.
    - DELETE /friends/{id}: Remove a friend.
