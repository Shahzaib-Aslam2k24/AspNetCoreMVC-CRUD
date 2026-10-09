using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.Data;
namespace CRUDApplication.Models
{
    public class Cruddata
    {
       
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter name")]
        public string Name { get; set; }

        [Required (ErrorMessage ="Email Is requierd")]
        [EmailAddress (ErrorMessage ="Enter correcct formate")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please enter cast")]

        public string Cast { get; set; }
        public string Address { get; set; }
        //[Phone (ErrorMessage ="Enter correct formate")]
        public string Number { get; set; }
        public string City { get; set; }
        public string Province { get; set; }

        // For database insert 
        public void Insertdata()
        {
            string sa = "Data Source=DESKTOP-TO7PFSO;Initial Catalog=shahzaibaslam;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";
            SqlConnection con = new SqlConnection(sa);                            
                SqlCommand cmd = new SqlCommand("crudinsert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Password", Password);
                cmd.Parameters.AddWithValue("@Cast", Cast);
                cmd.Parameters.AddWithValue("@Address", Address);
                cmd.Parameters.AddWithValue("@Number", Number);
                cmd.Parameters.AddWithValue("@City", City);
                cmd.Parameters.AddWithValue("@Province", Province);
                con.Open();
                cmd.ExecuteNonQuery();
            con.Close();          

        }

        //For database show data
        public DataTable Showdata()
        {
            string sa = "Data Source=DESKTOP-TO7PFSO;Initial Catalog=shahzaibaslam;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";
            SqlConnection con = new SqlConnection(sa);
            SqlCommand cmd = new SqlCommand("crudshow", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
            con.Close();
        }

        //For Delete Data
        public void delete(int number)
        {
            string sa = "Data Source=DESKTOP-TO7PFSO;Initial Catalog=shahzaibaslam;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";
            SqlConnection con = new SqlConnection(sa);
            SqlCommand cmd = new SqlCommand("delete_data", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", number);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        // Get data for form
        public void getdata(int id)
        {
            string sa = "Data Source=DESKTOP-TO7PFSO;Initial Catalog=shahzaibaslam;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";
            SqlConnection con = new SqlConnection(sa);
            SqlCommand cmd = new SqlCommand("get_data_by_id", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Id =  Convert.ToInt32(reader["id"]);
                Name = reader["name"].ToString();
                Email = reader["email"].ToString();
                Password = reader["password"].ToString();
                Cast = reader["cast"].ToString();
                Address = reader["address"].ToString();
                Number = reader["number"].ToString();
                City = reader["city"].ToString();
                Province = reader["province"].ToString();
                con.Close();
            }            
        }

        // For Update Data
        public void updatedata()
        {
            string sa = "Data Source=DESKTOP-TO7PFSO;Initial Catalog=shahzaibaslam;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";
            SqlConnection con = new SqlConnection(sa);
            SqlCommand cmd = new SqlCommand("update_data_by_id", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", Id);
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@Pass", Password);
            cmd.Parameters.AddWithValue("@Cast", Cast);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@Number", Number);
            cmd.Parameters.AddWithValue("@City", City);
            cmd.Parameters.AddWithValue("@Province", Province);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

    }
}
