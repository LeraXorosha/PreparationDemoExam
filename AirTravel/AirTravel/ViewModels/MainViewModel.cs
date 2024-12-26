using AirTravel.Models.Entities;
using AirTravel.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTravel.Views;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;


namespace AirTravel.ViewModels
{
	public class MainViewModel : NotifyProperty
	{
		Database db = Database.getInstance();
		public ObservableCollection<Flight> Flights { get => db.Flights.Local.ToObservableCollection(); }
		public ObservableCollection<Ticket> Tickets { get => db.Tickets.Local.ToObservableCollection(); }

		public MainViewModel()
		{
			AddCommand = new(Add);
			EditCommand = new(Edit);
			DeleteCommand = new(Delete);
			AddTicketCommand = new(AddTicket);

		}

		public RelayCommand AddCommand { get; set; }
		public RelayCommand EditCommand { get; set; }
		public RelayCommand DeleteCommand { get; set; }
		public RelayCommand AddTicketCommand { get; set; }


		void Add(object obj)
		{
			var vm = new FlightAddEditViewModel();
			if (new FlightAddEditWindow { DataContext = vm}.ShowDialog() != true) return;
			db.Flights.Add(vm.Flight);
			db.SaveChanges();
			OnPropertyChanged(nameof(Flights));
		}
		
		public void Edit(object obj) {
			var vm = new FlightAddEditViewModel(){Flight = (Flight)obj};
			if (new FlightAddEditWindow { DataContext = vm }.ShowDialog() != true) return;
			db.Entry(vm.Flight).State = EntityState.Modified;
			db.SaveChanges();
			OnPropertyChanged(nameof(Flights));
		}
		public void Delete(object obj) {
			db.Flights.Remove((Flight)obj);
			db.SaveChanges();
			OnPropertyChanged(nameof(Flights));
		}


		void AddTicket(object obj)
		{
			var vm = new AddTicketViewModel() { Ticket = new Ticket() { Flight = (Flight)obj } };
			if (new AddTicket { DataContext = vm }.ShowDialog() != true) return;
			db.Tickets.Add(vm.Ticket);
			db.SaveChanges();
			OnPropertyChanged(nameof(Tickets));
		}

	}
}
