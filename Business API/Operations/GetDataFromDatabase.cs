using BussinessApi.DAL;
using BussinessApi.Model;
using Microsoft.EntityFrameworkCore;

namespace BussinessApi.Operations
{
    public class GetDataFromDatabase
    {
        private readonly CurrencyDB _context;
        public GetDataFromDatabase(CurrencyDB context)
        {
            _context = context;
        }
        public List<CurrencyViewModel> Handle(string currencyCode)
        {
            var mylist = _context.Currencies.Where(x => x.CurrencyCode == currencyCode).
                Select(x => new CurrencyViewModel
                {
                    Date = x.Date,
                    ForexBuying = x.ForexBuying
                }).
                ToList();
            return mylist;
        }
    }
}
