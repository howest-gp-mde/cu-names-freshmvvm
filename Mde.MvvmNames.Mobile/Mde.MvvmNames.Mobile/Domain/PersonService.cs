using System;
using System.Collections.Generic;
using System.Text;

namespace Mde.MvvmNames.Mobile.Domain
{
    public class PersonService
    {
        private static Person thePerson = new Person
        {
            GivenName = "Joeri",
            SurName = "Schmitzer"
        };

        public Person GetPerson()
        {
            return thePerson;
        }

        public void Save(Person person)
        {
            //fake save person in memory 
            thePerson = new Person { 
                GivenName = person.GivenName,
                SurName = person.SurName 
            };
        }

    }
}
