#nullable enable

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsBooksData
    {
        public static DataTable GetAllBooks()
        {
            DataTable dt = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT * FROM Books";

            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                    dt.Load(Reader);

                Reader.Close();
            }

            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                Connection.Close();
            }

            return dt;
        }
        public static int AddNewBook(string Author, string Title, string ISBN, DateTime PublicationDate, string Genre, int Quantity, string? AdditionalDetails, string? ImagePath)
        {
            int BookID = -1;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"INSERT INTO Books (Author, Title, ISBN, PublicationDate, Genre, Quantity, AdditionalDetails, ImagePath)
                             VALUES (@Author, @Title, @ISBN, @PublicationDate, @Genre, @Quantity, @AdditionalDetails, @ImagePath);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@Author", Author);
            Command.Parameters.AddWithValue("@Title", Title);
            Command.Parameters.AddWithValue("@ISBN", ISBN);
            Command.Parameters.AddWithValue("@PublicationDate", PublicationDate);
            Command.Parameters.AddWithValue("@Genre", Genre);
            Command.Parameters.AddWithValue("@Quantity", Quantity);

            if (AdditionalDetails != null)
                Command.Parameters.AddWithValue("@AdditionalDetails", AdditionalDetails);
            else
                Command.Parameters.AddWithValue("@AdditionalDetails", System.DBNull.Value);


            if (ImagePath != null)
                Command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                Command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);


            try
            {
                Connection.Open();

                object result = Command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    BookID = insertedID;
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                Connection.Close();
            }

            return BookID;
        }
        public static bool UpdateBook(int BookID, string Author, string Title, string ISBN, DateTime PublicationDate, string Genre, int Quantity, string? AdditionalDetails, string? ImagePath)
        {
            int rowsAffected = 0;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"Update  Books  
                            set Author = @Author, Title = @Title, ISBN = @ISBN, PublicationDate = @PublicationDate, Genre = @Genre, Quantity = @Quantity, AdditionalDetails = @AdditionalDetails, ImagePath = @ImagePath
                                where BookID = @BookID ";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@BookID", BookID);
            Command.Parameters.AddWithValue("@Author", Author);
            Command.Parameters.AddWithValue("@Title", Title);
            Command.Parameters.AddWithValue("@ISBN", ISBN);
            Command.Parameters.AddWithValue("@PublicationDate", PublicationDate);
            Command.Parameters.AddWithValue("@Genre", Genre);
            Command.Parameters.AddWithValue("@Quantity", Quantity);

            if (AdditionalDetails != null)
                Command.Parameters.AddWithValue("@AdditionalDetails", AdditionalDetails);
            else
                Command.Parameters.AddWithValue("@AdditionalDetails", System.DBNull.Value);


            if (ImagePath != null)
                Command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                Command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);

            try
            {
                Connection.Open();
                rowsAffected = Command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            finally
            {
                Connection.Close();
            }

            return (rowsAffected > 0);
        }
        public static bool DeleteBook(int BookID)
        {
            int rowsAffected = 0;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"Delete Books 
                                where BookID = @BookID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@BookID", BookID);
            try
            {
                Connection.Open();

                rowsAffected = Command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {

                Connection.Close();

            }

            return (rowsAffected > 0);

        }
        public static bool GetBookInfoByID(int BookID, ref string Author, ref string Title, ref string ISBN, ref DateTime PublicationDate, ref string Genre, ref int Quantity, ref string? AdditionalDetails, ref string? ImagePath)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "SELECT * FROM Books WHERE BookID = @BookID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@BookID", BookID);
            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    // The record was found
                    isFound = true;

                    Author = (string)Reader["Author"];
                    Title = (string)Reader["Title"];
                    ISBN = (string)Reader["ISBN"];
                    PublicationDate = (DateTime)Reader["PublicationDate"];
                    Genre = (string)Reader["Genre"];
                    Quantity = (int)Reader["Quantity"];
                    if (Reader["AdditionalDetails"] != DBNull.Value)
                    {
                        AdditionalDetails = (string?)Reader["AdditionalDetails"];
                    }
                    else
                    {
                        AdditionalDetails = null;
                    }
                    if (Reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string?)Reader["ImagePath"];
                    }
                    else
                    {
                        ImagePath = null;
                    }


                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                Reader.Close();
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

                isFound = false;
            }
            finally
            {
                Connection.Close();
            }

            return isFound;
        }
        public static bool IsBookExist(int BookID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "SELECT Found=1 FROM Books WHERE BookID = @BookID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@BookID", BookID);
            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                isFound = Reader.HasRows;

                Reader.Close();
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                Connection.Close();
            }

            return isFound;
        }
        public static int NextCopyToBorrow(int BookID)
        {
            int NextCopyID = -1;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();

                    string Query = @$"SELECT TOP 1 CopyID FROM BookCopies 
                            WHERE BookID = @BookID AND AvailabilityStatus = 1
                            ORDER BY CopyID ASC";

                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Command.Parameters.AddWithValue("@BookID", BookID);

                        object result = Command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int CopyID)) 
                            NextCopyID = CopyID;
                    }
                }
            }
            catch
            {
                return -1;
            }

            return NextCopyID;
        }
    }
}
