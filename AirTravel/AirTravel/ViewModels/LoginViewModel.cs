using AirTravel.Models;
using AirTravel.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;



namespace AirTravel.ViewModels
{
	public class LoginViewModel
	{
		public Database db = Database.getInstance();
		public string Login { get; set; }
		public string Password { get; set; }

		public LoginViewModel()
		{
			LoginCommand = new RelayCommand(LogIn);
		}
		public RelayCommand LoginCommand { get; set; }
		void LogIn(object o)
		{
			var u = db.Users.Where(x => x.Login == Login && x.Password == Password).FirstOrDefault();
			if (u != null)
			{
				if (u.Role.Name == "Admin" )
				{
					var w = new MainWindow();
					w.Show();
					Application.Current.MainWindow.Close();
					Application.Current.MainWindow = w;
				}
				else
				{
					var w = new FlightUserWindow() { DataContext = new FlightUserViewModel() };
					w.Show();
					Application.Current.MainWindow.Close();
					Application.Current.MainWindow = w;
				}
			}
			else
				MessageBox.Show("Incorrect login/password");
		}
	}
}
