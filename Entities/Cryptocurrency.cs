using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities;

public enum CryptoCurrencyType
{
    Bitcoin,
    Ethereum,
    Litecoin
}

public class WalletAddress
{
    public string Address { get; set; }
    public CryptoCurrencyType CurrencyType { get; set; }
    public DateTime CreatedDate { get; set;}
    public string PrivateKey { get; set; }

}

public enum TransactionStatus
{
    Pending,
    Confirmed,
    Failed
}

public class Transaction
{
    public string TransactionId { get; set; }
    public string FromAddress { get; set; }
    public string ToAddress { get; set; }

    public decimal Amount { get; set; }
    public decimal Fee { get; set; }

    public DateTime Timestamp { get; set; }
    public TransactionStatus Status { get; set; }
    public CryptoCurrencyType CurrencyType { get; set; }
}


public class CryptoWallet
{
    public Guid WalletId { get; set; }
    public string UserId { get; set; }
    public string WalletName { get; set; }
    public List<WalletAddress> Addresses { get; set; }
    public List<Transaction> Transactions { get; set; }
    public DateTime CreatedDate { get; set; }
    public decimal TotalBalance => CalculateTotalBalance();

    private decimal CalculateTotalBalance()
    {
        decimal balance = 0;
        foreach (var transaction in Transactions)
        {
            if (transaction.Status == TransactionStatus.Confirmed)
            {
                if (Addresses.Any(a => a.Address == transaction.ToAddress))
                    balance += transaction.Amount;
                if (Addresses.Any(a => a.Address == transaction.FromAddress))
                    balance -= (transaction.Amount + transaction.Fee);
            }
        }
        return balance;
    }
}

public class WalletUser
{
    public string UserId { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public List<CryptoWallet> Wallets { get; set; }
    public DateTime RegistrationDate { get; set; }
 }
