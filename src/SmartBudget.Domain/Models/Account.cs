using System;

namespace SmartBudget.Domain.Models
{
    public enum AccountType
    {
        Bank,
        CreditCard
    }

    public class Account : DomainObject
    {
        public User AccountHolder { get; set; }
        public string Name { get; set; }
        public AccountType Type { get; set; }
        public string AccountNumber { get; set; }
        public string RoutingNumber { get; set; }
        public double Balance { get; set; }
        public string Note { get; set; }
        public bool Favorite { get; set; }
        public string ExpirationDate { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }

        public override string ToString()
        {
            return string.Format($"{Name}: {Balance:c}");
        }
    }
}