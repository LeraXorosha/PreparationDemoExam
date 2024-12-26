using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsApp.Models.Data
{
	public class Animal : NotifyProperty
	{
		private int _id;
		private string _name = null!;
		private string _description = null!;
		private string _imagePath = null!;
		private Class _class = null!;
		private Nutrition _nutrition = null!;
		private string _family = null!;

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
		public string Description {
			get => _description;
			set
			{
				if (_description != value)
				{
					_description = value;
					OnPropertyChanged();
				}
			}
		}
		public string ImagePath {
			get => _imagePath;
			set
			{
				if (_imagePath != value)
				{
					_imagePath = value;
					OnPropertyChanged();
				}
			}
		}

		public Class Class
		{
			get => _class;
			set
			{
				if (_class != value)
				{
					_class = value;
					OnPropertyChanged();
				}
			}
		}

		public Nutrition Nutrition
		{
			get => _nutrition;
			set
			{
				if (_nutrition != value)
				{
					_nutrition = value;
					OnPropertyChanged();
				}
			}
		}

		public string Family
		{
			get => _family;
			set
			{
				if (_family != value)
				{
					_family = value;
					OnPropertyChanged();
				}
			}
		}
	}
}

