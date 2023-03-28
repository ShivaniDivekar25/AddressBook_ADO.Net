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
                Email = "Shivani@gmail.com",
            };
            AddressBookModel addressBookModel1 = new AddressBookModel()
            {
                FirstName = "Shubham",
                LastName = "D",
                Address = "KN",
                City = "Pune",
                State = "Maharastra",
                Zip = 400045,
                PhoneNumber = 8983921256,
                Email = "malhar@gmail.com",
            };
            AddressBookModel addressUpdate = new AddressBookModel
            {
                FirstName = "Mandy",
                LastName = "D"
            };
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Enter an option");
                Console.WriteLine("1:Add new contact\n2:Get all data from DataBase\n3:Delete specific data\n4:Update specific data\n5:Exit");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        addressBook.AddNewContactInDataBase(addressBookModel);
                        addressBook.AddNewContactInDataBase(addressBookModel1);
                        break;
                    case 2:
                        addressBook.GetAllDataFromDB();
                        break;
                    case 3:
                        addressBook.DeleteSpecificData("Shivani","Divekar");
                        break;
                    case 4:
                        addressBook.UpdateSpecificData(addressUpdate);
                        break;
                    case 5:
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Enter correct option");
                        break;
                }
            }
        }
    }
}