using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTravel.Models.Entities
{
	public class User : NotifyProperty
	{
		private int _id;

		private string _fullName = null!;

		private DateOnly? _dateBorn;

		private int _passportSeries;
		private int _passportNumber;

		private string _login = null!;

		private string _password = null!;

		private Role _role { get; set; } = null!;

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

		public string FullName
		{
			get => _fullName;
			set
			{
				if (_fullName != value)
				{
					_fullName = value;
					OnPropertyChanged();
				}
			}
		}

		public DateOnly? DateBorn {
			get => _dateBorn;
			set
			{
				if (_dateBorn != value)
				{
					_dateBorn = value;
					OnPropertyChanged();
				}
			}
		}

		public int PassportSeries {
			get => _passportSeries;
			set
			{
				if (_passportSeries != value)
				{
					_passportSeries = value;
					OnPropertyChanged();
				}
			}
		}

		public int PassportNumber {
			get => _passportNumber;
			set
			{
				if (_passportNumber != value)
				{
					_passportNumber = value;
					OnPropertyChanged();
				}
			}
		}

		public string Login {
			get => _login;
			set
			{
				if (_login != value)
				{
					_login = value;
					OnPropertyChanged();
				}
			}
		}

		public string Password {
			get => _password;
			set
			{
				if (_password != value)
				{
					_password = value;
					OnPropertyChanged();
				}
			}
		}

		public Role Role {
			get => _role;
			set
			{
				if (_role != value)
				{
					_role = value;
					OnPropertyChanged();
				}
			}
		}
	}
}
