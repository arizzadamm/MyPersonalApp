using MyPersonalApp.Models;

namespace MyPersonalApp.DAL
{

        public class EmployeeEF : IEmployee
        {
            private AppDbContext _dbcontext;

            public EmployeeEF(AppDbContext dbContext)
             { 
                _dbcontext = dbContext;
             }
            public void Delete(string Oid)
            {
                throw new NotImplementedException();
            }

            public IEnumerable<Employees> GetAll()
            {
            var results = _dbcontext.Employees.OrderByDescending(s => s.PositionId).ToList();
            return results;
            }

            public Employees GetByPositionId(int id)
            {
            var result = _dbcontext.Employees.FirstOrDefault(s=> s.PositionId == id);
            if (result == null)
            {
                throw new Exception($"Data Nomor Posisi {id} Tidak ditemukan");
            }
            return result;
            }

            public IEnumerable<Employees> GetByName(string name)
            {
                var result = _dbcontext.Employees.Where(s => s.Name.Contains(name)).ToList();
                if (!result.Any())
                {
                     throw new Exception($"Data Nama {name} Tidak ditemukan");     
                }
            return result;

        }

            public Employees Insert(Employees employee)
            {
            try
            {
                    _dbcontext.Employees.Add(employee);
                    _dbcontext.SaveChanges();
                    return employee;
            }
            catch (Exception Ex)
            {

                throw new Exception(Ex.Message);
            }
            }
            //public Position Insert(Position position)
            //{
            // try
            // {
            //    _dbcontext.Positions.Add(position);
            //    _dbcontext.SaveChanges();
            //    return position;
            // }
            //catch (Exception Ex)
            // {

            //    throw new Exception(Ex.Message);
            // }
            // }

        public Employees Update(Employees employee)
            {
                throw new NotImplementedException();
            }

    }
}
