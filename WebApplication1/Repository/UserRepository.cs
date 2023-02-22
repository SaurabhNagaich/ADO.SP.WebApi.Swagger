using Microsoft.AspNetCore.Http;
using MySqlX.XDevAPI.Common;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using WebApplication1.Model;

namespace WebApplication1.Repository
{
    public class UserRepository
    {
       // string conString = ConfigurationManager.ConnectionStrings["userSQLConnectionStr"].ToString();
       SqlConnection conString=new SqlConnection("data source=TRAININGDB01; database=SNAGAICH_User; integrated security=true");
        //Get all Users
        public List<User> GetAllUser()
        {
            List<User> userlist = new List<User>();
            SqlCommand cmd = new SqlCommand("sp_GetAllUser", conString);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt=new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                userlist.Add(new User
                {
                    UserId = Convert.ToInt32(dr["UserId"]),
                    UName = dr["UName"].ToString(),
                    FatherName = dr["FatherName"].ToString(),
                    MotherName = dr["MotherName"].ToString(),
                    DOB = dr["DOB"].ToString(),
                    UPassword = dr["UPassword"].ToString(),
                    Email = dr["Email"].ToString(),
                    
                    Img = dr["Img"].ToString()
                });
            }
            
            return userlist;
        }
        

        // inser Data
        public bool InsertUser(User user)
        {
            //int id = 0;
            //using (SqlConnection connection = new SqlConnection(conString))
            //{
            //    SqlCommand command = new SqlCommand("sp_AddUsers", connection);
            //    command.CommandType = CommandType.StoredProcedure;
            //    command.Parameters.AddWithValue("@UName", user.UName);
            //    command.Parameters.AddWithValue("@FatherName", user.FatherName);
            //    command.Parameters.AddWithValue("@MotherName", user.MotherName);
            //    command.Parameters.AddWithValue("@DOB", user.DOB);
            //    command.Parameters.AddWithValue("@Email", user.Email);
            //    command.Parameters.AddWithValue("@UPassword", user.UPassword);
            //    command.Parameters.AddWithValue("@Img", user.Img);

            //connection.Open();
            //id = command.ExecuteNonQuery();
            //connection.Close();

            //}
            SqlCommand cmd = new SqlCommand("sp_AddUsers", conString);
            cmd.CommandType = CommandType.StoredProcedure;
            conString.Open();
            cmd.Parameters.AddWithValue("@UName", user.UName);
            cmd.Parameters.AddWithValue("@FatherName", user.FatherName);
            cmd.Parameters.AddWithValue("@MotherName", user.MotherName);
            cmd.Parameters.AddWithValue("@DOB", user.DOB);
            cmd.Parameters.AddWithValue("@Email", user.Email);
            cmd.Parameters.AddWithValue("@UPassword", user.UPassword);
            cmd.Parameters.AddWithValue("@Img", user.Img);
            //SqlConnection connection = new SqlConnection(conString)
            //connection.Open();
            int i= cmd.ExecuteNonQuery();
            conString.Close();
           // return true;
            //id= cmd.ExecuteNonQuery();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
