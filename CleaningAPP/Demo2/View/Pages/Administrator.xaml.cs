using Demo2.Model;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Demo2.View.Pages
{
	/// <summary>
	/// Логика взаимодействия для Administrator.xaml
	/// </summary>
	public partial class Administrator : Page
	{
		public Administrator()
		{
			InitializeComponent();
			var allClient = Demo2Entities.GetContext().Клиент.OrderBy(p=>p.ФИО).ToList();
			allClient.Insert(0, new Клиент {ФИО = "Все клиенты"});
			ComboClient.ItemsSource = allClient;
			ComboClient.SelectedIndex = 0;
			SortSquare.SelectedIndex = 0;
			UpdateRequest();
		}

		private void UpdateRequest()
		{

			var currentRequest = Demo2Entities.GetContext().Заявки.ToList();
			CountRequest.Text = $"{currentRequest.Count()}";
			var selectedClient = ComboClient.SelectedItem as Клиент;

			if (ComboClient.SelectedIndex > 0)
			{
				currentRequest = currentRequest.Where(p => p.Клиент1 != null &&p.Клиент1.ФИО.Contains(selectedClient.ФИО)).ToList();
			}

			if(SortSquare.SelectedIndex == 1)
			{
				currentRequest = currentRequest.OrderBy(p => p.Помещение1.Площадь).ToList();
			}
			else if(SortSquare.SelectedIndex == 2)
			{
				currentRequest = currentRequest.OrderByDescending(p => p.Помещение1.Площадь).ToList();
			}
			

			if (TBoxSearch != null)
			{
				currentRequest = currentRequest.Where(p => p.Помещение1.Адрес.Contains(TBoxSearch.Text)).ToList();
			}

			CountRequest.Text = $"{currentRequest.Count()}";

			if (currentRequest.Count() == 0)
			{
				NoResultsText.Text = "НЕ НАЙДЕНО";
				NoResultsText.Visibility = Visibility.Visible;
			}
			else
			{
				NoResultsText.Visibility = Visibility.Collapsed;
			}
			DGridRequests.ItemsSource = currentRequest;
		}
		private void BtnEdit_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new Pages.AddEditRequestPage((sender as Button).DataContext as Заявки));

		}

		private void BtnAdd_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new Pages.AddEditRequestPage(null));
		}

		private void BtnDelete_Click(object sender, RoutedEventArgs e)
		{
			var itemToDelete = (sender as Button).DataContext as Заявки;
			
			if (MessageBox.Show("Вы точно хотите удалить этот элемент?", "Внимание!!!",
				MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
			{
				try
				{
					
					Demo2Entities.GetContext().Заявки.Remove(itemToDelete);
					Demo2Entities.GetContext().SaveChanges();
					MessageBox.Show("Данные удалены!");

					var relatedServices = Demo2Entities.GetContext().C_Услуги_в_зявке_.Where(s => s.Номер_заявки == itemToDelete.Id);
					foreach (var service in relatedServices)
					{
						Demo2Entities.GetContext().C_Услуги_в_зявке_.Remove(service);
					}

					DGridRequests.ItemsSource = Demo2Entities.GetContext().Заявки.ToList();
					DGridServices.ItemsSource = Demo2Entities.GetContext().C_Услуги_в_зявке_.ToList();

				}

				catch (Exception ex)
				{
					MessageBox.Show(ex.Message.ToString());
				}
			}
		}

		private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			if (Visibility == Visibility.Visible)
			{
				Demo2Entities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
				DGridRequests.ItemsSource = Demo2Entities.GetContext().Заявки.ToList();
				DGridServices.ItemsSource = Demo2Entities.GetContext().C_Услуги_в_зявке_.ToList();
			}
		}

		private void ComboClient_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			UpdateRequest();
		}

		private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
		{
			UpdateRequest();
		}


		private void SortSquare_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			UpdateRequest();
		}

		private void ReturnFilter_Click(object sender, RoutedEventArgs e)
		{
			ComboClient.SelectedIndex = 0;
			SortSquare.SelectedIndex = 0;
			TBoxSearch.Text = null;
		}

		
	}
}
