using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AnimalsApp.ViewModels;
using AnimalsApp.Models;



namespace AnimalsApp
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}


		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			//if (DataContext is not AnimalViewModel vm) return;

			//foreach (var animal in vm.Animals)
			//{
			//	var newUserControl = new AnimalControl(animal);
			//	stckPnlAnimals.Children.Add(newUserControl);
			//}

		}
		private void AddNewAnimal_Click(object sender, RoutedEventArgs e)
		{

		}

		private void EditSelectedAnimal_Click(object sender, RoutedEventArgs e)
		{

		}

		private void DeleteSelectedAnimal_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}