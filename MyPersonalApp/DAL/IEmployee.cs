using MyPersonalApp.Models;
using System.Data;

namespace MyPersonalApp.DAL

{
    public interface IEmployee
    {
        public IEnumerable<Employees> GetAll();
        public IEnumerable<Employees> GetByName(String Name);
        public Employees Insert(Employees employee);
        public Employees Update(Employees employee);
        public void Delete(String Oid);

    }
}
