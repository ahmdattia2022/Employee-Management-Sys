using System.Linq;
using WebApplication1.BL.Interface;
using WebApplication1.DAL.Database;
using WebApplication1.Models;

namespace WebApplication1.BL.Reposatory
{
    public class CityRep:ICityRep
    {
        private readonly DbContainer db;
        public CityRep(DbContainer db)
        {
            this.db = db;
        }
        public IQueryable<CityVM> Get()
        {
            IQueryable<CityVM> data = GetAllCities();
            return data;
        }
        private IQueryable<CityVM> GetAllCities()
        {
            return db.Cities.Select(a => new CityVM{Id = a.Id,Name = a.Name, CountryId = a.CountryId, CountryName = a.Country.Name });
        }
        public CityVM GetByID(int ID)
        {
            CityVM data = GetCityByID(ID);
            return data;
        }
        private CityVM GetCityByID(int id)
        {
            return db.Cities.Where(a => a.Id == id).Select(a => new CityVM { Id = a.Id, Name = a.Name, CountryId = a.CountryId, CountryName = a.Country.Name})
                .FirstOrDefault();
        }
    }
}
