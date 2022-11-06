using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.BL.Interface
{
    public interface ICountryRep
    {
        IQueryable<CountryVM> Get();
        CountryVM GetByID(int Id);
    }
}
