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
					TransmissionType = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
					ImageUrl = "https://res.cloudinary.com/dkscwnhd9/image/upload/v1700475328/DotNet%20API/hxsu50sgmt5onrl3p1p8.jpg",
					Occupancy = 4,
					Rate = 200,
					ReleaseYear = new DateTime(2018, 01, 01),
					Classification = "Sedan",
					CreatedDate = DateTime.Now
				},
				new CarModel
				{
					Id = 2,
					Name = "Ford Explorer",
					TransmissionType = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
					ImageUrl = "https://res.cloudinary.com/dkscwnhd9/image/upload/v1700475327/DotNet%20API/sopj1bycevitusiddh0n.jpg",
					Occupancy = 4,
					Rate = 500,
					ReleaseYear = new DateTime(2019, 02, 01),
					Classification = "SUV",
					CreatedDate = DateTime.Now
				},
				new CarModel
				{
					Id = 3,
					Name = "Ford Mustang",
					TransmissionType = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
					ImageUrl = "https://res.cloudinary.com/dkscwnhd9/image/upload/v1700475327/DotNet%20API/zq2f27omunuan1lba1tg.jpg",
					Occupancy = 2,
					Rate = 200,
					ReleaseYear = new DateTime(2019, 03, 01),
					Classification = "Convertible",
					CreatedDate = DateTime.Now
				},
				new CarModel
				{
					Id = 4,
					Name = "Chrysler 300",
					TransmissionType = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
					ImageUrl = "https://res.cloudinary.com/dkscwnhd9/image/upload/v1700475328/DotNet%20API/l5zxmoivfspke86qmu9b.jpg",
					Occupancy = 4,
					Rate = 300,
					ReleaseYear = new DateTime(2014, 04, 05),
					Classification = "Sedan",
					CreatedDate = DateTime.Now
				},
				new CarModel
				{
					Id = 5,
					Name = "Volkswagen Jetta",
					TransmissionType = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
					ImageUrl = "https://res.cloudinary.com/dkscwnhd9/image/upload/v1700475328/DotNet%20API/nhobn79bdvgoasgwtxvt.jpg",
					Occupancy = 4,
					Rate = 290,
					ReleaseYear = new DateTime(2017, 05, 01),
					Classification = "Sedan",
					CreatedDate = DateTime.Now
				}
			);
		}
	}
}
