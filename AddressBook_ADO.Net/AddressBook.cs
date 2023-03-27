using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook_ADO.Net
{
    public class AddressBook
    {
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AddressBook_Service";
        public void AddNewContactInDataBase(AddressBookModel addressBookModel)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                using (sqlConnection)
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("SpAddingNewData", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@FirstName", addressBookModel.FirstName);
                    sqlCommand.Parameters.AddWithValue("@LastName", addressBookModel.LastName);
                    sqlCommand.Parameters.AddWithValue("@Address", addressBookModel.Address);
                    sqlCommand.Parameters.AddWithValue("@City", addressBookModel.City);
                    sqlCommand.Parameters.AddWithValue("@State", addressBookModel.State);
                    sqlCommand.Parameters.AddWithValue("@Zip", addressBookModel.Zip);
                    sqlCommand.Parameters.AddWithValue("@PhoneNumber", addressBookModel.PhoneNumber);
                    sqlCommand.Parameters.AddWithValue("@Email", addressBookModel.Email);

                    int result = sqlCommand.ExecuteNonQuery();      //Execute stored procedure
                    sqlConnection.Close();
                    if (result >= 1)
                        Console.WriteLine("New contact added successfully.");
                    else
                        Console.WriteLine("Error while adding");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
