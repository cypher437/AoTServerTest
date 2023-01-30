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
    public class Store
    {

        //NOTES we want to implement payment gate ways and the the various flows.
        public Store(string config){
            // parse in any configs like endpoints

            // once connected grab latest offers and such from db
            retreveDBConfig();
        }
        private void checkOut(PurchaseItem item, Account user, Processor processor)
        {
            // user wants to buy
            let transactions = Transaction(item, user, processor);
        }
        public void parseDBConfig(string config){
            // Parse store config of items and prices  from the Database

        }
    }
    // Class to represent the offer, pull the config from Database.
    public class PurchaseItem
    {
        public offer ID { get; set; }
        public Item Product {get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public decimal DisplayPrice {get; set;}
        public string Currency {get; set;}
    }

}