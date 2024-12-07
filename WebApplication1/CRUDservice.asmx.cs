using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebApplication1
{
    /// <summary>
    /// Summary description for CRUDservice
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CRUDservice : System.Web.Services.WebService
    {
        private SqlConnection con = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=crud-db;Integrated Security=True;Encrypt=False");
        [WebMethod]
        public bool InsertPerson(string name, string email,string passwordHash,string Role)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(" INSERT INTO Users (name,email,passwordHash,Role) VALUES (@name,@email,@passwordHash,@Role)", con);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@passwordHash", passwordHash);
                cmd.Parameters.AddWithValue("@Role", Role);
                con.Open();
                int result = cmd.ExecuteNonQuery();
                bool isSuccess = result > 0;
                return isSuccess;

            }
            catch
            {
                return false;

            }
            finally { 
                if(con.State==ConnectionState.Open) con.Close();
            
            }
        }

        [WebMethod]
        public DataTable GetPerson(int id)
        {
            try
            {
                DataTable dt = new DataTable("Users");
                SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE Id = @id", con);
                cmd.Parameters.AddWithValue ("@id", id);
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                return dt;
            }
            catch {
                return null;

            }
            finally
            {
                if(con.State==ConnectionState.Open)
                    con.Close();
            }
        }
        [WebMethod]
        public bool UpdatePerson(string name, string email, string passwordHash, string Role)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(" INSERT INTO Users (name,email,passwordHash,Role) VALUES (@name,@email,@passwordHash,@Role)", con);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@passwordHash", passwordHash);
                cmd.Parameters.AddWithValue("@Role", Role);
                con.Open();
                int result = cmd.ExecuteNonQuery();
                bool inSuccess = result > 0;
                return inSuccess;

            }
            catch
            {
                return false;

            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();

            }
        }
        [WebMethod]
        public bool DeletePerson(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(" DELETE FROM Users WHERE Id= @id", con);
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                int result = cmd.ExecuteNonQuery();
                bool isSuccess = result > 0;
                return isSuccess;

            }
            catch
            {
                return false;

            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();

            }
        }
    }
}
