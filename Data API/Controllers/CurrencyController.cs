using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml;
using WebApiKurlar1.DAL;
using WebApiKurlar1.Models;
using WebApiKurlar1.Operations;

namespace WebApiKurlar1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly CurrencyDB _context;
        public CurrencyController(CurrencyDB context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }
        [HttpGet]
        public IActionResult GetCurrencies()
        {
            DateTime previousdate = DateTime.Today.AddMonths(-2);

            for(DateTime day=previousdate; day < DateTime.Today; day = day.AddDays(1))
            {
                UrlFormatter formatter = new UrlFormatter(); 
                string url = formatter.Handle(day);

                UrlExists urlExists = new UrlExists();
                if (urlExists.Handle(url) == true)
                {

                    ConvertXmlToObject convertXml = new ConvertXmlToObject();
                    List<Currency> currencylist = convertXml.Handle(url);

                    foreach (Currency currency in currencylist)
                    {
                        _context.Add(currency);
                        _context.SaveChanges();
                    }
                }
            }

            return Ok();
        }
    }
}
