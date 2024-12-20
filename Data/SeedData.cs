using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShelfSpace.Data;
using System;
using System.Linq;


namespace ShelfSpace.Data;
public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new ShelfSpaceContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<ShelfSpaceContext>>()))
        {
            // Check if database is already seeded
            if (context.User.Any() || context.Media.Any())
            {
                return; // DB already seeded
            }

            // Create MediaItems
var gatsby = new MediaItem {
    SpecialId = "M001", 
    UserId = "U001", 
    Title = "The Great Gatsby", 
    Genre = "Classic", 
    Year = 1925, 
    Type = MediaType.Book
};

var abbeyRoad = new MediaItem 
{
    SpecialId = "M002", 
    UserId = "U001", 
    Title = "The Beatles - Abbey Road", 
    Genre = "Rock", 
    Year = 1969, 
    Type = MediaType.CD
};

var inception = new MediaItem 
{
    SpecialId = "M003", 
    UserId = "U001", 
    Title = "Inception", 
    Genre = "Sci-Fi", 
    Year = 2010, 
    Type = MediaType.Movie
};

var office = new MediaItem 
{
    SpecialId = "M004", 
    UserId = "U001", 
    Title = "The Office", 
    Genre = "Comedy", 
    Year = 2005, 
    Type = MediaType.TVShow
};

var catcherInTheRye = new MediaItem 
{
    SpecialId = "M005", 
    UserId = "U001", 
    Title = "The Catcher in the Rye", 
    Genre = "Fiction", 
    Year = 1951, 
    Type = MediaType.Book
};

var breakingBad = new MediaItem 
{
    SpecialId = "M006", 
    UserId = "U002", 
    Title = "Breaking Bad", 
    Genre = "Drama", 
    Year = 2008, 
    Type = MediaType.TVShow
};

var nineteenEightyFour = new MediaItem 
{
    SpecialId = "M007", 
    UserId = "U002", 
    Title = "1984", 
    Genre = "Dystopian", 
    Year = 1949, 
    Type = MediaType.Book
};

var darkSideOfTheMoon = new MediaItem 
{
    SpecialId = "M008", 
    UserId = "U002", 
    Title = "Pink Floyd - Dark Side of the Moon", 
    Genre = "Progressive Rock", 
    Year = 1973, 
    Type = MediaType.CD
};

var shawshank = new MediaItem 
{
    SpecialId = "M009", 
    UserId = "U002", 
    Title = "The Shawshank Redemption", 
    Genre = "Drama", 
    Year = 1994, 
    Type = MediaType.Movie
};

var theSimpsons = new MediaItem 
{
    SpecialId = "M010", 
    UserId = "U002", 
    Title = "The Simpsons", 
    Genre = "Comedy", 
    Year = 1989, 
    Type = MediaType.TVShow
};

var theMatrix = new MediaItem 
{
    SpecialId = "M011", 
    UserId = "U003", 
    Title = "The Matrix", 
    Genre = "Sci-Fi", 
    Year = 1999, 
    Type = MediaType.Movie
};

var godfather = new MediaItem 
{
    SpecialId = "M012", 
    UserId = "U003", 
    Title = "The Godfather", 
    Genre = "Crime", 
    Year = 1972, 
    Type = MediaType.Movie
};

var friends = new MediaItem 
{
    SpecialId = "M013", 
    UserId = "U003", 
    Title = "Friends", 
    Genre = "Comedy", 
    Year = 1994, 
    Type = MediaType.TVShow
};

var lordOfTheRings = new MediaItem 
{
    SpecialId = "M014", 
    UserId = "U003", 
    Title = "Lord of the Rings", 
    Genre = "Fantasy", 
    Year = 2001, 
    Type = MediaType.Book
};

var darkKnight = new MediaItem 
{
    SpecialId = "M015", 
    UserId = "U003", 
    Title = "The Dark Knight", 
    Genre = "Action", 
    Year = 2008, 
    Type = MediaType.Movie
};


            context.Media.AddRange(abbeyRoad, nineteenEightyFour, theMatrix, darkKnight);

            // Create Users and assign MediaShelves
           var alice = new User 
            {
                Id = "U001",
                Name = "Alice", 
                LastName = "Johnson",
                Email = "alice.johnson@example.com",
                Phone = "555-123-4567",
                Address = "123 Maple Street, Springfield, USA",
                BirthDate = "4/12/1985",
                PasswordHash = "0M0l4Xaq.BlsFyUDyMyuBWvztTmg8VuheY8occ.reRuOK2V5HVK"
            };

            var bob = new User 
            {
                Id = "U002",
                Name = "Bob", 
                LastName = "Smith",
                Email = "bob.smith@example.com",
                Phone = "555-234-5678",
                Address = "456 Oak Avenue, Greenville, USA",
                BirthDate = "4/12/1985",
                PasswordHash = "$2y$10$y/0M0l4Xaq.BlsFyUDyMyuBWvztTmg8VuheY8occ.reRuOK2V5HVK"
            };

            var charlie = new User 
            {
                Id = "U003",
                Name = "Charlie",
                LastName = "Davis",
                Email = "charlie.davis@example.com",
                Phone = "555-345-6789",
                Address = "789 Pine Road, Riverdale, USA",
                BirthDate = "4/12/1985",
                PasswordHash = "$2y$10$y/0M0l4Xaq.BlsFyUDyMyuBWvztTmg8VuheY8occ.reRuOK2V5HVK"
            };

            var diana = new User 
            {
                Id = "U004",
                Name = "Diana",
                LastName = "Martinez",
                Email = "diana.martinez@example.com",
                Phone = "555-456-7890",
                Address = "321 Birch Lane, Phoenix, USA",
                BirthDate = "4/12/1985",
                PasswordHash = "$2y$10$y/0M0l4Xaq.BlsFyUDyMyuBWvztTmg8VuheY8occ.reRuOK2V5HVK"
            };

            var evan = new User 
            {
                Id = "U005",
                Name = "Evan",
                LastName = "Roberts",
                Email = "evan.roberts@example.com",
                Phone = "555-567-8901",
                Address = "654 Cedar Blvd, Dallas, USA",
                BirthDate = "4/12/1985",
                PasswordHash = "$2y$10$y/0M0l4Xaq.BlsFyUDyMyuBWvztTmg8VuheY8occ.reRuOK2V5HVK"
            };

            var fiona = new User 
            {
                Id = "U006",
                Name = "Fiona",
                LastName = "Harris",
                Email = "fiona.harris@example.com",
                Phone = "555-678-9012",
                Address = "987 Elm Street, Austin, USA",
                BirthDate = "4/12/1985",
                PasswordHash = "$2y$10$y/0M0l4Xaq.BlsFyUDyMyuBWvztTmg8VuheY8occ.reRuOK2V5HVK"
            };

            var george = new User 
            {
                Id = "U007",
                Name = "George",
                LastName = "Miller",
                Email = "george.miller@example.com",
                Phone = "555-789-0123",
                Address = "123 Willow Road, Chicago, USA",
                BirthDate = "4/12/1985",
                PasswordHash = "$2y$10$y/0M0l4Xaq.BlsFyUDyMyuBWvztTmg8VuheY8occ.reRuOK2V5HVK"
            };

            var hannah = new User 
            {
                Id = "U008",
                Name = "Hannah",
                LastName ="Gonzalez", 
                Email = "hannah.gonzalez@example.com",
                Phone = "555-890-1234",
                Address = "432 Pine Avenue, Seattle, USA",
                BirthDate = "4/12/1985",
                PasswordHash = "$2y$10$y/0M0l4Xaq.BlsFyUDyMyuBWvztTmg8VuheY8occ.reRuOK2V5HVK"
            };

            var isaac = new User 
            {
                Id = "U009",
                Name = "Isaac",
                LastName ="Taylor", 
                Email = "isaac.taylor@example.com",
                Phone = "555-901-2345",
                Address = "567 Oak Street, Boston, USA",
                BirthDate = "4/12/1985",
                PasswordHash = "$2y$10$eHnUSER5iWjDqh8VwZkLYO3u81LUQlsEX3OYWWcxhfmZcm8NAaWBa"
            };

            var jenna = new User 
            {
                Id = "U010",
                Name = "Jenna",
                LastName ="White", 
                Email = "jenna.white@example.com",
                Phone = "555-012-3456",
                Address = "876 Maple Drive, Miami, USA",
                BirthDate = "4/12/1985",
                PasswordHash = "$2y$10$y/0M0l4Xaq.BlsFyUDyMyuBWvztTmg8VuheY8occ.reRuOK2V5HVK"
            };

            context.User.AddRange(alice, jenna);

            // Save Changes
            context.SaveChanges();
        }
    }
}