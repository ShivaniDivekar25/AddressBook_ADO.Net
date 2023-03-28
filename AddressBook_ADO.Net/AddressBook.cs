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
        public void GetAllDataFromDB()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                List<AddressBookModel> addressBookList = new List<AddressBookModel>();
                using (sqlConnection)
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("SpGetAllData", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sqlReader = sqlCommand.ExecuteReader();
                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {
                            AddressBookModel addressBookModel = new AddressBookModel();
                            addressBookModel.FirstName = sqlReader.GetString(0);
                            addressBookModel.LastName = sqlReader.GetString(1);
                            addressBookModel.Address = sqlReader.GetString(2);
                            addressBookModel.City = sqlReader.GetString(3);
                            addressBookModel.State = sqlReader.GetString(4);
                            addressBookModel.Zip = sqlReader.GetInt32(5);
                            addressBookModel.PhoneNumber = sqlReader.GetInt64(6);
                            addressBookModel.Email = sqlReader.GetString(7);

                            addressBookList.Add(addressBookModel);
                        }
                        foreach (AddressBookModel contact in addressBookList)
                        {
                            Console.WriteLine(contact.FirstName + " " + contact.LastName + " " + contact.Address + " " + contact.City + " " + contact.State + " " + contact.Zip);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found in table");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void DeleteSpecificData(string firstName,string lastName)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                using (sqlConnection)
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("SpSpecificDataFromDB", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@FirstName", firstName);
                    sqlCommand.Parameters.AddWithValue("@LastName", lastName);
                    int result = sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();

                    if(result >= 1)
                        Console.WriteLine("Data deleted successfully");
                    else
                        Console.WriteLine("Error occur while deleting data");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void UpdateSpecificData(AddressBookModel addressBookModel)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                using (sqlConnection)
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("SpUpdateSpecificData", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@FirstName", addressBookModel.FirstName);
                    sqlCommand.Parameters.AddWithValue("@LastName", addressBookModel.LastName);
                    int result = sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();

                    if (result >= 1)
                        Console.WriteLine("Data updated successfully");
                    else
                        Console.WriteLine("Data not fount to update");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
