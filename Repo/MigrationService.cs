using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Lab8.Repo
{
    public class MigrationService
    {
        public static void MigrateDatabase()
        {
            using (var db = new MusicDbContext())
            {
                try
                {
                    db.Database.Migrate();
                    Console.WriteLine("Database migration completed successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error occurred during database migration: {ex.Message}");
                }
            }
        }
    }
}
