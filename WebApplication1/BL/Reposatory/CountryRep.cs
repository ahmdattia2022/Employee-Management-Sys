using System.Linq;
using WebApplication1.BL.Interface;
using WebApplication1.DAL.Database;
using WebApplication1.Models;

namespace WebApplication1.BL.Reposatory
{
    public class CountryRep:ICountryRep
    {
        private readonly DbContainer db;
        public CountryRep(DbContainer db)
        {
            this.db = db;
        }
        public IQueryable<CountryVM> Get()
        {
            IQueryable<CountryVM> data = GetAllCountries();
            return data;
        }
        private IQueryable<CountryVM> GetAllCountries()
        {
            return db.Countries .Select(a => new CountryVM {id = a.id, Name = a.Name});
        }
        public CountryVM GetByID(int ID)
        {
            CountryVM data = GetCountryByID(ID);
            return data;
        }
        private CountryVM GetCountryByID(int id)
        {
            return db.Countries.Where(a => a.id == id).Select(a => new CountryVM{id = a.id,Name = a.Name }).FirstOrDefault();
        }

    }
}
