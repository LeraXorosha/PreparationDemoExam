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
	/// Логика взаимодействия для AddEditRequestPage.xaml
	/// </summary>
	public partial class AddEditRequestPage : Page
	{
		private Заявки _currentRequest = new Заявки();

		public AddEditRequestPage(Заявки selectedRequest)
		{
			InitializeComponent();
			if (selectedRequest != null)
				_currentRequest = selectedRequest;

			DataContext = _currentRequest;
			ComboClient.ItemsSource = Demo2Entities.GetContext().Клиент.ToList();
			ComboEmployee.ItemsSource = Demo2Entities.GetContext().Сотрудник.ToList();
			ComboTypeClean.ItemsSource = Demo2Entities.GetContext().C_Тип_уборки_.ToList();
			ComboAddress.ItemsSource = Demo2Entities.GetContext().Помещение.ToList();
			//DGridService.ItemsSource = Demo2Entities.GetContext().C_Услуги_в_зявке_.ToList();


			//var servicesForRequest = (selectedRequest.Id); // Метод получения услуг по ID заявки
			//DGridService.ItemsSource = servicesForRequest;
		}

		private void BtnSave_Click(object sender, RoutedEventArgs e)
		{
			StringBuilder errors = new StringBuilder();

			if (_currentRequest.Клиент == null)
				errors.AppendLine("Выбеите клиента");
			if (_currentRequest.Помещение == null)
				errors.AppendLine("Выбеите адрес помещения");
			if (_currentRequest.Дата_исполнения == null)
				errors.AppendLine("Введите дату исполнения заявки");
			if (_currentRequest.Сотрудник == null)
				errors.AppendLine("Выбеите исполнителя");
			if (_currentRequest.C_Тип_уборки_ == null)
				errors.AppendLine("Выбеите тип уборки");

			if (errors.Length > 0)
			{
				MessageBox.Show(errors.ToString());
				return;
			}

			if (_currentRequest.Id == 0)
			{
				Demo2Entities.GetContext().Заявки.Add(_currentRequest);
			}

			try
			{
				Demo2Entities.GetContext().SaveChanges();
				MessageBox.Show("Информация успешно сохранена!");
				NavigationService.GoBack();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void BtnCreatrClient_Click(object sender, RoutedEventArgs e)
		{
			//NavigationService.Navigate(new AddEditClientPage(null));
		}
	}
}
