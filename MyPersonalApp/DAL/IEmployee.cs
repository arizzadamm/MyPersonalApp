using MyPersonalApp.Models;
using System.Data;

namespace MyPersonalApp.DAL

{
    public interface IEmployee
    {
        public IEnumerable<Employees>GetAll();
        public IEnumerable<Employees> GetByName(String Name);        

    }
}
