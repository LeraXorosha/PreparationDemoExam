using AirTravel.Models.Entities;
using AirTravel.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTravel.ViewModels
{
    class FlightAddEditViewModel
    {
		Database db = Database.getInstance();
		public ObservableCollection<JetType> JetTypes { get => db.JetTypes.Local.ToObservableCollection(); }

		public Flight Flight { get; set; } = new Flight();
	}
}
