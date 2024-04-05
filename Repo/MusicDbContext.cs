using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab8.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Windows.UI;

namespace Lab8.Repo
{

    public class MusicDbContext : DbContext
    {
        public DbSet<MusicTrack> Tracks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=MusicCollectionDB;Username=postgres;Password=postgres");
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MusicDbContext>();
        }


    }
}