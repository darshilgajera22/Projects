using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Assignment1.Models;

namespace Assignment1.Data
{
    public class Assignment1Context : DbContext
    {
        public Assignment1Context (DbContextOptions<Assignment1Context> options)
            : base(options)
        {
            Database.EnsureCreated();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>().HasData(
                new Game
                {
                    GameId = 1,
                    Title = "GunShip Battle",
                    Developer = "JoyCity Corporation",
                    Genre = "Action",
                    ReleaseYear = 2011,
                    PurchaseDate =  DateTime.Today,
                    Rating = 9
                }, new Game
                {
                    GameId = 2,
                    Title = "Dr. Driving",
                    Developer = "SUD Inc",
                    Genre = "Driving",
                    ReleaseYear = 2015,
                    PurchaseDate = DateTime.Today,
                    Rating = 7
                }, new Game
                {
                    GameId = 3,
                    Title = "PUBG",
                    Developer = "Tencent Studio",
                    Genre = "Action",
                    ReleaseYear = 2018,
                    PurchaseDate = DateTime.Today,
                    Rating = 10
                }, new Game
                {
                    GameId = 4,
                    Title = "WCC3",
                    Developer = "Crafted Studio",
                    Genre = "FPS",
                    ReleaseYear = 2014,
                    PurchaseDate = DateTime.Today,
                    Rating = 9
                }
            );
        }


        public DbSet<Assignment1.Models.Game> Game { get; set; } = default!;
    }
}
