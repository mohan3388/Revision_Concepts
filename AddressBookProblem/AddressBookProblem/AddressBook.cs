using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookProblem
{
    public class AddressBook
    {
        List<Contact> Book = new List<Contact>();
        public void AddBook()
        {
            Contact contact1 = new Contact()
            {
                firstName = "mohan",
                lastName = "sahu",
                Address = "green valey",
                City = "bhilai",
                State = "cg",
                Email = "sahu@12gmail.com",
                Zip = 124519,
                Phone = 7445515529

            };
            Contact contact2 = new Contact()
            {
                firstName = "rajesh",
                lastName = "sah",
                Address = "devendra nagar",
                City = "raipur",
                State = "cg",
                Email = "raj@gmail.com",
                Zip = 231450,
                Phone = 7898625487
            };
            Book.Add(contact1);
            Book.Add(contact2);
        }
        public void DisplayBook()
        {
            foreach (var contact in Book)
            {
                Console.WriteLine(contact.firstName + " " + contact.lastName + " " + contact.Address + " " + contact.City + " " + contact.State + " " + contact.Email + " " + contact.Zip + " " + contact.Phone);
            }
        }
    }
}
