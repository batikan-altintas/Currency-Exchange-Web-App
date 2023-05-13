namespace WebApiKurlar1.Models
{
    public class Currency
    {
        public int Id { get; set; }
        public string Tarih { get; set; }
        public string Date { get; set; }
        public string Bulten_No { get; set; }
        public string CurrencyCode { get; set; }
        public int Unit { get; set; }
        public string Isim { get; set; }
        public string CurrencyName { get; set; }
        public decimal? ForexBuying { get; set; }
        public decimal? ForexSelling { get; set; }
        public decimal? BanknoteBuying { get; set; }
        public decimal? BanknoteSelling { get; set; }
        public decimal? CrossRateUSD { get; set; }
        public decimal? CrossRateOther { get; set; }
    }
}
