// File: Database.cs
using Microsoft.EntityFrameworkCore;

public static class Database
{
    public static ApplicationDbContext Context { get; private set; }
    public static void Init(string connectionString)
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            .Options;

        Context = new ApplicationDbContext(options);
    }
}