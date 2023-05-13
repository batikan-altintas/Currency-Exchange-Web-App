using System.Xml;
using WebApiKurlar1.Models;

namespace WebApiKurlar1.Operations
{
    public class ConvertXmlToObject
    {
        public List<Currency> Handle(string url)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(url);

            List<Currency> currencylist = new List<Currency>();

            for(int i =0; i < xmldoc.ChildNodes[2].ChildNodes.Count; i++)
            {
                Currency currency = new Currency();

                currency.Tarih = xmldoc.ChildNodes[2].Attributes["Tarih"].Value;
                currency.Date = xmldoc.ChildNodes[2].Attributes["Date"].Value;
                currency.Bulten_No = xmldoc.ChildNodes[2].Attributes["Bulten_No"].Value;

                currency.CurrencyCode = xmldoc.ChildNodes[2].ChildNodes[i].Attributes["CurrencyCode"].Value;
                currency.Unit = int.Parse(xmldoc.ChildNodes[2].ChildNodes[i].ChildNodes[0].InnerText);
                currency.Isim = xmldoc.ChildNodes[2].ChildNodes[i].ChildNodes[1].InnerText;
                currency.CurrencyName = xmldoc.ChildNodes[2].ChildNodes[i].ChildNodes[2].InnerText;

                if (xmldoc.ChildNodes[2].ChildNodes[i].ChildNodes[3].InnerText != string.Empty)
                    currency.ForexBuying = decimal.Parse(xmldoc.ChildNodes[2].ChildNodes[i].ChildNodes[3].InnerText);

                if (xmldoc.ChildNodes[2].ChildNodes[i].ChildNodes[4].InnerText != string.Empty)
                    currency.ForexSelling = decimal.Parse(xmldoc.ChildNodes[2].ChildNodes[i].ChildNodes[4].InnerText);

                if (xmldoc.ChildNodes[2].ChildNodes[i].ChildNodes[5].InnerText != string.Empty)
                    currency.BanknoteBuying = decimal.Parse(xmldoc.ChildNodes[2].ChildNodes[i].ChildNodes[5].InnerText);

                if (xmldoc.ChildNodes[2].ChildNodes[i].ChildNodes[6].InnerText != string.Empty)
                    currency.BanknoteSelling = decimal.Parse(xmldoc.ChildNodes[2].ChildNodes[i].ChildNodes[6].InnerText);

                if (xmldoc.ChildNodes[2].ChildNodes[i].ChildNodes[7].InnerText != string.Empty)
                    currency.CrossRateUSD = decimal.Parse(xmldoc.ChildNodes[2].ChildNodes[i].ChildNodes[7].InnerText);

                if (xmldoc.ChildNodes[2].ChildNodes[i].ChildNodes[8].InnerText != string.Empty)
                    currency.CrossRateOther = decimal.Parse(xmldoc.ChildNodes[2].ChildNodes[i].ChildNodes[8].InnerText);

                currencylist.Add(currency);
            }
            return currencylist;
        }
    }
}
