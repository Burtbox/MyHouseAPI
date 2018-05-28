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
        public int EnteredByOccupantId { get; set; }
        public string EnteredByDisplayName { get; set; }
        public DateTime EnteredDate { get; set; }
        public string CreditorDisplayName { get; set; } // TODO: Refactor this inheritance properly! 
        public string DebtorDisplayName { get; set; }
    }

    public abstract class TransactionOccupantsDetails
    {
        public string CreditorDisplayName { get; set; }
        public string DebtorDisplayName { get; set; }
    }

    public class TransactionSummaryResponse : TransactionOccupantsDetails
    {
        public decimal Gross { get; set; }
        public int CreditorOccupantId { get; set; }
        public int DebtorOccupantId { get; set; }
        public int CreditorHouseholdId { get; set; }
        public int DebtorHouseholdId { get; set; }
    }
}
