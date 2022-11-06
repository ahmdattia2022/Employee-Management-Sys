using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.BL.Interface
{
    public interface IDistrictRep
    {
        IQueryable<DistrictVM> Get();
        DistrictVM GetByID(int Id);
    }
}
