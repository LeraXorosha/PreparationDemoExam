using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AnimalsApp.Models.Data;

namespace AnimalsApp.Models
{
	public class DataBase : DbContext
	{
		public DbSet<Animal> Animals { get; set; } = null!;
		public DbSet<Class> Classes { get; set; } = null!;
		public DbSet<Nutrition> Nutritions { get; set;} = null!;

		private static DataBase? instance;
		public static DataBase getInstance()
		{
			if (instance == null)
			{
				instance = new DataBase();
				instance.Database.EnsureDeleted();

				var exists = instance.Database.EnsureCreated();
				instance.Animals.Load();
				instance.Classes.Load();
				instance.Nutritions.Load();



				if (exists)
					instance.Nutritions.AddRange(NutritionData);
				instance.Classes.AddRange(ClassData);
				instance.Animals.AddRange(AnimalData);


				instance.SaveChanges();
			}
			return instance;
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=LAPTOP-V2HVEM5K\SQLEXPRESS;Database=AnimalsApp;Trusted_Connection=True; TrustServerCertificate=True");
		}


		static List<Class> ClassData = new()
		{
			new Class() {Name = ""},
			new Class() {Name = "Рыбы"},
			new Class() {Name = "Земноводные"},
			new Class() {Name = "Птицыы"},
			new Class() {Name = "Рептилии"},
			new Class() {Name = "Млекопитающие"},
		};

		static List<Nutrition> NutritionData = new()
		{
			new Nutrition() {Name = ""},
			new Nutrition() {Name = "Растительноядные"},
			new Nutrition() {Name = "Хищники"},
			new Nutrition() {Name = "Всеядные"},
			new Nutrition() {Name = "Симбионты"},
			new Nutrition() {Name = "Паразиты"},
			new Nutrition() {Name = "Падальщики"},
		};


		static List<Animal> AnimalData = new()
		{
			new Animal() {
				Name = "Жираф",
				Description = "Жирафы - самые высокие млекопитающие на Земле.",
				ImagePath = "D:\\Work\\AnimalsApp\\AnimalsApp\\images\\navy_seal.jpg",
				Class =  ClassData[4],
				Nutrition = NutritionData[0],
				Family = "Жирафовые"},

			new Animal() {
				Name = "Морской котик",
				Description = "Обитают вдоль умеренных и арктических морских побережий Северного полушария.",
				ImagePath = "/images/navy_seal.jpg",
				Class = ClassData[4],
				Nutrition = NutritionData[2],
				Family = "Ластоногие"},

			new Animal() {
				 Name = "Бурый медведь",
				 Description = "Один из самых крупных наземных хищников.",
				 ImagePath = "/images/bear.jpg",
				 Class = ClassData[4],
				 Nutrition = NutritionData[1],
				 Family = " Медвежьи"}

		};
		
	
	}
}
