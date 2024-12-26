using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using AnimalsApp.Models.Data;
using AnimalsApp.Models;


namespace AnimalsApp.ViewModels
{   public class AddEditAnimalViewModel : NotifyProperty
    {

		DataBase db = DataBase.getInstance();
		public ObservableCollection<Class> Classes { get => db.Classes.Local.ToObservableCollection(); }
		public ObservableCollection<Nutrition> Nutritions { get => db.Nutritions.Local.ToObservableCollection(); }


		public Animal Animal { get; set; } = new Animal();


		public AnimalViewModel MainVM { get; set; }
	}
 
}
