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
            throw new NotImplementedException();
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
