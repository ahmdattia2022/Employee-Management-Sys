using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.BL.Interface
{
    public interface ICityRep
    {
        IQueryable<CityVM> Get();
        CityVM GetByID(int Id);
    }
}
