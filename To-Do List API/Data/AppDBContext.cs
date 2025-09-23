using Microsoft.EntityFrameworkCore;
using To_Do_List_API.Models.Entities;
using To_Do_List_API.Models;

namespace To_Do_List_API.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options)
        : DbContext(options)
    {
        public DbSet<ToDoItem> ToDoItems { get; set; }
    }
}
