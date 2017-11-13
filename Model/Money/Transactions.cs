using System;
using System.ComponentModel.DataAnnotations;

namespace HouseMoneyAPI.Model {
  public class Transaction {
        //TODO add validation here!
      [Key]
      [Required (ErrorMessage = "Transaction id is required.")]
      public int TransactionId { get; set; }

      [Required (ErrorMessage = "Creditor is required.")]
      [StringLength (36, ErrorMessage = "The creditor's user id can't exceed 36 characters.")]
      public string Creditor { get; set; }

      [Required (ErrorMessage = "Debtor is required.")]
      [StringLength (36, ErrorMessage = "The debtor's user id can't exceed 36 characters.")]
      public string Debtor { get; set; }

      [Required (ErrorMessage = "Value is required.")]
      public decimal Gross { get; set; }

      [StringLength (36, ErrorMessage = "The debtor's user id can't exceed 36 characters.")]
      public string Reference { get; set; }

      public DateTime Date { get; set; }

      [Required (ErrorMessage = "The user id that entered this transaction is required.")]
      public string EnteredBy { get; set; }

      public DateTime EnteredDate { get; set; }
  }
}
