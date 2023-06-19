using MyPersonalApp.Models;

namespace MyPersonalApp.DAL
{
    public interface IPosition
    {
        public IEnumerable<Position> GetAll();
        public Position GetByPositionId(int id);
        public IEnumerable<Position> GetByName(String Name);
        public Position Insert(Position position);
        public Position Update(Position position);
        public void Delete(int PositionId);
    }
}
