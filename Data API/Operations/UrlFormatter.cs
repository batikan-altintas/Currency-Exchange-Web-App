namespace WebApiKurlar1.Operations
{
    public class UrlFormatter
    {
        public string Handle(DateTime day)
        {
            string formatteddate = day.ToString("ddMMyyyy");

            string formatted = day.ToString("yyyyMM");

            string url = $"https://www.tcmb.gov.tr/kurlar/{formatted}/{formatteddate}.xml";

            return url;
        }
    }
}
