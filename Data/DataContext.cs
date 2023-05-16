using Microsoft.EntityFrameworkCore;
using ODataTutorial.Models;

namespace ODataTutorial.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // modelBuilder.Entity<Note>()
            //     .HasOne<Todo>(n => n.Todo)
            //     .WithMany(t => t.Notes)
            //     .HasForeignKey(n => n.TodoId);

            modelBuilder.Entity<Todo>()
                .HasMany<Note>(g => g.Notes)
                .WithOne(s => s.Todo)
                .HasForeignKey(s => s.TodoId);
        }

        public DbSet<Todo> Todos { get; set; } = default!;
        public DbSet<Note> Notes { get; set; } = default!;

    }
}