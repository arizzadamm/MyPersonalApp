using MyPersonalApp.Models;

namespace MyPersonalApp.DAL
{
    public class PositionEF : IPosition
    {
        private AppDbContext _dbcontext;

        public PositionEF(AppDbContext dbContext)
        {
            _dbcontext = dbContext;    
        }

        public IEnumerable<Position> GetAll()
        {
            var position = _dbcontext.Positions;
            return position;
        }

        public IEnumerable<Position> GetByName(string Name)
        {
            var results = _dbcontext.Positions.Where(p => p.PositionName.Contains(Name)).ToList();
            if (!results.Any())
            {
                throw new Exception($"Data Nama {Name} Tidak ditemukan");
            }
            return results;
        }

        public Position GetByPositionId(int id)
        {
            var position = _dbcontext.Positions.FirstOrDefault(q=>q.PositionId==id);
            if (position == null)
                throw new Exception($"Data Position {id} not Available");
            return position;
        }

        public Position Insert(Position position)
        {
            try
            {
                _dbcontext.Positions.Add(position);
                _dbcontext.SaveChanges();
                return position;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Position Update(Position position)
        {
            var updatePosition = GetByPositionId(position.PositionId);
            if (updatePosition == null)
            {
                throw new Exception($"Data Position {position.PositionId} Tidak ditemukan");
            }
            try
            {
                updatePosition.PositionName = position.PositionName;
                _dbcontext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return updatePosition;
        }

        public void Delete(int PositionId)
        {
            var deleteposition = GetByPositionId(PositionId);
            if (deleteposition == null)
                throw new Exception($"Data Position {PositionId} tidak ditemukan");
            try
            {
                _dbcontext.Remove(deleteposition);
                _dbcontext.SaveChanges();
            }
            catch (Exception Ex)
            {

                throw new Exception(Ex.Message);
            }

        }


    }
}
