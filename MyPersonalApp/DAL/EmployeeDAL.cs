using Microsoft.Data.SqlClient;
using MyPersonalApp.Models;
using System.Data;
using System.Linq;

namespace MyPersonalApp.DAL
{
    public class EmployeeDAL : IEmployee
    {
        private readonly IConfiguration _config;
<<<<<<< HEAD
        public EmployeeDAL(IConfiguration config)
=======
        public EmployeeDAL(IConfiguration config) 
>>>>>>> e6eb58c7488093f510233ee9268d82d756604fe7
        {
            _config = config;
        }

        public void Delete(String Oid)
        {
            using (SqlConnection conn = new(GetConn()))
            {
                string strSql = @"DELETE FROM Employee WHERE Oid=@Oid";
                SqlCommand cmd = new(strSql, conn);
<<<<<<< HEAD
                cmd.Parameters.AddWithValue("@Oid", Oid);
=======
                cmd.Parameters.AddWithValue("@Oid",Oid);
>>>>>>> e6eb58c7488093f510233ee9268d82d756604fe7

                try
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                }
                catch (SqlException SqlEx)
                {

                    throw new Exception($"Failed To Delete Data: {SqlEx.Message}");
                }

<<<<<<< HEAD

=======
               
>>>>>>> e6eb58c7488093f510233ee9268d82d756604fe7
            }
        }

        public IEnumerable<Employees> GetAll()
        {
<<<<<<< HEAD
            using (SqlConnection conn = new(GetConn()))
=======
            using (SqlConnection conn = new (GetConn()))
>>>>>>> e6eb58c7488093f510233ee9268d82d756604fe7
            {
                List<Employees> listemployee = new();
                string strSql = @"select * from Employee order by name asc";
                SqlCommand cmd = new(strSql, conn);
                conn.Open();

<<<<<<< HEAD
                SqlDataReader dr = cmd.ExecuteReader();
=======
                SqlDataReader dr= cmd.ExecuteReader();
>>>>>>> e6eb58c7488093f510233ee9268d82d756604fe7
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        listemployee.Add(new Employees()
                        {
                            Id = ((Guid)dr["Oid"]),
                            Name = dr["Name"].ToString(),
                            Email = dr["Email"].ToString(),
                            Phone = ((int)dr["Phone"]),
                            Address = dr["Address"].ToString(),
                            City = dr["City"].ToString(),
                            Region = dr["Region"].ToString(),
                            PostalCode = ((int)dr["PostalCode"]),
                            Country = Convert.IsDBNull(dr["Country"]) ? null : (string?)dr["Country"]
                        });
                    }
                }
                dr.Close();
                cmd.Dispose();
                conn.Close();

                return listemployee;

            }
        }

        public Employees GetById(UniqueConstraint uniqueConstraint)
        {
            throw new NotImplementedException();
        }

        //public Employees GetByName(string Name)
        //{
        //    using (SqlConnection conn = new(GetConn()))
        //    {
        //        Employees employee = new();
        //        string strSql = @"select * from Employee where Name LIKE @Name";
        //        SqlCommand cmd = new(strSql, conn);
        //        cmd.Parameters.AddWithValue("Name", Name);
        //        conn.Open();

        //        SqlDataReader dr = cmd.ExecuteReader();
        //        if (dr.HasRows)
        //        {
        //            dr.Read();
        //            employee.Id = ((Guid)dr["Oid"]);
        //            employee.Name = dr["Name"].ToString();
        //            employee.Email = dr["Email"].ToString();
        //            employee.Phone = ((int)dr["Phone"]);
        //            employee.Address = dr["Address"].ToString();
        //            employee.City = dr["City"].ToString();
        //            employee.Region = dr["Region"].ToString();
        //            employee.PostalCode = ((int)dr["PostalCode"]);
        //            employee.Country = Convert.IsDBNull(dr["Country"]) ? null : (string?)dr["Country"];

        //        }
        //        dr.Close();
        //        cmd.Dispose();
        //        conn.Close();

        //        return employee;

        //    }

        //}
        public IEnumerable<Employees> GetByName(string Name)
        {
            using (SqlConnection conn = new(GetConn()))
            {
<<<<<<< HEAD
                List<Employees> listemployee = new();
                string strSql = @"select * from Employee where Name LIKE @Name
                                order by Name";
                SqlCommand cmd = new(strSql, conn);
                cmd.Parameters.AddWithValue("@Name", "%" + Name + "%");
=======
                List <Employees> listemployee = new();
                string strSql = @"select * from Employee where Name LIKE @Name
                                order by Name";
                SqlCommand cmd = new(strSql, conn);
                cmd.Parameters.AddWithValue("@Name", "%"+Name+"%");
>>>>>>> e6eb58c7488093f510233ee9268d82d756604fe7
                conn.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        listemployee.Add(new Employees()
                        {
                            Id = ((Guid)dr["Oid"]),
                            Name = dr["Name"].ToString(),
                            Email = dr["Email"].ToString(),
                            Phone = ((int)dr["Phone"]),
                            Address = dr["Address"].ToString(),
                            City = dr["City"].ToString(),
                            Region = dr["Region"].ToString(),
                            PostalCode = ((int)dr["PostalCode"]),
                            Country = Convert.IsDBNull(dr["Country"]) ? null : (string?)dr["Country"]
                        });
                    }
                }
                dr.Close();
                cmd.Dispose();
                conn.Close();

                return listemployee;

            }

        }

        public Employees Insert(Employees employee)
        {
            using (SqlConnection conn = new(GetConn()))
            {
                List<Employees> listemployee = new();
                string strSql = @"INSERT INTO Employee (Name,Email,Phone,Address,City,Region,PostalCode,Country) 
                                  VALUES (@Name,@Email,@Phone,@Address,@City,@Region,@PostalCode,@Country)";
                SqlCommand cmd = new(strSql, conn);
                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@Email", employee.Email);
                cmd.Parameters.AddWithValue("@Phone", employee.Phone);
                cmd.Parameters.AddWithValue("@Address", employee.Address);
                cmd.Parameters.AddWithValue("@City", employee.City);
                cmd.Parameters.AddWithValue("@Region", employee.Region);
                cmd.Parameters.AddWithValue("@PostalCode", employee.PostalCode);
                cmd.Parameters.AddWithValue("@Country", employee.Country);

                try
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
<<<<<<< HEAD

=======
                        
>>>>>>> e6eb58c7488093f510233ee9268d82d756604fe7
                }
                catch (SqlException SqlEx)
                {

                    throw new Exception($"Failed To Insert Data: {SqlEx.Message}");
                }

                return employee;
            }
        }

        public Employees Update(Employees employee)
        {
            using (SqlConnection conn = new(GetConn()))
            {
                List<Employees> listemployee = new();
                string strSql = @"UPDATE Employee Set Name = @Name WHERE Oid=@Oid";
                SqlCommand cmd = new(strSql, conn);
                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@Oid", employee.Id);

                try
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                }
                catch (SqlException SqlEx)
                {

                    throw new Exception($"Failed To Update Data: {SqlEx.Message}");
                }

<<<<<<< HEAD
                return employee;
=======
                return employee;    
>>>>>>> e6eb58c7488093f510233ee9268d82d756604fe7

            }
        }

        private string GetConn()
        {
            return _config.GetConnectionString("CompanyConnection");
        }
    }
}
