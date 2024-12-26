using AirTravel.Models;
using AirTravel.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AirTravel.ViewModels
{
	public class AddTicketViewModel
	{
		Database db = Database.getInstance();
		public ObservableCollection<JetType> JetTypes { get => db.JetTypes.Local.ToObservableCollection(); }
		public ObservableCollection<Flight> Flights { get => db.Flights.Local.ToObservableCollection(); }
		public ObservableCollection<ComfortClass> ComfortClasses { get => db.ComfortClasses.Local.ToObservableCollection(); }
		public ObservableCollection<User> Users { get => db.Users.Local.ToObservableCollection(); }

		public Ticket Ticket { get; set; } = new Ticket();
		public Flight Flight { get; set; } = new Flight();
	}
}
