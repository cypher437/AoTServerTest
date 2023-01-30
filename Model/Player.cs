//using System.ComponentModel.DataAnnotations;
using System;
using System.IO;
using System.Text;
using System.Net;

namespace AoT.Models
{
    // Base class for inherited Player/Admin/Affliates/Anylsis classes
    public class Account
    {
        public uint ID { get; set; } // internal ID for DB, could use UUID to Obfuscate Sensative.
        public string Username { get; set; }
        public string Password { get; set; } // Plain text but OWASP current best practices recommend using PBKDF2 with (600k) rounds.
        public string Email { get; set; }
        public State State { get; set; } // is the account fully registered, flagged, banned
        public string Name {get; set;} //details
        public string Address { get; set; } // details
        public string Phone { get; set; } //details
        public string Currency { get; set; } // currency code to display
        public uint GemBalance {get; set;} // Should be updated from DB, In game gold could be part of game specific inventory
        public IReadOnlyList<string> Friends { get; } // Only read this from DB, probably limit this so player can't increase forever.

        public InventoryManager Inventories {get; set;}

        public Account()
        {
            ID = 1;// get next available ID from DB
            GemBalance = 0;
            Friends = new List<string>();
            Inventories = new InventoryManager();
        }

    }

    public enum State
    {
        UNREGISTERED,   // unregistered
        VERIFIED,       // confirmed registration
        VIP,            // whales
        CLOSE,          // players wishing to close account
        FLAGGED,        // potential victims of fraud
        BANNED          // bad activity
    }


}
