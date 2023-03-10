using FreshMvvm;
using Mde.MvvmNames.Mobile.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Mde.MvvmNames.Mobile.ViewModels
{
    public class NameViewModel : FreshBasePageModel
    {
        protected readonly PersonService personService;
        protected readonly RandomNameGenerator generator;

        public NameViewModel()
        {
            personService = new PersonService();
            generator = new RandomNameGenerator();
        }

        private string firstName = "Test FirstName";
        public string FirstName
        {
            get { return firstName; }
            set { 
                firstName = value;
                RaisePropertyChanged(nameof(FirstName)); 
            }
        }

        private string lastName = "Test LastName";
        public string LastName
        {
            get { return lastName; }
            set { 
                lastName = value;
                RaisePropertyChanged(nameof(LastName));
            }
        }

        public override void Init(object initData)
        {
            base.Init(initData);
        }

        public override void ReverseInit(object returnedData)
        {
            base.ReverseInit(returnedData);
        }

        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
            //this is executed when page is ready for data
            var person = personService.GetPerson();
            FirstName = person.GivenName;
            LastName = person.SurName;

            //_ = Task.Run(async () =>
            //{

            //    while (true)
            //    {

            //        string fullname = generator.GetRandomName();
            //        string[] names = fullname.Split(' ');

            //        FirstName = names[0];
            //        LastName = names[1];

            //        await Task.Delay(1000);
            //    }

            //});

            base.ViewIsAppearing(sender, e);
        }

        public Command NavigateToSettingsCommand => new Command(async () => 
        {
            int parameter = 42;
            await CoreMethods.PushPageModel<SettingsViewModel>(parameter, true);
        });

        public Command NavigateToPersonsCommand => new Command(async () =>
        {
            await CoreMethods.PushPageModel<PersonsViewModel>(true);
        });


        public Command SaveCommand => new Command(() => {
            //this is executed when save is clicked
            var person = new Person()
            {
                GivenName = FirstName,
                SurName = LastName
            };
            personService.Save(person);
        });
    }
}
