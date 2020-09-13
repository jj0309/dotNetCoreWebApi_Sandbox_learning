using _dotnetSandBox.Models;
using Microsoft.EntityFrameworkCore;

namespace _dotnetSandBox.Data
{
    public class DataContext : DbContext
    {
        // I have no idea of what that constructor is or does
        public DataContext(DbContextOptions<DataContext> options) :base(options)
        {
            
        }

        //table Characters in the db
        public DbSet<Character> Characters {get;set;}
    }
}