//using System.ComponentModel.DataAnnotations;
using System;
using System.IO;
using System.Text;
using System.Net;

namespace AoT.Models
{
    // NOTES would require implementing with a payment gateway
    // Android Pay can be initiated on PC and confirmed with phone.
    // StoreKit for Apple
    // https://developer.apple.com/documentation/storekit

    // class to represent each transaction made
    public class Transaction
    {

        public Transaction(PurchaseItem item, Account user, Processor processor)
        {
            // Check the user is authorized
            // Check everything is valid and item and prices are correct to avoid spoofing.
            InitPurchase(item, user, processor);
        }
        private void InitPurchase(PurchaseItem item, Account user, Processor processor)
        {
            // we'd have to integrated each processor
            // check if the user has credit
            // ask the user if they want to pay with a credit card
            // initate gateway request
            result = await TransactionRequest(item, user, processor);
        }
        private void StoreStateToDB()
        {
            // Here I'd call an SQL command to update state on the database

            // We'd want to record the state of the purchase
            // also log cancelled or failed transaction
        }
        private void retreveDBConfig()
        {
            // Pull the  products and price config from the Database

        }
    }
    public class TransactionRequest
    {
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
    // https://developer.apple.com/documentation/storekit/in-app_purchase/implementing_a_store_in_your_app_using_the_storekit_api
    public class Processor
    {
        public uint ID { get; set; }
        public string Name { get; set; }
        public string endpoint { get; set; }
    }
    public enum TransactionState
    {
        INITIATED,
        DECLINED,
        SUCCESS,
        CANCELLED,
        PENDING
    }
}