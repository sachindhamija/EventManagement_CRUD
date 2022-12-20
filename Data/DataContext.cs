using EventManagement_CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManagement_CRUD.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        {
        }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Event> Events { get; set; }
    }
}
