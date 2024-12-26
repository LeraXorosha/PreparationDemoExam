using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalsApp.Models;

namespace AnimalsApp.Models.Data
{
	public class Class : NotifyProperty
	{
		private int _id;

		private string _name = null!;

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

		public string Name
		{
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
	}
}
