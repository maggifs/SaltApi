using Salt.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Salt.WebApi.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options)
        {
        }
        
        public DbSet<TransactionDto> transactions { get; set; }
    }
}