using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using AnimalsApp.Models.Data;
using AnimalsApp.Models;
using System.Threading.Tasks;
using System.ComponentModel;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Media.Media3D;
using System.Windows.Input;
using AnimalsApp.Views;
using Microsoft.EntityFrameworkCore;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;


namespace AnimalsApp.ViewModels
{
	public class AnimalViewModel : NotifyProperty
	{
		private ObservableCollection<Animal> _animals;
		DataBase db = DataBase.getInstance();

		private Animal _selectedAnimal;
		private string _searchTerm;
		private string _selectedClass;
		private string _selectedFamily;
		private string _selectedNutrition;
		private bool _isFiltering = false;

		// Для добавления нового животного
		public Animal NewAnimal { get; set; } = new Animal();

		// Свойства для доступных классов, типов питания и семейств
		public List<string> AvailableClasses { get; } = new List<string>()
		{
			""
		}; 

		public List<string> AvailableNutritions { get; } = new List<string>()
		{
			""
		}; 

		public List<string> AvailableFamilies { get; } = new List<string>()
		{
			""
		}; 

		// Свойство для хранения данных из базы данных
		public ObservableCollection<Animal> AnimalsData
		{
			get => _animals;
			set
			{
				_animals = value;
				OnPropertyChanged();
				OnPropertyChanged(nameof(FilteredAnimals)); 
			}
		}

		public IEnumerable<Animal> FilteredAnimals
		{
			get
			{
				if (_isFiltering) return _animals; // Если фильтрация уже выполняется, возвращаем текущую коллекцию

				_isFiltering = true; // Устанавливаем флаг фильтрации
				try
				{
					var filtered = _animals.Where(a =>
						(string.IsNullOrEmpty(_searchTerm) || a.Name.ToLower().Contains(_searchTerm.ToLower())) &&
						(string.IsNullOrEmpty(_selectedClass) || a.Class.Name == _selectedClass) &&
						(string.IsNullOrEmpty(_selectedFamily) || a.Family == _selectedFamily) &&
						(string.IsNullOrEmpty(_selectedNutrition) || a.Nutrition.Name == _selectedNutrition));

					return filtered.ToList(); // Преобразуем в List для корректного отображения в ListView
				}
				finally
				{
					_isFiltering = false; // Сбрасываем флаг
				}
			}
		}

		// Конструктор
		public AnimalViewModel()
		{

			// Загрузите животных из базы данных
			LoadAnimalsFromDatabase();

			// Заполните AvailableClasses, AvailableNutritions и AvailableFamilies из базы данных
			LoadAvailableDataFromDatabase();

			// Инициализируйте команды
			EditCommand = new RelayCommand(EditAnimal);
			DeleteCommand = new RelayCommand(DeleteAnimal);
			AddAnimalCommand = new RelayCommand(AddAnimal);
		}

		// Метод для загрузки животных из базы данных
		private void LoadAnimalsFromDatabase()
		{
			try
			{
				AnimalsData = new ObservableCollection<Animal>(db.Animals.ToList());
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Ошибка при загрузке животных: {ex.Message}");
			}
		}

		// Метод для загрузки доступных классов, типов питания и семейств из базы данных
		private void LoadAvailableDataFromDatabase()
		{
			try
			{ 
				// Загрузите доступные классы
				AvailableClasses.Clear(); // Очистите список
				AvailableClasses.AddRange(db.Classes.Select(c => c.Name).Distinct()); // Добавьте уникальные классы из базы

				// Загрузите доступные типы питания
				AvailableNutritions.Clear();
				AvailableNutritions.AddRange(db.Nutritions.Select(n => n.Name).Distinct());

				// Загрузите доступные семейства
				AvailableFamilies.Clear();
				AvailableFamilies.AddRange(db.Animals.Select(a => a.Family).Distinct()); // Используйте Distinct для уникальных значений
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Ошибка при загрузке доступных данных: {ex.Message}");
			}
		}

		// Свойства для выбранных значений фильтров
		public Animal SelectedAnimal
		{
			get => _selectedAnimal;
			set
			{
				_selectedAnimal = value;
				OnPropertyChanged();
				OnPropertyChanged(nameof(FilteredAnimals));
			}
		}

		public string SearchTerm
		{
			get => _searchTerm;
			set
			{
				_searchTerm = value;
				OnPropertyChanged();
				OnPropertyChanged(nameof(FilteredAnimals));
			}
		}

		public string SelectedClass
		{
			get => _selectedClass;
			set
			{
				_selectedClass = value;
				OnPropertyChanged();
				OnPropertyChanged(nameof(FilteredAnimals));
			}
		}

		public string SelectedNutrition
		{
			get => _selectedNutrition;
			set
			{
				_selectedNutrition = value;
				OnPropertyChanged();
				OnPropertyChanged(nameof(FilteredAnimals));
			}
		}

		public string SelectedFamily
		{
			get => _selectedFamily;
			set
			{
				_selectedFamily = value;
				OnPropertyChanged();
				OnPropertyChanged(nameof(FilteredAnimals));
			}
		}

		// Команда для редактирования животного
		public ICommand EditCommand { get; set; }
		private void EditAnimal(object obj)
		{
			var vm = new AddEditAnimalViewModel
			{
				MainVM = this,
				Animal = (Animal)obj
			};
			if (new AddAnimalWindow { DataContext = vm }.ShowDialog() != true)
				return;

			// Обновление животного в базе данных
			UpdateAnimal(vm.Animal);
			OnPropertyChanged(nameof(FilteredAnimals));
			OnPropertyChanged(nameof(AnimalsData));
		}

		// Команда для удаления животного
		public ICommand DeleteCommand { get; set; }
		private void DeleteAnimal(object obj)
		{
			var animal = (Animal)obj;

			// Удаление животного из базы данных
			DeleteAnimalFromDatabase(animal.Id);

			// Удаление животного из коллекции
			AnimalsData.Remove(animal);
			OnPropertyChanged(nameof(FilteredAnimals));
			OnPropertyChanged(nameof(AnimalsData));
		}

		// Команда для добавления нового животного
		public ICommand AddAnimalCommand { get; private set; }
		private void AddAnimal(object obj)
		{

			var vm = new AddEditAnimalViewModel
			{
				MainVM = this,
			};

			if (new AddAnimalWindow { DataContext = vm }.ShowDialog() != true)
				return;

			AddAnimalToDatabase(vm.Animal);
			OnPropertyChanged(nameof(AnimalsData));
			OnPropertyChanged(nameof(FilteredAnimals));
		}

		// Методы для работы с базой данных
		private void UpdateAnimal(Animal animal)
		{
			try
			{
				db.Entry(animal).State = EntityState.Modified;
				db.SaveChanges();
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Ошибка при обновлении животного: {ex.Message}");
			}
		}

		private void DeleteAnimalFromDatabase(int id)
		{
			try
			{
				Animal animalToDelete = db.Animals.Find(id);
				if (animalToDelete != null)
				{
					db.Animals.Remove(animalToDelete);
					db.SaveChanges();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Ошибка при удалении животного: {ex.Message}");
			}
		}

		private void AddAnimalToDatabase(Animal animal)
		{
			try
			{
				db.Animals.Add(animal);
				db.SaveChanges();
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Ошибка при добавлении животного: {ex.Message}");
			}
		}
	}
}
