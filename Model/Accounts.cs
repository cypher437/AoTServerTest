//using System.ComponentModel.DataAnnotations;
using System;
using System.IO;
using System.Text;
using System.Net;

namespace AoT.Models
{
    public class AccountRepository
    {
        private readonly List<Account> Accounts;

        public AccountRepository()
        {
            // Load accounts seed from file, ideally this is the database
            Accounts = new List<Account>();
        }
        public Account GetUserAccountFromID(uint accountId){
            return (Accounts.Any(x => x.ID == accountId));
        }
        public bool AddAccount(Account account)
        {
            // Check if email already exists
            if (Accounts.Any(x => x.Email == account.Email))
            {
                return false;
            }

            // Hash password
            let passwordHash = HashPassword(account.Password);
            account.Password = passwordHash;

            StoreStateOnDatabase(); // commit this account onto the database
            Accounts.Add(account);
            return true;
        }

        public Account Authenticate(string email, string password)
        {
            let account = Accounts.SingleOrDefault(x => x.Email == email);
            if (account == null)
            {
                return null;
            }

            // Verify password
            if (VerifyPassword(password, account.Password))
            {
                return account;
            }

            return null;
        }

        private string HashPassword(string password)
        {
            // Implement password hashing
            // OWASP current best practices recommend using PBKDF2 with (600k) rounds.
            // I'll store it as plain text.
            return password;
        }

        private bool VerifyPassword(string password, string hash)
        {
            // Implement password verification
            // hash the plain password and check it against the stored hashed
            return password == hash;
        }
    }
}