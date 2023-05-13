using BussinessApi.DAL;
using BussinessApi.Extensions;
using BussinessApi.Model;
using BussinessApi.Operations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;

namespace BussinessApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly CurrencyDB _context;
        private readonly IDistributedCache _cache;
        public CurrencyController(CurrencyDB context, IDistributedCache cache)
        {
            _context = context;
            _cache = cache;
        }
        [HttpGet("{currencyCode}")]
        public async Task<IActionResult> GetCurrencies(string currencyCode)
        {
            string cacheKey = $"currency{currencyCode}";
            var cachedData = await _cache.GetRecordAsync<CurrencyViewModel>(cacheKey);

            if(cachedData != null)
            {
                return Ok(cachedData);
            }
            GetDataFromDatabase getData = new GetDataFromDatabase(_context);
            var dataList = getData.Handle(currencyCode);

            if (dataList.Any())
            {
                await _cache.SetRecordAsync($"currency{currencyCode}", dataList);

                return Ok(dataList);
            }
            else
            {
                return NotFound();
            }
            
        }

        [HttpGet("get-currency-codes")]
        public async Task<IActionResult> GetCurrencyCodes()
        {
            var currencyCodes = await _context.Currencies.Select(x => x.CurrencyCode).Distinct().ToListAsync();

            return Ok(currencyCodes);
        }
    }
}
