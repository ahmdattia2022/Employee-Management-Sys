using System.Linq;
using WebApplication1.BL.Interface;
using WebApplication1.DAL.Database;
using WebApplication1.Models;

namespace WebApplication1.BL.Reposatory
{
    public class DistrictRep:IDistrictRep
    {
        private readonly DbContainer db;
        public DistrictRep(DbContainer db)
        {
            this.db = db;
        }
        public IQueryable<DistrictVM> Get()
        {
            IQueryable<DistrictVM> data = GetAllDistricts();
            return data;
        }
        private IQueryable<DistrictVM> GetAllDistricts()
        {
            return db.Districts.Select(a => new DistrictVM{ Id = a.Id,Name = a.Name, CityId = a.CityId, Cityname = a.City.Name});
        }
        public DistrictVM GetByID(int ID)
        {
            DistrictVM data = GetDistrictByID(ID);
            return data;
        }
        private DistrictVM GetDistrictByID(int id)
        {
            return db.Districts.Where(a => a.Id == id).Select(a => new DistrictVM{Id = a.Id,Name = a.Name, CityId = a.CityId, Cityname = a.City.Name })
                .FirstOrDefault();
        }
    }
}
