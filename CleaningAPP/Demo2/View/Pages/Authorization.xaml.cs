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
	/// Логика взаимодействия для Authorization.xaml
	/// </summary>
	public partial class Authorization : Page
	{
		public Authorization()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{

        }

		private void Btn_Login(object sender, RoutedEventArgs e)
		{
			var context = Demo2Entities.GetContext();

			var user = context.Пользователь.FirstOrDefault(u => u.Пароль == PasswordTextBox.Password && u.Логин == LoginTextBox.Text);
			if (user == null)
			{
				MessageBox.Show("Ошибка!!! Введите корректный логин и пароль");
				return;
			}


			if (user.Роль == 3)
			{
				NavigationService.Navigate(new Pages.Administrator());
			}



		}

		private void BtnRegistr(object sender, RoutedEventArgs e)
		{
	
        }
    }
}
