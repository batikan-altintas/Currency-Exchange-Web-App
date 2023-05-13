using Microsoft.EntityFrameworkCore;
using WebApiKurlar1.Models;

namespace WebApiKurlar1.DAL
{
    public class CurrencyDB : DbContext
    {
        public CurrencyDB(DbContextOptions<CurrencyDB> options) : base(options)
        {

        }
        public DbSet<Currency> Currencies { get; set; }
    }
}
