using Microsoft.Data.SqlClient;
using MyPersonalApp.Models;
using System.Data;

namespace MyPersonalApp.DAL
{
    public class EmployeeDAL : IEmployee
    {
        private readonly IConfiguration _config;
        public EmployeeDAL(IConfiguration config) 
        {
            _config = config;
        }

        public IEnumerable<Employees> GetAll()
        {
            using (SqlConnection conn = new (GetConn()))
            {
                List<Employees> listemployee = new();
                string strSql = @"select * from Employee order by name asc";
                SqlCommand cmd = new(strSql, conn);
                conn.Open();

                SqlDataReader dr= cmd.ExecuteReader();
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
                List <Employees> listemployee = new();
                string strSql = @"select * from Employee where Name LIKE @Name
                                order by Name";
                SqlCommand cmd = new(strSql, conn);
                cmd.Parameters.AddWithValue("@Name", "%"+Name+"%");
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
        private string GetConn()
        {
            return _config.GetConnectionString("CompanyConnection");
        }
    }
}
