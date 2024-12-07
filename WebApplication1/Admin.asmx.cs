using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml.Linq;

namespace WebApplication1
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        private SqlConnection con = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=crud-db;Integrated Security=True;Encrypt=False");
        [WebMethod]
       
        public bool CreateProjectTheme(string ThemeName, string Description, string Deadline, int Budget)
        {
            try
            {
                string query = "INSERT INTO Projects (ThemeName, Description, Deadline, Budget) VALUES (@ThemeName, @Description, @Deadline, @Budget)";

                SqlCommand cmd = new SqlCommand(query, con);

                // Add parameters to the command
                cmd.Parameters.AddWithValue("@ThemeName", ThemeName);

                // Check if Description is null or empty, and assign DBNull.Value if so
                if (string.IsNullOrEmpty(Description))
                {
                    cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Description", Description);
                }

                cmd.Parameters.AddWithValue("@Deadline", Deadline);
                cmd.Parameters.AddWithValue("@Budget", Budget);

                // Open the connection and execute the query
                con.Open();

                int result = cmd.ExecuteNonQuery();  // Executes the INSERT statement

                bool isSuccess = result > 0; // If any row is inserted, return true

                // Log the query and result for debugging purposes
                Console.WriteLine("SQL Query: " + cmd.CommandText);
                Console.WriteLine("Rows affected: " + result);

                return isSuccess;
            }
            catch (Exception ex)
            {
                // Log the exception message for debugging
                Console.WriteLine("Error: " + ex.Message);
                return false; // Return false if an error occurs
            }
            finally
            {
                // Ensure the connection is closed
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }
        [WebMethod]
   
        public bool ModifyProjectTheme(string ThemeName, string Description, string Deadline, int Budget)
        {
            try
            {
                // Update query where the ThemeName is used to find the project to modify
                string query = "UPDATE Projects SET ThemeName = @ThemeName, Description = @Description, Deadline = @Deadline, Budget = @Budget WHERE ThemeName = @ThemeName";

                SqlCommand cmd = new SqlCommand(query, con);

                // Add parameters to the command
                cmd.Parameters.AddWithValue("@ThemeName", ThemeName);  // Use ThemeName to identify the project

                // Check if Description is null or empty, and assign DBNull.Value if so
                if (string.IsNullOrEmpty(Description))
                {
                    cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Description", Description);
                }

                cmd.Parameters.AddWithValue("@Deadline", Deadline);
                cmd.Parameters.AddWithValue("@Budget", Budget);

                // Open the connection and execute the query
                con.Open();

                int result = cmd.ExecuteNonQuery();  // Executes the UPDATE statement

                bool isSuccess = result > 0; // If any row is affected, return true

                // Log the query and result for debugging purposes
                Console.WriteLine("SQL Query: " + cmd.CommandText);
                Console.WriteLine("Rows affected: " + result);

                return isSuccess;
            }
            catch (Exception ex)
            {
                // Log the exception message for debugging
                Console.WriteLine("Error: " + ex.Message);
                return false; // Return false if an error occurs
            }
            finally
            {
                // Ensure the connection is closed
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        [WebMethod]
        public bool DeleteProjectTheme(int ProjectId)
        {
            try
            {
                string query = "DELETE FROM Projects WHERE ProjectId = @ProjectId";

                SqlCommand cmd = new SqlCommand(query, con);

                // Add the parameter to the command
                cmd.Parameters.AddWithValue("@ProjectId", ProjectId);

                // Open the connection and execute the query
                con.Open();

                int result = cmd.ExecuteNonQuery();  // Executes the DELETE statement

                bool isSuccess = result > 0; // If any row is affected, return true

                // Log the query and result for debugging purposes
                Console.WriteLine("SQL Query: " + cmd.CommandText);
                Console.WriteLine("Rows affected: " + result);

                return isSuccess;
            }
            catch (Exception ex)
            {
                // Log the exception message for debugging
                Console.WriteLine("Error: " + ex.Message);
                return false; // Return false if an error occurs
            }
            finally
            {
                // Ensure the connection is closed
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

    }
}
    

