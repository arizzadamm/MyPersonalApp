using MyPersonalApp.Models;
using System.Data;

namespace MyPersonalApp.DAL

{
    public interface IEmployee
    {
<<<<<<< HEAD
        public IEnumerable<Employees> GetAll();
        public IEnumerable<Employees> GetByName(String Name);
=======
        public IEnumerable<Employees>GetAll();
        public IEnumerable<Employees> GetByName(String Name);     
>>>>>>> e6eb58c7488093f510233ee9268d82d756604fe7
        public Employees Insert(Employees employee);
        public Employees Update(Employees employee);
        public void Delete(String Oid);

    }
}
