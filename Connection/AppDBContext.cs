/*using System;
using Microsoft.EntityFrameworkCore;

public class AppDBContext: DbContext
{
    // Database connection parameters
    private string Host = "localhost";
    private string Port = "5432";
    private string Database = "dbproducts";
    private string Username = "appuser";
    private string Password = "secret";
    // Define DbSets for each model
    public DbSet<Users> Users { get; set; }
    public DbSet<Orders> Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Configure PostgreSQL connection
        optionsBuilder.UseNpgsql(
            @$"Host={Host};
            Port={Port};
            Database={Database};
            Username={Username};
            Password={Password};"
        );       
    }
    // Configure model mappings
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Map entities to tables
        modelBuilder.Entity<Users>().ToTable("Users", schema: "public");
        modelBuilder.Entity<Orders>().ToTable("Orders",schema: "public");
    }    
    // Method to close the database connection
    public void CloseConnection()
    {
        Console.WriteLine("Closing database connection...");
        base.Dispose(); // Dispose the context to close the connection
        
        Console.WriteLine("Database connection closed.");
    }    
}*/