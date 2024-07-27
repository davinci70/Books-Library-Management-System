using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsBorrowingRecordsData
    {
        public static DataTable GetAllBorrowingRecords()
        {
            DataTable dt = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT * FROM BorrowingRecords";

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
        public static DataTable GetAllBorrowingRecordsByUserID(int UserID)
        {
            DataTable dt = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT * FROM BorrowingRecords
                             WHERE UserID = @UserID
                             AND ActualReturnDate IS NULL";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@UserID", UserID);

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
        public static int AddNewBorrowingRecord(int UserID, int CopyID, DateTime BorrowingDate, DateTime DueDate, DateTime? ActualReturnDate)
        {
            int BorrowingRecordID = -1;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"INSERT INTO BorrowingRecords (UserID, CopyID, BorrowingDate, DueDate, ActualReturnDate)
                             VALUES (@UserID, @CopyID, @BorrowingDate, @DueDate, @ActualReturnDate);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@UserID", UserID);
            Command.Parameters.AddWithValue("@CopyID", CopyID);
            Command.Parameters.AddWithValue("@BorrowingDate", BorrowingDate);
            Command.Parameters.AddWithValue("@DueDate", DueDate);

            if (ActualReturnDate != null)
                Command.Parameters.AddWithValue("@ActualReturnDate", ActualReturnDate);
            else
                Command.Parameters.AddWithValue("@ActualReturnDate", System.DBNull.Value);


            try
            {
                Connection.Open();

                object result = Command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    BorrowingRecordID = insertedID;
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

            return BorrowingRecordID;
        }
        public static bool UpdateBorrowingRecord(int BorrowingRecordID, int UserID, int CopyID, DateTime BorrowingDate, DateTime DueDate, DateTime? ActualReturnDate)
        {
            int rowsAffected = 0;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"Update  BorrowingRecords  
                            set UserID = @UserID, CopyID = @CopyID, BorrowingDate = @BorrowingDate, DueDate = @DueDate, ActualReturnDate = @ActualReturnDate
                                where BorrowingRecordID = @BorrowingRecordID ";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@BorrowingRecordID", BorrowingRecordID);
            Command.Parameters.AddWithValue("@UserID", UserID);
            Command.Parameters.AddWithValue("@CopyID", CopyID);
            Command.Parameters.AddWithValue("@BorrowingDate", BorrowingDate);
            Command.Parameters.AddWithValue("@DueDate", DueDate);

            if (ActualReturnDate != null)
                Command.Parameters.AddWithValue("@ActualReturnDate", ActualReturnDate);
            else
                Command.Parameters.AddWithValue("@ActualReturnDate", System.DBNull.Value);

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
        public static bool DeleteBorrowingRecord(int BorrowingRecordID)
        {
            int rowsAffected = 0;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"Delete BorrowingRecords 
                                where BorrowingRecordID = @BorrowingRecordID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@BorrowingRecordID", BorrowingRecordID);
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
        public static bool GetBorrowingRecordInfoByID(int BorrowingRecordID, ref int UserID, ref int CopyID, ref DateTime BorrowingDate, ref DateTime DueDate, ref DateTime? ActualReturnDate)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "SELECT * FROM BorrowingRecords WHERE BorrowingRecordID = @BorrowingRecordID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@BorrowingRecordID", BorrowingRecordID);
            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    // The record was found
                    isFound = true;

                    UserID = (int)Reader["UserID"];
                    CopyID = (int)Reader["CopyID"];
                    BorrowingDate = (DateTime)Reader["BorrowingDate"];
                    DueDate = (DateTime)Reader["DueDate"];
                    if (Reader["ActualReturnDate"] != DBNull.Value)
                    {
                        ActualReturnDate = (DateTime?)Reader["ActualReturnDate"];
                    }
                    else
                    {
                        ActualReturnDate = null;
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

        public static bool IsBorrowingRecordExist(int BorrowingRecordID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "SELECT Found=1 FROM BorrowingRecords WHERE BorrowingRecordID = @BorrowingRecordID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@BorrowingRecordID", BorrowingRecordID);
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
    }
}
