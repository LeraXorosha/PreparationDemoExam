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

namespace Demo2.View
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			FrameMain.Navigate(new Pages.Authorization());
		}

		private void ButtonBack_Click(object sender, RoutedEventArgs e)
		{
			FrameMain.GoBack();
        }

		private void ButtonExit_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void FrameMain_ContentRendered(object sender, EventArgs e)
		{
			if (FrameMain.CanGoBack)
			{
				ButtonBack.Visibility = Visibility.Visible;
			}
			else
			{
				ButtonBack.Visibility = Visibility.Hidden;
			}
		}
	}
}
