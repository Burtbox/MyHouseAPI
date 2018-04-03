using System;
using System.ComponentModel.DataAnnotations;

namespace MyHouseAPI.Model.Money
{
    public abstract class TransactionDetails
    {
        public int Creditor { get; set; }
        public int Debtor { get; set; }
        public decimal Gross { get; set; }
        public string Reference { get; set; }
        public DateTime Date { get; set; }
    }

    public abstract class Transaction : TransactionDetails
    {
        public int TransactionId { get; set; }
    }

    public class TransactionInsertRequest : TransactionDetails
    {
        public int EnteredBy { get; set; }
    }

    public class TransactionResponse : Transaction { }
}
