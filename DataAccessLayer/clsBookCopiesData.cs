using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsBookCopiesData
    {
        public static DataTable GetAllBookCopies()
        {
            DataTable dt = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT * FROM BookCopies";

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
        public static int AddNewCopy(int BookID, bool AvailabilityStatus)
        {
            int CopyID = -1;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"INSERT INTO BookCopies (BookID, AvailabilityStatus)
                             VALUES (@BookID, @AvailabilityStatus);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@BookID", BookID);
            Command.Parameters.AddWithValue("@AvailabilityStatus", AvailabilityStatus);

            try
            {
                Connection.Open();

                object result = Command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    CopyID = insertedID;
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

            return CopyID;
        }
        public static bool UpdateCopy(int CopyID, int BookID, bool AvailabilityStatus)
        {
            int rowsAffected = 0;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"Update  BookCopies  
                            set BookID = @BookID, AvailabilityStatus = @AvailabilityStatus
                                where CopyID = @CopyID ";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@CopyID", CopyID);
            Command.Parameters.AddWithValue("@BookID", BookID);
            Command.Parameters.AddWithValue("@AvailabilityStatus", AvailabilityStatus);
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
        public static bool DeleteCopy(int BookID, int deletedBooks)
        {
            int rowsAffected = 0;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $@"delete top({deletedBooks}) from BookCopies
                            where bookid = @BookID and AvailabilityStatus = 1";

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
        public static int CountCopiesThatWillNotBeDeleted(int BookID, int deletedBooks)
        {
            // some copies of the book is not going to be deleted because
            // they are borrowed, we will count them and tell the admin
            // while they (admins) are deleting copies

            int Copies = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $@"select count(*) from 
                            (
                            select top({deletedBooks}) CopyID from BookCopies
                                                        where BookID = @BookID and AvailabilityStatus = 1
                            ) r1";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("BookID", BookID);

            try
            {
                Connection.Open();
                Copies = (int)Command.ExecuteScalar();
            }
            catch
            {
                return -1;
            }
            finally
            {
                Connection.Close();
            }

            return Copies;
        }
        public static bool GetCopyInfoByID(int CopyID, ref int BookID, ref bool AvailabilityStatus)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "SELECT * FROM BookCopies WHERE CopyID = @CopyID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@CopyID", CopyID);
            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    // The record was found
                    isFound = true;

                    BookID = (int)Reader["BookID"];
                    AvailabilityStatus = (bool)Reader["AvailabilityStatus"];


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
        public static bool IsCopyExist(int CopyID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "SELECT Found=1 FROM BookCopies WHERE CopyID = @CopyID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@CopyID", CopyID);
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
        public static bool SetCopyAsNotAvailable(int CopyID)
        {
            int rowsAffected = 0;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    string Query = @$"UPDATE BookCopies
                                SET AvailabilityStatus = 0
                                WHERE CopyID = @CopyID";

                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Command.Parameters.AddWithValue("@CopyID", CopyID);

                        rowsAffected = Command.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                return false;
            }

            return (rowsAffected > 0);
        }
        
        public static bool SetCopyAsAvailable(int CopyID)
        {
            int rowsAffected = 0;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    string Query = @$"UPDATE BookCopies
                                SET AvailabilityStatus = 1
                                WHERE CopyID = @CopyID";

                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Command.Parameters.AddWithValue("@CopyID", CopyID);

                        rowsAffected = Command.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                return false;
            }

            return (rowsAffected > 0);
        }
        public static int CountAvailableCopies(int BookID)
        {
            int AvailableCopies = 0;

            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    string Query = @"SELECT COUNT(*) FROM BookCopies
                                 WHERE BookID = @BookID AND AvailabilityStatus = 1";

                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Command.Parameters.AddWithValue("@BookID", BookID);

                        object result = Command.ExecuteScalar();

                        AvailableCopies = (int)result;
                    }
                }
            }
            catch
            {
                return 0;
            }

            return AvailableCopies;
        }
        public static bool IsBookBorrowedByUser(int BookID, int UserID)
        {
            bool IsBookBorrowedByUser = false;

            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    string Query = @"SELECT    BorrowingRecords.CopyID, BorrowingRecords.UserID, BookCopies.BookID    FROM            BorrowingRecords INNER JOIN
                         BookCopies ON BorrowingRecords.CopyID = BookCopies.CopyID INNER JOIN
                         Books ON BookCopies.BookID = Books.BookID
						 where Books.BookID = @BookID and BorrowingRecords.UserID = @UserID";

                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Command.Parameters.AddWithValue("@BookID", BookID);
                        Command.Parameters.AddWithValue("@UserID", UserID);

                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            IsBookBorrowedByUser = Reader.HasRows;
                        }
                    }
                }
            }
            catch
            {
                return false;
            }

            return IsBookBorrowedByUser;
        }
    }
}
