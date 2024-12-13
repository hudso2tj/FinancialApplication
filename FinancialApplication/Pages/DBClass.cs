using Microsoft.AspNetCore.Identity;
using System;
using System.Data;
using Microsoft.Data.SqlClient;
using FinancialApplication.Pages.Data_Classes;



namespace FinancialApplication.Pages.DB
{
    public class DBClass
    {
        // Connection Object at Data Field Level
        public static SqlConnection FinanceAppDBConnection = new SqlConnection();

        // Connection String - How to find and connect to DB
        public static readonly String? FinanceAppDBConnString =
            "Server=Localhost;Database=FinanceApp;Trusted_Connection=True";

        public static void InsertSuggestionMessage(Suggestions suggestion)
        {
            string sqlQuery = "INSERT INTO Suggestions (SuggestionID, SugContent, SubmittedDate) VALUES (@SuggestionID, @Sugcontent, @SubmittedDate)";

            using (SqlConnection connection = new SqlConnection(FinanceAppDBConnString))
            {
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@SuggestionID", suggestion.SuggestionID);
                    cmd.Parameters.AddWithValue("@SugContent", suggestion.SugContent);
                    cmd.Parameters.AddWithValue("@SubmittedDate", suggestion.SubmittedDate);

                    connection.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

