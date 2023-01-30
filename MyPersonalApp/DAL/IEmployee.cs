using MyPersonalApp.Models;
using System.Data;

namespace MyPersonalApp.DAL

{
    public interface IEmployee
    {
        public IEnumerable<Employees>GetAll();
        public Employees GetById(UniqueConstraint uniqueConstraint);        

    }
}
