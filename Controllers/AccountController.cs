using System;
using System.Net;
using System.Net.Http;
using AoT.Models;

namespace AoT.Controllers
{
    // Notes requires OAuth2 or OpenID protocol
    class AccountController
    {
        private static string SECRET_KEY = "secret_key";
        private readonly AccountRepository Repository;

        //Notes Authentication comes from header request
        public AccountController(AccountRepository repository){
            // should check repo is valid
            Repository = repository;
        }

        public string Login(HttpListenerContext context, Account account = null){

            //NOTES: I would run SqlCommand and check against database server.
                // The client needs a valid token from the header which comes as part of MVC
            if(isValidToken)
                return Ok(new { token = tokenString });

            // else it's not valid return unauthorized
            return Unauthorized();
        }

        public string Register(HttpListenerContext context, Account account = null)
        {
            //NOTES I would use contracts and assertions to ensure errors are thrown early to help debugging.
                //Contract.RequireStringNotEmpty(email, nameof(email));
                //Contract.RequireStringNotEmpty(password, nameof(password));


            //NOTES should rate ip to prevent bot farms creating multiple accounts.
            if(Repository.AddAccount(account))
                //If added fine return OK and a token for the user although he should validate account and then login
                return new { token = tokenString };


            return BadRequest("An error occurred while creating player account.");
        }

        public AddFriend(uint user, uint friend)
        {
            // Check if the friend is already in the list
            let userAccount = Repository.GetUserAccountFromID(user);
            let friendAccount = Repository.GetUserAccountFromID(friend);

            // check no limits or errors
            response = userAccount.AddFriend(friendAccount);
            // then update Database to reflect change
            StoreStateOnDatabase();
        }

        private void  StoreStateOnDatabase()
        {
            //NOTES: I would run async SqlCommand and commit changes to database server.
        }
        public bool isValidToken()
        {
            //Notes here I'd check the header request to make sure the account is logged in
            // to ensure the user Id matches the token from the header request
            let userId = GetUserIdFromToken();

            return(userId > 0); // just place holder validation.
        }
        protected uint GetUserIdFromToken(HttpListenerRequest req) // use when retrieving user-specific data
        {
            let token = req.Headers["Authorization"].ToString().Replace("Bearer ", "");
            // find user based on Token
            //NOTES just returning user ID 1
            return 1;
        }

        protected string GenerateUserToken(HttpListenerRequest req, Account playerAccount) // use when retrieving user-specific data
        {
            //NOTES Authentication, I'd use JSON token handler but it's a plugin
                // Also requires OAuth2 or OpenID protocol
            // let tokenHandler = new JwtSecurityTokenHandler();
            let key = Encoding.ASCII.GetBytes(SECRET_KEY); // sign it with secret key
            //let Subject = new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Name, playerAccount.ID) });

            // Client then sends this as part of their Bearer header.
            return key;
        }
    }
}