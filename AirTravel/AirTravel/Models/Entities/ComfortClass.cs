using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTravel.Models.Entities
{
	public class ComfortClass : NotifyProperty
	{
		private int _id;

		private string _name = null!;

		private int _price;

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

		public int Price {
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
