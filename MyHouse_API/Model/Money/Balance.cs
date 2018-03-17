namespace MyHouseAPI.Model
{
    public class BalanceResponse
    {
        public string Creditor { get; set; }
        public string Debtor { get; set; }
        public decimal Gross { get; set; }
    }
}
