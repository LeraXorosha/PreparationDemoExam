using AirTravel.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirTravel.Models.Entities
{
	public class JetType : NotifyProperty
	{
		private int _id;
		private string _name = null!;

		private int _seatCapacityEconomy;

		private int _seatCapacityBusiness;


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

		public string Name {
			get => _name;
			set
			{
				if (_name != value)
				{
					_name = value;
					OnPropertyChanged();
				}
			}
		}

		[NotMapped]
		public int MaximumSeats {
			get => _seatCapacityEconomy + _seatCapacityBusiness;
			
		}

		public int SeatCapacityEconomy {
			get => _seatCapacityEconomy;
			set
			{
				if (_seatCapacityEconomy != value)
				{
					_seatCapacityEconomy = value;
					OnPropertyChanged();
				}
			}
		}

		public int SeatCapacityBusiness {
			get => _seatCapacityBusiness;
			set
			{
				if (_seatCapacityBusiness != value)
				{
					_seatCapacityBusiness = value;
					OnPropertyChanged();
				}
			}
		}

	}
}