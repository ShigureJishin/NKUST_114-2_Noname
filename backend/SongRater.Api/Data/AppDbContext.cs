using Microsoft.EntityFrameworkCore;
using SongRater.Api.Models;
using System.Collections.Generic;

namespace SongRater.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // 定義資料表
        public DbSet<Song> Songs { get; set; }
        public DbSet<Vote> Votes { get; set; }
    }
}