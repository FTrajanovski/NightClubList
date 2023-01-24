using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightClubList
{
    internal class Person
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAdress { get; set; }

        public int PhoneNumber { get; set; }

        public static List<Person> people = new List<Person>();

        public Person(int id, string firstname, string lastname, string emailadress, int phonenumber)
        {
            Id = id;
            FirstName = firstname;
            LastName = lastname;
            EmailAdress = emailadress;
            PhoneNumber = phonenumber;
        }


    }
}
