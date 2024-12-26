using AirTravel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AirTravel.Models.Entities
{
	public class Flight : NotifyProperty
	{
		private int _id;

		private string _departure = null!;

		private string _arrival = null!;

		private DateTime _departureTime;

		private DateTime _arrivalTime;

		private JetType _jetType = null!;

		private int _price;


		public int Id
		{
			get => _id;
			set
			{
				if (_id != value)
				{
					_id = value;
					OnPropertyChanged();
				}
			}
		}

		public string? Departure
		{
			get => _departure;
			set
			{
				if (_departure != value)
				{
					_departure = value;
					OnPropertyChanged();
				}
			}
		}

		public string? Arrival
		{
			get => _arrival;
			set
			{
				if (_arrival != value)
				{
					_arrival = value;
					OnPropertyChanged();
				}
			}
		}

		public DateTime DepartureTime
		{
			get => _departureTime;
			set
			{
				if (_departureTime != value)
				{
					_departureTime = value;
					OnPropertyChanged();
				}
			}
		}

		public DateTime ArrivalTime
		{
			get => _arrivalTime;
			set
			{
				if (_arrivalTime != value)
				{
					_arrivalTime = value;
					OnPropertyChanged();
				}
			}
		}

		public JetType JetType
		{
			get => _jetType;
			set
			{
				if (_jetType != value)
				{
					_jetType = value;
					OnPropertyChanged();
				}
			}
		}
		public int Price
		{
			get => _price;
			set
			{
				if (_price != value)
				{
					_price = value;
					OnPropertyChanged();
				}
			}
		}

		
	}
}
