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
	public class FlightUserViewModel : NotifyProperty
	{
		Database db = Database.getInstance();
		public ObservableCollection<Flight> Flights { get => db.Flights.Local.ToObservableCollection(); }

	}
}
