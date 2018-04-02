namespace MyHouseAPI.Model.Money
{
    public class BalanceResponse
    {
        public int CreditorOccupantId { get; set; }
        public string CreditorDisplayName { get; set; }
        public int DebtorOccupantId { get; set; }
        public string DebtorDisplayName { get; set; }
        public decimal Gross { get; set; }
    }
}
