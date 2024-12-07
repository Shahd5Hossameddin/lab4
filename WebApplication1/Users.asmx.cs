using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics.Eventing.Reader;

namespace WebApplication1
{
    /// <summary>
    /// Summary description for WebService2
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Users : System.Web.Services.WebService
    {
        private SqlConnection con = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=crud-db;Integrated Security=True;Encrypt=False");
        [WebMethod]
        public bool CreateUser(string name, string email, string passwordHash, string role)
        {

            try
            {               
                    // Step 1: Proceed with inserting the new user
                    string query = "INSERT INTO Users (Name, Email, PasswordHash, Role) VALUES (@Name, @Email, @PasswordHash, @Role)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@PasswordHash", passwordHash);
                        cmd.Parameters.AddWithValue("@Role", role);

                        con.Open();
                        int result = cmd.ExecuteNonQuery(); // Executes the INSERT statement

                        // Return true if a row was inserted, otherwise false
                        return result > 0;
                    }
                
            }
            catch (SqlException sqlEx)
            {
                // Log SQL errors such as constraint violations or connection issues
                Console.WriteLine("SQL Error: " + sqlEx.Message);
                Console.WriteLine("SQL Error Code: " + sqlEx.ErrorCode);
                return false;
            }
            catch (Exception ex)
            {
                // Log general exceptions
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
               




        }

        [WebMethod]
        public bool register (string name, string email, string passwordHash, string role)
        { return false; }

    }
}
