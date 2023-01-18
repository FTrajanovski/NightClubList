using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightClubList
{
    public class Person
    {

        public int Id;
        public string FirstName;
        public string LastName;
        public string EmailAdress;
        public int PhoneNumber;

            public Person(int Id, string FirstName, string LastName, string EmailAdress, int PhoneNumber)
            {
            this.Id = Id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.EmailAdress = EmailAdress;
            this.PhoneNumber = PhoneNumber;
             
            }

            
        }
}
