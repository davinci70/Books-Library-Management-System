using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsFinesData
    {
        public static DataTable GetAllFines()
        {
            DataTable dt = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT * FROM Fines";

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
        public static int AddNewFine(int UserID, int BorrowingRecordID, int NumberOfLateDays, decimal FineAmount, bool PaymentStatus)
        {
            int FineID = -1;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"INSERT INTO Fines (UserID, BorrowingRecordID, NumberOfLateDays, FineAmount, PaymentStatus)
                             VALUES (@UserID, @BorrowingRecordID, @NumberOfLateDays, @FineAmount, @PaymentStatus);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@UserID", UserID);
            Command.Parameters.AddWithValue("@BorrowingRecordID", BorrowingRecordID);
            Command.Parameters.AddWithValue("@NumberOfLateDays", NumberOfLateDays);
            Command.Parameters.AddWithValue("@FineAmount", FineAmount);
            Command.Parameters.AddWithValue("@PaymentStatus", PaymentStatus);

            try
            {
                Connection.Open();

                object result = Command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    FineID = insertedID;
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

            return FineID;
        }
        public static bool UpdateFine(int FineID, int UserID, int BorrowingRecordID, int NumberOfLateDays, decimal FineAmount, bool PaymentStatus)
        {
            int rowsAffected = 0;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"Update  Fines  
                            set UserID = @UserID, BorrowingRecordID = @BorrowingRecordID, NumberOfLateDays = @NumberOfLateDays, FineAmount = @FineAmount, PaymentStatus = @PaymentStatus
                                where FineID = @FineID ";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@FineID", FineID);
            Command.Parameters.AddWithValue("@UserID", UserID);
            Command.Parameters.AddWithValue("@BorrowingRecordID", BorrowingRecordID);
            Command.Parameters.AddWithValue("@NumberOfLateDays", NumberOfLateDays);
            Command.Parameters.AddWithValue("@FineAmount", FineAmount);
            Command.Parameters.AddWithValue("@PaymentStatus", PaymentStatus);
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
        public static bool DeleteFine(int FineID)
        {
            int rowsAffected = 0;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"Delete Fines 
                                where FineID = @FineID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@FineID", FineID);
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
        public static bool GetFineInfoByID(int FineID, ref int UserID, ref int BorrowingRecordID, ref int NumberOfLateDays, ref decimal FineAmount, ref bool PaymentStatus)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "SELECT * FROM Fines WHERE FineID = @FineID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@FineID", FineID);
            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    // The record was found
                    isFound = true;

                    UserID = (int)Reader["UserID"];
                    BorrowingRecordID = (int)Reader["BorrowingRecordID"];
                    NumberOfLateDays = (int)Reader["NumberOfLateDays"];
                    FineAmount = (decimal)Reader["FineAmount"];
                    PaymentStatus = (bool)Reader["PaymentStatus"];


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

        public static bool IsFineExist(int FineID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "SELECT Found=1 FROM Fines WHERE FineID = @FineID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@FineID", FineID);
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
