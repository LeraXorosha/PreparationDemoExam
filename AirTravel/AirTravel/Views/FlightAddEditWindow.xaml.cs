﻿using AirTravel.Models.Entities;
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

namespace AirTravel.Views
{
    /// <summary>
    /// Логика взаимодействия для FlightAddEditWindow.xaml
    /// </summary>
    public partial class FlightAddEditWindow : Window
    {
        public FlightAddEditWindow()
        {
            InitializeComponent();
        }

		private void Button_Click(object sender, RoutedEventArgs e)
		{
            DialogResult = true;

        }
    }
}
