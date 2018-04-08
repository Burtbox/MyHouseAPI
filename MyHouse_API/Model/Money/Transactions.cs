using System;
using System.ComponentModel.DataAnnotations;

namespace MyHouseAPI.Model.Money
{
    public abstract class TransactionDetails
    {
        public int CreditorOccupantId { get; set; }
        public int DebtorOccupantId { get; set; }
        public decimal Gross { get; set; }
        public string Reference { get; set; }
        public DateTime Date { get; set; }
    }

    public abstract class Transaction : TransactionDetails
    {
        public int TransactionId { get; set; }
    }

    public class TransactionInsertRequest : TransactionDetails { }

    public class TransactionResponse : Transaction { }

    public class TransactionHistoryResponse : TransactionResponse
    {
        public string PrimaryKey { get; set; }
        public int EnteredByOccupantId { get; set; }
        public string CreditorDisplayName { get; set; }
        public string DebtorDisplayName { get; set; }
        public string EnteredByDisplayName { get; set; }
        public DateTime EnteredDate { get; set; }
    }
}
