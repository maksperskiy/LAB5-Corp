using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using LAB5.Models;
using System.Data;

namespace LAB5
{
    public static class UseDB
    {
        public readonly static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=companydb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
        
        public static void AddStaff(Staff s)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string sqlExpression = "INSERT INTO Staffs (Surname, Name, FName, Post, YearOfBirth, YearOfAdoption, Address) " +
                                       "VALUES (@Surname, @Name, @FName, @Post, @YearOfBirth, @YearOfAdoption, @Address)";

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.Parameters.Add("@Surname", SqlDbType.NVarChar);
                command.Parameters.Add("@Name", SqlDbType.NVarChar);
                command.Parameters.Add("@FName", SqlDbType.NVarChar);
                command.Parameters.Add("@Post", SqlDbType.NVarChar);
                command.Parameters.Add("@YearOfBirth", SqlDbType.Int);
                command.Parameters.Add("@YearOfAdoption", SqlDbType.Int);
                command.Parameters.Add("@Address", SqlDbType.NVarChar);
                command.Parameters["@Surname"].Value = s.Surname;
                command.Parameters["@Name"].Value = s.Name;
                command.Parameters["@FName"].Value = s.FName;
                command.Parameters["@Post"].Value = s.Post;
                command.Parameters["@YearOfBirth"].Value = s.YearOfBirth;
                command.Parameters["@YearOfAdoption"].Value = s.YearOfAdoption;
                command.Parameters["@Address"].Value = s.Address;
         

                connection.Open();
                int number = command.ExecuteNonQuery();

            }
        }

        public static List<Staff> GetStaff()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                List<Staff> staffs = new List<Staff>();
                string sqlExpression = "SELECT * FROM Staffs";

                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader data = command.ExecuteReader();
                while (data.Read())
                {
                    Staff staff = new Staff();

                    staff.Id = data.GetInt32(0);
                    staff.Surname = data.GetString(1);
                    staff.Name = data.GetString(2);
                    staff.FName = data.GetString(3);
                    staff.Post = data.GetString(4);
                    staff.YearOfBirth = data.GetInt32(5);
                    staff.YearOfAdoption = data.GetInt32(6);
                    staff.Address = data.GetString(7);
                    staffs.Add(staff);
                }
                return staffs;
            }
        }

        public static Staff FindStaff(int Id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlExpression = "SELECT * FROM Staffs WHERE Id=" + Id;

                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader data = command.ExecuteReader();

                Staff staff = new Staff();

                while (data.Read())
                {

                    staff.Id = data.GetInt32(0);
                    staff.Surname = data.GetString(1);
                    staff.Name = data.GetString(2);
                    staff.FName = data.GetString(3);
                    staff.Post = data.GetString(4);
                    staff.YearOfBirth = data.GetInt32(5);
                    staff.YearOfAdoption = data.GetInt32(6);
                    staff.Address = data.GetString(7);
                }
                return staff;
            }
        }

        public static void EditStaff(Staff s)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlExpression = "UPDATE Staffs SET Surname=@Surname, " +
                                                            "Name=@Name, " +
                                                            "FName=@FName, " +
                                                            "Post=@Post, " +
                                                            "YearOfBirth=@YearOfBirth, " +
                                                            "YearOfAdoption=@YearOfAdoption, " +
                                                            "Address=@Address " +
                                                            "WHERE Id=@Id";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.Parameters.Add("@Surname", SqlDbType.NVarChar);
                command.Parameters.Add("@Name", SqlDbType.NVarChar);
                command.Parameters.Add("@FName", SqlDbType.NVarChar);
                command.Parameters.Add("@Post", SqlDbType.NVarChar);
                command.Parameters.Add("@YearOfBirth", SqlDbType.Int);
                command.Parameters.Add("@YearOfAdoption", SqlDbType.Int);
                command.Parameters.Add("@Address", SqlDbType.NVarChar);
                command.Parameters.Add("@Id", SqlDbType.Int);
                command.Parameters["@Surname"].Value = s.Surname;
                command.Parameters["@Name"].Value = s.Name;
                command.Parameters["@FName"].Value = s.FName;
                command.Parameters["@Post"].Value = s.Post;
                command.Parameters["@YearOfBirth"].Value = s.YearOfBirth;
                command.Parameters["@YearOfAdoption"].Value = s.YearOfAdoption;
                command.Parameters["@Address"].Value = s.Address;
                command.Parameters["@Id"].Value = s.Id;

                connection.Open();
                int number = command.ExecuteNonQuery();
            }
        }

        public static void DelStaff(int Id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlExpression = "DELETE Staffs WHERE Id=" + Id;

                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int data = command.ExecuteNonQuery();
            }
        }

        public static List<Staff> SearchStaff(string s)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                List<Staff> staffs = new List<Staff>();
                string sqlExpression = "SELECT * FROM Staffs WHERE Address=@Address" ;

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.Parameters.Add("@Address", SqlDbType.NVarChar);
                command.Parameters["@Address"].Value = s;

                connection.Open();
                SqlDataReader data = command.ExecuteReader();

                while (data.Read())
                {
                    Staff staff = new Staff();

                    staff.Id = data.GetInt32(0);
                    staff.Surname = data.GetString(1);
                    staff.Name = data.GetString(2);
                    staff.FName = data.GetString(3);
                    staff.Post = data.GetString(4);
                    staff.YearOfBirth = data.GetInt32(5);
                    staff.YearOfAdoption = data.GetInt32(6);
                    staff.Address = data.GetString(7);
                    staffs.Add(staff);
                }
                return staffs;
            }
        }
    }
}
