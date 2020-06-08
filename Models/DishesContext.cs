using Microsoft.EntityFrameworkCore;

namespace CruDelicious.Models
{
    public class DishesContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public DishesContext(DbContextOptions options) : base(options) { }
        public DbSet<Dish> Dishes { get; set; }
    }
}