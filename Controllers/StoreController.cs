using System;
using System.Net;
using System.Net.Http;
using AoT.Models;

namespace AoT.Controllers
{

    class StoreController
    {
        private readonly Store Repository;

        public StoreController(Store repository)
        {
            // check it's configured properly and valid.
            Repository = repository;

        }
        private void StoreStateToDB()
        {
            // Here I'd call an SQL command to update state on the database

            // We'd want to record the state of the purchase
            // also log cancelled or failed transaction
        }
        public void retreveDBConfig()
        {
            // Pull the config items from the Database and update the store model
            let response =  await getOffersDB();
            if(response)
                Repository.parseDBConfig(response);
        }
        public string Purchase(HttpListenerContext context)
        {

            // look up and validate each item from context
           return result = await TransactionRequest(context.item, context.user, context. processor);
        }
        public async TransactionRequest(PurchaseItem item, Account user, Processor processor)
        {
            // Transaction would be sent to the specific gateway passing in the details
            // then we need to handle the response, we could use type resolving on a generic response something like
            // let Result = await Transaction.fetch<HandleTransactionRespons>({endpoint: processor.endpoint, product: item.ID, price:item.DisplayPrice, currency:item.Currency, user:user.Email})

        }
        public HandleTransactionResponse(string response)
        {
            // Log transaction result to DB
            // Award Item
            // Update user message
        }

    }
}