using BussinessApi.Model;
using Microsoft.EntityFrameworkCore;

namespace BussinessApi.DAL
{
    public class CurrencyDB : DbContext
    {
        public CurrencyDB(DbContextOptions<CurrencyDB> options) : base(options)
        {

        }
        public DbSet<Currency> Currencies { get; set; }
    }
}
