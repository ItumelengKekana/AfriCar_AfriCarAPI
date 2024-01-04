using AfriCar_AfriCarAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AfriCar_AfriCarAPI.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}

		public DbSet<CarModel> Cars { get; set; }
		public DbSet<CarNumberModel> CarNumbers { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<CarModel>().HasData(
				new CarModel
				{
					Id = 1,
					Name = "Toyota Corolla",
					Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
					ImageUrl = "https://res.cloudinary.com/dkscwnhd9/image/upload/v1700475328/DotNet%20API/hxsu50sgmt5onrl3p1p8.jpg",
					Occupancy = 4,
					Rate = 200,
					ReleaseYear = "2018",
					Classification = "Sedan",
					CreatedDate = DateTime.Now
				},
				new CarModel
				{
					Id = 2,
					Name = "Ford Explorer",
					Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
					ImageUrl = "https://res.cloudinary.com/dkscwnhd9/image/upload/v1700475327/DotNet%20API/sopj1bycevitusiddh0n.jpg",
					Occupancy = 4,
					Rate = 500,
					ReleaseYear = "2019",
					Classification = "SUV",
					CreatedDate = DateTime.Now
				},
				new CarModel
				{
					Id = 3,
					Name = "Ford Mustang",
					Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
					ImageUrl = "https://res.cloudinary.com/dkscwnhd9/image/upload/v1700475327/DotNet%20API/zq2f27omunuan1lba1tg.jpg",
					Occupancy = 2,
					Rate = 200,
					ReleaseYear = "2019",
					Classification = "Convertible",
					CreatedDate = DateTime.Now
				},
				new CarModel
				{
					Id = 4,
					Name = "Chrysler 300",
					Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
					ImageUrl = "https://res.cloudinary.com/dkscwnhd9/image/upload/v1700475328/DotNet%20API/l5zxmoivfspke86qmu9b.jpg",
					Occupancy = 4,
					Rate = 300,
					ReleaseYear = "2014",
					Classification = "Sedan",
					CreatedDate = DateTime.Now
				},
				new CarModel
				{
					Id = 5,
					Name = "Volkswagen Jetta",
					Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
					ImageUrl = "https://res.cloudinary.com/dkscwnhd9/image/upload/v1700475328/DotNet%20API/nhobn79bdvgoasgwtxvt.jpg",
					Occupancy = 4,
					Rate = 290,
					ReleaseYear = "2017",
					Classification = "Sedan",
					CreatedDate = DateTime.Now
				}
			);
		}
	}
}
