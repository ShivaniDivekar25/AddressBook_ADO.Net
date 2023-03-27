using System.Linq.Expressions;

namespace AddressBook_ADO.Net
{
    internal class Program
    {
        //What is ADO.Net - It is framework. ADO.Net is used to connected between UI and SSMS database.
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book System Using ADO.Net");
            AddressBook addressBook = new AddressBook();
            AddressBookModel addressBookModel = new AddressBookModel()
            {
                FirstName = "Shivani",
                LastName = "Divekar",
                Address = "Dange Chauk",
                City = "Pune",
                State = "Maharastra",
                Zip = 40035,
                PhoneNumber = 8983922703,
                Email = "Shivani@gmail.com"
            };
            Console.WriteLine("Enter an option");
            Console.WriteLine("1:Add new contact");
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    addressBook.AddNewContactInDataBase(addressBookModel);
                    break;
                default:
                    Console.WriteLine("Enter correct option");
                    break;
            }
        }
    }
}