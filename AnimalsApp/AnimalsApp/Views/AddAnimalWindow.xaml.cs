using AnimalsApp.ViewModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AnimalsApp.Views
{
    /// <summary>
    /// Логика взаимодействия для AddAnimalWindow.xaml
    /// </summary>
    public partial class AddAnimalWindow : Window
    {
        public AddAnimalWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult=true;
        }

		private void SelectImage_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png";
			if (openFileDialog.ShowDialog() == true)
			{
				//  AddEditAnimalViewModel должен быть доступен в DataContext
				var viewModel = (AddEditAnimalViewModel)DataContext;
				viewModel.Animal.ImagePath = openFileDialog.FileName;
			}
		}
    }
}
