using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AirTravel.Models.Entities
{
	public class Ticket : NotifyProperty
	{
		private int _id;

		private Flight _flight = null!;

		private ComfortClass _comfortClass = null!;

		private User _user = null!;

		

		public int Id {
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

		public Flight Flight {
			get => _flight;
			set
			{
				if (_flight != value)
				{
					_flight = value;
					OnPropertyChanged();
				}
			}
		}

		public ComfortClass ComfortClass {
			get => _comfortClass;
			set
			{
				if (_comfortClass != value)
				{
					_comfortClass = value;
					OnPropertyChanged();
				}
			}
		}

		public User User {
			get => _user;
			set
			{
				if (_user != value)
				{
					_user = value;
					OnPropertyChanged();
				}
			}
		}

	}
}
