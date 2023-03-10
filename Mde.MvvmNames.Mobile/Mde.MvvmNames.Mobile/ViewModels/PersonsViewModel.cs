using FreshMvvm;
using Mde.MvvmNames.Mobile.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Mde.MvvmNames.Mobile.ViewModels
{
    public class PersonsViewModel : FreshBasePageModel
    {
		protected readonly RandomNameGenerator randomNameGenerator;

		public PersonsViewModel()
		{
			persons = new ObservableCollection<Person>();
            randomNameGenerator = new RandomNameGenerator();

        }

		private ObservableCollection<Person> persons;

        public ObservableCollection<Person> Persons
		{
			get { return persons; }
			set { 
				persons = value;
				RaisePropertyChanged();
			}
		}

        protected override async void ViewIsAppearing(object sender, EventArgs e)
        {
			int numberOfNames = 42;
			for(int i = 0; i < numberOfNames; i++)
			{
				//generate a random person
				var name = randomNameGenerator.GetRandomName();
				var names = name.Split(' ');
				var person = new Person
				{
					GivenName = names[0],
					SurName = names[1],
				};
				
				//add person to collection
				Persons.Add(person);

				await Task.Delay(1000);
			}


            base.ViewIsAppearing(sender, e);
        }


    }
}
