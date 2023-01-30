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

        private string GetConn()
        {
            return _config.GetConnectionString("CompanyConnection");
        }
    }
}
